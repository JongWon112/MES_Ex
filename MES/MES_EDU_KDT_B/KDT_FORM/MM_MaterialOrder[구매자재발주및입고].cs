#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM_MaterialOrder
//   Form Name    : 구매자재 발주 및 입고
//   Name Space   : KDT_Form
//   Created Date : 2023-01-04
//   Made By      : 이종원
//   Description  : 최초 프로그램 생성
// *---------------------------------------------------------------------------------------------*
#endregion

using DC00_assm;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KDT_Form
{
    public partial class MM_MaterialOrder : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스
        public MM_MaterialOrder()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >

        private void MM_MaterialOrder_Load(object sender, EventArgs e)
        {
             // 1. 그리드 셋팅
           
            GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",     GridColDataType_emu.VarChar,      100, HAlign.Left,   true, true);
            
            // 구매 자재 발주
            GridUtil.InitColumnUltraGrid(grid1, "PONO",      "발주번호", GridColDataType_emu.VarChar,      130, HAlign.Center, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",  "발주품목", GridColDataType_emu.VarChar,      150, HAlign.Left,   true, true);
            GridUtil.InitColumnUltraGrid(grid1, "PODATE",    "발주일자", GridColDataType_emu.YearMonthDay, 150, HAlign.Left,   true, true);
            GridUtil.InitColumnUltraGrid(grid1, "POQTY",     "발주수량", GridColDataType_emu.Double,       80,  HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",  "단위",     GridColDataType_emu.VarChar,      80,  HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",  "거래처",   GridColDataType_emu.VarChar,      150, HAlign.Left,   true, false);
                                                             
            //구매 자재 입고                                 
            GridUtil.InitColumnUltraGrid(grid1, "CHK",       "입고",     GridColDataType_emu.CheckBox,     80,  HAlign.Center, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "INQTY",     "입고수량", GridColDataType_emu.Double,       80,  HAlign.Right,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "LOTNO",     "LOT번호",  GridColDataType_emu.VarChar,      130, HAlign.Center, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "INDATE",    "입고일자", GridColDataType_emu.VarChar,      100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "INWORKER",  "입고자",   GridColDataType_emu.VarChar,      100, HAlign.Left,   true, false);
                                                                                                                         
            GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",  "등록일시", GridColDataType_emu.DateTime24,   150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "MAKER",     "등록자",   GridColDataType_emu.VarChar,      100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",  "수정일시", GridColDataType_emu.DateTime24,   150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "EDITOR",    "수정자",   GridColDataType_emu.VarChar,      100, HAlign.Left,   true, false);
            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅

            //거래처
            dtTemp = Common.GET_Cust_Code();                  
            Common.FillComboboxMaster(cboCustCode, dtTemp);  
            //UltraGridUtil.SetComboUltraGrid(grid1, "CUSTCODE", dtTemp);

            //단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp); // 작업지시 종료 여부

            //품목
            //ROH : 원자재, HLAB : 반제품, FERT : 완제품
            dtTemp = Common.Get_ItemCode(new string[] {"ROH"});
            Common.FillComboboxMaster(cboItemCode, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMCODE", dtTemp); // 작업지시 종료 여부
        }
        #endregion

        #region < TOOLBAR AREA >

        public override void DoInquire()
        {
            base.DoInquire();
             //트랜잭션을 사용하지 않을 helper
            DBHelper helper = new DBHelper(false);
            try
            {
                // 조회조건 변수 등록 및 데이터 대입
                string sPlantCode   = Convert.ToString(cboPlantCode.Value);            // 공장
                string sCustCode    = Convert.ToString(cboCustCode.Value);             // 거래처 코드
                string sPoNo        = txtPoNO.Text;                                    // 발주 번호
                string sItemCode    = Convert.ToString(cboItemCode.Value);             // 품목코드
                string sPOStartDate = string.Format("{0:yyyy-MM-dd}", dtpStart.Value); // 발주 시작일자
                string sPOEndDate   = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);   // 발주 종료일자

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("04MM_MaterialOrder_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                           , helper.CreateParameter("@CUSTCODE",  sCustCode)
                                           , helper.CreateParameter("@PONO",      sPoNo)
                                           , helper.CreateParameter("@ITEMCODE",  sItemCode)
                                           , helper.CreateParameter("@STARTDATE", sPOStartDate)
                                           , helper.CreateParameter("@ENDDATE",   sPOEndDate)
                                           );
                
               if(dtTemp.Rows.Count == 0 ) 
               {
                    ShowDialog("조회할 내역이 없습니다.");
                    GridUtil.Grid_Clear(grid1);
                    return;
               }
               grid1.DataSource= dtTemp;
               
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            finally 
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
            grid1.InsertRow();

            //기본갑 세팅
            grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
            grid1.SetDefaultValue("CHK", 0); // 확정체크
        }

        public override void DoDelete()
        {
            grid1.DeleteRow();
        }

        public override void DoSave()
        {
            base.DoSave();

            DataTable dtTemp = grid1.chkChange();

            if (dtTemp == null)
            {
                ShowDialog("저장할 행이 없습니다.");
                return;
            }

            string sMessage = string.Empty; // 필수 입력 내역 확인용 변수


            DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB 커넥터

            try
            {
                foreach (DataRow dr in dtTemp.Rows)
                {


                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges(); // 삭제된 데이터 원상복귀

                            //생산계획을 취소

                            helper.ExecuteNoneQuery("04MM_MaterialOrder_D1", CommandType.StoredProcedure,
                                                    helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                    helper.CreateParameter("@PLANNO",    Convert.ToString(dr["PLANNO"]))
                                                    );
                            break;
                        case DataRowState.Added:
                            if (Convert.ToString(dr["ITEMCODE"]) == "") sMessage = "생산품목 ";
                            if (Convert.ToString(dr["PLANQTY"]) == "") sMessage += "계획수량 ";

                            if(sMessage != "") throw new Exception(sMessage + "을(를) 입력하지 않았습니다.");
                         
                            helper.ExecuteNoneQuery("04MM_MaterialOrder_I1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@ITEMCODE",  Convert.ToString(dr["ITEMCODE"])),
                                                   helper.CreateParameter("@PLANQTY",   Convert.ToString(dr["PLANQTY"])),
                                                   helper.CreateParameter("@UNITCODE",  Convert.ToString(dr["UNITCODE"])),
                                                   helper.CreateParameter("@MAKER",     LoginInfo.UserID)
                                                   );                                   
                            break;

                            
                        case DataRowState.Modified:
                            string sWorkcenterCode = Convert.ToString(dr["WORKCENTERCODE"]); //작업지시 확정 작업장
                            if (sWorkcenterCode == "") throw new Exception("작업자 정보를 입력하지 않았습니다.");

                           

                            // 작업지시 확정 체크 여부 확인
                            string sOrderFlag = "N";
                            if (Convert.ToString(dr["CHK"]) == "1" ) sOrderFlag = "Y";

                            string sOrderNo = Convert.ToString(dr["ORDERNO"]); 

                            if (sOrderFlag == "N" && sOrderNo == "")
                            {
                                throw new Exception("확정 체크를 하지 않았습니다.");
                            }

                            // 생산 계획 번호 확인
                            string sPlanNo = Convert.ToString(dr["PLANNO"]);
                            if (sPlanNo == "") throw new Exception("생산 계획이 확정되지 않은 내역입니다.");

                            helper.ExecuteNoneQuery("04MM_MaterialOrder_U1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE",      Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode),
                                                   helper.CreateParameter("@PLANNO",         sPlanNo),
                                                   helper.CreateParameter("@ORDERFLAG",      sOrderFlag),
                                                   helper.CreateParameter("@EDITOR",         LoginInfo.UserID)
                                                   );
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        //1번째 방법
                        helper.Rollback();
                        ShowDialog(helper.RSMSG);
                        return;
                        ////2번째 방법
                        //throw new Exception(helper.RSMSG);
                    }

                }

                //ClosePrgForm();
                helper.Commit();
                ShowDialog("정상적으로 등록 하였습니다.");
                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

    }
}
