namespace HanShipProformaApp
{
    partial class StraitsResultPanel
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
            lblResultCustomerInfo = new Label();
            lblResultShipInfo = new Label();
            label1 = new Label();
            label2 = new Label();
            lblShipInfo = new Label();
            lblCustomerInfo = new Label();
            btnBack = new Button();
            labelSanitaryDues = new Label();
            labelLightDues = new Label();
            labelPilotageServices = new Label();
            labelTugboat = new Label();
            labelStraitInformers = new Label();
            labelAAF = new Label();
            labelTotal = new Label();
            tboxTotal = new TextBox();
            gbStrait = new GroupBox();
            tboxRemarkTOTAL = new TextBox();
            label4 = new Label();
            label3 = new Label();
            tboxRemarkAAF = new TextBox();
            tboxRemarkSI = new TextBox();
            tboxRemarkETF = new TextBox();
            tboxRemarkPS = new TextBox();
            tboxRemarkLLS = new TextBox();
            tboxRemarkSD = new TextBox();
            lblResultSI = new Label();
            lblResultPS = new Label();
            lblResultAAF = new Label();
            lblResultLLS = new Label();
            lblResultSD = new Label();
            lblResultETF = new Label();
            btnGeneratePDF = new Button();
            btnGenerateWord = new Button();
            tboxRemarkTOTALEURO = new TextBox();
            tboxTotalEURO = new TextBox();
            panelHeader.SuspendLayout();
            gbStrait.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(57, 52, 130);
            panelHeader.Controls.Add(lblResultCustomerInfo);
            panelHeader.Controls.Add(lblResultShipInfo);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(label2);
            panelHeader.Controls.Add(lblShipInfo);
            panelHeader.Controls.Add(lblCustomerInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1276, 118);
            panelHeader.TabIndex = 0;
            // 
            // lblResultCustomerInfo
            // 
            lblResultCustomerInfo.AutoSize = true;
            lblResultCustomerInfo.Location = new Point(174, 70);
            lblResultCustomerInfo.Name = "lblResultCustomerInfo";
            lblResultCustomerInfo.Size = new Size(0, 20);
            lblResultCustomerInfo.TabIndex = 6;
            // 
            // lblResultShipInfo
            // 
            lblResultShipInfo.AutoSize = true;
            lblResultShipInfo.Location = new Point(174, 29);
            lblResultShipInfo.Name = "lblResultShipInfo";
            lblResultShipInfo.Size = new Size(0, 20);
            lblResultShipInfo.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 25);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 3;
            label1.Text = "Ship Info :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 65);
            label2.Name = "label2";
            label2.Size = new Size(148, 25);
            label2.TabIndex = 4;
            label2.Text = "Customer Info : ";
            // 
            // lblShipInfo
            // 
            lblShipInfo.AutoSize = true;
            lblShipInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblShipInfo.ForeColor = Color.White;
            lblShipInfo.Location = new Point(20, 25);
            lblShipInfo.Name = "lblShipInfo";
            lblShipInfo.Size = new Size(0, 28);
            lblShipInfo.TabIndex = 1;
            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomerInfo.ForeColor = Color.White;
            lblCustomerInfo.Location = new Point(20, 55);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(0, 28);
            lblCustomerInfo.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(57, 52, 130);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(1104, 627);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 36);
            btnBack.TabIndex = 18;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // labelSanitaryDues
            // 
            labelSanitaryDues.AutoSize = true;
            labelSanitaryDues.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSanitaryDues.ForeColor = Color.FromArgb(50, 45, 126);
            labelSanitaryDues.Location = new Point(25, 102);
            labelSanitaryDues.Name = "labelSanitaryDues";
            labelSanitaryDues.Size = new Size(170, 28);
            labelSanitaryDues.TabIndex = 1;
            labelSanitaryDues.Text = "Sanitary Dues = ";
            // 
            // labelLightDues
            // 
            labelLightDues.AutoSize = true;
            labelLightDues.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelLightDues.ForeColor = Color.FromArgb(50, 45, 126);
            labelLightDues.Location = new Point(25, 157);
            labelLightDues.Name = "labelLightDues";
            labelLightDues.Size = new Size(290, 28);
            labelLightDues.TabIndex = 3;
            labelLightDues.Text = "Light and Life Saving Dues = ";
            // 
            // labelPilotageServices
            // 
            labelPilotageServices.AutoSize = true;
            labelPilotageServices.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPilotageServices.ForeColor = Color.FromArgb(50, 45, 126);
            labelPilotageServices.Location = new Point(25, 208);
            labelPilotageServices.Name = "labelPilotageServices";
            labelPilotageServices.Size = new Size(200, 28);
            labelPilotageServices.TabIndex = 5;
            labelPilotageServices.Text = "Pilotage Services = ";
            // 
            // labelTugboat
            // 
            labelTugboat.AutoSize = true;
            labelTugboat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTugboat.ForeColor = Color.FromArgb(50, 45, 126);
            labelTugboat.Location = new Point(25, 256);
            labelTugboat.Name = "labelTugboat";
            labelTugboat.Size = new Size(170, 28);
            labelTugboat.TabIndex = 7;
            labelTugboat.Text = "Escort Tug Fee =";
            // 
            // labelStraitInformers
            // 
            labelStraitInformers.AutoSize = true;
            labelStraitInformers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelStraitInformers.ForeColor = Color.FromArgb(50, 45, 126);
            labelStraitInformers.Location = new Point(25, 307);
            labelStraitInformers.Name = "labelStraitInformers";
            labelStraitInformers.Size = new Size(188, 28);
            labelStraitInformers.TabIndex = 9;
            labelStraitInformers.Text = "Strait Informers = ";
            // 
            // labelAAF
            // 
            labelAAF.AutoSize = true;
            labelAAF.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelAAF.ForeColor = Color.FromArgb(50, 45, 126);
            labelAAF.Location = new Point(25, 357);
            labelAAF.Name = "labelAAF";
            labelAAF.Size = new Size(261, 28);
            labelAAF.TabIndex = 11;
            labelAAF.Text = "Agency Attendance Fee = ";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTotal.ForeColor = Color.FromArgb(50, 45, 126);
            labelTotal.Location = new Point(127, 441);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(98, 28);
            labelTotal.TabIndex = 13;
            labelTotal.Text = "TOTAL = ";
            // 
            // tboxTotal
            // 
            tboxTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tboxTotal.Location = new Point(327, 435);
            tboxTotal.Name = "tboxTotal";
            tboxTotal.ReadOnly = true;
            tboxTotal.Size = new Size(170, 34);
            tboxTotal.TabIndex = 14;
            // 
            // gbStrait
            // 
            gbStrait.Controls.Add(tboxRemarkTOTALEURO);
            gbStrait.Controls.Add(tboxTotalEURO);
            gbStrait.Controls.Add(tboxRemarkTOTAL);
            gbStrait.Controls.Add(label4);
            gbStrait.Controls.Add(label3);
            gbStrait.Controls.Add(tboxRemarkAAF);
            gbStrait.Controls.Add(tboxRemarkSI);
            gbStrait.Controls.Add(tboxRemarkETF);
            gbStrait.Controls.Add(tboxRemarkPS);
            gbStrait.Controls.Add(tboxRemarkLLS);
            gbStrait.Controls.Add(tboxRemarkSD);
            gbStrait.Controls.Add(lblResultSI);
            gbStrait.Controls.Add(lblResultPS);
            gbStrait.Controls.Add(lblResultAAF);
            gbStrait.Controls.Add(lblResultLLS);
            gbStrait.Controls.Add(lblResultSD);
            gbStrait.Controls.Add(lblResultETF);
            gbStrait.Controls.Add(labelSanitaryDues);
            gbStrait.Controls.Add(tboxTotal);
            gbStrait.Controls.Add(labelTotal);
            gbStrait.Controls.Add(labelLightDues);
            gbStrait.Controls.Add(labelAAF);
            gbStrait.Controls.Add(labelPilotageServices);
            gbStrait.Controls.Add(labelStraitInformers);
            gbStrait.Controls.Add(labelTugboat);
            gbStrait.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gbStrait.ForeColor = Color.FromArgb(50, 45, 126);
            gbStrait.Location = new Point(20, 135);
            gbStrait.Name = "gbStrait";
            gbStrait.Size = new Size(978, 547);
            gbStrait.TabIndex = 19;
            gbStrait.TabStop = false;
            gbStrait.Text = "Strait Fees";
            // 
            // tboxRemarkTOTAL
            // 
            tboxRemarkTOTAL.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkTOTAL.Location = new Point(574, 438);
            tboxRemarkTOTAL.Multiline = true;
            tboxRemarkTOTAL.Name = "tboxRemarkTOTAL";
            tboxRemarkTOTAL.ScrollBars = ScrollBars.Vertical;
            tboxRemarkTOTAL.Size = new Size(365, 34);
            tboxRemarkTOTAL.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(716, 30);
            label4.Name = "label4";
            label4.Size = new Size(106, 28);
            label4.TabIndex = 29;
            label4.Text = "REMARKS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(376, 30);
            label3.Name = "label3";
            label3.Size = new Size(55, 28);
            label3.TabIndex = 28;
            label3.Text = "FEES";
            // 
            // tboxRemarkAAF
            // 
            tboxRemarkAAF.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkAAF.Location = new Point(574, 354);
            tboxRemarkAAF.Multiline = true;
            tboxRemarkAAF.Name = "tboxRemarkAAF";
            tboxRemarkAAF.ScrollBars = ScrollBars.Vertical;
            tboxRemarkAAF.Size = new Size(365, 34);
            tboxRemarkAAF.TabIndex = 27;
            // 
            // tboxRemarkSI
            // 
            tboxRemarkSI.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkSI.Location = new Point(574, 298);
            tboxRemarkSI.Multiline = true;
            tboxRemarkSI.Name = "tboxRemarkSI";
            tboxRemarkSI.ScrollBars = ScrollBars.Vertical;
            tboxRemarkSI.Size = new Size(365, 34);
            tboxRemarkSI.TabIndex = 26;
            // 
            // tboxRemarkETF
            // 
            tboxRemarkETF.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkETF.Location = new Point(574, 247);
            tboxRemarkETF.Multiline = true;
            tboxRemarkETF.Name = "tboxRemarkETF";
            tboxRemarkETF.ScrollBars = ScrollBars.Vertical;
            tboxRemarkETF.Size = new Size(365, 34);
            tboxRemarkETF.TabIndex = 25;
            // 
            // tboxRemarkPS
            // 
            tboxRemarkPS.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkPS.Location = new Point(574, 199);
            tboxRemarkPS.Multiline = true;
            tboxRemarkPS.Name = "tboxRemarkPS";
            tboxRemarkPS.ScrollBars = ScrollBars.Vertical;
            tboxRemarkPS.Size = new Size(365, 34);
            tboxRemarkPS.TabIndex = 24;
            // 
            // tboxRemarkLLS
            // 
            tboxRemarkLLS.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkLLS.Location = new Point(574, 148);
            tboxRemarkLLS.Multiline = true;
            tboxRemarkLLS.Name = "tboxRemarkLLS";
            tboxRemarkLLS.ScrollBars = ScrollBars.Vertical;
            tboxRemarkLLS.Size = new Size(365, 34);
            tboxRemarkLLS.TabIndex = 23;
            // 
            // tboxRemarkSD
            // 
            tboxRemarkSD.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkSD.Location = new Point(574, 99);
            tboxRemarkSD.Multiline = true;
            tboxRemarkSD.Name = "tboxRemarkSD";
            tboxRemarkSD.ScrollBars = ScrollBars.Vertical;
            tboxRemarkSD.Size = new Size(365, 34);
            tboxRemarkSD.TabIndex = 22;
            // 
            // lblResultSI
            // 
            lblResultSI.AutoSize = true;
            lblResultSI.Location = new Point(329, 296);
            lblResultSI.Name = "lblResultSI";
            lblResultSI.Size = new Size(0, 28);
            lblResultSI.TabIndex = 19;
            // 
            // lblResultPS
            // 
            lblResultPS.AutoSize = true;
            lblResultPS.Location = new Point(329, 202);
            lblResultPS.Name = "lblResultPS";
            lblResultPS.Size = new Size(0, 28);
            lblResultPS.TabIndex = 18;
            // 
            // lblResultAAF
            // 
            lblResultAAF.AutoSize = true;
            lblResultAAF.Location = new Point(329, 340);
            lblResultAAF.Name = "lblResultAAF";
            lblResultAAF.Size = new Size(0, 28);
            lblResultAAF.TabIndex = 17;
            // 
            // lblResultLLS
            // 
            lblResultLLS.AutoSize = true;
            lblResultLLS.Location = new Point(329, 151);
            lblResultLLS.Name = "lblResultLLS";
            lblResultLLS.Size = new Size(0, 28);
            lblResultLLS.TabIndex = 16;
            // 
            // lblResultSD
            // 
            lblResultSD.AutoSize = true;
            lblResultSD.Location = new Point(329, 102);
            lblResultSD.Name = "lblResultSD";
            lblResultSD.Size = new Size(0, 28);
            lblResultSD.TabIndex = 15;
            // 
            // lblResultETF
            // 
            lblResultETF.AutoSize = true;
            lblResultETF.Location = new Point(329, 250);
            lblResultETF.Name = "lblResultETF";
            lblResultETF.Size = new Size(0, 28);
            lblResultETF.TabIndex = 21;
            // 
            // btnGeneratePDF
            // 
            btnGeneratePDF.BackColor = Color.FromArgb(0, 122, 204);
            btnGeneratePDF.FlatStyle = FlatStyle.Flat;
            btnGeneratePDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGeneratePDF.ForeColor = Color.White;
            btnGeneratePDF.Location = new Point(1039, 248);
            btnGeneratePDF.Name = "btnGeneratePDF";
            btnGeneratePDF.Size = new Size(209, 71);
            btnGeneratePDF.TabIndex = 20;
            btnGeneratePDF.Text = "Generate PDF";
            btnGeneratePDF.UseVisualStyleBackColor = false;
            // 
            // btnGenerateWord
            // 
            btnGenerateWord.BackColor = Color.FromArgb(0, 122, 204);
            btnGenerateWord.FlatStyle = FlatStyle.Flat;
            btnGenerateWord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateWord.ForeColor = Color.White;
            btnGenerateWord.Location = new Point(1039, 142);
            btnGenerateWord.Name = "btnGenerateWord";
            btnGenerateWord.Size = new Size(209, 71);
            btnGenerateWord.TabIndex = 17;
            btnGenerateWord.Text = "Generate Word";
            btnGenerateWord.UseVisualStyleBackColor = false;
            // 
            // tboxRemarkTOTALEURO
            // 
            tboxRemarkTOTALEURO.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tboxRemarkTOTALEURO.Location = new Point(574, 475);
            tboxRemarkTOTALEURO.Multiline = true;
            tboxRemarkTOTALEURO.Name = "tboxRemarkTOTALEURO";
            tboxRemarkTOTALEURO.ScrollBars = ScrollBars.Vertical;
            tboxRemarkTOTALEURO.Size = new Size(365, 34);
            tboxRemarkTOTALEURO.TabIndex = 32;
            // 
            // tboxTotalEURO
            // 
            tboxTotalEURO.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tboxTotalEURO.Location = new Point(327, 475);
            tboxTotalEURO.Name = "tboxTotalEURO";
            tboxTotalEURO.ReadOnly = true;
            tboxTotalEURO.Size = new Size(170, 34);
            tboxTotalEURO.TabIndex = 31;
            // 
            // StraitsResultPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 733);
            Controls.Add(btnGeneratePDF);
            Controls.Add(gbStrait);
            Controls.Add(panelHeader);
            Controls.Add(btnGenerateWord);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StraitsResultPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Straits Result Panel";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            gbStrait.ResumeLayout(false);
            gbStrait.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblShipInfo;
        private Label lblCustomerInfo;
        private Button btnBack;
        private Label labelSanitaryDues;
        private Label labelLightDues;
        private Label labelPilotageServices;
        private Label labelTugboat;
        private Label labelStraitInformers;
        private Label labelAAF;
        private Label labelTotal;
        private TextBox tboxTotal;
        private Label label1;
        private Label label2;
        private GroupBox gbStrait;
        private Button btnGeneratePDF;
        private Label lblResultSI;
        private Label lblResultPS;
        private Label lblResultAAF;
        private Label lblResultLLS;
        private Label lblResultSD;
        private Label lblResultETF;
        private Label lblResultCustomerInfo;
        private Label lblResultShipInfo;
        private Button btnGenerateWord;
        private TextBox tboxRemarkPS;
        private TextBox tboxRemarkLLS;
        private TextBox tboxRemarkSD;
        private Label label4;
        private Label label3;
        private TextBox tboxRemarkAAF;
        private TextBox tboxRemarkSI;
        private TextBox tboxRemarkETF;
        private TextBox tboxRemarkTOTAL;
        private TextBox tboxRemarkTOTALEURO;
        private TextBox tboxTotalEURO;
    }
}