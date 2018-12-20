/**
 * \file      frmMain.cs
 * \author    Johan Voland & Leandro Saraiva Maia
 * \version   1.0
 * \date      November 21. 2018
 * \brief     Main form of the game
 *
 * \details   This form will represent a page in our interactive digital book.
 * It contains the main text, an image, option button, player caracteristics button and usable link in the text.
 */

#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Xarxaria
{
    public partial class frmMain : Form
    {
        #region private attributes
        Page actualPage;
        Bitmap myImage;
        Player actualPlayer;
        List<int> inactiveLinks;
        #endregion

        #region public accessor
        public float ZoomFactor { get { return txtPage.ZoomFactor; } set { txtPage.ZoomFactor = value; } }
        public HorizontalAlignment TextAlign { get { return txtPage.SelectionAlignment; } set {
                //When the change alignement change, select all the text to change alignement
                txtPage.SelectAll();
                txtPage.SelectionAlignment = value;
            } }
        #endregion

        #region constructor
        /// <summary>
        /// Main form constructor that load a player
        /// </summary>
        public frmMain(int playerId)
        {
            InitializeComponent();

            //Get the selected player in the database
            actualPlayer = Program.connection.GetPlayerById(playerId);

            //Load the page of the player
            ChangePage(actualPlayer.IdActualPage);

            //Wire mouse enter events for sound effect
            cmdPlayer.MouseEnter += cmd_MouseEnter;
            cmdMenu.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region click events
        /// <summary>
        /// Click on the button "Feuille de personnage"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmdPlayer_Click(object sender, EventArgs e)
        {
            using (var form = new frmPlayer(actualPlayer))
            {
                void MainThreadProc()
                {
                    Application.Run(new frmPlayer(actualPlayer));
                }

                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(MainThreadProc));

                t.Start();
            }
        }

        /// <summary>
        /// Click on the button "Menu"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmdMenu_Click(object sender, EventArgs e)
        {

            using (var form = new frmMenu())
            {
                var result = form.ShowDialog();

                //If the menu form is closed and sent a message to go back to title screen, open start screen and close main form
                if (result == DialogResult.Abort)
                {
                    //Open the start screen
                    void StartScreenThreadProc()
                    {
                        Application.Run(new frmStart());
                    }

                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(StartScreenThreadProc));

                    t.Start();

                    Close();
                }
            }
        }

        /// <summary>
        /// Event when with have any contact with the main text (Selection or click)
        /// 
        /// The active control is redirected to the titleLabel,
        /// this avoid the main text to be selected not look good
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPage_Enter(object sender, EventArgs e)
        {
            ActiveControl = lblPageTitle;
        }

        /// <summary>
        /// Event when a link in the main text is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            //Add the link index to the inactive Links list
            //This list determines what link will be inactive
            inactiveLinks.Add(int.Parse(contents[2]));

            //Reload text
            txtPage.Text = "";
            ChangeText(actualPage.Text, inactiveLinks);

            //Get what action need to be done
            int actualActionId = int.Parse(contents[0]);

            //Test what action need to be done
            switch (actualActionId)
            {
                case (int)Program.actionId.pageChange:

                    //Get the page id
                    int pageId = int.Parse(contents[1]);

                    //Actually change the page
                    ChangePage(pageId);

                    break;
                case (int)Program.actionId.changeItem:

                    int itemId = int.Parse(actionValues[0]);
                    int numberOfItems = int.Parse(actionValues[1]);

                    actualPlayer.SetItem(itemId, numberOfItems);
                    
                    if (numberOfItems < 0) { MessageBox.Show("Vous perdez " + Math.Abs(numberOfItems) + " fois l'objet '" + Program.itemLists[itemId] + "'", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (numberOfItems > 0) { MessageBox.Show("Vous obtenez " + numberOfItems + " fois l'objet '" + Program.itemLists[itemId] + "'", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    break;
                case (int)Program.actionId.changePlayerHp:

                    actualPlayer.SetPv(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points de vie", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0){ MessageBox.Show("+" + contents[1] + " points de vie", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    break;
                //The force works a bit differently, it replaces the value of the force and it's not adding or substracting anything
                case (int)Program.actionId.setPlayerForce:

                    actualPlayer.SetForce(-actualPlayer.Force + actionValue);

                    //Will maybe be replaced by a little animation/sound
                    MessageBox.Show("Votre force passe à " + contents[1], "Aah", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                case (int)Program.actionId.changePlayerArmor:

                    actualPlayer.SetArmor(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points d'armure", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0) { MessageBox.Show("+" + contents[1] + " points d'armure", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

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

        #region private methods
        /// <summary>
        /// Change the actual page with a given id
        /// </summary>
        /// <param name="pageId"></param>
        void ChangePage(int pageId)
        {
            //Get page from database
            actualPage = Program.connection.GetPage(pageId);

            //Change page title
            lblPageTitle.Text = actualPage.Title;

            //Change page text
            txtPage.Text = "";

            //trigger the getter of the zoomFactor to apply zoom correctly
            float dump = txtPage.ZoomFactor;

            //Load the text
            ChangeText(actualPage.Text);

            //Change the ZoomFactor value
            txtPage.ZoomFactor = Program.textZoom;

            //Change image
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = currentDirectory + actualPage.Image;
            myImage = new Bitmap(imagePath);
            picPage.Image = (Image)myImage;
            
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

            //Set text alignement
            TextAlign = Program.horizontalAlignment;

            return numberOfLinks - 1;
        }
        #endregion

        #region graphic events
        //There is not a doxagen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image
        private void cmdMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdMenu.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdMenu_MouseLeave(object sender, EventArgs e)
        {
            cmdMenu.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdPlayer.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdPlayer_MouseLeave(object sender, EventArgs e)
        {
            cmdPlayer.BackgroundImage = Properties.Resources.Simple_Button;
        }
        #endregion

        #region sound events
        /// <summary>
        /// The mouse enter in a button :
        /// 
        /// Play hover sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_MouseEnter(object sender, EventArgs e)
        {
            Program.playHoverSound();
        }
        #endregion

        //Temporary debug
        private void cmdDebug_Click(object sender, EventArgs e)
        {
            ChangePage(int.Parse(txtDebug.Text));
        }
    }
}
