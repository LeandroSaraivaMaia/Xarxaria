/**
* \file      frmStart.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      December 13. 2018
* \brief     Start form of the game
*
* \details   This form is the first thing shown to the player when the application launch.
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
    public partial class frmStart : Form
    {
        #region constructor
        /// <summary>
        /// The start form constructor
        /// </summary>
        public frmStart()
        {
            InitializeComponent();
        }
        #endregion

        #region buttons click
        /// <summary>
        /// Click on new game button :
        /// 
        /// Open introduction form and close start form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNewGame_Click(object sender, EventArgs e)
        {
            void IntroductionThreadProc()
            {
                Application.Run(new frmIntroduction());
            }

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(IntroductionThreadProc));

            t.Start();

            this.Close();
        }

        /// <summary>
        /// Click on load button :
        /// 
        /// Open a form to select game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            using (var form = new frmLoadPlayerSelection())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int selectedPlayerId = form.PlayerId;

                    void MainThreadProc()
                    {
                        Application.Run(new frmMain(selectedPlayerId));
                    }

                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(MainThreadProc));

                    t.Start();

                    this.Close();
                }
            }
        }

        /// <summary>
        /// Click on quit button :
        /// 
        /// Quit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuit_Click(object sender, EventArgs e)
        {
            //Ask the user if he is sure to quit the game
            if (MessageBox.Show("Vous êtes sûr de vouloir quitter le jeu ?", "Quitter le jeu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                Close();
        }

        /// <summary>
        /// Click on the options button :
        /// 
        /// Open the form option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOptions_Click(object sender, EventArgs e)
        {
            frmOptions frmOptions = new frmOptions();
            frmOptions.ShowDialog();
        }
        #endregion

        #region graphic events
        //There is not a doxagen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image

        private void cmdNewGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdNewGame.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
            }
        }

        private void cmdNewGame_MouseLeave(object sender, EventArgs e)
        {
            cmdNewGame.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdLoad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdLoad.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
            }
        }

        private void cmdLoad_MouseLeave(object sender, EventArgs e)
        {
            cmdLoad.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdOptions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdOptions.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
            }
        }

        private void cmdOptions_MouseLeave(object sender, EventArgs e)
        {
            cmdOptions.BackgroundImage = Properties.Resources.Simple_Button;
        }

        private void cmdQuit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdQuit.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
            }
        }

        private void cmdQuit_MouseLeave(object sender, EventArgs e)
        {
            cmdQuit.BackgroundImage = Properties.Resources.Simple_Button;
        }
        #endregion
    }
}
