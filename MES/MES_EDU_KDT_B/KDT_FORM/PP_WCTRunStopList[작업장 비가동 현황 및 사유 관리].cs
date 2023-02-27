#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_WCTRunStopList
//   Form Name    : 작업장 비가동 현황 및 사유 관리
//   Name Space   : KDT_Form
//   Created Date : 2022/02/05
//   Made By      : LJW
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDT_Form
{
    public partial class PP_WCTRunStopList : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        DataTable rtnDtTemp = new DataTable(); // 
        #endregion


        #region < CONSTRUCTOR >
        public PP_WCTRunStopList()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_WCTRunStopList_Load(object sender, EventArgs e)
        { 
            string plantCode        = LoginInfo.PlantCode;

            #region ▶ GRID ◀
           
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",               GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSEQ",          "작업장 지시별 순번", GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",             GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장 명",          GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시번호",       GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",               GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품명",               GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",     "작업자",             GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSNAME",     "가동/비가동",        GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSTARTDATE",    "시작일시",           GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSENDDATE",      "종료일시",           GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "TIMEDIFF",       "소요시간",           GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",           GridColDataType_emu.Double,     100, Infragistics.Win.HAlign.Right,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",           GridColDataType_emu.Double,     100, Infragistics.Win.HAlign.Right,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",         "사유",               GridColDataType_emu.VarChar,    160, Infragistics.Win.HAlign.Left,   true,  true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",          "등록자",             GridColDataType_emu.VarChar,    160, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "등록일시",           GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",         "수정자",             GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",       "수정일시",           GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true,  false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.GET_Workcenter_Code();  // 작업장
           //' Common.FillComboboxMaster(this.cboWorkcentercode, rtnDtTemp);

            rtnDtTemp = Common.GET_StopList();
            UltraGridUtil.SetComboUltraGrid(this.grid1, "REMARK", rtnDtTemp);


			#endregion

			#region ▶ POP-UP ◀
			#endregion

			#region ▶ ENTER-MOVE ◀
			cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
                string sWorkcenterCode = Convert.ToString(this.cboWorkcentercode.Value);
                string sStartDate = string.Format(String.Format("{0:yyyy-MM-dd}", dtStartDate.Value));
                string sEndDate = string.Format(String.Format("{0:yyyy-MM-dd}", dtEnddate.Value));

                rtnDtTemp = helper.FillTable("04PP_WCTRunStopList_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                    , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                    , helper.CreateParameter("@STARTDATE",      sStartDate)
                                    , helper.CreateParameter("@ENDDATE",        sEndDate)
                                    );

                this.grid1.DataSource = rtnDtTemp;


            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoSave()
        {
            if (grid1.Rows.Count == 0) return;

            // 그리드 에서 변경 된 행 을 받아온다.
            DataTable dtChang = grid1.chkChange();
            if (dtChang == null) return;

            DBHelper helper = new DBHelper(true);
            try
            {
              

                string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sOrderNo        = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                double iRsSEQ          = Convert.ToInt32(grid1.ActiveRow.Cells["RSSEQ"].Value);
                string sRemark         = Convert.ToString(grid1.ActiveRow.Cells["REMARK"].Value);
                string sEditor         = Convert.ToString(grid1.ActiveRow.Cells["EDITOR"].Value);

                foreach (DataRow dr in dtChang.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Modified:

                            helper.ExecuteNoneQuery("04PP_WCTRunStopList_U1", CommandType.StoredProcedure,
                                                    helper.CreateParameter("@PLANTCODE",      sPlantCode),
                                                    helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode),
                                                    helper.CreateParameter("@ORDERNO",        sOrderNo),
                                                    helper.CreateParameter("@RSSEQ",          iRsSEQ),
                                                    helper.CreateParameter("@REMARK",         sRemark),
                                                    helper.CreateParameter("@EDITOR",         sEditor)
                                                    );

                            break;
                    }

                    if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
                  
                }

                helper.Commit();
                ShowDialog("비가동 사유 등록을 완료하였습니다.");
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




