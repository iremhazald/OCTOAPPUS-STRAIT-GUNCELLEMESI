namespace HanShipProformaApp
{
    partial class BeginningPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeginningPanel));
            pictureBoxBeginning = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBeginning).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBeginning
            // 
            pictureBoxBeginning.BackColor = Color.Transparent;
            pictureBoxBeginning.Dock = DockStyle.Fill;
            pictureBoxBeginning.Image = (Image)resources.GetObject("pictureBoxBeginning.Image");
            pictureBoxBeginning.Location = new Point(0, 0);
            pictureBoxBeginning.Margin = new Padding(3, 4, 3, 4);
            pictureBoxBeginning.Name = "pictureBoxBeginning";
            pictureBoxBeginning.Size = new Size(563, 749);
            pictureBoxBeginning.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBeginning.TabIndex = 0;
            pictureBoxBeginning.TabStop = false;
            // 
            // BeginningPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 749);
            Controls.Add(pictureBoxBeginning);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "BeginningPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HanShip Proforma";
            MouseDown += BeginningPanel_MouseDown;
            MouseMove += BeginningPanel_MouseMove;
            MouseUp += BeginningPanel_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBeginning).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBeginning;
    }
} 