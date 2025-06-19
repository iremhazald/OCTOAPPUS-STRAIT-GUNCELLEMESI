namespace HanShipProformaApp
{
    partial class Straits
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbTransitType = new ComboBox();
            btnCalculate = new Button();
            groupBoxVesselInfo = new GroupBox();
            btnsave = new Button();
            btncheck = new Button();
            label2 = new Label();
            labelIMO = new Label();
            tboxIMO = new TextBox();
            labelShipName = new Label();
            tboxShipName = new TextBox();
            labelCustomer = new Label();
            tboxCustomer = new TextBox();
            labelLOA = new Label();
            tboxLOA = new TextBox();
            labelBEAM = new Label();
            tboxBeam = new TextBox();
            labelDraft = new Label();
            tboxDraft = new TextBox();
            labelDWT = new Label();
            tboxDWT = new TextBox();
            labelNetTonnage = new Label();
            tboxNetTonage = new TextBox();
            labelGrossTonnage = new Label();
            tboxGrossTonage = new TextBox();
            labelCargoWeight = new Label();
            tboxCargoWeight = new TextBox();
            labelCargoType = new Label();
            cmbBoxCargoType = new ComboBox();
            tboxOtherCargoType = new TextBox();
            labelInbound = new Label();
            cmbBoxInBound = new ComboBox();
            labelOutbound = new Label();
            cmbBoxOutBound = new ComboBox();
            groupBox1 = new GroupBox();
            gbPD = new GroupBox();
            cmbSecondDirection = new ComboBox();
            cmbFirstDirection = new ComboBox();
            lblSD = new Label();
            lblFD = new Label();
            chkDardanelles = new CheckBox();
            chkBosphorus = new CheckBox();
            lblTT = new Label();
            labelPassangeCount = new Label();
            nudPC = new NumericUpDown();
            gbERS = new GroupBox();
            labelDolarTL = new Label();
            labelEuroDolar = new Label();
            tboxmanualdolar = new TextBox();
            Lblmanual = new Label();
            tboxmanualeuro = new TextBox();
            Lblmanual2 = new Label();
            labelEuroRate = new Label();
            chkUSD = new CheckBox();
            chkEURO = new CheckBox();
            groupBox3 = new GroupBox();
            lblFlagName = new Label();
            tboxFlagName = new TextBox();
            lblNation = new Label();
            cmboxNation = new ComboBox();
            labelFlag = new Label();
            cmbBoxFlag = new ComboBox();
            tboxOutbound = new TextBox();
            tboxInbound = new TextBox();
            gbOverrides = new GroupBox();
            lblNote1 = new Label();
            chkWP = new CheckBox();
            chkStraitInformersDeleted = new CheckBox();
            lblAFC = new Label();
            groupBox2 = new GroupBox();
            tboxHusbandryName = new TextBox();
            tboxHusbandryPrices = new TextBox();
            chkHusbandry = new CheckBox();
            groupBoxVesselInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            gbPD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPC).BeginInit();
            gbERS.SuspendLayout();
            groupBox3.SuspendLayout();
            gbOverrides.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbTransitType
            // 
            cmbTransitType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransitType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTransitType.FormattingEnabled = true;
            cmbTransitType.Items.AddRange(new object[] { "FULL TRANSIT", "HALF TRANSIT", "NON TRANSIT" });
            cmbTransitType.Location = new Point(170, 34);
            cmbTransitType.Name = "cmbTransitType";
            cmbTransitType.Size = new Size(157, 29);
            cmbTransitType.TabIndex = 10;
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.MidnightBlue;
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(913, 809);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(330, 63);
            btnCalculate.TabIndex = 11;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += HandleCalculateClick;
            // 
            // groupBoxVesselInfo
            // 
            groupBoxVesselInfo.Controls.Add(btnsave);
            groupBoxVesselInfo.Controls.Add(btncheck);
            groupBoxVesselInfo.Controls.Add(label2);
            groupBoxVesselInfo.Controls.Add(labelIMO);
            groupBoxVesselInfo.Controls.Add(tboxIMO);
            groupBoxVesselInfo.Controls.Add(labelShipName);
            groupBoxVesselInfo.Controls.Add(tboxShipName);
            groupBoxVesselInfo.Controls.Add(labelCustomer);
            groupBoxVesselInfo.Controls.Add(tboxCustomer);
            groupBoxVesselInfo.Controls.Add(labelLOA);
            groupBoxVesselInfo.Controls.Add(tboxLOA);
            groupBoxVesselInfo.Controls.Add(labelBEAM);
            groupBoxVesselInfo.Controls.Add(tboxBeam);
            groupBoxVesselInfo.Controls.Add(labelDraft);
            groupBoxVesselInfo.Controls.Add(tboxDraft);
            groupBoxVesselInfo.Controls.Add(labelDWT);
            groupBoxVesselInfo.Controls.Add(tboxDWT);
            groupBoxVesselInfo.Controls.Add(labelNetTonnage);
            groupBoxVesselInfo.Controls.Add(tboxNetTonage);
            groupBoxVesselInfo.Controls.Add(labelGrossTonnage);
            groupBoxVesselInfo.Controls.Add(tboxGrossTonage);
            groupBoxVesselInfo.Controls.Add(labelCargoWeight);
            groupBoxVesselInfo.Controls.Add(tboxCargoWeight);
            groupBoxVesselInfo.Controls.Add(labelCargoType);
            groupBoxVesselInfo.Controls.Add(cmbBoxCargoType);
            groupBoxVesselInfo.Controls.Add(tboxOtherCargoType);
            groupBoxVesselInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxVesselInfo.ForeColor = Color.FromArgb(57, 52, 130);
            groupBoxVesselInfo.Location = new Point(20, 12);
            groupBoxVesselInfo.Name = "groupBoxVesselInfo";
            groupBoxVesselInfo.Size = new Size(1223, 344);
            groupBoxVesselInfo.TabIndex = 15;
            groupBoxVesselInfo.TabStop = false;
            groupBoxVesselInfo.Text = "Vessel Information";
            // 
            // btnsave
            // 
            btnsave.BackColor = Color.FromArgb(90, 159, 223);
            btnsave.FlatStyle = FlatStyle.Flat;
            btnsave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnsave.ForeColor = Color.White;
            btnsave.Location = new Point(647, 271);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(496, 45);
            btnsave.TabIndex = 34;
            btnsave.Text = "Save";
            btnsave.UseVisualStyleBackColor = false;
            btnsave.Click += btnsave_Click;
            // 
            // btncheck
            // 
            btncheck.BackColor = Color.FromArgb(90, 159, 223);
            btncheck.FlatStyle = FlatStyle.Flat;
            btncheck.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btncheck.ForeColor = Color.White;
            btncheck.Location = new Point(67, 271);
            btncheck.Name = "btncheck";
            btncheck.Size = new Size(496, 45);
            btncheck.TabIndex = 33;
            btncheck.Text = "Check";
            btncheck.UseVisualStyleBackColor = false;
            btncheck.Click += btncheck_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(50, 45, 126);
            label2.Location = new Point(963, 185);
            label2.Name = "label2";
            label2.Size = new Size(111, 23);
            label2.TabIndex = 16;
            label2.Text = "Cargo Detail";
            // 
            // labelIMO
            // 
            labelIMO.AutoSize = true;
            labelIMO.ForeColor = Color.FromArgb(50, 45, 126);
            labelIMO.Location = new Point(66, 41);
            labelIMO.Name = "labelIMO";
            labelIMO.Size = new Size(44, 23);
            labelIMO.TabIndex = 0;
            labelIMO.Text = "IMO";
            // 
            // tboxIMO
            // 
            tboxIMO.Location = new Point(66, 66);
            tboxIMO.Name = "tboxIMO";
            tboxIMO.Size = new Size(172, 30);
            tboxIMO.TabIndex = 1;
            // 
            // labelShipName
            // 
            labelShipName.AutoSize = true;
            labelShipName.ForeColor = Color.FromArgb(50, 45, 126);
            labelShipName.Location = new Point(284, 40);
            labelShipName.Name = "labelShipName";
            labelShipName.Size = new Size(98, 23);
            labelShipName.TabIndex = 2;
            labelShipName.Text = "Ship Name";
            // 
            // tboxShipName
            // 
            tboxShipName.Location = new Point(284, 66);
            tboxShipName.Name = "tboxShipName";
            tboxShipName.Size = new Size(185, 30);
            tboxShipName.TabIndex = 2;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.ForeColor = Color.FromArgb(50, 45, 126);
            labelCustomer.Location = new Point(520, 41);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(80, 23);
            labelCustomer.TabIndex = 3;
            labelCustomer.Text = "Principal";
            // 
            // tboxCustomer
            // 
            tboxCustomer.Location = new Point(520, 68);
            tboxCustomer.Name = "tboxCustomer";
            tboxCustomer.Size = new Size(185, 30);
            tboxCustomer.TabIndex = 3;
            // 
            // labelLOA
            // 
            labelLOA.AutoSize = true;
            labelLOA.ForeColor = Color.FromArgb(50, 45, 126);
            labelLOA.Location = new Point(66, 107);
            labelLOA.Name = "labelLOA";
            labelLOA.Size = new Size(44, 23);
            labelLOA.TabIndex = 6;
            labelLOA.Text = "LOA";
            // 
            // tboxLOA
            // 
            tboxLOA.Location = new Point(66, 134);
            tboxLOA.Name = "tboxLOA";
            tboxLOA.Size = new Size(172, 30);
            tboxLOA.TabIndex = 6;
            // 
            // labelBEAM
            // 
            labelBEAM.AutoSize = true;
            labelBEAM.ForeColor = Color.FromArgb(50, 45, 126);
            labelBEAM.Location = new Point(284, 107);
            labelBEAM.Name = "labelBEAM";
            labelBEAM.Size = new Size(58, 23);
            labelBEAM.TabIndex = 7;
            labelBEAM.Text = "BEAM";
            // 
            // tboxBeam
            // 
            tboxBeam.Location = new Point(284, 133);
            tboxBeam.Name = "tboxBeam";
            tboxBeam.Size = new Size(185, 30);
            tboxBeam.TabIndex = 7;
            // 
            // labelDraft
            // 
            labelDraft.AutoSize = true;
            labelDraft.ForeColor = Color.FromArgb(50, 45, 126);
            labelDraft.Location = new Point(520, 107);
            labelDraft.Name = "labelDraft";
            labelDraft.Size = new Size(53, 23);
            labelDraft.TabIndex = 8;
            labelDraft.Text = "Draft";
            // 
            // tboxDraft
            // 
            tboxDraft.Location = new Point(520, 134);
            tboxDraft.Name = "tboxDraft";
            tboxDraft.Size = new Size(185, 30);
            tboxDraft.TabIndex = 8;
            // 
            // labelDWT
            // 
            labelDWT.AutoSize = true;
            labelDWT.ForeColor = Color.FromArgb(50, 45, 126);
            labelDWT.Location = new Point(745, 105);
            labelDWT.Name = "labelDWT";
            labelDWT.Size = new Size(50, 23);
            labelDWT.TabIndex = 9;
            labelDWT.Text = "DWT";
            // 
            // tboxDWT
            // 
            tboxDWT.Location = new Point(745, 134);
            tboxDWT.Name = "tboxDWT";
            tboxDWT.Size = new Size(180, 30);
            tboxDWT.TabIndex = 9;
            // 
            // labelNetTonnage
            // 
            labelNetTonnage.AutoSize = true;
            labelNetTonnage.ForeColor = Color.FromArgb(50, 45, 126);
            labelNetTonnage.Location = new Point(521, 185);
            labelNetTonnage.Name = "labelNetTonnage";
            labelNetTonnage.Size = new Size(111, 23);
            labelNetTonnage.TabIndex = 10;
            labelNetTonnage.Text = "Net Tonnage";
            // 
            // tboxNetTonage
            // 
            tboxNetTonage.Location = new Point(521, 211);
            tboxNetTonage.Name = "tboxNetTonage";
            tboxNetTonage.Size = new Size(185, 30);
            tboxNetTonage.TabIndex = 10;
            // 
            // labelGrossTonnage
            // 
            labelGrossTonnage.AutoSize = true;
            labelGrossTonnage.ForeColor = Color.FromArgb(50, 45, 126);
            labelGrossTonnage.Location = new Point(746, 184);
            labelGrossTonnage.Name = "labelGrossTonnage";
            labelGrossTonnage.Size = new Size(125, 23);
            labelGrossTonnage.TabIndex = 11;
            labelGrossTonnage.Text = "Gross Tonnage";
            // 
            // tboxGrossTonage
            // 
            tboxGrossTonage.Location = new Point(746, 211);
            tboxGrossTonage.Name = "tboxGrossTonage";
            tboxGrossTonage.Size = new Size(180, 30);
            tboxGrossTonage.TabIndex = 11;
            // 
            // labelCargoWeight
            // 
            labelCargoWeight.AutoSize = true;
            labelCargoWeight.ForeColor = Color.FromArgb(50, 45, 126);
            labelCargoWeight.Location = new Point(67, 180);
            labelCargoWeight.Name = "labelCargoWeight";
            labelCargoWeight.Size = new Size(122, 23);
            labelCargoWeight.TabIndex = 12;
            labelCargoWeight.Text = "Cargo Weight";
            // 
            // tboxCargoWeight
            // 
            tboxCargoWeight.Location = new Point(67, 207);
            tboxCargoWeight.Name = "tboxCargoWeight";
            tboxCargoWeight.Size = new Size(172, 30);
            tboxCargoWeight.TabIndex = 12;
            // 
            // labelCargoType
            // 
            labelCargoType.AutoSize = true;
            labelCargoType.ForeColor = Color.FromArgb(50, 45, 126);
            labelCargoType.Location = new Point(285, 179);
            labelCargoType.Name = "labelCargoType";
            labelCargoType.Size = new Size(101, 23);
            labelCargoType.TabIndex = 13;
            labelCargoType.Text = "Cargo Type";
            // 
            // cmbBoxCargoType
            // 
            cmbBoxCargoType.BackColor = Color.White;
            cmbBoxCargoType.ForeColor = Color.Black;
            cmbBoxCargoType.FormattingEnabled = true;
            cmbBoxCargoType.Location = new Point(285, 205);
            cmbBoxCargoType.Name = "cmbBoxCargoType";
            cmbBoxCargoType.Size = new Size(185, 31);
            cmbBoxCargoType.TabIndex = 13;
            // 
            // tboxOtherCargoType
            // 
            tboxOtherCargoType.Location = new Point(963, 212);
            tboxOtherCargoType.Name = "tboxOtherCargoType";
            tboxOtherCargoType.Size = new Size(185, 30);
            tboxOtherCargoType.TabIndex = 14;
            // 
            // labelInbound
            // 
            labelInbound.AutoSize = true;
            labelInbound.ForeColor = Color.FromArgb(50, 45, 126);
            labelInbound.Location = new Point(15, 34);
            labelInbound.Name = "labelInbound";
            labelInbound.Size = new Size(77, 23);
            labelInbound.TabIndex = 0;
            labelInbound.Text = "Inbound";
            // 
            // cmbBoxInBound
            // 
            cmbBoxInBound.BackColor = Color.White;
            cmbBoxInBound.ForeColor = Color.Black;
            cmbBoxInBound.FormattingEnabled = true;
            cmbBoxInBound.Location = new Point(15, 60);
            cmbBoxInBound.Name = "cmbBoxInBound";
            cmbBoxInBound.Size = new Size(185, 31);
            cmbBoxInBound.TabIndex = 15;
            // 
            // labelOutbound
            // 
            labelOutbound.AutoSize = true;
            labelOutbound.ForeColor = Color.FromArgb(50, 45, 126);
            labelOutbound.Location = new Point(15, 144);
            labelOutbound.Name = "labelOutbound";
            labelOutbound.Size = new Size(92, 23);
            labelOutbound.TabIndex = 16;
            labelOutbound.Text = "Outbound";
            // 
            // cmbBoxOutBound
            // 
            cmbBoxOutBound.BackColor = Color.White;
            cmbBoxOutBound.ForeColor = Color.Black;
            cmbBoxOutBound.FormattingEnabled = true;
            cmbBoxOutBound.Location = new Point(15, 171);
            cmbBoxOutBound.Name = "cmbBoxOutBound";
            cmbBoxOutBound.Size = new Size(185, 31);
            cmbBoxOutBound.TabIndex = 16;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(gbPD);
            groupBox1.Controls.Add(chkDardanelles);
            groupBox1.Controls.Add(chkBosphorus);
            groupBox1.Controls.Add(lblTT);
            groupBox1.Controls.Add(labelPassangeCount);
            groupBox1.Controls.Add(nudPC);
            groupBox1.Controls.Add(cmbTransitType);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(57, 52, 130);
            groupBox1.Location = new Point(20, 371);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(408, 319);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Transit Conditions";
            // 
            // gbPD
            // 
            gbPD.Controls.Add(cmbSecondDirection);
            gbPD.Controls.Add(cmbFirstDirection);
            gbPD.Controls.Add(lblSD);
            gbPD.Controls.Add(lblFD);
            gbPD.ForeColor = Color.FromArgb(57, 52, 130);
            gbPD.Location = new Point(13, 173);
            gbPD.Name = "gbPD";
            gbPD.Size = new Size(386, 134);
            gbPD.TabIndex = 32;
            gbPD.TabStop = false;
            gbPD.Text = "Passage Directions";
            // 
            // cmbSecondDirection
            // 
            cmbSecondDirection.FormattingEnabled = true;
            cmbSecondDirection.Location = new Point(223, 85);
            cmbSecondDirection.Name = "cmbSecondDirection";
            cmbSecondDirection.Size = new Size(151, 31);
            cmbSecondDirection.TabIndex = 45;
            // 
            // cmbFirstDirection
            // 
            cmbFirstDirection.FormattingEnabled = true;
            cmbFirstDirection.Location = new Point(223, 46);
            cmbFirstDirection.Name = "cmbFirstDirection";
            cmbFirstDirection.Size = new Size(151, 31);
            cmbFirstDirection.TabIndex = 44;
            // 
            // lblSD
            // 
            lblSD.AutoSize = true;
            lblSD.Location = new Point(8, 88);
            lblSD.Name = "lblSD";
            lblSD.Size = new Size(212, 23);
            lblSD.TabIndex = 43;
            lblSD.Text = "Final Passage (Optional) :";
            // 
            // lblFD
            // 
            lblFD.AutoSize = true;
            lblFD.Location = new Point(8, 46);
            lblFD.Name = "lblFD";
            lblFD.Size = new Size(133, 23);
            lblFD.TabIndex = 42;
            lblFD.Text = "Initial Passage :";
            // 
            // chkDardanelles
            // 
            chkDardanelles.AutoSize = true;
            chkDardanelles.Location = new Point(158, 104);
            chkDardanelles.Name = "chkDardanelles";
            chkDardanelles.Size = new Size(126, 27);
            chkDardanelles.TabIndex = 31;
            chkDardanelles.Text = "Dardanelles";
            chkDardanelles.UseVisualStyleBackColor = true;
            // 
            // chkBosphorus
            // 
            chkBosphorus.AutoSize = true;
            chkBosphorus.Location = new Point(18, 104);
            chkBosphorus.Name = "chkBosphorus";
            chkBosphorus.Size = new Size(115, 27);
            chkBosphorus.TabIndex = 30;
            chkBosphorus.Text = "Bosphorus";
            chkBosphorus.UseVisualStyleBackColor = true;
            // 
            // lblTT
            // 
            lblTT.AutoSize = true;
            lblTT.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTT.Location = new Point(13, 34);
            lblTT.Name = "lblTT";
            lblTT.Size = new Size(117, 23);
            lblTT.TabIndex = 14;
            lblTT.Text = "Transit Type :";
            // 
            // labelPassangeCount
            // 
            labelPassangeCount.AutoSize = true;
            labelPassangeCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPassangeCount.ForeColor = Color.FromArgb(50, 45, 126);
            labelPassangeCount.Location = new Point(18, 138);
            labelPassangeCount.Name = "labelPassangeCount";
            labelPassangeCount.Size = new Size(140, 23);
            labelPassangeCount.TabIndex = 22;
            labelPassangeCount.Text = "Passage Count  :";
            // 
            // nudPC
            // 
            nudPC.ForeColor = Color.FromArgb(0, 0, 64);
            nudPC.Location = new Point(177, 137);
            nudPC.Name = "nudPC";
            nudPC.Size = new Size(150, 30);
            nudPC.TabIndex = 28;
            // 
            // gbERS
            // 
            gbERS.Controls.Add(labelDolarTL);
            gbERS.Controls.Add(labelEuroDolar);
            gbERS.Controls.Add(tboxmanualdolar);
            gbERS.Controls.Add(Lblmanual);
            gbERS.Controls.Add(tboxmanualeuro);
            gbERS.Controls.Add(Lblmanual2);
            gbERS.Controls.Add(labelEuroRate);
            gbERS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbERS.ForeColor = Color.FromArgb(57, 52, 130);
            gbERS.Location = new Point(456, 637);
            gbERS.Name = "gbERS";
            gbERS.Size = new Size(340, 259);
            gbERS.TabIndex = 36;
            gbERS.TabStop = false;
            gbERS.Text = "Exchange Rates and Settings";
            // 
            // labelDolarTL
            // 
            labelDolarTL.AutoSize = true;
            labelDolarTL.Location = new Point(25, 85);
            labelDolarTL.Name = "labelDolarTL";
            labelDolarTL.Size = new Size(0, 23);
            labelDolarTL.TabIndex = 33;
            // 
            // labelEuroDolar
            // 
            labelEuroDolar.AutoSize = true;
            labelEuroDolar.Location = new Point(25, 45);
            labelEuroDolar.Name = "labelEuroDolar";
            labelEuroDolar.Size = new Size(0, 23);
            labelEuroDolar.TabIndex = 32;
            // 
            // tboxmanualdolar
            // 
            tboxmanualdolar.Font = new Font("Segoe UI", 10F);
            tboxmanualdolar.Location = new Point(180, 180);
            tboxmanualdolar.Name = "tboxmanualdolar";
            tboxmanualdolar.Size = new Size(150, 30);
            tboxmanualdolar.TabIndex = 31;
            // 
            // Lblmanual
            // 
            Lblmanual.AutoSize = true;
            Lblmanual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Lblmanual.ForeColor = Color.FromArgb(50, 45, 126);
            Lblmanual.Location = new Point(20, 140);
            Lblmanual.Name = "Lblmanual";
            Lblmanual.Size = new Size(154, 23);
            Lblmanual.TabIndex = 0;
            Lblmanual.Text = "Manual EUR/USD:";
            // 
            // tboxmanualeuro
            // 
            tboxmanualeuro.Font = new Font("Segoe UI", 10F);
            tboxmanualeuro.Location = new Point(180, 140);
            tboxmanualeuro.Name = "tboxmanualeuro";
            tboxmanualeuro.Size = new Size(150, 30);
            tboxmanualeuro.TabIndex = 30;
            // 
            // Lblmanual2
            // 
            Lblmanual2.AutoSize = true;
            Lblmanual2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Lblmanual2.ForeColor = Color.FromArgb(50, 45, 126);
            Lblmanual2.Location = new Point(20, 180);
            Lblmanual2.Name = "Lblmanual2";
            Lblmanual2.Size = new Size(153, 23);
            Lblmanual2.TabIndex = 0;
            Lblmanual2.Text = "Manual USD/TRY:";
            // 
            // labelEuroRate
            // 
            labelEuroRate.AutoSize = true;
            labelEuroRate.Location = new Point(865, 335);
            labelEuroRate.Name = "labelEuroRate";
            labelEuroRate.Size = new Size(131, 23);
            labelEuroRate.TabIndex = 35;
            labelEuroRate.Text = "EUR/USD Rate:";
            labelEuroRate.Visible = false;
            // 
            // chkUSD
            // 
            chkUSD.AutoSize = true;
            chkUSD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkUSD.Location = new Point(1081, 776);
            chkUSD.Name = "chkUSD";
            chkUSD.Size = new Size(67, 27);
            chkUSD.TabIndex = 40;
            chkUSD.Text = "USD";
            chkUSD.UseVisualStyleBackColor = true;
            // 
            // chkEURO
            // 
            chkEURO.AutoSize = true;
            chkEURO.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkEURO.Location = new Point(1163, 776);
            chkEURO.Name = "chkEURO";
            chkEURO.Size = new Size(77, 27);
            chkEURO.TabIndex = 41;
            chkEURO.Text = "EURO";
            chkEURO.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblFlagName);
            groupBox3.Controls.Add(tboxFlagName);
            groupBox3.Controls.Add(lblNation);
            groupBox3.Controls.Add(cmboxNation);
            groupBox3.Controls.Add(labelFlag);
            groupBox3.Controls.Add(cmbBoxFlag);
            groupBox3.Controls.Add(tboxOutbound);
            groupBox3.Controls.Add(tboxInbound);
            groupBox3.Controls.Add(labelInbound);
            groupBox3.Controls.Add(cmbBoxInBound);
            groupBox3.Controls.Add(labelOutbound);
            groupBox3.Controls.Add(cmbBoxOutBound);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(57, 52, 130);
            groupBox3.Location = new Point(436, 371);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(538, 251);
            groupBox3.TabIndex = 37;
            groupBox3.TabStop = false;
            groupBox3.Text = "Operation Settings";
            // 
            // lblFlagName
            // 
            lblFlagName.AutoSize = true;
            lblFlagName.Location = new Point(283, 179);
            lblFlagName.Name = "lblFlagName";
            lblFlagName.Size = new Size(67, 23);
            lblFlagName.TabIndex = 43;
            lblFlagName.Text = "Name :";
            // 
            // tboxFlagName
            // 
            tboxFlagName.Location = new Point(286, 208);
            tboxFlagName.Name = "tboxFlagName";
            tboxFlagName.Size = new Size(185, 30);
            tboxFlagName.TabIndex = 42;
            // 
            // lblNation
            // 
            lblNation.AutoSize = true;
            lblNation.ForeColor = Color.FromArgb(50, 45, 126);
            lblNation.Location = new Point(286, 33);
            lblNation.Name = "lblNation";
            lblNation.Size = new Size(64, 23);
            lblNation.TabIndex = 40;
            lblNation.Text = "Nation";
            // 
            // cmboxNation
            // 
            cmboxNation.BackColor = Color.White;
            cmboxNation.ForeColor = Color.Black;
            cmboxNation.FormattingEnabled = true;
            cmboxNation.Location = new Point(286, 60);
            cmboxNation.Name = "cmboxNation";
            cmboxNation.Size = new Size(185, 31);
            cmboxNation.TabIndex = 41;
            // 
            // labelFlag
            // 
            labelFlag.AutoSize = true;
            labelFlag.ForeColor = Color.FromArgb(50, 45, 126);
            labelFlag.Location = new Point(286, 115);
            labelFlag.Name = "labelFlag";
            labelFlag.Size = new Size(54, 23);
            labelFlag.TabIndex = 38;
            labelFlag.Text = "Flag :";
            // 
            // cmbBoxFlag
            // 
            cmbBoxFlag.BackColor = Color.White;
            cmbBoxFlag.ForeColor = Color.Black;
            cmbBoxFlag.FormattingEnabled = true;
            cmbBoxFlag.Location = new Point(286, 141);
            cmbBoxFlag.Name = "cmbBoxFlag";
            cmbBoxFlag.Size = new Size(185, 31);
            cmbBoxFlag.TabIndex = 39;
            // 
            // tboxOutbound
            // 
            tboxOutbound.Location = new Point(15, 208);
            tboxOutbound.Name = "tboxOutbound";
            tboxOutbound.Size = new Size(185, 30);
            tboxOutbound.TabIndex = 18;
            // 
            // tboxInbound
            // 
            tboxInbound.Location = new Point(15, 101);
            tboxInbound.Name = "tboxInbound";
            tboxInbound.Size = new Size(185, 30);
            tboxInbound.TabIndex = 17;
            // 
            // gbOverrides
            // 
            gbOverrides.Controls.Add(lblNote1);
            gbOverrides.Controls.Add(chkWP);
            gbOverrides.Controls.Add(chkStraitInformersDeleted);
            gbOverrides.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbOverrides.ForeColor = Color.FromArgb(57, 52, 130);
            gbOverrides.Location = new Point(20, 696);
            gbOverrides.Name = "gbOverrides";
            gbOverrides.Size = new Size(237, 251);
            gbOverrides.TabIndex = 38;
            gbOverrides.TabStop = false;
            gbOverrides.Text = "Calculation Overrides ";
            // 
            // lblNote1
            // 
            lblNote1.AutoSize = true;
            lblNote1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblNote1.Location = new Point(6, 173);
            lblNote1.Name = "lblNote1";
            lblNote1.Size = new Size(222, 51);
            lblNote1.TabIndex = 30;
            lblNote1.Text = "💡 Note : Use these options only\r\n if you wish to override automatic \r\n calculations.";
            // 
            // chkWP
            // 
            chkWP.AutoSize = true;
            chkWP.Location = new Point(6, 99);
            chkWP.Name = "chkWP";
            chkWP.Size = new Size(191, 27);
            chkWP.TabIndex = 27;
            chkWP.Text = "Is Weekend Passage";
            // 
            // chkStraitInformersDeleted
            // 
            chkStraitInformersDeleted.AutoSize = true;
            chkStraitInformersDeleted.Location = new Point(6, 35);
            chkStraitInformersDeleted.Name = "chkStraitInformersDeleted";
            chkStraitInformersDeleted.Size = new Size(228, 27);
            chkStraitInformersDeleted.TabIndex = 23;
            chkStraitInformersDeleted.Text = "Strait Informers Deleted";
            // 
            // lblAFC
            // 
            lblAFC.AutoSize = true;
            lblAFC.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAFC.ForeColor = Color.FromArgb(50, 45, 126);
            lblAFC.Location = new Point(918, 776);
            lblAFC.Name = "lblAFC";
            lblAFC.Size = new Size(149, 23);
            lblAFC.TabIndex = 24;
            lblAFC.Text = "Currency Choice :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tboxHusbandryName);
            groupBox2.Controls.Add(tboxHusbandryPrices);
            groupBox2.Controls.Add(chkHusbandry);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(57, 52, 130);
            groupBox2.Location = new Point(980, 382);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(290, 278);
            groupBox2.TabIndex = 42;
            groupBox2.TabStop = false;
            groupBox2.Text = "Additional Costs";
            // 
            // tboxHusbandryName
            // 
            tboxHusbandryName.Location = new Point(17, 81);
            tboxHusbandryName.Name = "tboxHusbandryName";
            tboxHusbandryName.Size = new Size(201, 30);
            tboxHusbandryName.TabIndex = 3;
            // 
            // tboxHusbandryPrices
            // 
            tboxHusbandryPrices.Location = new Point(17, 135);
            tboxHusbandryPrices.Name = "tboxHusbandryPrices";
            tboxHusbandryPrices.Size = new Size(201, 30);
            tboxHusbandryPrices.TabIndex = 2;
            // 
            // chkHusbandry
            // 
            chkHusbandry.AutoSize = true;
            chkHusbandry.Location = new Point(17, 39);
            chkHusbandry.Name = "chkHusbandry";
            chkHusbandry.Size = new Size(120, 27);
            chkHusbandry.TabIndex = 0;
            chkHusbandry.Text = "Husbandry";
            chkHusbandry.UseVisualStyleBackColor = true;
            // 
            // Straits
            // 
            AcceptButton = btnCalculate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1282, 908);
            Controls.Add(groupBox2);
            Controls.Add(chkEURO);
            Controls.Add(chkUSD);
            Controls.Add(gbOverrides);
            Controls.Add(lblAFC);
            Controls.Add(gbERS);
            Controls.Add(groupBox3);
            Controls.Add(btnCalculate);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxVesselInfo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(30, 30, 30);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1000, 700);
            Name = "Straits";
            StartPosition = FormStartPosition.CenterParent;
            Text = "StraitsPanel";
            WindowState = FormWindowState.Maximized;
            Load += Straits_Load;
            groupBoxVesselInfo.ResumeLayout(false);
            groupBoxVesselInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbPD.ResumeLayout(false);
            gbPD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPC).EndInit();
            gbERS.ResumeLayout(false);
            gbERS.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbOverrides.ResumeLayout(false);
            gbOverrides.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox cmbTransitType;
        private System.Windows.Forms.Button btnCalculate;
        private GroupBox groupBoxVesselInfo;
        private Label label2;
        private Label labelIMO;
        private TextBox tboxIMO;
        private Label labelShipName;
        private TextBox tboxShipName;
        private Label labelCustomer;
        private TextBox tboxCustomer;
        private Label labelLOA;
        private TextBox tboxLOA;
        private Label labelBEAM;
        private TextBox tboxBeam;
        private TextBox tboxDraft;
        private Label labelDWT;
        private TextBox tboxDWT;
        private Label labelNetTonnage;
        private TextBox tboxNetTonage;
        private Label labelGrossTonnage;
        private TextBox tboxGrossTonage;
        private Label labelCargoWeight;
        private TextBox tboxCargoWeight;
        private Label labelCargoType;
        private ComboBox cmbBoxCargoType;
        private TextBox tboxOtherCargoType;
        private GroupBox groupBox1;
        private Label lblTT;
        private Button btncheck;
        private Button btnsave;
        private GroupBox gbERS;
        private Label labelDolarTL;
        private Label labelEuroDolar;
        private TextBox tboxmanualdolar;
        private Label Lblmanual;
        private TextBox tboxmanualeuro;
        private Label Lblmanual2;
        private GroupBox groupBox3;
        private Label labelPassangeCount;
        private NumericUpDown nudPC;
        private GroupBox gbOverrides;
        private CheckBox chkStraitInformersDeleted;
        private CheckBox chkWP;
        private CheckBox chkDardanelles;
        private CheckBox chkBosphorus;
        private Label lblNote1;
        private Label lblAFC;
        private CheckBox chkUSD;
        private CheckBox chkEURO;
        private Label labelEuroRate;
        private GroupBox gbPD;
        private ComboBox cmbSecondDirection;
        private ComboBox cmbFirstDirection;
        private Label lblSD;
        private Label lblFD;
        private Label labelInbound;
        private ComboBox cmbBoxInBound;
        private Label labelOutbound;
        private ComboBox cmbBoxOutBound;
        private TextBox tboxOutbound;
        private TextBox tboxInbound;
        private GroupBox groupBox2;
        private TextBox tboxHusbandryPrices;
        private CheckBox chkHusbandry;
        private TextBox tboxHusbandryName;
        private Label labelDraft;
        private TextBox tboxFlagName;
        private Label lblNation;
        private ComboBox cmboxNation;
        private Label labelFlag;
        private ComboBox cmbBoxFlag;
        private Label lblFlagName;
    }
}