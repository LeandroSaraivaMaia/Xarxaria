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
            //Quit the game
            this.Close();
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
    }
}
