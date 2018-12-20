/**
* \file      frmPlayer.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      November 22. 2018
* \brief     Player form
*
* \details   Display the current player caracteristics and items
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
    public partial class frmPlayer : Form
    {
        #region private attributes
        Player player;
        #endregion

        #region constructor
        /// <summary>
        /// Player form constructo, takes a player as an argument
        /// </summary>
        /// <param name="player"></param>
        public frmPlayer(Player player)
        {
            InitializeComponent();
            this.player = player;

            //Change caracteristic text
            lblHealth.Text = "Points de vie : " + player.Pv.ToString();
            lblForce.Text = "Force : " + player.Force.ToString();
            lblAgility.Text = "Agilité : " + player.Agility.ToString();
            lblArmor.Text = "Armure : " + player.Armor.ToString();
            lblLuck.Text = "Chance : " + player.Luck.ToString();
            lblPlayerName.Text = player.Name.ToString();

            //Change item list text
            for (int itemId = 0; itemId < Program.itemLists.Length; itemId++)
            {
                int numberOfItems = player.GetInventory.Items[itemId];
                if (numberOfItems != 0)
                    lstItems.Items.Add(Program.itemLists[itemId] + "\t" + numberOfItems);
            }

            //Wire mouse enter events for sound effect
            cmdPlayerContinue.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region click events
        /// <summary>
        /// Continue button :
        /// 
        /// Close the player form and go back to the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlayerContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region graphic events
        //There is not a doxagen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image
        private void cmdPlayerContinue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdPlayerContinue.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdPlayerContinue_MouseLeave(object sender, EventArgs e)
        {
            cmdPlayerContinue.BackgroundImage = Properties.Resources.Simple_Button;
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
