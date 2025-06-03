namespace HanShipProformaApp
{
    partial class MainPanel
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
            this.btnStraits = new System.Windows.Forms.Button();
            this.btnPorts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStraits
            // 
            this.btnStraits.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnStraits.Location = new System.Drawing.Point(44, 38);
            this.btnStraits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStraits.Name = "btnStraits";
            this.btnStraits.Size = new System.Drawing.Size(262, 150);
            this.btnStraits.TabIndex = 0;
            this.btnStraits.Text = "Straits";
            this.btnStraits.UseVisualStyleBackColor = true;
            this.btnStraits.Click += new System.EventHandler(this.btnStraits_Click);
            // 
            // btnPorts
            // 
            this.btnPorts.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnPorts.Location = new System.Drawing.Point(350, 38);
            this.btnPorts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPorts.Name = "btnPorts";
            this.btnPorts.Size = new System.Drawing.Size(262, 150);
            this.btnPorts.TabIndex = 1;
            this.btnPorts.Text = "Ports";
            this.btnPorts.UseVisualStyleBackColor = true;
            this.btnPorts.Click += new System.EventHandler(this.btnPorts_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 225);
            this.Controls.Add(this.btnPorts);
            this.Controls.Add(this.btnStraits);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HanShip Proforma";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnStraits;
        private System.Windows.Forms.Button btnPorts;
    }
}
