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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Xarxaria
{
    public partial class frmMenu : Form
    {
        #region constructor
        /// <summary>
        /// Menu form constructor
        /// </summary>
        public frmMenu()
        {
            InitializeComponent();
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
            this.Close();
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

        }

        /// <summary>
        /// Options button :
        /// 
        /// TODO Open another form to change options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOptions_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Quit button :
        /// 
        /// Quit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
