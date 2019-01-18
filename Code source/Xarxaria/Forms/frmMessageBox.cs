/**
* \file      frmMessageBox.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      January 17. 2019
* \brief     Message box replacement
*
* \details   This is a new texture for the traditional message box.
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
    #region private attributes
    #endregion

    public partial class frmMessageBox : Form
    {
        #region constructor
        public frmMessageBox(string message, string title)
        {
            InitializeComponent();

            //Set title and message
            lblTitle.Text = title;
            txtMessage.Text = message;

            //Wire mouse enter events for sound effect
            cmdOk.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region events
        /// <summary>
        /// Event when there is any contact with the message text (Selection or click)
        /// 
        /// The active control is redirected to the titleLabel,
        /// this avoid the message text to be selected not look good
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMessage_Enter(object sender, EventArgs e)
        {
            ActiveControl = lblTitle;
        }

        /// <summary>
        /// Click on the ok button :
        /// 
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region graphic events
        //There is not a doxagen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image
        private void cmdOk_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdOk.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdOk_MouseLeave(object sender, EventArgs e)
        {
            cmdOk.BackgroundImage = Properties.Resources.Simple_Button;
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
