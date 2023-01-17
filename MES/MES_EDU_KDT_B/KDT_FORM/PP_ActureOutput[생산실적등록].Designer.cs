namespace KDT_Form
{
    partial class PP_ActureOutput
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.sLabel1 = new DC00_Component.SLabel();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel5 = new DC00_Component.SLabel();
            this.cboWorkcenter = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grid1 = new DC00_Component.Grid(this.components);
            this.sLabel2 = new DC00_Component.SLabel();
            this.txtWorkerID = new DC00_Component.SBtnTextEditor();
            this.txtWorkerName = new DC00_Component.STextBox(this.components);
            this.btnWorkerReg = new Infragistics.Win.Misc.UltraButton();
            this.btnOrderNo = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtINLotNo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnLOTIn = new Infragistics.Win.Misc.UltraButton();
            this.sLabel4 = new DC00_Component.SLabel();
            this.btnRunStop = new Infragistics.Win.Misc.UltraButton();
            this.txtProdQty = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.sLabel3 = new DC00_Component.SLabel();
            this.sLabel6 = new DC00_Component.SLabel();
            this.txtBadQty = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnProdReg = new Infragistics.Win.Misc.UltraButton();
            this.btnOrderClose = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkcenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtINLotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBadQty)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txtBadQty);
            this.gbxHeader.Controls.Add(this.txtProdQty);
            this.gbxHeader.Controls.Add(this.btnOrderClose);
            this.gbxHeader.Controls.Add(this.btnProdReg);
            this.gbxHeader.Controls.Add(this.btnRunStop);
            this.gbxHeader.Controls.Add(this.ultraGroupBox1);
            this.gbxHeader.Controls.Add(this.btnOrderNo);
            this.gbxHeader.Controls.Add(this.btnWorkerReg);
            this.gbxHeader.Controls.Add(this.txtWorkerName);
            this.gbxHeader.Controls.Add(this.txtWorkerID);
            this.gbxHeader.Controls.Add(this.cboPlantCode);
            this.gbxHeader.Controls.Add(this.cboWorkcenter);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.sLabel5);
            this.gbxHeader.Controls.Add(this.sLabel6);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Size = new System.Drawing.Size(1249, 170);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 170);
            this.gbxBody.Size = new System.Drawing.Size(1249, 481);
            // 
            // sLabel1
            // 
            appearance25.FontData.BoldAsString = "False";
            appearance25.FontData.UnderlineAsString = "False";
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Right";
            appearance25.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance25;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(-40, 12);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(123, 34);
            this.sLabel1.TabIndex = 0;
            this.sLabel1.Text = "공장";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Location = new System.Drawing.Point(89, 12);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(146, 29);
            this.cboPlantCode.TabIndex = 1;
            // 
            // sLabel5
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.sLabel5.Appearance = appearance3;
            this.sLabel5.DbField = null;
            this.sLabel5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel5.Location = new System.Drawing.Point(186, 12);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel5.Size = new System.Drawing.Size(123, 34);
            this.sLabel5.TabIndex = 0;
            this.sLabel5.Text = "(1)작업장";
            // 
            // cboWorkcenter
            // 
            this.cboWorkcenter.Location = new System.Drawing.Point(315, 12);
            this.cboWorkcenter.Name = "cboWorkcenter";
            this.cboWorkcenter.Size = new System.Drawing.Size(331, 29);
            this.cboWorkcenter.TabIndex = 1;
            this.cboWorkcenter.ValueChanged += new System.EventHandler(this.cboWorkcenter_ValueChanged);
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance11;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance12;
            appearance13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance13;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance14.BackColor2 = System.Drawing.SystemColors.Control;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance14;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance21;
            appearance15.BackColor = System.Drawing.SystemColors.Highlight;
            appearance15.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance15;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)(((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance18;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance22;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance20.BackColor = System.Drawing.SystemColors.Control;
            appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance20.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance20;
            appearance16.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance19;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1237, 469);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.AfterCellActivate += new System.EventHandler(this.grid1_AfterCellActivate);
            // 
            // sLabel2
            // 
            appearance8.FontData.BoldAsString = "False";
            appearance8.FontData.UnderlineAsString = "False";
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance8;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(589, 12);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(123, 34);
            this.sLabel2.TabIndex = 0;
            this.sLabel2.Text = "작업자";
            // 
            // txtWorkerID
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerID.Appearance = appearance4;
            this.txtWorkerID.btnImgType = DC00_Component.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtWorkerID.btnWidth = 26;
            this.txtWorkerID.Location = new System.Drawing.Point(718, 12);
            this.txtWorkerID.Name = "txtWorkerID";
            this.txtWorkerID.RequireFlag = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerID.RequirePop = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerID.Size = new System.Drawing.Size(140, 29);
            this.txtWorkerID.TabIndex = 3;
            // 
            // txtWorkerName
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerName.Appearance = appearance2;
            this.txtWorkerName.Location = new System.Drawing.Point(864, 12);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.RequireFlag = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtWorkerName.RequirePop = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtWorkerName.Size = new System.Drawing.Size(116, 29);
            this.txtWorkerName.TabIndex = 4;
            // 
            // btnWorkerReg
            // 
            this.btnWorkerReg.Location = new System.Drawing.Point(986, 10);
            this.btnWorkerReg.Name = "btnWorkerReg";
            this.btnWorkerReg.Size = new System.Drawing.Size(124, 34);
            this.btnWorkerReg.TabIndex = 5;
            this.btnWorkerReg.Text = "(2)작업자 등록";
            this.btnWorkerReg.Click += new System.EventHandler(this.btnWorkerReg_Click);
            // 
            // btnOrderNo
            // 
            this.btnOrderNo.Location = new System.Drawing.Point(47, 66);
            this.btnOrderNo.Name = "btnOrderNo";
            this.btnOrderNo.Size = new System.Drawing.Size(188, 97);
            this.btnOrderNo.TabIndex = 5;
            this.btnOrderNo.Text = "(3)작업지시 선택";
            this.btnOrderNo.Click += new System.EventHandler(this.btnOrderNo_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtINLotNo);
            this.ultraGroupBox1.Controls.Add(this.btnLOTIn);
            this.ultraGroupBox1.Controls.Add(this.sLabel4);
            this.ultraGroupBox1.Location = new System.Drawing.Point(252, 52);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(371, 116);
            this.ultraGroupBox1.TabIndex = 6;
            this.ultraGroupBox1.Text = "LOT 투입";
            // 
            // txtINLotNo
            // 
            this.txtINLotNo.Location = new System.Drawing.Point(80, 27);
            this.txtINLotNo.Name = "txtINLotNo";
            this.txtINLotNo.Size = new System.Drawing.Size(284, 29);
            this.txtINLotNo.TabIndex = 1;
            // 
            // btnLOTIn
            // 
            this.btnLOTIn.Location = new System.Drawing.Point(164, 73);
            this.btnLOTIn.Name = "btnLOTIn";
            this.btnLOTIn.Size = new System.Drawing.Size(188, 34);
            this.btnLOTIn.TabIndex = 5;
            this.btnLOTIn.Text = "(4) LOT 투입";
            // 
            // sLabel4
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance6;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(6, 27);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(68, 34);
            this.sLabel4.TabIndex = 0;
            this.sLabel4.Text = "LOT번호";
            // 
            // btnRunStop
            // 
            this.btnRunStop.Location = new System.Drawing.Point(639, 66);
            this.btnRunStop.Name = "btnRunStop";
            this.btnRunStop.Size = new System.Drawing.Size(173, 97);
            this.btnRunStop.TabIndex = 7;
            this.btnRunStop.Text = "(5)가동";
            // 
            // txtProdQty
            // 
            this.txtProdQty.Location = new System.Drawing.Point(890, 55);
            this.txtProdQty.Name = "txtProdQty";
            this.txtProdQty.Size = new System.Drawing.Size(124, 29);
            this.txtProdQty.TabIndex = 7;
            // 
            // sLabel3
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance5;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(816, 55);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(68, 34);
            this.sLabel3.TabIndex = 6;
            this.sLabel3.Text = "양품수량";
            // 
            // sLabel6
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.sLabel6.Appearance = appearance1;
            this.sLabel6.DbField = null;
            this.sLabel6.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel6.Location = new System.Drawing.Point(816, 90);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel6.Size = new System.Drawing.Size(68, 34);
            this.sLabel6.TabIndex = 6;
            this.sLabel6.Text = "불량수량";
            // 
            // txtBadQty
            // 
            this.txtBadQty.Location = new System.Drawing.Point(890, 90);
            this.txtBadQty.Name = "txtBadQty";
            this.txtBadQty.Size = new System.Drawing.Size(124, 29);
            this.txtBadQty.TabIndex = 7;
            // 
            // btnProdReg
            // 
            this.btnProdReg.Location = new System.Drawing.Point(849, 125);
            this.btnProdReg.Name = "btnProdReg";
            this.btnProdReg.Size = new System.Drawing.Size(165, 38);
            this.btnProdReg.TabIndex = 7;
            this.btnProdReg.Text = "(6)생산 실적 등록";
            // 
            // btnOrderClose
            // 
            this.btnOrderClose.Location = new System.Drawing.Point(1033, 57);
            this.btnOrderClose.Name = "btnOrderClose";
            this.btnOrderClose.Size = new System.Drawing.Size(136, 97);
            this.btnOrderClose.TabIndex = 7;
            this.btnOrderClose.Text = "(7)작업지시종료";
            // 
            // PP_ActureOutput
            // 
            this.ClientSize = new System.Drawing.Size(1249, 651);
            this.Name = "PP_ActureOutput";
            this.Text = "생산 실적 등록";
            this.Load += new System.EventHandler(this.PP_ActureOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkcenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtINLotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBadQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private DC00_Component.SLabel sLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboWorkcenter;
        private DC00_Component.SLabel sLabel5;
        private DC00_Component.Grid grid1;
        private DC00_Component.SLabel sLabel2;
        private DC00_Component.STextBox txtWorkerName;
        private DC00_Component.SBtnTextEditor txtWorkerID;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtProdQty;
        private Infragistics.Win.Misc.UltraButton btnRunStop;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtINLotNo;
        private Infragistics.Win.Misc.UltraButton btnLOTIn;
        private DC00_Component.SLabel sLabel4;
        private Infragistics.Win.Misc.UltraButton btnOrderNo;
        private Infragistics.Win.Misc.UltraButton btnWorkerReg;
        private DC00_Component.SLabel sLabel3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBadQty;
        private DC00_Component.SLabel sLabel6;
        private Infragistics.Win.Misc.UltraButton btnProdReg;
        private Infragistics.Win.Misc.UltraButton btnOrderClose;
    }
}
