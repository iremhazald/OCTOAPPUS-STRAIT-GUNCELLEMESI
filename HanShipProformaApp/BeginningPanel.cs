using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HanShipProformaApp
{
    public partial class BeginningPanel : Form
    {
        private Point lastPoint;
        private readonly System.Windows.Forms.Timer transitionTimer;

        public BeginningPanel()
        {
            InitializeComponent();
            this.Paint += BeginningPanel_Paint;
            
            // Timer'ı başlat
            transitionTimer = new System.Windows.Forms.Timer
            {
                Interval = 2500 // 2.5 saniye
            };
            transitionTimer.Tick += TransitionTimer_Tick;
            transitionTimer.Start();
        }

        private void TransitionTimer_Tick(object? sender, EventArgs e)
        {
            transitionTimer.Stop();
            var mainPanel = new MainPanel();
            mainPanel.Show();
            this.Hide();
        }

        private void BeginningPanel_Paint(object? sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                ColorTranslator.FromHtml("#dddddd"),  // Açık gri
                ColorTranslator.FromHtml("#709fe1"),  // Mavi
                90F))  // 90 derece gradyan (doğrusal)
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void BeginningPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void BeginningPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void BeginningPanel_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = Point.Empty;
        }
    }
} 