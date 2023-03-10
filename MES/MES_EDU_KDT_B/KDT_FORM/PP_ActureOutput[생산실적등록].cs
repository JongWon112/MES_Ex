#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_ActureOutput
//   Form Name    : 자재 재고 현황
//   Name Space   : KDT_Form
//   Created Date : 2023-01-04
//   Made By      : 이종원
//   Description  : 최초 프로그램 생성
// *---------------------------------------------------------------------------------------------*
#endregion

using DC_POPUP;
using DC00_assm;
using DC00_PuMan;
using DC00_WinForm;
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
    public partial class PP_ActureOutput : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스
        public PP_ActureOutput()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >

        private void PP_ActureOutput_Load(object sender, EventArgs e)
        {
             // 1. 그리드 셋팅
           
            GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "공장",         GridColDataType_emu.VarChar,    100, HAlign.Left,  false, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장",       GridColDataType_emu.VarChar,    100, HAlign.Left,  false, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",  "작업장명",     GridColDataType_emu.VarChar,    150, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",         "작업지시",     GridColDataType_emu.VarChar,    200, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "생산품목",     GridColDataType_emu.VarChar,    300, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "생산품명",     GridColDataType_emu.VarChar,    200, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY",        "지시수량",     GridColDataType_emu.Double,     120, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",         "양품수량",     GridColDataType_emu.Double,     120, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "BADQTY",          "불량수량",     GridColDataType_emu.Double,     120, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",        "단위",         GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUSCODE",  "R/S코드",      GridColDataType_emu.VarChar,    100, HAlign.Left,  false, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS",      "상태",         GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
                                                                                   
            GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",        "투입LOT",      GridColDataType_emu.VarChar,    300, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY",    "투입잔량",     GridColDataType_emu.Double,     120, HAlign.Right,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKER",          "작업자코드",   GridColDataType_emu.VarChar,    100, HAlign.Left,  false, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",      "작업자명",     GridColDataType_emu.VarChar,    100, HAlign.Left,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDSTARTDATE",    "지시시작일자", GridColDataType_emu.DateTime24, 400, HAlign.Left,   true, false);


  
    
            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅. - 사업장, 단위 , 작업장
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅

            //단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);

            //작업장
            dtTemp = Common.GET_Workcenter_Code();
            Common.FillComboboxMaster(this.cboWorkcenter, dtTemp);


            //작업자 팝업 호출
            BizTextBoxManager btbManger = new BizTextBoxManager();
            btbManger.PopUpAdd(txtWorkerID, txtWorkerName, "WORKER_MASTER");
        }
        #endregion

        #region < TOOLBAR AREA >

        public override void DoInquire()
        {
            
             //트랜잭션을 사용하지 않을 helper
            DBHelper helper = new DBHelper(false);
            try
            {
                // 조회조건 변수 등록 및 데이터 대입
                string sPlantCode      = Convert.ToString(this.cboPlantCode.Value);
                string sWorkCenterCode = Convert.ToString(this.cboWorkcenter.Value);
          

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("04PP_ActureOutput_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                           , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
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

        private void cboWorkcenter_ValueChanged(object sender, EventArgs e)
        {
            DoInquire();
        }

        //public override void DoNew()
        //{
        //    grid1.InsertRow();

        //    //기본갑 세팅
        //    grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
        //    grid1.SetDefaultValue("CHK", 0); // 확정체크
        //    grid1.SetDefaultValue("PODATE", string.Format("{0:yyyy-MM-dd}",DateTime.Now)); // 오늘일자
        //}

        //public override void DoDelete()
        //{
        //    grid1.DeleteRow();
        //}

        public override void DoSave()
        {
           
        }

        #endregion


      

        #region < 2. 작업자 등록 >
        private void btnWorkerReg_Click(object sender, EventArgs e)
        {
            // 작업장을 선택 하였는지 확인.
            if(grid1.ActiveRow == null) return;

            // 조회된 작업장이 없을 경우
            if (grid1.Rows.Count == null) return;

            // 등록할 작업자를 조회하였는지 확인
            string sWorkerId = txtWorkerID.Text;
            if(sWorkerId == "")
            {
                ShowDialog("작업자를 선택 후 진행하세요.");
                return;
            }

            DBHelper helper = new DBHelper();
            try 
            {
                string sWorkCenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                helper.ExecuteNoneQuery("04PP_ActureOutput_I1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                            , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode)
                                            , helper.CreateParameter("@WORKERID", sWorkerId)
                                            );

                if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    helper.Rollback();
                    return;
                }

                helper.Commit();
                ShowDialog("작업자 등록을 완료하였습니다.");
                DoInquire();
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

        #region < 그리드 row 선택 시 작업자id, 작업자명 세팅 >
        private void grid1_AfterCellActivate(object sender, EventArgs e)
        {
            // 작업자 세팅
            txtWorkerID.Text   = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            txtWorkerName.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKERNAME"].Value);

            // lot 투입 내역 조회 및 투입/투입취소 버튼으로 변경
            string sLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if(sLotNo == "")
            {
                btnLOTIn.Text = "(4) LOT 투입";
                txtINLotNo.Text = "";
            }
            else
            {
                btnLOTIn.Text = "(4) LOT 투입 취소";
                txtINLotNo.Text = sLotNo;
            }

            // 가동 / 비가동 상태 체크 
            string sRunStop = Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value);
            if (sRunStop == "R") btnRunStop.Text = "(5)비가동";
            else btnRunStop.Text = "(5)가동";
        

        }
        #endregion

        #region < 3. 작업지시 선택 >
        private void btnOrderNo_Click(object sender, EventArgs e)
        {
            // 작업장을 선택하지 않았거나 작업지시 등록 대상 작업장이 그리드에 조회되지 않았을 경우
            if (grid1.ActiveRow == null || grid1.Rows.Count == 0) return;

            // 작업자 등록 여부 확인
            string sWorkerId = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (sWorkerId == "")
            {
                ShowDialog("작업자를 선택 후 진행 하세요.");
                return;
            }

            //작업장이 비가동 상태인지 CHK
            if (Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value) == "R") // 가동 중일 때
            {
                ShowDialog("현재 작업장이 가동 중입니다. \r\n비가동 등록 후 진행하세요.");
                return;
            }

            //LOT 투입 여부
            if (Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value) != "")
            {
                ShowDialog("작업장에 투입된 원자재 LOT의 정보가 존재합니다. \r\n 투입을 취소 후 진행하세요.");
                return;
            }
            // 작업지시를 선택 할 작업장 정보 변수에 담기.
            string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sWorkcenterName = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERNAME"].Value);


            POP_ORDERNO orderPopup = new POP_ORDERNO(sWorkcenterCode, sWorkcenterName);

            orderPopup.ShowDialog(); // Show() -> 팝업 닫히기 전에 아래 로직 실행, ShowDialog() -> 팝업이 닫힐 때 까지 아래 로직이 실행 x (대기)
            string dOrderNo = Convert.ToString(orderPopup.Tag);
            if (dOrderNo == "") return;

            //선택한 작업지시 등록 로직
            DBHelper helper = new DBHelper(true);
            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                helper.ExecuteNoneQuery("04PP_ActureOutput_I2" , CommandType.StoredProcedure
                                            , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                            , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                            , helper.CreateParameter("@ORDERNO", dOrderNo)
                                            , helper.CreateParameter("@WORKERID", sWorkerId)
                                            );

                if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    helper.Rollback();
                    return;
                }

                helper.Commit();
                ShowDialog("작업지시 등록을 완료하였습니다.");
                DoInquire();

                helper.Commit();

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

        #region < 4. LOT 투입 >
        private void btnLOTIn_Click(object sender, EventArgs e)
        {
            if(grid1.ActiveRow == null ) return;

            DBHelper helper = new DBHelper(true);
            try
            {
                string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                if(sOrderNo == "")
                {
                    ShowDialog("등록된 작업지시가 없습니다. \r\n 작업지시 등록 후 진행하세요.");
                    return;
                }

                string sWorkerId = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
                if (sWorkerId == "")
                {
                    ShowDialog("등록된 작업자가 없습니다. \r\n 작업자 등록 후 진행하세요.");
                    return;
                }

                string sInCancleFlag = "IN"; // LOT 투입/취소 여부
                if (btnLOTIn.Text != "(4) LOT 투입") sInCancleFlag = "OUT";
                
                string sItemCode       = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sUnitCode       = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                string sLoTNo          = txtINLotNo.Text;
                
                

                helper.ExecuteNoneQuery("04PP_ActureOutput_I3", CommandType.StoredProcedure
                                            , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                            , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                            , helper.CreateParameter("@ORDERNO",        sOrderNo)
                                            , helper.CreateParameter("@WORKERID",       sWorkerId)
                                            , helper.CreateParameter("@LOTNO",          sLoTNo)
                                            , helper.CreateParameter("@ITEMCODE",       sItemCode)
                                            , helper.CreateParameter("@UNITCODE",       sUnitCode)
                                            , helper.CreateParameter("@INCANCLEFLAG",   sInCancleFlag)
                                            );

                if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    helper.Rollback();
                    return;
                }

                helper.Commit();
                ShowDialog("LOT 투입/취소 등록을 완료하였습니다.");
                DoInquire();

                helper.Commit();

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

        #region < 5. 가동/ 비가동 >
        private void btnRunStop_Click(object sender, EventArgs e)
        {
            // 작업장의 가동 / 비가동 상태를 등록 함
            if (grid1.Rows.Count == 0 || grid1.ActiveRow == null) return;

            string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            if(sOrderNo == "")
            {
                ShowDialog("작업지시를 선택하지 않았습니다. 작업지시 선택 후 진행하세요.");
                return;
            }

            string sWorker = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (sWorker == "")
            {
                ShowDialog("작업자를 선택하지 않았습니다. 작업자 선택 후 진행하세요.");
                return;
            }


            string sRunStop = "S";
            if (btnRunStop.Text == "(5)가동") sRunStop = "R";

            string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sItemCode       = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);

            DBHelper helper = new DBHelper(true);
            try
            {
                helper.ExecuteNoneQuery("04PP_ActureOutput_I4", CommandType.StoredProcedure,
                                          helper.CreateParameter("@PLANTCODE",     sPlantCode),
                                          helper.CreateParameter("@WORKCENTERCODE",sWorkcenterCode),
                                          helper.CreateParameter("@ORDERNO",       sOrderNo),
                                          helper.CreateParameter("@ITEMCODE",      sItemCode),
                                          helper.CreateParameter("@STATUS",        sRunStop)

                                          );

                if (helper.RSCODE != "S") throw new Exception("등록 실패하였습니다.");

                helper.Commit();
                ShowDialog("정상적으로 등록 되었습니다.");

                DoInquire();
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

        #region < 6. 생산 실적 등록 >
        private void btnProdReg_Click(object sender, EventArgs e)
        {
            // 생산 실적을 등록한다.
            if (grid1.Rows.Count == 0 || grid1.ActiveRow == null) return;

            double dProdQty   = 0; // 누적 양품 수량
            double dErrorQty  = 0; // 누적 불량 수량
            double dTProdQty  = 0; // 입력 양품 수량
            double dTErrorQty = 0; // 입력 불량 수량
            double dOrderQty  = 0; // 작업지시 수량

            // 누적 양품 수량
            string sProdQty = Convert.ToString(grid1.ActiveRow.Cells["PRODQTY"].Value).Replace(",", ""); //3자리마다 , 제거
            double.TryParse(sProdQty, out dProdQty);

            //누적 불량 수량
            string sErrorQty = Convert.ToString(grid1.ActiveRow.Cells["BADQTY"].Value).Replace(",", ""); //3자리마다 , 제거
            double.TryParse(sErrorQty, out dErrorQty);

            //입력 양품 수량
            string sTProdQty = Convert.ToString(txtProdQty.Text).Replace(",", "");
            double.TryParse(sTProdQty, out dTProdQty);

            //입력 불량 수량
            string sTErrorQty = Convert.ToString(txtBadQty.Text).Replace(",", "");
            double.TryParse(sTErrorQty, out dTErrorQty);

            //지시 수량
            string sOrderQty = Convert.ToString(grid1.ActiveRow.Cells["ORDERQTY"].Value).Replace(",", ""); //3자리마다 , 제거
            double.TryParse(sOrderQty, out dOrderQty);

            
            // 실적 수량을 입력 하였는지 체크
            if(dTProdQty + dTErrorQty == 0)
            {
                ShowDialog("실적 수량을 입력하지 않았습니다. 확인 후 진행하세요.");
                return;
            } 

            // 누적 양품 수량 + 입력 양품수량이 지시 수량을 초과하는 지 확인
            if(dProdQty + dTProdQty > dOrderQty)
            {
                ShowDialog("총 생산 수량이 작업지시 수량보다 많습니다.");
                return;
            }


            string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            if (sOrderNo == "")
            {
                ShowDialog("작업지시를 선택하지 않았습니다. 작업지시 선택 후 진행하세요.");
                return;
            }

            string sWorker = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (sWorker == "")
            {
                ShowDialog("작업자를 선택하지 않았습니다. 작업자 선택 후 진행하세요.");
                return;
            }

            string sMatLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if(sMatLotNo == "")
            {
                ShowDialog("투입된 LOT가 없습니다. LOT 투입 후 진행하세요.");
                return;
            }

            string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sItemCode       = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sUnitCode       = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
           
       
 

            DBHelper helper = new DBHelper(true);
            try
            {
                helper.ExecuteNoneQuery("04PP_ActureOutput_I5", CommandType.StoredProcedure,
                                          helper.CreateParameter("@PLANTCODE",      sPlantCode),
                                          helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode),
                                          helper.CreateParameter("@ORDERNO",        sOrderNo),
                                          helper.CreateParameter("@ITEMCODE",       sItemCode),
                                          helper.CreateParameter("@UNITCODE",       sUnitCode),
                                          helper.CreateParameter("@PRODQTY",        dTProdQty),
                                          helper.CreateParameter("@BADQTY",         dTErrorQty),
                                          helper.CreateParameter("@MATLOTNO",       sMatLotNo)
                                          );

                if (helper.RSCODE != "S") throw new Exception("등록 실패하였습니다." + helper.RSMSG);

                helper.Commit();
                ShowDialog("정상적으로 등록 되었습니다.");

                // 제품 식별표에 출력할 제품 LOT별 데이터 조회
                DataTable dtTemp = helper.FillTable("04PP_ActureOutput_S2", CommandType.StoredProcedure
                                 , helper.CreateParameter("@PLANTCODE      ", sPlantCode)
                                 , helper.CreateParameter("@LOTNO          ", helper.RSMSG)
                                 );

                // 바코드 디자이너에 던져줄 원자재 품목 데이터 변수 설정. 



                // 바코드 디자이너에 출력할 식별표 데이터 매핑

                // 바코드 디자이너 객체 생성.
                Report_LotBacodeFERT FERT_BARCODE = new Report_LotBacodeFERT();

                // 레포트 북 객체 생성.
                Telerik.Reporting.ReportBook reportBook = new Telerik.Reporting.ReportBook();

                // 바코드 디자인 객체 에 데이터 매핑 
                FERT_BARCODE.DataSource = dtTemp;

                // 디자인을 레포트 북에 등록.
                reportBook.Reports.Add(FERT_BARCODE);

                // 바코드 디자이너 뷰어(미리보기) 에 레포트 북 등록 및 표현. 
                ReportViewer Viewer = new ReportViewer(reportBook, 1);
                Viewer.ShowDialog();

                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < 7. 작업지시 종료 > 

        private void btnOrderClose_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null || grid1.Rows.Count == 0) return;

            string sMatLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            string sRunStop = Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value);

            if (sMatLotNo != "")
            {
                ShowDialog("투입 LOT가 존재 합니다. LOT 투입 취소 후 진행하세요.");
                return;
            }

            if (sRunStop == "R")
            {
                ShowDialog("작업장이 가동 상태입니다. 비가동 등록 후 진행하세요.");
                return;
            }

            DBHelper helper = new DBHelper(true);

            try
            {
                string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sOrderNo        = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                helper.ExecuteNoneQuery("04PP_ActureOutput_I6", CommandType.StoredProcedure,
                                        helper.CreateParameter("@PLANTCODE",      sPlantCode),
                                        helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode),
                                        helper.CreateParameter("@ORDERNO",        sOrderNo)
                                        ); 


                if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
                helper.Commit();
                ShowDialog("작업지시가 종료되었습니다.");
                DoInquire();
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
