/**
* \file      frmCombat.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      December 13. 2018
* \brief     Combat form of the game
*
* \details   This form is opened when a combat is asked. It takes the enemy id as argument and it purpose is to enable the player
* to fight an enemy.
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
    public partial class frmCombat : Form
    {
        #region private attributes
        int idEnemy;
        #endregion

        #region constructor
        /// <summary>
        /// The combat form constructor
        /// </summary>
        /// <param name="idEnemy"></param>
        public frmCombat(int idEnemy)
        {
            InitializeComponent();

            //Get enemy id
            this.idEnemy = idEnemy;

            //Wire mouse enter events for sound effect
            cmdNextTurn.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region events
        /// <summary>
        /// Click on next turn button :
        /// 
        /// Play the next turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNextTurn_Click(object sender, EventArgs e)
        {

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
