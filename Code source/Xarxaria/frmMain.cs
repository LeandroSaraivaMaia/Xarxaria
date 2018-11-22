using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xarxaria
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdPlayer_Click(object sender, EventArgs e)
        {
            frmPlayer playerForm = new frmPlayer();

            playerForm.ShowDialog();
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            frmMenu menuForm = new frmMenu();

            menuForm.ShowDialog();
        }
    }
}
