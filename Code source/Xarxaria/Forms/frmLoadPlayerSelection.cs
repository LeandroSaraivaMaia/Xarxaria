/**
* \file      frmLoadPlayerSelection.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      December 13. 2018
* \brief     Load selection form of the game.
*
* \details   This form allows the user to load a save in the database.
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
    public partial class frmLoadPlayerSelection : Form
    {
        #region private attributes
        int playerId;
        #endregion

        #region accessor
        public int PlayerId { get { return playerId; } }
        #endregion

        #region constructor
        /// <summary>
        /// Load player selection constructor.
        /// </summary>
        public frmLoadPlayerSelection()
        {
            InitializeComponent();

            //Get all athe players in the database
            List<Player> players = Program.connection.GetPlayers();

            //Fill the listbox with all the players
            foreach (Player player in players)
                lstSaveFile.Items.Add(player);

            //Set the select save button to inactive (it wiil be active when a list is selected)
            cmdChooseSave.Enabled = false;
            cmdChooseSave.BackgroundImage = Properties.Resources.Simple_Button_Pressed;

            //Wire mouse enter events for sound effect
            cmdGoBack.MouseEnter += cmd_MouseEnter;
            cmdChooseSave.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region events
        /// <summary>
        /// Click on the choose save button :
        /// 
        /// Return the selected save to the start form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChooseSave_Click(object sender, EventArgs e)
        {
            //Get the player save from the list box
            Player selectedPlayer = (Player)lstSaveFile.SelectedItem;

            //Set the choosen save id
            playerId = selectedPlayer.Id;

            //Set dialogResult and quit
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Click on the "retour" button :
        /// 
        /// Go back to the start screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGoBack_Click(object sender, EventArgs e)
        {
            //Set dialogResult and quit
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// The selected save is changed :
        /// 
        /// Active the load save button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSaveFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSaveFile.SelectedItem != null)
            {
                cmdChooseSave.Enabled = true;
                cmdChooseSave.BackgroundImage = Properties.Resources.Simple_Button;
            }
        }
        #endregion

        #region graphic events
        //There is not a doxygen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image
        private void cmdGoBack_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdGoBack.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdGoBack_MouseLeave(object sender, EventArgs e)
        {
            cmdGoBack.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdChooseSave_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdChooseSave.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdChooseSave_MouseLeave(object sender, EventArgs e)
        {
            cmdChooseSave.BackgroundImage = Properties.Resources.Simple_Button;
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
