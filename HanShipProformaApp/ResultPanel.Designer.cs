namespace HanShipProformaApp
{
    partial class ResultPanel
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
            panelHeader = new Panel();
            btnExit = new Button();
            lblShipInfo = new Label();
            lblCustomerInfo = new Label();
            panelFees = new Panel();
            groupBox1 = new GroupBox();
            LBLFiscal = new Label();
            LBLAgency = new Label();
            LBLLaunch = new Label();
            LBLNotary = new Label();
            LBLSundries = new Label();
            LBLPostage = new Label();
            LBLCOEX = new Label();
            btnBack = new Button();
            btnGenerate = new Button();
            panelPortFees = new GroupBox();
            labelSanitaryDues = new Label();
            labelLightDues = new Label();
            labelVTS = new Label();
            labelPilotageFees = new Label();
            labelTugboat = new Label();
            labelMooring = new Label();
            labelGarbageFee = new Label();
            labelWharfageFee = new Label();
            panelAgencyFees = new GroupBox();
            labelHarbourMasterCoShipping = new Label();
            labelOvertimeDues = new Label();
            labelAgencyService = new Label();
            labelSupervisionServices = new Label();
            panelHeader.SuspendLayout();
            panelFees.SuspendLayout();
            groupBox1.SuspendLayout();
            panelPortFees.SuspendLayout();
            panelAgencyFees.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(57, 52, 130);
            panelHeader.Controls.Add(btnExit);
            panelHeader.Controls.Add(lblShipInfo);
            panelHeader.Controls.Add(lblCustomerInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1290, 100);
            panelHeader.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(192, 0, 0);
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.ForeColor = SystemColors.Window;
            btnExit.Location = new Point(1182, 0);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(38, 29);
            btnExit.TabIndex = 37;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // lblShipInfo
            // 
            lblShipInfo.AutoSize = true;
            lblShipInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblShipInfo.ForeColor = Color.White;
            lblShipInfo.Location = new Point(21, 20);
            lblShipInfo.Name = "lblShipInfo";
            lblShipInfo.Size = new Size(108, 28);
            lblShipInfo.TabIndex = 0;
            lblShipInfo.Text = "Ship Info :";
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomerInfo.ForeColor = Color.White;
            lblCustomerInfo.Location = new Point(21, 60);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(163, 28);
            lblCustomerInfo.TabIndex = 1;
            lblCustomerInfo.Text = "Customer Info : ";
            // 
            // panelFees
            // 
            panelFees.BackColor = SystemColors.Control;
            panelFees.Controls.Add(groupBox1);
            panelFees.Controls.Add(btnBack);
            panelFees.Controls.Add(btnGenerate);
            panelFees.Controls.Add(panelPortFees);
            panelFees.Controls.Add(panelAgencyFees);
            panelFees.Dock = DockStyle.Fill;
            panelFees.Location = new Point(0, 100);
            panelFees.Name = "panelFees";
            panelFees.Padding = new Padding(10, 11, 10, 11);
            panelFees.Size = new Size(1290, 541);
            panelFees.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LBLFiscal);
            groupBox1.Controls.Add(LBLAgency);
            groupBox1.Controls.Add(LBLLaunch);
            groupBox1.Controls.Add(LBLNotary);
            groupBox1.Controls.Add(LBLSundries);
            groupBox1.Controls.Add(LBLPostage);
            groupBox1.Controls.Add(LBLCOEX);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.Location = new Point(883, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 412);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Additional Costs";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // LBLFiscal
            // 
            LBLFiscal.AutoSize = true;
            LBLFiscal.Font = new Font("Segoe UI", 11F);
            LBLFiscal.Location = new Point(21, 280);
            LBLFiscal.Name = "LBLFiscal";
            LBLFiscal.Size = new Size(251, 25);
            LBLFiscal.TabIndex = 8;
            LBLFiscal.Text = "Fiscal Stamps/Stationary Ex=";
            LBLFiscal.Click += LBLFiscal_Click;
            // 
            // LBLAgency
            // 
            LBLAgency.AutoSize = true;
            LBLAgency.Font = new Font("Segoe UI", 11F);
            LBLAgency.Location = new Point(21, 240);
            LBLAgency.Name = "LBLAgency";
            LBLAgency.Size = new Size(245, 25);
            LBLAgency.TabIndex = 7;
            LBLAgency.Text = "Agency Staff Car Expenses=";
            // 
            // LBLLaunch
            // 
            LBLLaunch.AutoSize = true;
            LBLLaunch.Font = new Font("Segoe UI", 11F);
            LBLLaunch.Location = new Point(21, 199);
            LBLLaunch.Name = "LBLLaunch";
            LBLLaunch.Size = new Size(197, 25);
            LBLLaunch.TabIndex = 5;
            LBLLaunch.Text = "Launchboat Services=";
            // 
            // LBLNotary
            // 
            LBLNotary.AutoSize = true;
            LBLNotary.Font = new Font("Segoe UI", 11F);
            LBLNotary.Location = new Point(21, 39);
            LBLNotary.Name = "LBLNotary";
            LBLNotary.Size = new Size(173, 25);
            LBLNotary.TabIndex = 0;
            LBLNotary.Text = "Notary Public Fee=";
            // 
            // LBLSundries
            // 
            LBLSundries.AutoSize = true;
            LBLSundries.Font = new Font("Segoe UI", 11F);
            LBLSundries.Location = new Point(21, 79);
            LBLSundries.Name = "LBLSundries";
            LBLSundries.Size = new Size(98, 25);
            LBLSundries.TabIndex = 1;
            LBLSundries.Text = "Sundries=";
            LBLSundries.Click += LBLSundries_Click;
            // 
            // LBLPostage
            // 
            LBLPostage.AutoSize = true;
            LBLPostage.Font = new Font("Segoe UI", 11F);
            LBLPostage.Location = new Point(21, 119);
            LBLPostage.Name = "LBLPostage";
            LBLPostage.Size = new Size(91, 25);
            LBLPostage.TabIndex = 2;
            LBLPostage.Text = "Postage=";
            // 
            // LBLCOEX
            // 
            LBLCOEX.AutoSize = true;
            LBLCOEX.Font = new Font("Segoe UI", 11F);
            LBLCOEX.Location = new Point(21, 159);
            LBLCOEX.Name = "LBLCOEX";
            LBLCOEX.Size = new Size(241, 25);
            LBLCOEX.TabIndex = 3;
            LBLCOEX.Text = "Communication Expenses=";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(0, 122, 204);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(769, 453);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(200, 60);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(0, 122, 204);
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(987, 453);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(200, 60);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate Word";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // panelPortFees
            // 
            panelPortFees.Controls.Add(labelSanitaryDues);
            panelPortFees.Controls.Add(labelLightDues);
            panelPortFees.Controls.Add(labelVTS);
            panelPortFees.Controls.Add(labelPilotageFees);
            panelPortFees.Controls.Add(labelTugboat);
            panelPortFees.Controls.Add(labelMooring);
            panelPortFees.Controls.Add(labelGarbageFee);
            panelPortFees.Controls.Add(labelWharfageFee);
            panelPortFees.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            panelPortFees.Location = new Point(47, 11);
            panelPortFees.Name = "panelPortFees";
            panelPortFees.Size = new Size(271, 412);
            panelPortFees.TabIndex = 0;
            panelPortFees.TabStop = false;
            panelPortFees.Text = "Port Fees";
            // 
            // labelSanitaryDues
            // 
            labelSanitaryDues.AutoSize = true;
            labelSanitaryDues.Font = new Font("Segoe UI", 11F);
            labelSanitaryDues.Location = new Point(21, 40);
            labelSanitaryDues.Name = "labelSanitaryDues";
            labelSanitaryDues.Size = new Size(150, 25);
            labelSanitaryDues.TabIndex = 0;
            labelSanitaryDues.Text = "Sanitary Dues = ";
            // 
            // labelLightDues
            // 
            labelLightDues.AutoSize = true;
            labelLightDues.Font = new Font("Segoe UI", 11F);
            labelLightDues.Location = new Point(21, 80);
            labelLightDues.Name = "labelLightDues";
            labelLightDues.Size = new Size(119, 25);
            labelLightDues.TabIndex = 1;
            labelLightDues.Text = "Light Dues =";
            // 
            // labelVTS
            // 
            labelVTS.AutoSize = true;
            labelVTS.Font = new Font("Segoe UI", 11F);
            labelVTS.Location = new Point(21, 120);
            labelVTS.Name = "labelVTS";
            labelVTS.Size = new Size(62, 25);
            labelVTS.TabIndex = 2;
            labelVTS.Text = "VTS =";
            // 
            // labelPilotageFees
            // 
            labelPilotageFees.AutoSize = true;
            labelPilotageFees.Font = new Font("Segoe UI", 11F);
            labelPilotageFees.Location = new Point(21, 160);
            labelPilotageFees.Name = "labelPilotageFees";
            labelPilotageFees.Size = new Size(141, 25);
            labelPilotageFees.TabIndex = 3;
            labelPilotageFees.Text = "Pilotage Fees =";
            // 
            // labelTugboat
            // 
            labelTugboat.AutoSize = true;
            labelTugboat.Font = new Font("Segoe UI", 11F);
            labelTugboat.Location = new Point(21, 200);
            labelTugboat.Name = "labelTugboat";
            labelTugboat.Size = new Size(100, 25);
            labelTugboat.TabIndex = 4;
            labelTugboat.Text = "Tugboat =";
            // 
            // labelMooring
            // 
            labelMooring.AutoSize = true;
            labelMooring.Font = new Font("Segoe UI", 11F);
            labelMooring.Location = new Point(21, 240);
            labelMooring.Name = "labelMooring";
            labelMooring.Size = new Size(108, 25);
            labelMooring.TabIndex = 5;
            labelMooring.Text = "Mooring = ";
            // 
            // labelGarbageFee
            // 
            labelGarbageFee.AutoSize = true;
            labelGarbageFee.Font = new Font("Segoe UI", 11F);
            labelGarbageFee.Location = new Point(21, 280);
            labelGarbageFee.Name = "labelGarbageFee";
            labelGarbageFee.Size = new Size(136, 25);
            labelGarbageFee.TabIndex = 6;
            labelGarbageFee.Text = "Garbage Fee =";
            // 
            // labelWharfageFee
            // 
            labelWharfageFee.AutoSize = true;
            labelWharfageFee.Font = new Font("Segoe UI", 11F);
            labelWharfageFee.Location = new Point(21, 320);
            labelWharfageFee.Name = "labelWharfageFee";
            labelWharfageFee.Size = new Size(147, 25);
            labelWharfageFee.TabIndex = 7;
            labelWharfageFee.Text = "Wharfage Fee =";
            // 
            // panelAgencyFees
            // 
            panelAgencyFees.Controls.Add(labelHarbourMasterCoShipping);
            panelAgencyFees.Controls.Add(labelOvertimeDues);
            panelAgencyFees.Controls.Add(labelAgencyService);
            panelAgencyFees.Controls.Add(labelSupervisionServices);
            panelAgencyFees.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            panelAgencyFees.Location = new Point(465, 11);
            panelAgencyFees.Name = "panelAgencyFees";
            panelAgencyFees.Size = new Size(288, 412);
            panelAgencyFees.TabIndex = 1;
            panelAgencyFees.TabStop = false;
            panelAgencyFees.Text = "Agency Fees";
            // 
            // labelHarbourMasterCoShipping
            // 
            labelHarbourMasterCoShipping.AutoSize = true;
            labelHarbourMasterCoShipping.Font = new Font("Segoe UI", 11F);
            labelHarbourMasterCoShipping.Location = new Point(21, 40);
            labelHarbourMasterCoShipping.Name = "labelHarbourMasterCoShipping";
            labelHarbourMasterCoShipping.Size = new Size(271, 25);
            labelHarbourMasterCoShipping.TabIndex = 0;
            labelHarbourMasterCoShipping.Text = "Harbour Master Co Shipping =";
            // 
            // labelOvertimeDues
            // 
            labelOvertimeDues.AutoSize = true;
            labelOvertimeDues.Font = new Font("Segoe UI", 11F);
            labelOvertimeDues.Location = new Point(21, 80);
            labelOvertimeDues.Name = "labelOvertimeDues";
            labelOvertimeDues.Size = new Size(159, 25);
            labelOvertimeDues.TabIndex = 1;
            labelOvertimeDues.Text = "Overtime Dues = ";
            // 
            // labelAgencyService
            // 
            labelAgencyService.AutoSize = true;
            labelAgencyService.Font = new Font("Segoe UI", 11F);
            labelAgencyService.Location = new Point(21, 120);
            labelAgencyService.Name = "labelAgencyService";
            labelAgencyService.Size = new Size(162, 25);
            labelAgencyService.TabIndex = 2;
            labelAgencyService.Text = "Agency Service = ";
            // 
            // labelSupervisionServices
            // 
            labelSupervisionServices.AutoSize = true;
            labelSupervisionServices.Font = new Font("Segoe UI", 11F);
            labelSupervisionServices.Location = new Point(21, 160);
            labelSupervisionServices.Name = "labelSupervisionServices";
            labelSupervisionServices.Size = new Size(206, 25);
            labelSupervisionServices.TabIndex = 3;
            labelSupervisionServices.Text = "Supervision Services = ";
            // 
            // ResultPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 641);
            Controls.Add(panelFees);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResultPanel";
            Text = "Result Panel";
            Load += ResultPanel_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFees.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelPortFees.ResumeLayout(false);
            panelPortFees.PerformLayout();
            panelAgencyFees.ResumeLayout(false);
            panelAgencyFees.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblShipInfo;
        private Label lblCustomerInfo;
        private Panel panelFees;
        private GroupBox panelPortFees;
        private GroupBox panelAgencyFees;
        private Label labelSanitaryDues;
        private Label labelLightDues;
        private Label labelVTS;
        private Label labelPilotageFees;
        private Label labelTugboat;
        private Label labelMooring;
        private Label labelGarbageFee;
        private Label labelWharfageFee;
        private Label labelHarbourMasterCoShipping;
        private Label labelOvertimeDues;
        private Label labelAgencyService;
        private Label labelSupervisionServices;
        private Button btnGenerate;
        private Button btnBack;
        private GroupBox groupBox1;
        private Label LBLNotary;
        private Label LBLSundries;
        private Label LBLPostage;
        private Label LBLCOEX;
        private Label LBLFiscal;
        private Label LBLAgency;
        private Label LBLLaunch;
        private Button btnExit;
    }
}