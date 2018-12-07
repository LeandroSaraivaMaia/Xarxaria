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
        Page actualPage;
        ConnectionDB connection;
        Player actualPlayer;
        public frmMain()
        {
            InitializeComponent();

            connection = new ConnectionDB();

            actualPlayer = connection.GetPlayer(1);

            ChangePage(1);
        }

        #region Click events

        void cmdPlayer_Click(object sender, EventArgs e)
        {
            frmPlayer playerForm = new frmPlayer(actualPlayer);

            playerForm.ShowDialog();
        }

        void cmdMenu_Click(object sender, EventArgs e)
        {
            frmMenu menuForm = new frmMenu();
            menuForm.ShowDialog();
        }

        void txtPage_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            //Separate shown text to link text
            int separationIndex = e.LinkText.IndexOf('#');
            string shownLink = e.LinkText.Substring(0, separationIndex);
            string actualLink = e.LinkText.Substring(separationIndex + 1);

            //Get all content of the actual link
            string[] contents = actualLink.Split(',');

            //Contents of action content (separated by ;)
            string[] actionValuecontents;

            //contents[]
            //The first value [0] is the action id (see enum actionId)
            //The second value [1] is the action value

            //Test what action need to be done
            switch (int.Parse(contents[0]))
            {
                case (int)Program.actionId.pageChange:

                    //Get the page id
                    int pageId = int.Parse(contents[1]);

                    //Actually change the page
                    ChangePage(pageId);

                    break;
                case (int)Program.actionId.addItem:

                    //Get the different action values
                    actionValuecontents = contents[1].Split(';');

                    actualPlayer.AddItem(int.Parse(actionValuecontents[0]), int.Parse(actionValuecontents[1]));
                    //temp
                    MessageBox.Show("Vous ajoutez " + actionValuecontents[1] + " fois l'objet avec l'id " + int.Parse(actionValuecontents[0]));

                    break;
                case (int)Program.actionId.removeItem:

                    //Get the different action values
                    actionValuecontents = contents[1].Split(';');

                    break;
                default : throw new Exception("Action id unknown");
            }
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Change the actual page with a given id
        /// </summary>
        /// <param name="pageId"></param>
        void ChangePage(int pageId)
        {
            //Get page from database
            actualPage = connection.GetPage(pageId);

            //Change page title
            lblPageTitle.Text = actualPage.Title;

            //Change page text
            txtPage.Text = "";
            ChangeText(actualPage.Text);
        }

        /// <summary>
        /// Change the actual page text
        /// </summary>
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
                //If we open a beacon
                if (text[i] == '<')
                {
                    //If it is the last caracter, throw an exception
                    if (i == text.Length - 1) throw new Exception("Cannot open \"<\" at the end of the text");

                    pageChangedOpen = i;

                    //Add the text before the symbol
                    txtPage.SelectedText = text.Substring(lastFreeChar, (i) - lastFreeChar);
                }

                //If we close a beacon
                if (text[i] == '>')
                {
                    if (pageChangedOpen == -1) throw new Exception("Closed \">\" without opening");
                    if (pageChangedOpen + 1 == i) throw new Exception("Empty symbol data \"<>\"");

                    //Add the link text
                    string linkContent = text.Substring(pageChangedOpen + 1, i - (pageChangedOpen + 1));
                    string[] contents = linkContent.Split(',');

                    //contents[]
                    //The first value [0] is the action id (see enum actionId)
                    //The second value [1] is the shown text
                    //The third value [2] is the action value

                    txtPage.InsertLink(contents[1], contents[0] + "," + contents[2]);

                    lastFreeChar = i + 1;

                    pageChangedOpen = -1;

                    //If it is the last caracter, break the for so it doesn't get two time the text
                    if (i == text.Length - 1) break;
                }

                //If it is the last caracter
                if (i == text.Length - 1)
                {
                    if (pageChangedOpen == -1)
                        txtPage.SelectedText = text.Substring(lastFreeChar, i - lastFreeChar + 1);
                }
            }
        }

        #endregion
    }
}
