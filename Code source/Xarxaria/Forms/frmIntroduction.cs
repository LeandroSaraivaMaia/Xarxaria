/**
* \file      frmIntroduction.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      December 13. 2018
* \brief     Introduction form of the game
*
* \details   The form create a player with personal caracteristics.
*/

#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Xarxaria
{
    public partial class frmIntroduction : Form
    {
        #region private attributes
        string defaultName = "Sir Godfroyd de Monaco";
        int defaultHealth = 20;
        int defaultAgility = 1;
        int defaultLuck = 1;
        int defaultForce = 1;
        int defaultArmor = 0;
        int defaultPointsToDistribute = 7;
        int maxNameSize = 50;

        //get points to distrbute
        int pointsToDistribute => defaultPointsToDistribute - ((int)numHealth.Value - defaultHealth) - ((int)numAgility.Value - defaultAgility) - ((int)numLuck.Value - defaultLuck);

        Player player;
        #endregion

        #region constructor
        /// <summary>
        /// Introduction form constructor
        /// </summary>
        public frmIntroduction()
        {
            InitializeComponent();

            //Wire the events of all numerical valules
            numHealth.ValueChanged += num_ValueChanged;
            numAgility.ValueChanged += num_ValueChanged;
            numLuck.ValueChanged += num_ValueChanged;

            //Set defaults values for caracteristics and name
            txtPlayerName.Text = defaultName;
            numHealth.Value = defaultHealth;
            numAgility.Value = defaultAgility;
            numLuck.Value = defaultLuck;

            //Disable the continue button because no validation check
            cmdStartAventure.Enabled = false;
            cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button_Pressed;

            //Wire mouse enter events for sound effect
            cmdStartAventure.MouseEnter += cmd_MouseEnter;
            cmdGoBackToStartScreen.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Check if ther is enought points to distribute, if not then show an error and disable the start adventure button
        /// </summary>
        /// <param name="points"></param>
        /// <returns>Whether or not there is enought points</returns>
        private bool checkIfEnoughtPoints(int points)
        {
            //Not enought points to distribute
            if (pointsToDistribute < 0)
            {
                showError("Vous n'avez plus de points à distribuer");

                cmdStartAventure.Enabled = false;
                cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button_Pressed;

                return false;
            }

            return true;
        }

        /// <summary>
        /// Displays an erorr message box
        /// </summary>
        /// <param name="errorMessage"></param>
        private void showError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// Run the main form (thread)
        /// </summary>
        private void ThreadProc_frmMain()
        {
            Application.Run(new frmMain(player.Id));
        }

        /// <summary>
        /// Run the start form (thread)
        /// </summary>
        private void ThreadProc_frmStart()
        {
            Application.Run(new frmStart());
        }
        #endregion

        #region form events
        /// <summary>
        /// Click on the start adventure button :
        /// 
        /// Open main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStartAventure_Click(object sender, EventArgs e)
        {
            //Check if the player name contains at least 1 letter
            if (Regex.Matches(txtPlayerName.Text, @"[a-zA-Z]").Count < 1)
            {
                showError("Le nom du joueur doit au moins contenir une lettre [a - z]");
                return;
            }

            //Add player in database
            Program.connection.AddPlayer(txtPlayerName.Text, (int)numHealth.Value, defaultForce, defaultArmor, (int)numAgility.Value, (int)numLuck.Value, 1, 0);

            //Get the last player in the database
            int lastPlayerId = Program.connection.GetNumberOfPlayer();

            player = Program.connection.GetPlayerById(lastPlayerId);

            //Creates a new thread for the new form
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc_frmMain));
            
            //Open the new thread (main form)
            t.Start();

            //Close the introduction form
            this.Close();
        }

        /// <summary>
        /// Click on the go back t ostart screen menu :
        /// 
        /// Close this form and open the start form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGoBackToStartScreen_Click(object sender, EventArgs e)
        {
            //Creates a new thread for the new form
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc_frmStart));

            //Open the new thread (main form)
            t.Start();

            //Close the introduction form
            this.Close();
        }

        /// <summary>
        /// Change text on player name textbox :
        /// 
        /// Check if not too long
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {
            //If the player name is bigger than the arbitrary value for the max name size, displays an error
            if (txtPlayerName.TextLength > maxNameSize)
            {
                showError("Le nom du joueur est trop long (pas plus de " + maxNameSize + " caractères)");
                txtPlayerName.Text = txtPlayerName.Text.Substring(0, maxNameSize);
            }
        }

        /// <summary>
        /// Change value in numeric health :
        /// 
        /// Validation verification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numHealth_ValueChanged(object sender, EventArgs e)
        {
            //If the changed health value is less than the default value, show an error and put the num value to the default value
            if (numHealth.Value < defaultHealth)
            {
                showError("Vous ne pouvez pas avoir des points de vie inférieur à " + defaultHealth.ToString());
                numHealth.Value = defaultHealth;
            }

            //If there is not enought points to distribute, decrement health value
            if (!checkIfEnoughtPoints(pointsToDistribute))
            {
                numHealth.Value--;
            }
        }

        /// <summary>
        /// Change value in numeric agility :
        /// 
        /// Validation verification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numAgility_ValueChanged(object sender, EventArgs e)
        {
            //If the changed agility value is less than the default value, show an error and put the num value to the default value
            if (numAgility.Value < defaultAgility)
            {
                showError("Vous ne pouvez pas avoir des points d'agilité inférieur à " + defaultAgility.ToString());
                numAgility.Value = defaultAgility;
            }

            //If there is not enought points to distribute, decrement agility value
            if (!checkIfEnoughtPoints(pointsToDistribute))
            {
                numAgility.Value--;
            }
        }

        /// <summary>
        /// Change value in numeric luck :
        /// 
        /// Validation verification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numLuck_ValueChanged(object sender, EventArgs e)
        {
            //If the changed luck value is less than the default value, show an error and put the num value to the default value
            if (numLuck.Value < defaultLuck)
            {
                showError("Vous ne pouvez pas avoir des points de chance inférieur à " + defaultLuck.ToString());
                numLuck.Value = defaultLuck;
            }

            //If there is not enought points to distribute, decrement luck value
            if (!checkIfEnoughtPoints(pointsToDistribute))
            {
                numLuck.Value--;
            }
        }

        /// <summary>
        /// Change in any numeric :
        /// 
        /// Change label number of points to distribute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void num_ValueChanged(object sender, EventArgs e)
        {
            //Display the number of points to distribute
            lblDistributePointsValue.Text = pointsToDistribute.ToString();

            if (pointsToDistribute > 0)
            {
                cmdStartAventure.Enabled = false;
                cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
            }
            else if (pointsToDistribute == 0)
            {
                cmdStartAventure.Enabled = true;
                cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button;
            }
        }

        /// <summary>
        /// Event when there is any contact with the introduction text (Selection or click)
        /// 
        /// The active control is redirected to the titleLabel,
        /// this avoid the introduction text to be selected not look good
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIntroduction_Enter(object sender, EventArgs e)
        {
            ActiveControl = lblIntroduction;
        }
        #endregion

        #region graphic events
        //There is not a doxagen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image
        private void cmdStartAventure_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdStartAventure_MouseLeave(object sender, EventArgs e)
        {
            cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdGoBackToStartScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdGoBackToStartScreen.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdGoBackToStartScreen_MouseLeave(object sender, EventArgs e)
        {
            cmdGoBackToStartScreen.BackgroundImage = Properties.Resources.Simple_Button;
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
