#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM_StockOut
//   Form Name    : 원자재 생산 출고 등록
//   Name Space   : KDT_Form
//   Created Date : 2023-01-16
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
    public partial class MM_StockOut : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스
        public MM_StockOut()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >

        private void MM_StockOut_Load(object sender, EventArgs e)
        {
             // 1. 그리드 셋팅
           
            GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "CHK",       "선택",     GridColDataType_emu.CheckBox,   70,  HAlign.Center, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",     GridColDataType_emu.VarChar,    120, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "INDATE",    "입고일자", GridColDataType_emu.VarChar,    140, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",  "품목",     GridColDataType_emu.VarChar,    140, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",  "품목명",   GridColDataType_emu.VarChar,    140, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",  "LOT번호",  GridColDataType_emu.VarChar,    120, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",  "재고수량", GridColDataType_emu.Double,     80,  HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",  "단위",     GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "MAKER",     "입고자",   GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);       
            GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",  "등록일시", GridColDataType_emu.DateTime24, 150, HAlign.Left,   true, false);
    
            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅


            ////창고
            //dtTemp = Common.StandardCODE("WHCODE");
            //Common.Get_ItemCode(new string[] { "FERT" });
            //UltraGridUtil.SetComboUltraGrid(grid1, "WHCODE", dtTemp); // 작업지시 종료 여부

            //품목
            //ROH : 원자재, HLAB : 반제품, FERT : 완제품
            dtTemp = Common.Get_ItemCode(new string[] {"ROH"});
            Common.FillComboboxMaster(cboItemCode, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMCODE", dtTemp); 

            ////거래처
            //dtTemp = Common.GET_Cust_Code();
            //UltraGridUtil.SetComboUltraGrid(grid1, "CUSTCODE", dtTemp);
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
                string sPlantCode = Convert.ToString(cboPlantCode.Value); // 공장
                string sItemCode = Convert.ToString(cboItemCode.Value);   // 품목 코드
                string sLOTNO = txtLOTNO.Text;                            // LOT 번호
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtEndDate.Value);


                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("04MM_StockOut_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                           , helper.CreateParameter("@ITEMCODE",  sItemCode)
                                           , helper.CreateParameter("@LOTNO",     sLOTNO)
                                           , helper.CreateParameter("@STARTDATE", sStartDate)
                                           , helper.CreateParameter("@ENDDATE",   sEndDate)
                                           );

                if (dtTemp.Rows.Count == 0)
                {
                    ShowDialog("조회할 내역이 없습니다.");
                    GridUtil.Grid_Clear(grid1);
                    return;
                }
                grid1.DataSource = dtTemp;

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

        public override void DoSave()
        {
            // 데이터 변경 내역 확인
            // 체크박스 체크 된 내역 확인
            DataTable dtTemp = new DataTable();
            dtTemp = grid1.chkChange(); // 변경 된 내역만 담는다.

            DBHelper helper = new DBHelper(true); // 파라미터는 트랜잭션 사용 유무
            try
            {
                string sChkStatus = string.Empty;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    sChkStatus = Convert.ToString(dtTemp.Rows[i]["CHK"]);
                    if(sChkStatus != "1")
                    {
                        // 출고등록 대상으로 체크를 하지 않았다면 continue;
                        continue;
                    }

                    //원자재 출고 등록 로직 구현.
                    helper.ExecuteNoneQuery("04MM_StockOut_U1", CommandType.StoredProcedure
                                            ,helper.CreateParameter("@PLANTCODE", Convert.ToString(dtTemp.Rows[i]["PLANTCODE"]))
                                            ,helper.CreateParameter("@ITEMCODE",  Convert.ToString(dtTemp.Rows[i]["ITEMCODE"]))
                                            ,helper.CreateParameter("@LOTNO",     Convert.ToString(dtTemp.Rows[i]["MATLOTNO"]))
                                            ,helper.CreateParameter("@QTY",       Convert.ToString(dtTemp.Rows[i]["STOCKQTY"]))
                                            ,helper.CreateParameter("@UNITCODE",  Convert.ToString(dtTemp.Rows[i]["UNITCODE"]))
                                            ,helper.CreateParameter("@WORKERID",  LoginInfo.UserID)
                                            );
                    
                    if(helper.RSCODE != "S")
                    {
                        throw new Exception($"출고 등록 중 오류가 발생하였습니다.\r\n{helper.RSMSG}");
                    }
                }

                helper.Commit();
                ShowDialog("정상적으로 출고 등록을 완료 하였습니다.");
            }
            catch(Exception ex)
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
