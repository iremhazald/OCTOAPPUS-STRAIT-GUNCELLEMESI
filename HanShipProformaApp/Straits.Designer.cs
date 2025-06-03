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
            labelStraitFees = new Label();
            tboxStraitFees = new TextBox();
            checkIsTanker = new CheckBox();
            cmbTransitType = new ComboBox();
            btnCalculate = new Button();
            groupBoxVesselInfo = new GroupBox();
            btnsave = new Button();
            btncheck = new Button();
            label2 = new Label();
            labelCountry = new Label();
            labelIMO = new Label();
            tboxIMO = new TextBox();
            labelShipName = new Label();
            tboxShipName = new TextBox();
            labelCustomer = new Label();
            tboxCustomer = new TextBox();
            labelFlag = new Label();
            cmbBoxFlag = new ComboBox();
            flagname = new TextBox();
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
            groupBox1 = new GroupBox();
            chkNB = new CheckBox();
            chkSB = new CheckBox();
            lblPD = new Label();
            chkDardanelles = new CheckBox();
            chkBosphorus = new CheckBox();
            nudPC = new NumericUpDown();
            labelPassangeCount = new Label();
            lblTT = new Label();
            gbERS = new GroupBox();
            labelDolarTL = new Label();
            labelEuroDolar = new Label();
            tboxmanualdolar = new TextBox();
            Lblmanual = new Label();
            tboxmanualeuro = new TextBox();
            Lblmanual2 = new Label();
            labelDuration = new Label();
            tboxDuration = new TextBox();
            labelMooringRate = new Label();
            tboxMooringRate = new TextBox();
            groupBox3 = new GroupBox();
            gbT = new GroupBox();
            lblMT = new Label();
            tboxMT = new TextBox();
            lblTowageTariff = new Label();
            tboxTT = new TextBox();
            gbTO = new GroupBox();
            gbOverrides = new GroupBox();
            chkGarbageFee = new CheckBox();
            lblNote1 = new Label();
            chkLD = new CheckBox();
            chkNCFlag = new CheckBox();
            chkWP = new CheckBox();
            chkSanitaryOverride = new CheckBox();
            chkStraitInformersDeleted = new CheckBox();
            chkForceEscortTug = new CheckBox();
            chkManualAgencyFee = new CheckBox();
            numericManualAgencyFee = new NumericUpDown();
            lblAFC = new Label();
            gbAD = new GroupBox();
            lblNote2 = new Label();
            chkUSD = new CheckBox();
            chkEURO = new CheckBox();
            labelEuroRate = new Label();
            groupBoxVesselInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPC).BeginInit();
            gbERS.SuspendLayout();
            groupBox3.SuspendLayout();
            gbT.SuspendLayout();
            gbTO.SuspendLayout();
            gbOverrides.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericManualAgencyFee).BeginInit();
            gbAD.SuspendLayout();
            SuspendLayout();
            // 
            // labelStraitFees
            // 
            labelStraitFees.AutoSize = true;
            labelStraitFees.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelStraitFees.ForeColor = Color.FromArgb(50, 45, 126);
            labelStraitFees.Location = new Point(6, 36);
            labelStraitFees.Name = "labelStraitFees";
            labelStraitFees.Size = new Size(187, 23);
            labelStraitFees.TabIndex = 6;
            labelStraitFees.Text = "Number of Tugboats :";
            // 
            // tboxStraitFees
            // 
            tboxStraitFees.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxStraitFees.Location = new Point(199, 39);
            tboxStraitFees.Name = "tboxStraitFees";
            tboxStraitFees.Size = new Size(130, 29);
            tboxStraitFees.TabIndex = 7;
            // 
            // checkIsTanker
            // 
            checkIsTanker.AutoSize = true;
            checkIsTanker.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkIsTanker.Location = new Point(163, 148);
            checkIsTanker.Name = "checkIsTanker";
            checkIsTanker.Size = new Size(98, 27);
            checkIsTanker.TabIndex = 8;
            checkIsTanker.Text = "Is Tanker";
            checkIsTanker.UseVisualStyleBackColor = true;
            // 
            // cmbTransitType
            // 
            cmbTransitType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransitType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTransitType.FormattingEnabled = true;
            cmbTransitType.Items.AddRange(new object[] { "FULL TRANSIT", "HALF TRANSIT", "NON TRANSIT" });
            cmbTransitType.Location = new Point(163, 113);
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
            btnCalculate.Location = new Point(889, 879);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(330, 51);
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
            groupBoxVesselInfo.Controls.Add(labelCountry);
            groupBoxVesselInfo.Controls.Add(labelIMO);
            groupBoxVesselInfo.Controls.Add(tboxIMO);
            groupBoxVesselInfo.Controls.Add(labelShipName);
            groupBoxVesselInfo.Controls.Add(tboxShipName);
            groupBoxVesselInfo.Controls.Add(labelCustomer);
            groupBoxVesselInfo.Controls.Add(tboxCustomer);
            groupBoxVesselInfo.Controls.Add(labelFlag);
            groupBoxVesselInfo.Controls.Add(cmbBoxFlag);
            groupBoxVesselInfo.Controls.Add(flagname);
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
            groupBoxVesselInfo.Size = new Size(1167, 328);
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
            btnsave.Location = new Point(597, 246);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(525, 45);
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
            btncheck.Location = new Point(17, 246);
            btncheck.Name = "btncheck";
            btncheck.Size = new Size(525, 45);
            btncheck.TabIndex = 33;
            btncheck.Text = "Check";
            btncheck.UseVisualStyleBackColor = false;
            btncheck.Click += btncheck_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(50, 45, 126);
            label2.Location = new Point(708, 167);
            label2.Name = "label2";
            label2.Size = new Size(111, 23);
            label2.TabIndex = 16;
            label2.Text = "Cargo Detail";
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.ForeColor = Color.FromArgb(50, 45, 126);
            labelCountry.Location = new Point(922, 31);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(75, 23);
            labelCountry.TabIndex = 15;
            labelCountry.Text = "Country";
            // 
            // labelIMO
            // 
            labelIMO.AutoSize = true;
            labelIMO.ForeColor = Color.FromArgb(50, 45, 126);
            labelIMO.Location = new Point(30, 32);
            labelIMO.Name = "labelIMO";
            labelIMO.Size = new Size(44, 23);
            labelIMO.TabIndex = 0;
            labelIMO.Text = "IMO";
            // 
            // tboxIMO
            // 
            tboxIMO.Location = new Point(30, 57);
            tboxIMO.Name = "tboxIMO";
            tboxIMO.Size = new Size(172, 30);
            tboxIMO.TabIndex = 1;
            // 
            // labelShipName
            // 
            labelShipName.AutoSize = true;
            labelShipName.ForeColor = Color.FromArgb(50, 45, 126);
            labelShipName.Location = new Point(248, 31);
            labelShipName.Name = "labelShipName";
            labelShipName.Size = new Size(98, 23);
            labelShipName.TabIndex = 2;
            labelShipName.Text = "Ship Name";
            // 
            // tboxShipName
            // 
            tboxShipName.Location = new Point(248, 57);
            tboxShipName.Name = "tboxShipName";
            tboxShipName.Size = new Size(185, 30);
            tboxShipName.TabIndex = 2;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.ForeColor = Color.FromArgb(50, 45, 126);
            labelCustomer.Location = new Point(707, 30);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(87, 23);
            labelCustomer.TabIndex = 3;
            labelCustomer.Text = "Customer";
            // 
            // tboxCustomer
            // 
            tboxCustomer.Location = new Point(707, 57);
            tboxCustomer.Name = "tboxCustomer";
            tboxCustomer.Size = new Size(174, 30);
            tboxCustomer.TabIndex = 3;
            // 
            // labelFlag
            // 
            labelFlag.AutoSize = true;
            labelFlag.ForeColor = Color.FromArgb(50, 45, 126);
            labelFlag.Location = new Point(485, 29);
            labelFlag.Name = "labelFlag";
            labelFlag.Size = new Size(44, 23);
            labelFlag.TabIndex = 4;
            labelFlag.Text = "Flag";
            // 
            // cmbBoxFlag
            // 
            cmbBoxFlag.BackColor = Color.White;
            cmbBoxFlag.ForeColor = Color.Black;
            cmbBoxFlag.FormattingEnabled = true;
            cmbBoxFlag.Location = new Point(485, 56);
            cmbBoxFlag.Name = "cmbBoxFlag";
            cmbBoxFlag.Size = new Size(180, 31);
            cmbBoxFlag.TabIndex = 4;
            // 
            // flagname
            // 
            flagname.Enabled = false;
            flagname.Location = new Point(922, 57);
            flagname.Name = "flagname";
            flagname.Size = new Size(185, 30);
            flagname.TabIndex = 5;
            // 
            // labelLOA
            // 
            labelLOA.AutoSize = true;
            labelLOA.ForeColor = Color.FromArgb(50, 45, 126);
            labelLOA.Location = new Point(30, 101);
            labelLOA.Name = "labelLOA";
            labelLOA.Size = new Size(44, 23);
            labelLOA.TabIndex = 6;
            labelLOA.Text = "LOA";
            // 
            // tboxLOA
            // 
            tboxLOA.Location = new Point(30, 128);
            tboxLOA.Name = "tboxLOA";
            tboxLOA.Size = new Size(172, 30);
            tboxLOA.TabIndex = 6;
            // 
            // labelBEAM
            // 
            labelBEAM.AutoSize = true;
            labelBEAM.ForeColor = Color.FromArgb(50, 45, 126);
            labelBEAM.Location = new Point(248, 100);
            labelBEAM.Name = "labelBEAM";
            labelBEAM.Size = new Size(58, 23);
            labelBEAM.TabIndex = 7;
            labelBEAM.Text = "BEAM";
            // 
            // tboxBeam
            // 
            tboxBeam.Location = new Point(248, 126);
            tboxBeam.Name = "tboxBeam";
            tboxBeam.Size = new Size(185, 30);
            tboxBeam.TabIndex = 7;
            // 
            // labelDraft
            // 
            labelDraft.AutoSize = true;
            labelDraft.ForeColor = Color.FromArgb(50, 45, 126);
            labelDraft.Location = new Point(485, 100);
            labelDraft.Name = "labelDraft";
            labelDraft.Size = new Size(53, 23);
            labelDraft.TabIndex = 8;
            labelDraft.Text = "Draft";
            // 
            // tboxDraft
            // 
            tboxDraft.Location = new Point(485, 127);
            tboxDraft.Name = "tboxDraft";
            tboxDraft.Size = new Size(180, 30);
            tboxDraft.TabIndex = 8;
            // 
            // labelDWT
            // 
            labelDWT.AutoSize = true;
            labelDWT.ForeColor = Color.FromArgb(50, 45, 126);
            labelDWT.Location = new Point(709, 102);
            labelDWT.Name = "labelDWT";
            labelDWT.Size = new Size(50, 23);
            labelDWT.TabIndex = 9;
            labelDWT.Text = "DWT";
            // 
            // tboxDWT
            // 
            tboxDWT.Location = new Point(709, 129);
            tboxDWT.Name = "tboxDWT";
            tboxDWT.Size = new Size(172, 30);
            tboxDWT.TabIndex = 9;
            // 
            // labelNetTonnage
            // 
            labelNetTonnage.AutoSize = true;
            labelNetTonnage.ForeColor = Color.FromArgb(50, 45, 126);
            labelNetTonnage.Location = new Point(922, 101);
            labelNetTonnage.Name = "labelNetTonnage";
            labelNetTonnage.Size = new Size(111, 23);
            labelNetTonnage.TabIndex = 10;
            labelNetTonnage.Text = "Net Tonnage";
            // 
            // tboxNetTonage
            // 
            tboxNetTonage.Location = new Point(922, 127);
            tboxNetTonage.Name = "tboxNetTonage";
            tboxNetTonage.Size = new Size(185, 30);
            tboxNetTonage.TabIndex = 10;
            // 
            // labelGrossTonnage
            // 
            labelGrossTonnage.AutoSize = true;
            labelGrossTonnage.ForeColor = Color.FromArgb(50, 45, 126);
            labelGrossTonnage.Location = new Point(485, 167);
            labelGrossTonnage.Name = "labelGrossTonnage";
            labelGrossTonnage.Size = new Size(125, 23);
            labelGrossTonnage.TabIndex = 11;
            labelGrossTonnage.Text = "Gross Tonnage";
            // 
            // tboxGrossTonage
            // 
            tboxGrossTonage.Location = new Point(485, 194);
            tboxGrossTonage.Name = "tboxGrossTonage";
            tboxGrossTonage.Size = new Size(180, 30);
            tboxGrossTonage.TabIndex = 11;
            // 
            // labelCargoWeight
            // 
            labelCargoWeight.AutoSize = true;
            labelCargoWeight.ForeColor = Color.FromArgb(50, 45, 126);
            labelCargoWeight.Location = new Point(30, 168);
            labelCargoWeight.Name = "labelCargoWeight";
            labelCargoWeight.Size = new Size(122, 23);
            labelCargoWeight.TabIndex = 12;
            labelCargoWeight.Text = "Cargo Weight";
            // 
            // tboxCargoWeight
            // 
            tboxCargoWeight.Location = new Point(30, 195);
            tboxCargoWeight.Name = "tboxCargoWeight";
            tboxCargoWeight.Size = new Size(172, 30);
            tboxCargoWeight.TabIndex = 12;
            // 
            // labelCargoType
            // 
            labelCargoType.AutoSize = true;
            labelCargoType.ForeColor = Color.FromArgb(50, 45, 126);
            labelCargoType.Location = new Point(248, 167);
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
            cmbBoxCargoType.Location = new Point(248, 193);
            cmbBoxCargoType.Name = "cmbBoxCargoType";
            cmbBoxCargoType.Size = new Size(185, 31);
            cmbBoxCargoType.TabIndex = 13;
            // 
            // tboxOtherCargoType
            // 
            tboxOtherCargoType.Location = new Point(708, 194);
            tboxOtherCargoType.Name = "tboxOtherCargoType";
            tboxOtherCargoType.Size = new Size(172, 30);
            tboxOtherCargoType.TabIndex = 14;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkNB);
            groupBox1.Controls.Add(chkSB);
            groupBox1.Controls.Add(lblPD);
            groupBox1.Controls.Add(chkDardanelles);
            groupBox1.Controls.Add(chkBosphorus);
            groupBox1.Controls.Add(nudPC);
            groupBox1.Controls.Add(labelPassangeCount);
            groupBox1.Controls.Add(lblTT);
            groupBox1.Controls.Add(cmbTransitType);
            groupBox1.Controls.Add(checkIsTanker);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(57, 52, 130);
            groupBox1.Location = new Point(20, 345);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(411, 258);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Transit Conditions";
            // 
            // chkNB
            // 
            chkNB.AutoSize = true;
            chkNB.Location = new Point(254, 66);
            chkNB.Name = "chkNB";
            chkNB.Size = new Size(56, 27);
            chkNB.TabIndex = 34;
            chkNB.Text = "NB";
            chkNB.UseVisualStyleBackColor = true;
            // 
            // chkSB
            // 
            chkSB.AutoSize = true;
            chkSB.Location = new Point(182, 66);
            chkSB.Name = "chkSB";
            chkSB.Size = new Size(53, 27);
            chkSB.TabIndex = 33;
            chkSB.Text = "SB";
            chkSB.UseVisualStyleBackColor = true;
            // 
            // lblPD
            // 
            lblPD.AutoSize = true;
            lblPD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPD.Location = new Point(13, 65);
            lblPD.Name = "lblPD";
            lblPD.Size = new Size(161, 23);
            lblPD.TabIndex = 32;
            lblPD.Text = "Passage Direction :";
            // 
            // chkDardanelles
            // 
            chkDardanelles.AutoSize = true;
            chkDardanelles.Location = new Point(154, 29);
            chkDardanelles.Name = "chkDardanelles";
            chkDardanelles.Size = new Size(126, 27);
            chkDardanelles.TabIndex = 31;
            chkDardanelles.Text = "Dardanelles";
            chkDardanelles.UseVisualStyleBackColor = true;
            // 
            // chkBosphorus
            // 
            chkBosphorus.AutoSize = true;
            chkBosphorus.Location = new Point(14, 29);
            chkBosphorus.Name = "chkBosphorus";
            chkBosphorus.Size = new Size(115, 27);
            chkBosphorus.TabIndex = 30;
            chkBosphorus.Text = "Bosphorus";
            chkBosphorus.UseVisualStyleBackColor = true;
            // 
            // nudPC
            // 
            nudPC.ForeColor = Color.FromArgb(0, 0, 64);
            nudPC.Location = new Point(163, 191);
            nudPC.Name = "nudPC";
            nudPC.Size = new Size(150, 30);
            nudPC.TabIndex = 28;
            // 
            // labelPassangeCount
            // 
            labelPassangeCount.AutoSize = true;
            labelPassangeCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPassangeCount.ForeColor = Color.FromArgb(50, 45, 126);
            labelPassangeCount.Location = new Point(12, 193);
            labelPassangeCount.Name = "labelPassangeCount";
            labelPassangeCount.Size = new Size(140, 23);
            labelPassangeCount.TabIndex = 22;
            labelPassangeCount.Text = "Passage Count  :";
            // 
            // lblTT
            // 
            lblTT.AutoSize = true;
            lblTT.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTT.Location = new Point(12, 113);
            lblTT.Name = "lblTT";
            lblTT.Size = new Size(117, 23);
            lblTT.TabIndex = 14;
            lblTT.Text = "Transit Type :";
            // 
            // gbERS
            // 
            gbERS.Controls.Add(labelDolarTL);
            gbERS.Controls.Add(labelEuroDolar);
            gbERS.Controls.Add(tboxmanualdolar);
            gbERS.Controls.Add(Lblmanual);
            gbERS.Controls.Add(tboxmanualeuro);
            gbERS.Controls.Add(Lblmanual2);
            gbERS.Controls.Add(chkUSD);
            gbERS.Controls.Add(chkEURO);
            gbERS.Controls.Add(labelEuroRate);
            gbERS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbERS.ForeColor = Color.FromArgb(57, 52, 130);
            gbERS.Location = new Point(790, 616);
            gbERS.Name = "gbERS";
            gbERS.Size = new Size(429, 203);
            gbERS.TabIndex = 36;
            gbERS.TabStop = false;
            gbERS.Text = "Exchange Rates and Settings";
            // 
            // labelDolarTL
            // 
            labelDolarTL.AutoSize = true;
            labelDolarTL.Location = new Point(16, 89);
            labelDolarTL.Name = "labelDolarTL";
            labelDolarTL.Size = new Size(0, 23);
            labelDolarTL.TabIndex = 33;
            // 
            // labelEuroDolar
            // 
            labelEuroDolar.AutoSize = true;
            labelEuroDolar.Location = new Point(16, 45);
            labelEuroDolar.Name = "labelEuroDolar";
            labelEuroDolar.Size = new Size(0, 23);
            labelEuroDolar.TabIndex = 32;
            // 
            // tboxmanualdolar
            // 
            tboxmanualdolar.Font = new Font("Segoe UI", 10F);
            tboxmanualdolar.Location = new Point(176, 157);
            tboxmanualdolar.Name = "tboxmanualdolar";
            tboxmanualdolar.Size = new Size(176, 30);
            tboxmanualdolar.TabIndex = 31;
            // 
            // Lblmanual
            // 
            Lblmanual.AutoSize = true;
            Lblmanual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Lblmanual.ForeColor = Color.FromArgb(50, 45, 126);
            Lblmanual.Location = new Point(16, 117);
            Lblmanual.Name = "Lblmanual";
            Lblmanual.Size = new Size(154, 23);
            Lblmanual.TabIndex = 0;
            Lblmanual.Text = "Manual EUR/USD:";
            // 
            // tboxmanualeuro
            // 
            tboxmanualeuro.Font = new Font("Segoe UI", 10F);
            tboxmanualeuro.Location = new Point(176, 117);
            tboxmanualeuro.Name = "tboxmanualeuro";
            tboxmanualeuro.Size = new Size(176, 30);
            tboxmanualeuro.TabIndex = 30;
            // 
            // Lblmanual2
            // 
            Lblmanual2.AutoSize = true;
            Lblmanual2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Lblmanual2.ForeColor = Color.FromArgb(50, 45, 126);
            Lblmanual2.Location = new Point(16, 157);
            Lblmanual2.Name = "Lblmanual2";
            Lblmanual2.Size = new Size(153, 23);
            Lblmanual2.TabIndex = 0;
            Lblmanual2.Text = "Manual USD/TRY:";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelDuration.ForeColor = Color.FromArgb(50, 45, 126);
            labelDuration.Location = new Point(6, 76);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(145, 23);
            labelDuration.TabIndex = 18;
            labelDuration.Text = "Duration (hour) :";
            // 
            // tboxDuration
            // 
            tboxDuration.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxDuration.Location = new Point(198, 79);
            tboxDuration.Name = "tboxDuration";
            tboxDuration.Size = new Size(131, 29);
            tboxDuration.TabIndex = 19;
            // 
            // labelMooringRate
            // 
            labelMooringRate.AutoSize = true;
            labelMooringRate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMooringRate.ForeColor = Color.FromArgb(50, 45, 126);
            labelMooringRate.Location = new Point(14, 36);
            labelMooringRate.Name = "labelMooringRate";
            labelMooringRate.Size = new Size(130, 23);
            labelMooringRate.TabIndex = 20;
            labelMooringRate.Text = "Mooring Rate :";
            // 
            // tboxMooringRate
            // 
            tboxMooringRate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxMooringRate.Location = new Point(158, 33);
            tboxMooringRate.Name = "tboxMooringRate";
            tboxMooringRate.Size = new Size(161, 29);
            tboxMooringRate.TabIndex = 21;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(gbT);
            groupBox3.Controls.Add(gbTO);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(57, 52, 130);
            groupBox3.Location = new Point(471, 346);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(748, 257);
            groupBox3.TabIndex = 37;
            groupBox3.TabStop = false;
            groupBox3.Text = "Operation Settings";
            // 
            // gbT
            // 
            gbT.Controls.Add(lblMT);
            gbT.Controls.Add(tboxMooringRate);
            gbT.Controls.Add(tboxMT);
            gbT.Controls.Add(labelMooringRate);
            gbT.Controls.Add(lblTowageTariff);
            gbT.Controls.Add(tboxTT);
            gbT.Location = new Point(390, 37);
            gbT.Name = "gbT";
            gbT.Size = new Size(342, 187);
            gbT.TabIndex = 27;
            gbT.TabStop = false;
            gbT.Text = "Tariffs";
            // 
            // lblMT
            // 
            lblMT.AutoSize = true;
            lblMT.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMT.ForeColor = Color.FromArgb(50, 45, 126);
            lblMT.Location = new Point(14, 138);
            lblMT.Name = "lblMT";
            lblMT.Size = new Size(138, 23);
            lblMT.TabIndex = 25;
            lblMT.Text = "Mooring Tariff :";
            // 
            // tboxMT
            // 
            tboxMT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxMT.Location = new Point(158, 136);
            tboxMT.Name = "tboxMT";
            tboxMT.Size = new Size(161, 29);
            tboxMT.TabIndex = 24;
            // 
            // lblTowageTariff
            // 
            lblTowageTariff.AutoSize = true;
            lblTowageTariff.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTowageTariff.ForeColor = Color.FromArgb(50, 45, 126);
            lblTowageTariff.Location = new Point(14, 76);
            lblTowageTariff.Name = "lblTowageTariff";
            lblTowageTariff.Size = new Size(125, 46);
            lblTowageTariff.TabIndex = 22;
            lblTowageTariff.Text = "Towage Tariff \r\n(per GRT) :";
            // 
            // tboxTT
            // 
            tboxTT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxTT.Location = new Point(158, 79);
            tboxTT.Name = "tboxTT";
            tboxTT.Size = new Size(161, 29);
            tboxTT.TabIndex = 23;
            // 
            // gbTO
            // 
            gbTO.Controls.Add(labelStraitFees);
            gbTO.Controls.Add(labelDuration);
            gbTO.Controls.Add(tboxDuration);
            gbTO.Controls.Add(tboxStraitFees);
            gbTO.Location = new Point(14, 37);
            gbTO.Name = "gbTO";
            gbTO.Size = new Size(354, 187);
            gbTO.TabIndex = 26;
            gbTO.TabStop = false;
            gbTO.Text = "Tugboat Operations";
            // 
            // gbOverrides
            // 
            gbOverrides.Controls.Add(chkGarbageFee);
            gbOverrides.Controls.Add(lblNote1);
            gbOverrides.Controls.Add(chkLD);
            gbOverrides.Controls.Add(chkNCFlag);
            gbOverrides.Controls.Add(chkWP);
            gbOverrides.Controls.Add(chkSanitaryOverride);
            gbOverrides.Controls.Add(chkStraitInformersDeleted);
            gbOverrides.Controls.Add(chkForceEscortTug);
            gbOverrides.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbOverrides.ForeColor = Color.FromArgb(57, 52, 130);
            gbOverrides.Location = new Point(20, 614);
            gbOverrides.Name = "gbOverrides";
            gbOverrides.Size = new Size(306, 309);
            gbOverrides.TabIndex = 38;
            gbOverrides.TabStop = false;
            gbOverrides.Text = "Calculation Overrides ";
            // 
            // chkGarbageFee
            // 
            chkGarbageFee.AutoSize = true;
            chkGarbageFee.Location = new Point(10, 223);
            chkGarbageFee.Name = "chkGarbageFee";
            chkGarbageFee.Size = new Size(132, 27);
            chkGarbageFee.TabIndex = 31;
            chkGarbageFee.Text = "Garbage Fee";
            // 
            // lblNote1
            // 
            lblNote1.AutoSize = true;
            lblNote1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblNote1.Location = new Point(6, 265);
            lblNote1.Name = "lblNote1";
            lblNote1.Size = new Size(282, 34);
            lblNote1.TabIndex = 30;
            lblNote1.Text = "💡 Note: Use these options only if you wish\r\nto override automatic calculations.";
            // 
            // chkLD
            // 
            chkLD.AutoSize = true;
            chkLD.Location = new Point(10, 192);
            chkLD.Name = "chkLD";
            chkLD.Size = new Size(159, 27);
            chkLD.TabIndex = 29;
            chkLD.Text = "Skip Light Dues";
            // 
            // chkNCFlag
            // 
            chkNCFlag.AutoSize = true;
            chkNCFlag.Location = new Point(10, 159);
            chkNCFlag.Name = "chkNCFlag";
            chkNCFlag.Size = new Size(207, 27);
            chkNCFlag.TabIndex = 28;
            chkNCFlag.Text = "Non-Commercial Flag";
            // 
            // chkWP
            // 
            chkWP.AutoSize = true;
            chkWP.Location = new Point(10, 126);
            chkWP.Name = "chkWP";
            chkWP.Size = new Size(191, 27);
            chkWP.TabIndex = 27;
            chkWP.Text = "Is Weekend Passage";
            // 
            // chkSanitaryOverride
            // 
            chkSanitaryOverride.AutoSize = true;
            chkSanitaryOverride.Location = new Point(10, 30);
            chkSanitaryOverride.Name = "chkSanitaryOverride";
            chkSanitaryOverride.Size = new Size(211, 27);
            chkSanitaryOverride.TabIndex = 22;
            chkSanitaryOverride.Text = "Sanitary Paid at Limas";
            // 
            // chkStraitInformersDeleted
            // 
            chkStraitInformersDeleted.AutoSize = true;
            chkStraitInformersDeleted.Location = new Point(10, 62);
            chkStraitInformersDeleted.Name = "chkStraitInformersDeleted";
            chkStraitInformersDeleted.Size = new Size(228, 27);
            chkStraitInformersDeleted.TabIndex = 23;
            chkStraitInformersDeleted.Text = "Strait Informers Deleted";
            // 
            // chkForceEscortTug
            // 
            chkForceEscortTug.AutoSize = true;
            chkForceEscortTug.Location = new Point(10, 93);
            chkForceEscortTug.Name = "chkForceEscortTug";
            chkForceEscortTug.Size = new Size(163, 27);
            chkForceEscortTug.TabIndex = 26;
            chkForceEscortTug.Text = "Force Escort Tug";
            // 
            // chkManualAgencyFee
            // 
            chkManualAgencyFee.AutoSize = true;
            chkManualAgencyFee.Location = new Point(25, 40);
            chkManualAgencyFee.Name = "chkManualAgencyFee";
            chkManualAgencyFee.Size = new Size(230, 27);
            chkManualAgencyFee.TabIndex = 24;
            chkManualAgencyFee.Text = "Use Manual Agency Fee :";
            // 
            // numericManualAgencyFee
            // 
            numericManualAgencyFee.DecimalPlaces = 2;
            numericManualAgencyFee.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericManualAgencyFee.Location = new Point(25, 75);
            numericManualAgencyFee.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericManualAgencyFee.Name = "numericManualAgencyFee";
            numericManualAgencyFee.Size = new Size(230, 30);
            numericManualAgencyFee.TabIndex = 25;
            numericManualAgencyFee.ThousandsSeparator = true;
            // 
            // lblAFC
            // 
            lblAFC.AutoSize = true;
            lblAFC.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAFC.ForeColor = Color.FromArgb(50, 45, 126);
            lblAFC.Location = new Point(889, 837);
            lblAFC.Name = "lblAFC";
            lblAFC.Size = new Size(149, 23);
            lblAFC.TabIndex = 24;
            lblAFC.Text = "Currency Choice :";
            // 
            // gbAD
            // 
            gbAD.Controls.Add(lblNote2);
            gbAD.Controls.Add(chkManualAgencyFee);
            gbAD.Controls.Add(numericManualAgencyFee);
            gbAD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbAD.ForeColor = Color.FromArgb(57, 52, 130);
            gbAD.Location = new Point(340, 616);
            gbAD.Name = "gbAD";
            gbAD.Size = new Size(435, 203);
            gbAD.TabIndex = 39;
            gbAD.TabStop = false;
            gbAD.Text = "Agency Details";
            // 
            // lblNote2
            // 
            lblNote2.AutoSize = true;
            lblNote2.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblNote2.Location = new Point(25, 122);
            lblNote2.Name = "lblNote2";
            lblNote2.Size = new Size(359, 17);
            lblNote2.TabIndex = 28;
            lblNote2.Text = "💡 Note: Leave unchecked for automatic fee calculation.";
            // 
            // chkUSD
            // 
            chkUSD.AutoSize = true;
            chkUSD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkUSD.Location = new Point(1052, 837);
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
            chkEURO.Location = new Point(1134, 837);
            chkEURO.Name = "chkEURO";
            chkEURO.Size = new Size(77, 27);
            chkEURO.TabIndex = 41;
            chkEURO.Text = "EURO";
            chkEURO.UseVisualStyleBackColor = true;
            // 
            // labelEuroRate
            // 
            labelEuroRate.AutoSize = true;
            labelEuroRate.Location = new Point(865, 335);
            labelEuroRate.Name = "labelEuroRate";
            labelEuroRate.Size = new Size(140, 20);
            labelEuroRate.TabIndex = 35;
            labelEuroRate.Text = "EUR/USD Rate:";
            labelEuroRate.Visible = false;
            gbERS.Controls.Add(labelEuroRate);
            // 
            // Straits
            // 
            AcceptButton = btnCalculate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1268, 957);
            Controls.Add(chkEURO);
            Controls.Add(chkUSD);
            Controls.Add(gbAD);
            Controls.Add(gbOverrides);
            Controls.Add(lblAFC);
            Controls.Add(groupBox3);
            Controls.Add(gbERS);
            Controls.Add(btnCalculate);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxVesselInfo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(30, 30, 30);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Straits";
            StartPosition = FormStartPosition.CenterParent;
            Text = "StraitsPanel";
            groupBoxVesselInfo.ResumeLayout(false);
            groupBoxVesselInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPC).EndInit();
            gbERS.ResumeLayout(false);
            gbERS.PerformLayout();
            groupBox3.ResumeLayout(false);
            gbT.ResumeLayout(false);
            gbT.PerformLayout();
            gbTO.ResumeLayout(false);
            gbTO.PerformLayout();
            gbOverrides.ResumeLayout(false);
            gbOverrides.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericManualAgencyFee).EndInit();
            gbAD.ResumeLayout(false);
            gbAD.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label labelStraitFees;
        private System.Windows.Forms.TextBox tboxStraitFees;
        private System.Windows.Forms.CheckBox checkIsTanker;
        private System.Windows.Forms.ComboBox cmbTransitType;
        private System.Windows.Forms.Button btnCalculate;
        private GroupBox groupBoxVesselInfo;
        private Label label2;
        private Label labelCountry;
        private Label labelIMO;
        private TextBox tboxIMO;
        private Label labelShipName;
        private TextBox tboxShipName;
        private Label labelCustomer;
        private TextBox tboxCustomer;
        private Label labelFlag;
        private ComboBox cmbBoxFlag;
        private TextBox flagname;
        private Label labelLOA;
        private TextBox tboxLOA;
        private Label labelBEAM;
        private TextBox tboxBeam;
        private Label labelDraft;
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
        private Label labelDuration;
        private TextBox tboxDuration;
        private Label labelMooringRate;
        private TextBox tboxMooringRate;
        private GroupBox gbERS;
        private Label labelDolarTL;
        private Label labelEuroDolar;
        private TextBox tboxmanualdolar;
        private Label Lblmanual;
        private TextBox tboxmanualeuro;
        private Label Lblmanual2;
        private GroupBox groupBox3;
        private Label lblMT;
        private TextBox tboxMT;
        private TextBox tboxTT;
        private Label lblTowageTariff;
        private Label labelPassangeCount;
        private NumericUpDown nudPC;
        private GroupBox gbOverrides;
        private CheckBox chkSanitaryOverride;
        private CheckBox chkStraitInformersDeleted;
        private CheckBox chkForceEscortTug;
        private CheckBox chkWP;
        private CheckBox chkDardanelles;
        private CheckBox chkBosphorus;
        private NumericUpDown numericManualAgencyFee;
        private CheckBox chkManualAgencyFee;
        private CheckBox chkNB;
        private CheckBox chkSB;
        private Label lblPD;
        private CheckBox chkLD;
        private CheckBox chkNCFlag;
        private GroupBox gbT;
        private GroupBox gbTO;
        private Label lblNote1;
        private Label lblAFC;
        private GroupBox gbAD;
        private Label lblNote2;
        private CheckBox chkGarbageFee;
        private CheckBox chkUSD;
        private CheckBox chkEURO;
        private Label labelEuroRate;
    }
}