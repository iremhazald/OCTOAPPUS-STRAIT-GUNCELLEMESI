namespace HanShipProformaApp
{
    partial class ProformaPanel
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
            groupBoxVesselInfo = new GroupBox();
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
            groupBoxOperationDetails = new GroupBox();
            labelInbound = new Label();
            cmbBoxInBound = new ComboBox();
            labelOutbound = new Label();
            cmbBoxOutBound = new ComboBox();
            labelOperation = new Label();
            cmbBoxOperation = new ComboBox();
            labelAnchorageDay = new Label();
            tboxAnchorageDay = new TextBox();
            groupBoxPortInfo = new GroupBox();
            labelPort = new Label();
            cmbBoxPortCity = new ComboBox();
            labelTerminal = new Label();
            cmbBoxPort = new ComboBox();
            groupBoxAdditionalCosts = new GroupBox();
            label2 = new Label();
            tboxPrevious = new TextBox();
            labelNotaryPublicFee = new Label();
            tboxNotaryPublicFee = new TextBox();
            labelSundries = new Label();
            tboxSundries = new TextBox();
            labelAgencyStaffCarExpenses = new Label();
            tboxAgencyStaffCarExpenses = new TextBox();
            labelLaunchboatServices = new Label();
            tboxLaunchboatServices = new TextBox();
            labelCommunicationExpenses = new Label();
            tboxCommunicationExpenses = new TextBox();
            labelPostage = new Label();
            tboxpostage = new TextBox();
            labelFiscalStamps = new Label();
            tboxfiscal = new TextBox();
            Lblmanual = new Label();
            Lblmanual2 = new Label();
            tboxmanualeuro = new TextBox();
            tboxmanualdolar = new TextBox();
            btncheck = new Button();
            btnsave = new Button();
            btnCalculate = new Button();
            groupBox1 = new GroupBox();
            labelDolarTL = new Label();
            labelEuroDolar = new Label();
            btnExit = new Button();
            btnBack = new Button();
            label1 = new Label();
            groupBoxVesselInfo.SuspendLayout();
            groupBoxOperationDetails.SuspendLayout();
            groupBoxPortInfo.SuspendLayout();
            groupBoxAdditionalCosts.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxVesselInfo
            // 
            groupBoxVesselInfo.Controls.Add(label1);
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
            groupBoxVesselInfo.Location = new Point(22, 38);
            groupBoxVesselInfo.Name = "groupBoxVesselInfo";
            groupBoxVesselInfo.Size = new Size(680, 363);
            groupBoxVesselInfo.TabIndex = 0;
            groupBoxVesselInfo.TabStop = false;
            groupBoxVesselInfo.Text = "Vessel Information";
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.ForeColor = Color.FromArgb(50, 45, 126);
            labelCountry.Location = new Point(243, 95);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(75, 23);
            labelCountry.TabIndex = 15;
            labelCountry.Text = "Country";
            // 
            // labelIMO
            // 
            labelIMO.AutoSize = true;
            labelIMO.ForeColor = Color.FromArgb(50, 45, 126);
            labelIMO.Location = new Point(16, 32);
            labelIMO.Name = "labelIMO";
            labelIMO.Size = new Size(44, 23);
            labelIMO.TabIndex = 0;
            labelIMO.Text = "IMO";
            // 
            // tboxIMO
            // 
            tboxIMO.Location = new Point(16, 57);
            tboxIMO.Name = "tboxIMO";
            tboxIMO.Size = new Size(172, 30);
            tboxIMO.TabIndex = 1;
            // 
            // labelShipName
            // 
            labelShipName.AutoSize = true;
            labelShipName.ForeColor = Color.FromArgb(50, 45, 126);
            labelShipName.Location = new Point(243, 31);
            labelShipName.Name = "labelShipName";
            labelShipName.Size = new Size(98, 23);
            labelShipName.TabIndex = 2;
            labelShipName.Text = "Ship Name";
            // 
            // tboxShipName
            // 
            tboxShipName.Location = new Point(243, 57);
            tboxShipName.Name = "tboxShipName";
            tboxShipName.Size = new Size(185, 30);
            tboxShipName.TabIndex = 2;
            // 
            // labelCustomer
            // 
            labelCustomer.AutoSize = true;
            labelCustomer.ForeColor = Color.FromArgb(50, 45, 126);
            labelCustomer.Location = new Point(479, 32);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(87, 23);
            labelCustomer.TabIndex = 3;
            labelCustomer.Text = "Customer";
            // 
            // tboxCustomer
            // 
            tboxCustomer.Location = new Point(479, 59);
            tboxCustomer.Name = "tboxCustomer";
            tboxCustomer.Size = new Size(180, 30);
            tboxCustomer.TabIndex = 3;
            // 
            // labelFlag
            // 
            labelFlag.AutoSize = true;
            labelFlag.ForeColor = Color.FromArgb(50, 45, 126);
            labelFlag.Location = new Point(16, 96);
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
            cmbBoxFlag.Location = new Point(16, 123);
            cmbBoxFlag.Name = "cmbBoxFlag";
            cmbBoxFlag.Size = new Size(172, 31);
            cmbBoxFlag.TabIndex = 4;
            cmbBoxFlag.SelectedIndexChanged += cmbBoxFlag_SelectedIndexChanged;
            // 
            // flagname
            // 
            flagname.Enabled = false;
            flagname.Location = new Point(243, 121);
            flagname.Name = "flagname";
            flagname.Size = new Size(185, 30);
            flagname.TabIndex = 5;
            // 
            // labelLOA
            // 
            labelLOA.AutoSize = true;
            labelLOA.ForeColor = Color.FromArgb(50, 45, 126);
            labelLOA.Location = new Point(16, 160);
            labelLOA.Name = "labelLOA";
            labelLOA.Size = new Size(44, 23);
            labelLOA.TabIndex = 6;
            labelLOA.Text = "LOA";
            // 
            // tboxLOA
            // 
            tboxLOA.Location = new Point(16, 187);
            tboxLOA.Name = "tboxLOA";
            tboxLOA.Size = new Size(172, 30);
            tboxLOA.TabIndex = 6;
            // 
            // labelBEAM
            // 
            labelBEAM.AutoSize = true;
            labelBEAM.ForeColor = Color.FromArgb(50, 45, 126);
            labelBEAM.Location = new Point(243, 159);
            labelBEAM.Name = "labelBEAM";
            labelBEAM.Size = new Size(58, 23);
            labelBEAM.TabIndex = 7;
            labelBEAM.Text = "BEAM";
            // 
            // tboxBeam
            // 
            tboxBeam.Location = new Point(243, 185);
            tboxBeam.Name = "tboxBeam";
            tboxBeam.Size = new Size(185, 30);
            tboxBeam.TabIndex = 7;
            // 
            // labelDraft
            // 
            labelDraft.AutoSize = true;
            labelDraft.ForeColor = Color.FromArgb(50, 45, 126);
            labelDraft.Location = new Point(479, 159);
            labelDraft.Name = "labelDraft";
            labelDraft.Size = new Size(53, 23);
            labelDraft.TabIndex = 8;
            labelDraft.Text = "Draft";
            // 
            // tboxDraft
            // 
            tboxDraft.Location = new Point(479, 186);
            tboxDraft.Name = "tboxDraft";
            tboxDraft.Size = new Size(180, 30);
            tboxDraft.TabIndex = 8;
            // 
            // labelDWT
            // 
            labelDWT.AutoSize = true;
            labelDWT.ForeColor = Color.FromArgb(50, 45, 126);
            labelDWT.Location = new Point(16, 224);
            labelDWT.Name = "labelDWT";
            labelDWT.Size = new Size(50, 23);
            labelDWT.TabIndex = 9;
            labelDWT.Text = "DWT";
            // 
            // tboxDWT
            // 
            tboxDWT.Location = new Point(16, 251);
            tboxDWT.Name = "tboxDWT";
            tboxDWT.Size = new Size(172, 30);
            tboxDWT.TabIndex = 9;
            // 
            // labelNetTonnage
            // 
            labelNetTonnage.AutoSize = true;
            labelNetTonnage.ForeColor = Color.FromArgb(50, 45, 126);
            labelNetTonnage.Location = new Point(243, 223);
            labelNetTonnage.Name = "labelNetTonnage";
            labelNetTonnage.Size = new Size(111, 23);
            labelNetTonnage.TabIndex = 10;
            labelNetTonnage.Text = "Net Tonnage";
            // 
            // tboxNetTonage
            // 
            tboxNetTonage.Location = new Point(243, 249);
            tboxNetTonage.Name = "tboxNetTonage";
            tboxNetTonage.Size = new Size(185, 30);
            tboxNetTonage.TabIndex = 10;
            // 
            // labelGrossTonnage
            // 
            labelGrossTonnage.AutoSize = true;
            labelGrossTonnage.ForeColor = Color.FromArgb(50, 45, 126);
            labelGrossTonnage.Location = new Point(479, 223);
            labelGrossTonnage.Name = "labelGrossTonnage";
            labelGrossTonnage.Size = new Size(125, 23);
            labelGrossTonnage.TabIndex = 11;
            labelGrossTonnage.Text = "Gross Tonnage";
            // 
            // tboxGrossTonage
            // 
            tboxGrossTonage.Location = new Point(479, 250);
            tboxGrossTonage.Name = "tboxGrossTonage";
            tboxGrossTonage.Size = new Size(180, 30);
            tboxGrossTonage.TabIndex = 11;
            // 
            // labelCargoWeight
            // 
            labelCargoWeight.AutoSize = true;
            labelCargoWeight.ForeColor = Color.FromArgb(50, 45, 126);
            labelCargoWeight.Location = new Point(16, 288);
            labelCargoWeight.Name = "labelCargoWeight";
            labelCargoWeight.Size = new Size(122, 23);
            labelCargoWeight.TabIndex = 12;
            labelCargoWeight.Text = "Cargo Weight";
            // 
            // tboxCargoWeight
            // 
            tboxCargoWeight.Location = new Point(16, 315);
            tboxCargoWeight.Name = "tboxCargoWeight";
            tboxCargoWeight.Size = new Size(172, 30);
            tboxCargoWeight.TabIndex = 12;
            // 
            // labelCargoType
            // 
            labelCargoType.AutoSize = true;
            labelCargoType.ForeColor = Color.FromArgb(50, 45, 126);
            labelCargoType.Location = new Point(243, 287);
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
            cmbBoxCargoType.Location = new Point(243, 313);
            cmbBoxCargoType.Name = "cmbBoxCargoType";
            cmbBoxCargoType.Size = new Size(185, 31);
            cmbBoxCargoType.TabIndex = 13;
            cmbBoxCargoType.SelectedIndexChanged += cmbBoxCargoType_SelectedIndexChanged;
            // 
            // tboxOtherCargoType
            // 
            tboxOtherCargoType.Location = new Point(479, 314);
            tboxOtherCargoType.Name = "tboxOtherCargoType";
            tboxOtherCargoType.Size = new Size(180, 30);
            tboxOtherCargoType.TabIndex = 14;
            // 
            // groupBoxOperationDetails
            // 
            groupBoxOperationDetails.Controls.Add(labelInbound);
            groupBoxOperationDetails.Controls.Add(cmbBoxInBound);
            groupBoxOperationDetails.Controls.Add(labelOutbound);
            groupBoxOperationDetails.Controls.Add(cmbBoxOutBound);
            groupBoxOperationDetails.Controls.Add(labelOperation);
            groupBoxOperationDetails.Controls.Add(cmbBoxOperation);
            groupBoxOperationDetails.Controls.Add(labelAnchorageDay);
            groupBoxOperationDetails.Controls.Add(tboxAnchorageDay);
            groupBoxOperationDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxOperationDetails.ForeColor = Color.FromArgb(57, 52, 130);
            groupBoxOperationDetails.Location = new Point(721, 38);
            groupBoxOperationDetails.Name = "groupBoxOperationDetails";
            groupBoxOperationDetails.Size = new Size(427, 216);
            groupBoxOperationDetails.TabIndex = 1;
            groupBoxOperationDetails.TabStop = false;
            groupBoxOperationDetails.Text = "Operation Details";
            // 
            // labelInbound
            // 
            labelInbound.AutoSize = true;
            labelInbound.ForeColor = Color.FromArgb(50, 45, 126);
            labelInbound.Location = new Point(16, 32);
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
            cmbBoxInBound.Location = new Point(16, 59);
            cmbBoxInBound.Name = "cmbBoxInBound";
            cmbBoxInBound.Size = new Size(150, 31);
            cmbBoxInBound.TabIndex = 15;
            // 
            // labelOutbound
            // 
            labelOutbound.AutoSize = true;
            labelOutbound.ForeColor = Color.FromArgb(50, 45, 126);
            labelOutbound.Location = new Point(226, 32);
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
            cmbBoxOutBound.Location = new Point(226, 59);
            cmbBoxOutBound.Name = "cmbBoxOutBound";
            cmbBoxOutBound.Size = new Size(180, 31);
            cmbBoxOutBound.TabIndex = 16;
            // 
            // labelOperation
            // 
            labelOperation.AutoSize = true;
            labelOperation.ForeColor = Color.FromArgb(50, 45, 126);
            labelOperation.Location = new Point(226, 111);
            labelOperation.Name = "labelOperation";
            labelOperation.Size = new Size(91, 23);
            labelOperation.TabIndex = 17;
            labelOperation.Text = "Operation";
            // 
            // cmbBoxOperation
            // 
            cmbBoxOperation.BackColor = Color.White;
            cmbBoxOperation.ForeColor = Color.Black;
            cmbBoxOperation.FormattingEnabled = true;
            cmbBoxOperation.Location = new Point(226, 137);
            cmbBoxOperation.Name = "cmbBoxOperation";
            cmbBoxOperation.Size = new Size(180, 31);
            cmbBoxOperation.TabIndex = 17;
            // 
            // labelAnchorageDay
            // 
            labelAnchorageDay.AutoSize = true;
            labelAnchorageDay.ForeColor = Color.FromArgb(50, 45, 126);
            labelAnchorageDay.Location = new Point(16, 112);
            labelAnchorageDay.Name = "labelAnchorageDay";
            labelAnchorageDay.Size = new Size(132, 23);
            labelAnchorageDay.TabIndex = 18;
            labelAnchorageDay.Text = "Anchorage Day";
            // 
            // tboxAnchorageDay
            // 
            tboxAnchorageDay.Location = new Point(16, 139);
            tboxAnchorageDay.Name = "tboxAnchorageDay";
            tboxAnchorageDay.Size = new Size(150, 30);
            tboxAnchorageDay.TabIndex = 18;
            // 
            // groupBoxPortInfo
            // 
            groupBoxPortInfo.Controls.Add(labelPort);
            groupBoxPortInfo.Controls.Add(cmbBoxPortCity);
            groupBoxPortInfo.Controls.Add(labelTerminal);
            groupBoxPortInfo.Controls.Add(cmbBoxPort);
            groupBoxPortInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxPortInfo.ForeColor = Color.FromArgb(57, 52, 130);
            groupBoxPortInfo.Location = new Point(22, 406);
            groupBoxPortInfo.Name = "groupBoxPortInfo";
            groupBoxPortInfo.Size = new Size(683, 120);
            groupBoxPortInfo.TabIndex = 2;
            groupBoxPortInfo.TabStop = false;
            groupBoxPortInfo.Text = "Port Information";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.ForeColor = Color.FromArgb(50, 45, 126);
            labelPort.Location = new Point(16, 32);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(43, 23);
            labelPort.TabIndex = 0;
            labelPort.Text = "Port";
            // 
            // cmbBoxPortCity
            // 
            cmbBoxPortCity.BackColor = Color.White;
            cmbBoxPortCity.ForeColor = Color.Black;
            cmbBoxPortCity.FormattingEnabled = true;
            cmbBoxPortCity.Location = new Point(16, 59);
            cmbBoxPortCity.Name = "cmbBoxPortCity";
            cmbBoxPortCity.Size = new Size(250, 31);
            cmbBoxPortCity.TabIndex = 20;
            cmbBoxPortCity.SelectedIndexChanged += cmbBoxPortCity_SelectedIndexChanged;
            // 
            // labelTerminal
            // 
            labelTerminal.AutoSize = true;
            labelTerminal.ForeColor = Color.FromArgb(50, 45, 126);
            labelTerminal.Location = new Point(373, 32);
            labelTerminal.Name = "labelTerminal";
            labelTerminal.Size = new Size(79, 23);
            labelTerminal.TabIndex = 21;
            labelTerminal.Text = "Terminal";
            // 
            // cmbBoxPort
            // 
            cmbBoxPort.BackColor = Color.White;
            cmbBoxPort.ForeColor = Color.Black;
            cmbBoxPort.FormattingEnabled = true;
            cmbBoxPort.Location = new Point(373, 59);
            cmbBoxPort.Name = "cmbBoxPort";
            cmbBoxPort.Size = new Size(250, 31);
            cmbBoxPort.TabIndex = 21;
            // 
            // groupBoxAdditionalCosts
            // 
            groupBoxAdditionalCosts.Controls.Add(label2);
            groupBoxAdditionalCosts.Controls.Add(tboxPrevious);
            groupBoxAdditionalCosts.Controls.Add(labelNotaryPublicFee);
            groupBoxAdditionalCosts.Controls.Add(tboxNotaryPublicFee);
            groupBoxAdditionalCosts.Controls.Add(labelSundries);
            groupBoxAdditionalCosts.Controls.Add(tboxSundries);
            groupBoxAdditionalCosts.Controls.Add(labelAgencyStaffCarExpenses);
            groupBoxAdditionalCosts.Controls.Add(tboxAgencyStaffCarExpenses);
            groupBoxAdditionalCosts.Controls.Add(labelLaunchboatServices);
            groupBoxAdditionalCosts.Controls.Add(tboxLaunchboatServices);
            groupBoxAdditionalCosts.Controls.Add(labelCommunicationExpenses);
            groupBoxAdditionalCosts.Controls.Add(tboxCommunicationExpenses);
            groupBoxAdditionalCosts.Controls.Add(labelPostage);
            groupBoxAdditionalCosts.Controls.Add(tboxpostage);
            groupBoxAdditionalCosts.Controls.Add(labelFiscalStamps);
            groupBoxAdditionalCosts.Controls.Add(tboxfiscal);
            groupBoxAdditionalCosts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAdditionalCosts.ForeColor = Color.FromArgb(57, 52, 130);
            groupBoxAdditionalCosts.Location = new Point(22, 548);
            groupBoxAdditionalCosts.Name = "groupBoxAdditionalCosts";
            groupBoxAdditionalCosts.Size = new Size(683, 245);
            groupBoxAdditionalCosts.TabIndex = 3;
            groupBoxAdditionalCosts.TabStop = false;
            groupBoxAdditionalCosts.Text = "Additional Costs";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(50, 45, 126);
            label2.Location = new Point(186, 163);
            label2.Name = "label2";
            label2.Size = new Size(143, 23);
            label2.TabIndex = 30;
            label2.Text = "Previous Balance";
            // 
            // tboxPrevious
            // 
            tboxPrevious.Location = new Point(186, 189);
            tboxPrevious.Name = "tboxPrevious";
            tboxPrevious.Size = new Size(217, 30);
            tboxPrevious.TabIndex = 29;
            // 
            // labelNotaryPublicFee
            // 
            labelNotaryPublicFee.AutoSize = true;
            labelNotaryPublicFee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelNotaryPublicFee.ForeColor = Color.FromArgb(50, 45, 126);
            labelNotaryPublicFee.Location = new Point(16, 32);
            labelNotaryPublicFee.Name = "labelNotaryPublicFee";
            labelNotaryPublicFee.Size = new Size(152, 23);
            labelNotaryPublicFee.TabIndex = 0;
            labelNotaryPublicFee.Text = "Notary Public Fee";
            // 
            // tboxNotaryPublicFee
            // 
            tboxNotaryPublicFee.Font = new Font("Segoe UI", 10F);
            tboxNotaryPublicFee.Location = new Point(16, 59);
            tboxNotaryPublicFee.Name = "tboxNotaryPublicFee";
            tboxNotaryPublicFee.Size = new Size(150, 30);
            tboxNotaryPublicFee.TabIndex = 22;
            // 
            // labelSundries
            // 
            labelSundries.AutoSize = true;
            labelSundries.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSundries.ForeColor = Color.FromArgb(50, 45, 126);
            labelSundries.Location = new Point(16, 101);
            labelSundries.Name = "labelSundries";
            labelSundries.Size = new Size(79, 23);
            labelSundries.TabIndex = 0;
            labelSundries.Text = "Sundries";
            // 
            // tboxSundries
            // 
            tboxSundries.Font = new Font("Segoe UI", 10F);
            tboxSundries.Location = new Point(16, 127);
            tboxSundries.Name = "tboxSundries";
            tboxSundries.Size = new Size(150, 30);
            tboxSundries.TabIndex = 23;
            // 
            // labelAgencyStaffCarExpenses
            // 
            labelAgencyStaffCarExpenses.AutoSize = true;
            labelAgencyStaffCarExpenses.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAgencyStaffCarExpenses.ForeColor = Color.FromArgb(50, 45, 126);
            labelAgencyStaffCarExpenses.Location = new Point(416, 32);
            labelAgencyStaffCarExpenses.Name = "labelAgencyStaffCarExpenses";
            labelAgencyStaffCarExpenses.Size = new Size(222, 23);
            labelAgencyStaffCarExpenses.TabIndex = 0;
            labelAgencyStaffCarExpenses.Text = "Agency Staff Car Expenses";
            // 
            // tboxAgencyStaffCarExpenses
            // 
            tboxAgencyStaffCarExpenses.Font = new Font("Segoe UI", 10F);
            tboxAgencyStaffCarExpenses.Location = new Point(419, 59);
            tboxAgencyStaffCarExpenses.Name = "tboxAgencyStaffCarExpenses";
            tboxAgencyStaffCarExpenses.Size = new Size(222, 30);
            tboxAgencyStaffCarExpenses.TabIndex = 24;
            // 
            // labelLaunchboatServices
            // 
            labelLaunchboatServices.AutoSize = true;
            labelLaunchboatServices.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelLaunchboatServices.ForeColor = Color.FromArgb(50, 45, 126);
            labelLaunchboatServices.Location = new Point(186, 101);
            labelLaunchboatServices.Name = "labelLaunchboatServices";
            labelLaunchboatServices.Size = new Size(173, 23);
            labelLaunchboatServices.TabIndex = 0;
            labelLaunchboatServices.Text = "Launchboat Services";
            // 
            // tboxLaunchboatServices
            // 
            tboxLaunchboatServices.Font = new Font("Segoe UI", 10F);
            tboxLaunchboatServices.Location = new Point(186, 127);
            tboxLaunchboatServices.Name = "tboxLaunchboatServices";
            tboxLaunchboatServices.Size = new Size(213, 30);
            tboxLaunchboatServices.TabIndex = 25;
            // 
            // labelCommunicationExpenses
            // 
            labelCommunicationExpenses.AutoSize = true;
            labelCommunicationExpenses.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelCommunicationExpenses.ForeColor = Color.FromArgb(50, 45, 126);
            labelCommunicationExpenses.Location = new Point(186, 32);
            labelCommunicationExpenses.Name = "labelCommunicationExpenses";
            labelCommunicationExpenses.Size = new Size(213, 23);
            labelCommunicationExpenses.TabIndex = 0;
            labelCommunicationExpenses.Text = "Communication Expenses";
            // 
            // tboxCommunicationExpenses
            // 
            tboxCommunicationExpenses.Font = new Font("Segoe UI", 10F);
            tboxCommunicationExpenses.Location = new Point(186, 59);
            tboxCommunicationExpenses.Name = "tboxCommunicationExpenses";
            tboxCommunicationExpenses.Size = new Size(213, 30);
            tboxCommunicationExpenses.TabIndex = 26;
            // 
            // labelPostage
            // 
            labelPostage.AutoSize = true;
            labelPostage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPostage.ForeColor = Color.FromArgb(50, 45, 126);
            labelPostage.Location = new Point(16, 163);
            labelPostage.Name = "labelPostage";
            labelPostage.Size = new Size(72, 23);
            labelPostage.TabIndex = 0;
            labelPostage.Text = "Postage";
            // 
            // tboxpostage
            // 
            tboxpostage.Font = new Font("Segoe UI", 10F);
            tboxpostage.Location = new Point(16, 188);
            tboxpostage.Name = "tboxpostage";
            tboxpostage.Size = new Size(150, 30);
            tboxpostage.TabIndex = 27;
            // 
            // labelFiscalStamps
            // 
            labelFiscalStamps.AutoSize = true;
            labelFiscalStamps.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelFiscalStamps.ForeColor = Color.FromArgb(50, 45, 126);
            labelFiscalStamps.Location = new Point(414, 101);
            labelFiscalStamps.Name = "labelFiscalStamps";
            labelFiscalStamps.Size = new Size(233, 23);
            labelFiscalStamps.TabIndex = 0;
            labelFiscalStamps.Text = "Fiscal Stamps/Stationary Ex";
            // 
            // tboxfiscal
            // 
            tboxfiscal.Font = new Font("Segoe UI", 10F);
            tboxfiscal.Location = new Point(419, 127);
            tboxfiscal.Name = "tboxfiscal";
            tboxfiscal.Size = new Size(219, 30);
            tboxfiscal.TabIndex = 28;
            // 
            // Lblmanual
            // 
            Lblmanual.AutoSize = true;
            Lblmanual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Lblmanual.ForeColor = Color.FromArgb(50, 45, 126);
            Lblmanual.Location = new Point(21, 135);
            Lblmanual.Name = "Lblmanual";
            Lblmanual.Size = new Size(154, 23);
            Lblmanual.TabIndex = 0;
            Lblmanual.Text = "Manual EUR/USD:";
            // 
            // Lblmanual2
            // 
            Lblmanual2.AutoSize = true;
            Lblmanual2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Lblmanual2.ForeColor = Color.FromArgb(50, 45, 126);
            Lblmanual2.Location = new Point(21, 175);
            Lblmanual2.Name = "Lblmanual2";
            Lblmanual2.Size = new Size(153, 23);
            Lblmanual2.TabIndex = 0;
            Lblmanual2.Text = "Manual USD/TRY:";
            // 
            // tboxmanualeuro
            // 
            tboxmanualeuro.Font = new Font("Segoe UI", 10F);
            tboxmanualeuro.Location = new Point(181, 135);
            tboxmanualeuro.Name = "tboxmanualeuro";
            tboxmanualeuro.Size = new Size(191, 30);
            tboxmanualeuro.TabIndex = 30;
            tboxmanualeuro.TextChanged += tboxmanualeuro_TextChanged_1;
            // 
            // tboxmanualdolar
            // 
            tboxmanualdolar.Font = new Font("Segoe UI", 10F);
            tboxmanualdolar.Location = new Point(181, 175);
            tboxmanualdolar.Name = "tboxmanualdolar";
            tboxmanualdolar.Size = new Size(191, 30);
            tboxmanualdolar.TabIndex = 31;
            tboxmanualdolar.TextChanged += tboxmanualdolar_TextChanged_1;
            // 
            // btncheck
            // 
            btncheck.BackColor = Color.FromArgb(90, 159, 223);
            btncheck.FlatStyle = FlatStyle.Flat;
            btncheck.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btncheck.ForeColor = Color.White;
            btncheck.Location = new Point(721, 564);
            btncheck.Name = "btncheck";
            btncheck.Size = new Size(425, 57);
            btncheck.TabIndex = 32;
            btncheck.Text = "Check";
            btncheck.UseVisualStyleBackColor = false;
            btncheck.Click += button1_Click;
            // 
            // btnsave
            // 
            btnsave.BackColor = Color.FromArgb(90, 159, 223);
            btnsave.FlatStyle = FlatStyle.Flat;
            btnsave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnsave.ForeColor = Color.White;
            btnsave.Location = new Point(721, 645);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(425, 56);
            btnsave.TabIndex = 33;
            btnsave.Text = "Save";
            btnsave.UseVisualStyleBackColor = false;
            btnsave.Click += btnsave_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.FromArgb(90, 159, 223);
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(721, 721);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(425, 59);
            btnCalculate.TabIndex = 34;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelDolarTL);
            groupBox1.Controls.Add(labelEuroDolar);
            groupBox1.Controls.Add(tboxmanualdolar);
            groupBox1.Controls.Add(Lblmanual);
            groupBox1.Controls.Add(tboxmanualeuro);
            groupBox1.Controls.Add(Lblmanual2);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(57, 52, 130);
            groupBox1.Location = new Point(721, 270);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(425, 257);
            groupBox1.TabIndex = 35;
            groupBox1.TabStop = false;
            groupBox1.Text = "Exchange Rates and Settings";
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
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(192, 0, 0);
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnExit.ForeColor = SystemColors.ButtonFace;
            btnExit.Location = new Point(1092, 13);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(56, 29);
            btnExit.TabIndex = 36;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.MidnightBlue;
            btnBack.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBack.ForeColor = SystemColors.ButtonFace;
            btnBack.Location = new Point(22, 812);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(241, 59);
            btnBack.TabIndex = 37;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(50, 45, 126);
            label1.Location = new Point(479, 287);
            label1.Name = "label1";
            label1.Size = new Size(111, 23);
            label1.TabIndex = 16;
            label1.Text = "Cargo Detail";
            // 
            // ProformaPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 898);
            Controls.Add(btnBack);
            Controls.Add(btnExit);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxVesselInfo);
            Controls.Add(groupBoxOperationDetails);
            Controls.Add(groupBoxPortInfo);
            Controls.Add(groupBoxAdditionalCosts);
            Controls.Add(btncheck);
            Controls.Add(btnsave);
            Controls.Add(btnCalculate);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1170, 739);
            Name = "ProformaPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proforma Panel";
            Load += ProformaPanel_Load;
            groupBoxVesselInfo.ResumeLayout(false);
            groupBoxVesselInfo.PerformLayout();
            groupBoxOperationDetails.ResumeLayout(false);
            groupBoxOperationDetails.PerformLayout();
            groupBoxPortInfo.ResumeLayout(false);
            groupBoxPortInfo.PerformLayout();
            groupBoxAdditionalCosts.ResumeLayout(false);
            groupBoxAdditionalCosts.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxVesselInfo;
        private System.Windows.Forms.GroupBox groupBoxOperationDetails;
        private System.Windows.Forms.GroupBox groupBoxPortInfo;
        private System.Windows.Forms.GroupBox groupBoxAdditionalCosts;

        private System.Windows.Forms.Label labelIMO;
        private System.Windows.Forms.TextBox tboxIMO;
        private System.Windows.Forms.Label labelShipName;
        private System.Windows.Forms.TextBox tboxShipName;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.TextBox tboxCustomer;
        private System.Windows.Forms.Label labelFlag;
        private System.Windows.Forms.ComboBox cmbBoxFlag;
        private System.Windows.Forms.TextBox flagname;

        private System.Windows.Forms.Label labelLOA;
        private System.Windows.Forms.TextBox tboxLOA;
        private System.Windows.Forms.Label labelBEAM;
        private System.Windows.Forms.TextBox tboxBeam;
        private System.Windows.Forms.Label labelDraft;
        private System.Windows.Forms.TextBox tboxDraft;
        private System.Windows.Forms.Label labelDWT;
        private System.Windows.Forms.TextBox tboxDWT;

        private System.Windows.Forms.Label labelNetTonnage;
        private System.Windows.Forms.TextBox tboxNetTonage;
        private System.Windows.Forms.Label labelGrossTonnage;
        private System.Windows.Forms.TextBox tboxGrossTonage;
        private System.Windows.Forms.Label labelCargoWeight;
        private System.Windows.Forms.TextBox tboxCargoWeight;
        private System.Windows.Forms.Label labelCargoType;
        private System.Windows.Forms.ComboBox cmbBoxCargoType;
        private System.Windows.Forms.TextBox tboxOtherCargoType;

        private System.Windows.Forms.Label labelInbound;
        private System.Windows.Forms.ComboBox cmbBoxInBound;
        private System.Windows.Forms.Label labelOutbound;
        private System.Windows.Forms.ComboBox cmbBoxOutBound;
        private System.Windows.Forms.Label labelOperation;
        private System.Windows.Forms.ComboBox cmbBoxOperation;
        private System.Windows.Forms.Label labelAnchorageDay;
        private System.Windows.Forms.TextBox tboxAnchorageDay;

        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.ComboBox cmbBoxPortCity;
        private System.Windows.Forms.Label labelTerminal;
        private System.Windows.Forms.ComboBox cmbBoxPort;

        private System.Windows.Forms.Label labelNotaryPublicFee;
        private System.Windows.Forms.TextBox tboxNotaryPublicFee;
        private System.Windows.Forms.Label labelSundries;
        private System.Windows.Forms.TextBox tboxSundries;
        private System.Windows.Forms.Label labelAgencyStaffCarExpenses;
        private System.Windows.Forms.TextBox tboxAgencyStaffCarExpenses;
        private System.Windows.Forms.Label labelLaunchboatServices;
        private System.Windows.Forms.TextBox tboxLaunchboatServices;
        private System.Windows.Forms.Label labelCommunicationExpenses;
        private System.Windows.Forms.TextBox tboxCommunicationExpenses;
        private System.Windows.Forms.Label labelPostage;
        private System.Windows.Forms.TextBox tboxpostage;
        private System.Windows.Forms.Label labelFiscalStamps;
        private System.Windows.Forms.TextBox tboxfiscal;

        private System.Windows.Forms.TextBox tboxmanualeuro;
        private System.Windows.Forms.TextBox tboxmanualdolar;
        private System.Windows.Forms.Label Lblmanual;
        private System.Windows.Forms.Label Lblmanual2;

        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnCalculate;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox tboxPrevious;
        private Label labelDolarTL;
        private Label labelEuroDolar;
        private Button btnExit;
        private Label labelCountry;
        private Button btnBack;
        private Label label1;
    }
}