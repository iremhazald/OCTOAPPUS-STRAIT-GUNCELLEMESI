using System;
using System.Windows.Forms;

namespace HanShipProformaApp
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void btnStraits_Click(object sender, EventArgs e)
        {
            var straits = new Straits();
            straits.Show();
        }

        private void btnPorts_Click(object sender, EventArgs e)
        {
            var proformaPanel = new ProformaPanel();
            proformaPanel.Show();
        }
    }
} 