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
        int id = 1;
        Page actualPage;
        Bitmap myImage;

        ConnectionDB connection = new ConnectionDB();
        public frmMain()
        {
            InitializeComponent();

            actualPage = connection.ReadPage(id);
            ChangeText(actualPage.Text);
            lblPageTitle.Text = actualPage.Title;

            myImage = new Bitmap("P:\\MA\\Projet C#\\Xarxaria\\Code source\\Xarxaria\\DataBase\\images\\paysage_01.jpg");
            picPage.Image = (Image)myImage;
        }

        #region Click events

        void cmdPlayer_Click(object sender, EventArgs e)
        {
            frmPlayer playerForm = new frmPlayer();

            playerForm.ShowDialog();
        }

        void cmdMenu_Click(object sender, EventArgs e)
        {
            frmMenu menuForm = new frmMenu();
            menuForm.ShowDialog();
        }

        void txtPage_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            MessageBox.Show("A link has been clicked.\nThe link text is '" + e.LinkText + "'");

            //Separate shown text to link text
            int separationIndex = e.LinkText.IndexOf('#');

            string shownLink = e.LinkText.Substring(0, separationIndex);
            string actualLink = e.LinkText.Substring(separationIndex + 1);

            MessageBox.Show("shownLink : '" + shownLink + "'");
            MessageBox.Show("actualLink : '" + actualLink + "'");

            //If the link is a page change
            if (actualLink.Contains('<'))
            {
                id = int.Parse(shownLink);

                //Get page from database
                actualPage = connection.ReadPage(id);

                txtPage.Text = "";

                lblPageTitle.Text = actualPage.Title;

                //Text load
                ChangeText(actualPage.Text);
            }
        }

        #endregion

        #region Private methods
        void ChangeText(string text)
        {
            //The text can't end with a symbol !!

            //The text can't have an empty symbol
            //example : blabla <> blabla

            //The text can't put a symbol in a symbol !!
            //example : blabla < arrows value [ brackets value ] arrows value > blabla
            //correct : blabla < arrows value > blabla [ brackets value ] blabla

            int pageChangedOpen = -1;
            int lastFreeChar = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (i == text.Length - 1)
                {
                    txtPage.SelectedText = text.Substring(lastFreeChar, i - lastFreeChar + 1);
                }

                if (text[i] == '<')
                {
                    pageChangedOpen = i;

                    //Add the text before the symbol
                    txtPage.SelectedText = text.Substring(lastFreeChar, (i) - lastFreeChar);
                }

                if (text[i] == '>')
                {
                    if (pageChangedOpen == -1) throw new Exception("Closed \">\" without opening");
                    if (pageChangedOpen + 1 == i) throw new Exception("Empty symbol data \"<>\"");

                    //Add the link text
                    string linkText = text.Substring(pageChangedOpen, i - pageChangedOpen + 1);
                    string shownText = text.Substring(pageChangedOpen + 1, i - (pageChangedOpen + 1));
                    txtPage.InsertLink(shownText, linkText);

                    lastFreeChar = i + 1;

                    pageChangedOpen = -1;
                }
            }
        }

        #endregion
    }
}
