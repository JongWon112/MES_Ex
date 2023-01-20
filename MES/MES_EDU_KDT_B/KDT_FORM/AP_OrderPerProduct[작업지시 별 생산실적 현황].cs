#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP_OrderPerProduct
//   Form Name    : 작업지시 별 생산 실적 현황
//   Name Space   : KDT_Form
//   Created Date : 2023-01-20
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
    public partial class AP_OrderPerProduct : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스
        public AP_OrderPerProduct()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >

        private void AP_OrderPerProduct_Load(object sender, EventArgs e)
        {
             // 1. 그리드 셋팅
           
            GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",             GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시번호",     GridColDataType_emu.VarChar,    150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",             GridColDataType_emu.VarChar,    150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품목명",           GridColDataType_emu.VarChar,    150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드",       GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장",           GridColDataType_emu.VarChar,    120, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY",       "지시수량",         GridColDataType_emu.Double,     100, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",             GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE",      "지시일자",         GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",         GridColDataType_emu.Double,     100, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",         GridColDataType_emu.Double,     100, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "TOTALPRODQTY",   "합계",             GridColDataType_emu.Double,     100, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ACTRATE",        "지시달성률",       GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);                                    
            GridUtil.InitColumnUltraGrid(grid1, "FIRSTSTARTDATE", "지시시작일시",     GridColDataType_emu.DateTime24, 150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERCLOSEDATE", "지시종료일시",     GridColDataType_emu.DateTime24, 150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "TOTALRUNTIME",   "지시운영시간(분)", GridColDataType_emu.Double,     100, HAlign.Right,  true, false);
   
    
            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅

            //단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", dtTemp); // 그리드에 콤보박스 세팅

            //ROH : 원자재, HLAB : 반제품, FERT : 완제품
            dtTemp = Common.Get_ItemCode(new string[] {"FERT"});
            Common.FillComboboxMaster(cboItemCode, dtTemp);
          

            dtTemp = Common.GET_Workcenter_Code();
            Common.FillComboboxMaster(this.cboWorkcenter, dtTemp);

         

            
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
                string sWorkcenterCode = Convert.ToString(cboWorkcenter.Value); 
                string sStartDate = Convert.ToString(dtStartDate.Value);
                string sEndDate = Convert.ToString(dtEndDate.Value);
                string sItemCode = Convert.ToString(cboItemCode.Value);   // 품목 코드
                string sOrderNo = txtOrderNo.Text;                          
        


                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("04AP_OrderPerProduct_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                           , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                           , helper.CreateParameter("@STARTDATE",      sStartDate)
                                           , helper.CreateParameter("@ENDDATE",        sEndDate)
                                           , helper.CreateParameter("@ITEMCODE",       sItemCode)
                                           , helper.CreateParameter("@ORDERNO",        sOrderNo)
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

      

        #endregion

    }
}
