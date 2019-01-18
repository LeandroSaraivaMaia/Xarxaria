/**
* \file      frmMenu.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      November 22. 2018
* \brief     Menu form
*
* \details   This form contain options and save functionality
*/

#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Xarxaria
{
    public partial class frmMenu : Form
    {
        #region private attributes
        Player actualPlayer;
        bool returnToStartScreen;
        #endregion

        #region public accessor
        public bool ReturnToStartScreen { get { return returnToStartScreen; } }
        #endregion

        #region constructor
        /// <summary>
        /// Menu form constructor
        /// </summary>
        public frmMenu(Player player)
        {
            InitializeComponent();

            //Set the variable to tell the main form to not return to menu
            returnToStartScreen = false;

            //Wire mouse enter events for sound effect
            cmdContinue.MouseEnter += cmd_MouseEnter;
            cmdGoToStartScreen.MouseEnter += cmd_MouseEnter;
            cmdOptions.MouseEnter += cmd_MouseEnter;
            cmdSave.MouseEnter += cmd_MouseEnter;
            actualPlayer = player;
        }
        #endregion

        #region click events
        /// <summary>
        /// Continue button :
        /// 
        /// Close menu form and go back to main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdContinue_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Save button :
        /// 
        /// TODO Save the player state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            Program.connection.SavePlayer(actualPlayer);
            MessageBox.Show("Partie sauvegardée.", "Sauvegarde", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Options button :
        /// 
        /// Open the options form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOptions_Click(object sender, EventArgs e)
        {
            frmOptions form = new frmOptions();
            form.ShowDialog();
        }

        /// <summary>
        /// Quit button :
        /// 
        /// Return to the start screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGoToStartScreen_Click(object sender, EventArgs e)
        {
            //Ask the user if he is sure to go back to the start screen
            if (MessageBox.Show("Vous êtes sûr de vouloir revenir à l'écran titre ?\nToute progression non sauvegardée sera perdue.", "Retour à l'écran titre", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                //Close this menu form and change the returnToMenu variable to inform frmMain to go back to start screen
                returnToStartScreen = true;
                Close();
            }
        }
        #endregion

        #region graphic events
        //There is not a doxagen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image

        private void cmdContinue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdContinue.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdContinue_MouseLeave(object sender, EventArgs e)
        {
            cmdContinue.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdSave_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdSave.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdSave_MouseLeave(object sender, EventArgs e)
        {
            cmdSave.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdOptions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdOptions.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdOptions_MouseLeave(object sender, EventArgs e)
        {
            cmdOptions.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdGoToStartScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdGoToStartScreen.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdGoToStartScreen_MouseLeave(object sender, EventArgs e)
        {
            cmdGoToStartScreen.BackgroundImage = Properties.Resources.Simple_Button;
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
    }
}
