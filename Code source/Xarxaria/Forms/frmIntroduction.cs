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
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Xarxaria
{
    public partial class frmIntroduction : Form
    {
        #region private attributes
        string defaultName = "Sir Godfroyd de Monaco";
        int defaultHealth = 10;
        int defaultAgility = 2;
        int defaultLuck = 2;
        int defaultPointsToDistribute = 5;

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
        }
        #endregion

        #region private methods
        /// <summary>
        /// Displays an erorr message box
        /// </summary>
        /// <param name="errorMessage"></param>
        private void showError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// Run a form (thread)
        /// </summary>
        private void ThreadProc()
        {
            Application.Run(new frmMain(player.Id));
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
            //Add player's inventory in database
            Program.connection.AddEmptyInventory();

            //Get the id of the created inventory
            int inventoryId = Program.connection.GetNumberOfInventory();

            //Add player in database
            Program.connection.AddPlayer(txtPlayerName.Text, (int)numHealth.Value, 0, 0, (int)numAgility.Value, (int)numLuck.Value, 1, inventoryId);

            //Get the last player in the database
            int lastPlayerId = Program.connection.GetNumberOfPlayer();

            player = Program.connection.GetPlayerById(lastPlayerId);

            //Creates a new thread for the new form
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            
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
            //If the player name is bigger than the database size, show an error
            if (txtPlayerName.TextLength > 255)
            {
                showError("Le nom du joueur est trop long (pas plus de 255 caractères)");
                txtPlayerName.Text = defaultName;
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
            //Get number of points to distribute
            int pointsToDistribute = defaultPointsToDistribute - ((int)numHealth.Value - defaultHealth) - ((int)numAgility.Value - defaultAgility) - ((int)numLuck.Value - defaultLuck);

            //Display the number of points to distribute
            lblDistributePointsValue.Text = pointsToDistribute.ToString();

            if (pointsToDistribute < 0)
            {
                //Not enought points to distribute
                showError("Vous n'avez plus de points à distribuer");

                //Set values to default
                numHealth.Value = defaultHealth;
                numAgility.Value = defaultAgility;
                numLuck.Value = defaultLuck;

                cmdStartAventure.Enabled = false;
                cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
            }
            else if (pointsToDistribute > 0)
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
            }
        }

        private void cmdStartAventure_MouseLeave(object sender, EventArgs e)
        {
            cmdStartAventure.BackgroundImage = Properties.Resources.Simple_Button;
        }
        #endregion
    }
}
