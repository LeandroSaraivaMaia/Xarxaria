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
        Bitmap myImage;
        ConnectionDB connection;
        Player actualPlayer;
        List<int> inactiveLinks;
        public frmMain()
        {
            InitializeComponent();

            connection = new ConnectionDB();
            actualPlayer = connection.GetPlayer(1);
            ChangePage(1);


            // Get the path of the image
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = currentDirectory + actualPage.Image;

            picPage.Image = (Image)myImage;
            myImage = new Bitmap(imagePath);

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

        //Avoid main text to be selected
        private void txtPage_Enter(object sender, EventArgs e)
        {
            ActiveControl = lblPageTitle;
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
            //Get the different action values
            string[] actionValues = contents[1].Split(';');

            //Get the aciton value (int)
            int actionValue;
            int.TryParse(contents[1], out actionValue);

            //contents[]
            //The first value [0] is the action id (see enum actionId)
            //The second value [1] is the action value
            //The third value [2] is the link id

            inactiveLinks.Add(int.Parse(contents[2]));

            txtPage.Text = "";
            ChangeText(actualPage.Text, inactiveLinks);

            //Test what action need to be done
            int actualActionId = int.Parse(contents[0]);

            switch (actualActionId)
            {
                case (int)Program.actionId.pageChange:

                    //Get the page id
                    int pageId = int.Parse(contents[1]);

                    //Actually change the page
                    ChangePage(pageId);

                    break;
                case (int)Program.actionId.addItem:

                // Change image
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                string imagePath = currentDirectory + actualPage.Image;
                myImage = new Bitmap(imagePath);
                picPage.Image = (Image)myImage;
                    actualPlayer.SetItem(int.Parse(actionValues[0]), Math.Abs(int.Parse(actionValues[1])));
                    
                    MessageBox.Show("Vous obtenez " + actionValues[1] + " fois l'objet '" + Program.itemLists[int.Parse(actionValues[0])] + "'", "Ajout d'objet", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                case (int)Program.actionId.removeItem:

                    actualPlayer.SetItem(int.Parse(actionValues[0]), - Math.Abs(int.Parse(actionValues[1])));

                    MessageBox.Show("Vous perdez " + actionValues[1] + " fois l'objet '" + Program.itemLists[int.Parse(actionValues[0])] + "'", "Supression d'objet",MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                case (int)Program.actionId.changePlayerHp:

                    actualPlayer.SetPv(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points de vie", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0){ MessageBox.Show("+" + contents[1] + " points de vie", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    break;
                case (int)Program.actionId.changePlayerForce:

                    actualPlayer.SetForce(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points de force", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0) { MessageBox.Show("+" + contents[1] + " points de force", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    break;
                //The armor works a bit differently, it replaces the value of the armor
                case (int)Program.actionId.changePlayerArmor:

                    actualPlayer.SetArmor(- actualPlayer.Armor + actionValue);

                    //Will maybe be replaced by a little animation/sound
                    MessageBox.Show("Votre armure passe à " + contents[1], "Aah", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                case (int)Program.actionId.changePlayerAgility:

                    actualPlayer.SetAgility(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points d'agilité", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0) { MessageBox.Show("+" + contents[1] + " points d'agilité", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    break;
                case (int)Program.actionId.changePlayerLuck:

                    actualPlayer.SetLuck(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points de chance", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0) { MessageBox.Show("+" + contents[1] + " points de chance", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

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

            //Reset inactive links list
            inactiveLinks = new List<int>();
        }

        /// <summary>
        /// Takes a string and an int list in arguments
        /// 
        /// The methods iterate over the string.
        /// Every time there is a beacon with the symbol greater than and lesser than, the program read inside the beacon values that are formatted.
        /// 
        /// The format rules are as follow :
        /// 
        ///     There is 3 values in the beacon separated by commas
        ///     The first value [0] is the action id (Page change, item add, etc, see enum actionId)
        ///     The second value [1] is the shown text
        ///     The third value [2] is the action value
        ///     
        ///     The third value [2] can have multiple values divided by a semicolon
        ///     It is used for example in the item add action because it needs multiple values (id of the item and number of item added/removed)
        /// 
        /// The int list "selectedLinks" is used to set certain links inactive.
        /// The values in this list represent the index of the link in order of apparition (Begining to the end)
        /// If a value in this list is equal to the current iterated link, the link will be inactive otherwise it will be active
        /// 
        /// When a link is clicked, see txtPage_LinkClicked event to see what happen
        /// 
        /// The text can't end with a symbol !!
        /// 
        /// The text can't have an empty symbol
        /// example : blabla <> blabla
        /// 
        /// The text can't have two opening symbol or two closing symbol if they are not opened/closed
        /// </summary>
        /// <param name="text"></param>
        /// <param name="selectedInactiveLinks"></param>
        /// <returns>Number of links in the string</returns>
        int ChangeText(string text, List<int> selectedInactiveLinks = null)
        {
            int pageChangedOpen = -1;
            int lastFreeChar = 0;
            int numberOfLinks = 1;

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

                    
                    bool isLinkInactive = false;

                    //If there is inactive links
                    if (selectedInactiveLinks != null)
                    {
                        //Check if the iterated link is an inactive link in parameter
                        foreach (int selectedLink in selectedInactiveLinks)
                        {
                            if (selectedLink == numberOfLinks)
                            {
                                isLinkInactive = true;
                            }
                        }
                    }

                    if (isLinkInactive)
                    {
                        //Add inactive link
                        txtPage.AppendText(contents[1], SystemColors.ControlDarkDark, true);
                    }
                    else
                    {
                        //Add active link
                        //The first argument is the shown text, then the action id, then the action value(s) and the link number
                        txtPage.InsertLink(contents[1], contents[0] + "," + contents[2] + "," + numberOfLinks);
                    }

                    //Increment number of links
                    numberOfLinks++;

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

            return numberOfLinks - 1;
        }
        #endregion
    }
}
