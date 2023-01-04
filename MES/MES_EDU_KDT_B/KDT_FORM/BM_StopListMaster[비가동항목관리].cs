#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM_StopListMaster
//   Form Name    : 작업장 마스터
//   Name Space   : KDT_Form
//   Created Date : 2023-01-02
//   Made By      : 이종원
//   Description  : 기준정보(작업장마스터) 관리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

using DC00_assm;
using DC00_Component;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KDT_Form
{
    public partial class BM_StopListMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region< MEMBER AREA >
        public BM_StopListMaster()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >
        private void BM_StopListMaster_Load(object sender, EventArgs e)
        {
            #region < 그리드셋팅, 콤보박스 셋팅 >
            // 1. 그리드 셋팅
            UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스
            GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",       GridColDataType_emu.VarChar,    100, HAlign.Left, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "STOPCODE",  "비가동코드", GridColDataType_emu.VarChar,    100, HAlign.Left, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "STOPNAME",  "비가동명",   GridColDataType_emu.VarChar,    130, HAlign.Left, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "REMARK",    "비고",       GridColDataType_emu.VarChar,    100, HAlign.Left, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",   "사용여부",   GridColDataType_emu.VarChar,    100, HAlign.Left, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "MAKER",     "등록자",     GridColDataType_emu.VarChar,    100, HAlign.Left, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",  "등록일자",   GridColDataType_emu.DateTime24, 100, HAlign.Left, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "EDITOR",    "수정자",     GridColDataType_emu.VarChar,    100, HAlign.Left, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",  "수정일자",   GridColDataType_emu.DateTime24, 100, HAlign.Left, true, false);
   
            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            Common _Common = new Common(); //Common 클래스 객체 생성
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅

            //사용여부
            dtTemp = Common.StandardCODE("USEFLAG");
            Common.FillComboboxMaster(cboUseFlag, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", dtTemp); // 사용여부 

            #endregion

        }
        #endregion

        #region < TOOLBAR AREA >

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper();
            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sStopCode = txtStopCode.Text;
                string sStopName = txtStopName.Text;
                string sUseFlag = Convert.ToString(cboUseFlag.Value);

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("04BM_StopListMaster_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("PLANTCODE", sPlantCode)
                                           , helper.CreateParameter("STOPCODE", sStopCode)
                                           , helper.CreateParameter("STOPNAME", sStopName)
                                           , helper.CreateParameter("USEFLAG", sUseFlag)
                                           );

                grid1.DataSource = dtTemp;


            }
            catch(Exception ex) 
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
            //신규행 추가
            grid1.InsertRow();

            //기본값 세팅
            grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
            grid1.SetDefaultValue("USEFLAG", "Y"); // 사용여부

            grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;


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

            DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB 커넥터

            try
            {
                foreach (DataRow dr in dtTemp.Rows)
                {


                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges(); // 삭제된 데이터 원삭복귀

                            helper.ExecuteNoneQuery("04IDBM_StopListMaster_D1", CommandType.StoredProcedure,
                                                    helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                    helper.CreateParameter("@STOPCODE", Convert.ToString(dr["STOPCODE"]))
                                                    );
                            break;
                        case DataRowState.Added:
                            helper.ExecuteNoneQuery("04IDBM_StopListMaster_I1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@STOPCODE",  Convert.ToString(dr["STOPCODE"])),
                                                   helper.CreateParameter("@STOPNAME",  Convert.ToString(dr["STOPNAME"])),
                                                   helper.CreateParameter("@REMARK",    Convert.ToString(dr["REMARK"])),
                                                   helper.CreateParameter("@USEFLAG",   Convert.ToString(dr["USEFLAG"])),
                                                   helper.CreateParameter("@MAKER",     LoginInfo.UserID)
                                                   );
                            break;
                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("04IDBM_StopListMaster_U1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@STOPCODE", Convert.ToString(dr["STOPCODE"])),
                                                   helper.CreateParameter("@STOPNAME", Convert.ToString(dr["STOPNAME"])),
                                                   helper.CreateParameter("@REMARK", Convert.ToString(dr["REMARK"])),
                                                   helper.CreateParameter("@USEFLAG", Convert.ToString(dr["USEFLAG"])),
                                                   helper.CreateParameter("@EDITOR", LoginInfo.UserID)
                                                   );
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {

                        throw new Exception(helper.RSMSG);
                    }

                }
                        //2번째 방법

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
    }


        #endregion
    
}
