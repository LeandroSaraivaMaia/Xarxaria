/**
* \file      frmMain.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      November 21. 2018
* \brief     Main form of the game.
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
        Bitmap loadedImage;
        Player actualPlayer;
        bool returnToStartScreen;
        int infiniteLoopRedreshDelay = 10;
        #endregion

        #region public accessor
        public float ZoomFactor
        {
            get { return txtPage.ZoomFactor; }
            set
            {
                txtPage.ZoomFactor = value;
                txtPage.oldZoomFactor = value;
            }
        }
        public HorizontalAlignment TextAlign
        {
            get { return txtPage.SelectionAlignment; }
            set
            {
                //When the change alignement change, select all the text to change alignement
                txtPage.SelectAll();
                txtPage.SelectionAlignment = value;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Main form constructor that load a player.
        /// </summary>
        public frmMain(int playerId)
        {
            InitializeComponent();

            //Get the selected player in the database
            actualPlayer = Program.connection.GetPlayerById(playerId);

            //Load the page of the player
            ChangePage(actualPlayer.IdActualPage, actualPlayer.InactiveLinksInActualPage);

            //Set the variable returnToStartScreen to not return to start screen
            returnToStartScreen = false;

            //Initialize infinte loop
            infiniteLoop();

            //Wire mouse enter events for sound effect
            cmdPlayer.MouseEnter += cmd_MouseEnter;
            cmdMenu.MouseEnter += cmd_MouseEnter;
            cmdHelp.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region infinite loop
        /// <summary>
        /// Check if the forms needs to be closed.
        /// </summary>
        public async void infiniteLoop()
        {
            while (true)
            {
                await Task.Delay(infiniteLoopRedreshDelay);
                if (returnToStartScreen)
                {
                    Close();
                }
            }
        }
        #endregion

        #region events
        /// <summary>
        /// Click on the help button :
        /// 
        /// Display informations to play Xarxaria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Program.showMessage("Tout au long de l'aventure, des pages se succèdent.\n\n" +
                "Le texte contient des choix représentés par un lien en bleu cliquable.\n\n" +
                "Chaque choix a les actions possibles suivantes :\n" +
               "\tChanger de page\n" +
               "\tObtenir/Perdre un objet dans l'inventaire\n" +
               "\tCombattre un ennemi\n" +
               "\tModifier une caractéristique\n\t(pv, force, armure, agilité, chance)\n\n" +
               "L'inventaire et les caractéristiques sont disponibles en cliquant sur \"Feuille de personnage\"\n\n" +
               "Le bouton \"Menu\" permet de quitter la partie, modifier les options et sauvegarder la partie", "Informations");
        }

        /// <summary>
        /// Click on the button "Feuille de personnage".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmdPlayer_Click(object sender, EventArgs e)
        {
            frmPlayer playerForm = new frmPlayer(actualPlayer);

            playerForm.ShowDialog();
        }

        /// <summary>
        /// Click on the button "Menu".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmdMenu_Click(object sender, EventArgs e)
        {
            frmMenu menuForm = new frmMenu(actualPlayer);

            menuForm.ShowDialog();

            //If the menu form is closed and sent a message to go back to title screen, open start screen and close main form
            if (menuForm.ReturnToStartScreen)
            {
                //Open the start screen
                void ThreadProc_frmStart()
                {
                    Application.Run(new frmStart());
                }

                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc_frmStart));

                t.Start();

                returnToStartScreen = true;
            }
        }

        /// <summary>
        /// Event when with have any contact with the main text (Selection or click)
        /// 
        /// The active control is redirected to the titleLabel,
        /// this avoid the main text to be selected and not looking good.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPage_Enter(object sender, EventArgs e)
        {
            ActiveControl = lblPageTitle;
        }

        /// <summary>
        /// Event when a link in the main text is clicked.
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

            //Test the number of values between beacons, there must be 3
            if (contents.Length > 3)
            {
                throw new Exception("Too much values between beacons (needs 3 and there is " + contents.Length + "). Check commas");
            }
            else if (contents.Length < 3)
            {
                throw new Exception("Not enought values between beacons (needs 3 and there is " + contents.Length + "). Check commas");
            }

            //Get what action need to be done
            int linkActionId = int.Parse(contents[0]);

            //Contents of action content (separated by ;)
            //Get the different action values
            string[] actionValues = contents[1].Split(';');

            string actionName = Enum.GetName(typeof(Program.actionId), linkActionId);

            //Verify that there is not too much or not enought action values
            //Note that, for changeItem and displayMessage action, there needs to be 2 action values and for other actions, there needs to be 1 action value
            if (actionValues.Length == 0)
                throw new Exception("No action values for action : " + Enum.GetName(typeof(Program.actionId), linkActionId));

            if (linkActionId != (int)Program.actionId.changeItem && linkActionId != (int)Program.actionId.displayMessage)
            {
                if (actionValues.Length > 1)
                    throw new Exception("Too much action values for action : " + actionName + "\nThere needs to be 1 and there is " + actionValues.Length);
            }
            else if (actionValues.Length > 2)
                throw new Exception("Too much action values for action : " + actionName + "\nThere needs to be 2 and there is " + actionValues.Length);
            else if (actionValues.Length == 1)
                throw new Exception("Not enought action values for action : " + actionName + "\nThere needs to be 2 and there is " + actionValues.Length);

            //Get the action value (int)
            int actionValue;
            int.TryParse(contents[1], out actionValue);

            //contents[]
            //The first value [0] is the action id (see enum actionId)
            //The second value [1] is the action value
            //The third value [2] is the link id

            //Add the link index to the inactive Links list
            //This UINT determines what link will be inactive
            actualPlayer.InactiveLinksInActualPage |= uint.Parse(contents[2]);

            //Reload text
            txtPage.Text = "";
            ChangeText(actualPage.Text, actualPlayer.InactiveLinksInActualPage);

            //If the player is dead, use this function
            void GameOver()
            {
                MessageBox.Show("La partie est terminée car vous êtes mort, retour à l'écran principale", "Vous êtes mort", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Open the start screen
                void ThreadProc_frmStart()
                {
                    Application.Run(new frmStart());
                }

                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc_frmStart));

                t.Start();

                returnToStartScreen = true;
            }

            //Test what action need to be done
            switch (linkActionId)
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

                    //Get name
                    Item item = Program.connection.GetItemById(itemId + 1);

                    if (numberOfItems < 0) { MessageBox.Show("Vous perdez " + Math.Abs(numberOfItems) + " fois l'objet '" + item.Name + "'", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (numberOfItems > 0) { MessageBox.Show("Vous obtenez " + numberOfItems + " fois l'objet '" + item.Name + "'", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    break;
                case (int)Program.actionId.changePlayerHp:

                    actualPlayer.SetHp(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points de vie", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0) { MessageBox.Show("+" + contents[1] + " points de vie", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    //Test if the player die
                    if (actualPlayer.Hp <= 0)
                        GameOver();

                    break;
                case (int)Program.actionId.changePlayerForce:
                    actualPlayer.SetForce(actionValue);

                    //Will maybe be replaced by a little animation/sound
                    if (actionValue < 0) { MessageBox.Show(contents[1] + " points de force", "Ouch", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (actionValue > 0) { MessageBox.Show("+" + contents[1] + " points de force", "Mmmh", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    break;
                //The force works a bit differently, it replaces the value of the force and it's not adding or substracting anything. But we can also change the force like other caracteristic (enum changePlayerForce)
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
                case (int)Program.actionId.displayMessage:

                    //Show message
                    MessageBox.Show(actionValues[0], actionValues[1]);

                    break;
                case (int)Program.actionId.enemyFight:

                    frmCombat combatForm = new frmCombat(actualPlayer, actionValue);

                    combatForm.ShowDialog();

                    //Actualize player's caracteristics (HP)
                    actualPlayer = combatForm.GetPlayer;

                    //If the combat form is closed and sent a message to go back to title screen, open start screen and close main form
                    if (!combatForm.DoesPlayerWin)
                    {
                        GameOver();
                    }

                    break;
                default: throw new Exception("Action id unknown");
            }

            //Trigger the getter of the zoomFactor to apply zoom correctly
            float dump = txtPage.ZoomFactor;

            //Change the ZoomFactor value
            txtPage.ZoomFactor = Program.textZoom;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Change the actual page with a given id.
        /// </summary>
        /// <param name="pageId"></param>
        void ChangePage(int pageId, uint inactiveLinks = 0)
        {
            //Get page from database
            actualPage = Program.connection.GetPage(pageId);

            //Change page title
            lblPageTitle.Text = actualPage.Title;

            //Change player idActualPage
            actualPlayer.SetActualPage(actualPage.Id);

            //Change page text
            txtPage.Text = "";

            //Trigger the getter of the zoomFactor to apply zoom correctly
            float dump = txtPage.ZoomFactor;

            //Load the text
            ChangeText(actualPage.Text, inactiveLinks);

            //Change the ZoomFactor value
            txtPage.ZoomFactor = Program.textZoom;

            //Change image
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = currentDirectory + @"\assets\images\pages\" + actualPage.Image;
            try
            {
                loadedImage = new Bitmap(imagePath);
            }
            catch
            {
                throw new Exception("Image cannot be loaded, may be an access to an unexisting page");
            }
            picPage.Image = (Image)loadedImage;

            //Reset inactive links
            if (inactiveLinks == 0)
                actualPlayer.InactiveLinksInActualPage = 0;

            txtPage.ScrollToTop();
        }

        /// <summary>
        /// Takes a string and an int list in arguments.
        /// 
        /// The methods iterate over the string.
        /// Every time there is a beacon with the symbol greater than and lesser than, the program read inside the beacon values that are formatted.
        /// 
        /// The format rules are as follow :
        /// 
        ///     There is 3 values in the beacon separated by commas :
        ///     The first value [0] is the action id (Page change, item add, etc, see enum actionId).
        ///     The second value [1] is the shown text.
        ///     The third value [2] is the action value.
        ///     
        ///     The third value [2] can have multiple values divided by a semicolon.
        ///     It is used for example in the item add action because it needs multiple values (id of the item and number of item added/removed).
        /// 
        /// The int list "selectedLinks" is used to set certain links inactive.
        /// The values in this list represent the index of the link in order of apparition (Begining to the end).
        /// If a value in this list is equal to the current iterated link, the link will be inactive otherwise it will be active.
        /// 
        /// When a link is clicked, see txtPage_LinkClicked event to see what happen.
        /// 
        /// The text can't have an empty symbol.
        /// example : blabla <> blabla.
        /// 
        /// The text can't have two opening symbol or two closing symbol if they are not opened/closed.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="selectedInactiveLinks"></param>
        /// <returns>Number of links in the string</returns>
        int ChangeText(string text, uint selectedInactiveLinks = 0)
        {
            int pageChangedOpen = -1;
            int lastFreeChar = 0;
            uint iteratedLink = 1;
            int numberOfLinks = 1;

            bool textIsHighlighted = false;

            for (int i = 0; i < text.Length; i++)
            {
                //If there is a highlight beacon
                if (text[i] == '*')
                {
                    if (textIsHighlighted)
                    {
                        textIsHighlighted = false;
                        txtPage.AppendText(text.Substring(lastFreeChar, i - lastFreeChar), SystemColors.WindowText, false, true);
                        lastFreeChar = i + 1;
                        i++;
                    }
                    else
                    {
                        textIsHighlighted = true;
                        txtPage.AppendText(text.Substring(lastFreeChar, i - lastFreeChar));
                        lastFreeChar = i + 1;
                        i++;
                    }
                }

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

                    if (selectedInactiveLinks != 0)
                    {
                        //Check if the iterated link is an inactive link in parameter
                        if ((selectedInactiveLinks & iteratedLink) == iteratedLink)
                        {
                            isLinkInactive = true;
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
                        txtPage.InsertLink(contents[1], contents[0] + "," + contents[2] + "," + iteratedLink);
                    }

                    //Shift the bit number of links
                    iteratedLink = iteratedLink << 1;

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
                    {
                        //Add the text before the symbol
                        txtPage.SelectedText = text.Substring(lastFreeChar, i - lastFreeChar + 1);
                    }
                }
            }

            //Set text alignement
            TextAlign = Program.horizontalAlignment;

            return numberOfLinks - 1;
        }
        #endregion

        #region graphic events
        //There is not a doxygen commentary for each events, these are really repetitive
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

        private void cmdHelp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdHelp.BackgroundImage = Properties.Resources.Help_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdHelp_MouseLeave(object sender, EventArgs e)
        {
            cmdHelp.BackgroundImage = Properties.Resources.Help_Button;
        }
        #endregion

        #region sound events
        /// <summary>
        /// The mouse enter in a button :
        /// 
        /// Play hover sound.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_MouseEnter(object sender, EventArgs e)
        {
            Program.playHoverSound();
        }
        #endregion
    }
}
