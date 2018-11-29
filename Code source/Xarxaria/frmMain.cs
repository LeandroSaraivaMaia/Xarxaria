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
        ConnectionDB connection = new ConnectionDB();
        public frmMain()
        {
            InitializeComponent();

            txtPage.SelectedText = "With this extended RichTextBox you're able to insert\n";
            txtPage.SelectedText = "your own arbitrary links in the text: ";
            txtPage.InsertLink("Link with arbitrary text");
            txtPage.SelectedText = ".\nYou are not limited to the standard protocols any more,\n";
            txtPage.SelectedText = "but you can still use them, of course: ";
            txtPage.InsertLink("http://www.codeproject.com");
            txtPage.SelectedText = "\n\nThe new links fire the LinkClicked event, just like the standard\n";
            txtPage.SelectedText = "links do when AutoDetectUrls is set.\n\n";
            txtPage.SelectedText = "Managing hyperlinks independent of link text is possible as well: ";
            txtPage.InsertLink("Link text", "Hyperlink text");
            txtPage.SelectedText = connection.ReadPlayer();
        }

        #region click events

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

        private void txtPage_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            MessageBox.Show("A link has been clicked.\nThe link text is '" + e.LinkText + "'");
        }

        #endregion
    }
}
