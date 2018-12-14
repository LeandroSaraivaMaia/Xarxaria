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
                //Close this menu form and put the dialogResult to inform frmMain to go back to start screen
                DialogResult = DialogResult.Abort;
                Close();
            }
        }
        #endregion
    }
}
