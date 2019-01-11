/**
* \file      Program.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      November 11. 2018
* \brief     Main entry of the program
*
* \details   This is the main entry of the program.
* It contains useful contstants like item's name and action id.
* 
* In a possible futur update the item's name may be stocked in the database
*/

#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Reflection;
#endregion

namespace Xarxaria
{
    static class Program
    {
        #region private static attributes
        static WMPLib.WindowsMediaPlayer hoverSound;
        static WMPLib.WindowsMediaPlayer clickSound;
        #endregion

        #region public static attributes
        public static HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
        public static float textZoom = 1.4f;
        public static string[] itemLists = {
            "goldenCoin", "glowingStone", "stoneLantern"
        };
        public enum actionId { pageChange, changeItem, changePlayerHp, setPlayerForce, changePlayerArmor, changePlayerAgility, changePlayerLuck};
        public static ConnectionDB connection;
        #endregion

        #region public methods
        public static void playHoverSound()
        {
            try
            {
                hoverSound.controls.stop();
                hoverSound.controls.play();

            }
            catch
            {
                Console.WriteLine("Unknown error to play hover sound");
            }
            
        }

        public static void playClickSound()
        {
            try
            {
                clickSound.controls.stop();
                clickSound.controls.play();
            }
            catch
            {
                Console.WriteLine("Unknown error to play click sound");
            }
        }

        public static void GameOver()
        {
            MessageBox.Show("La partie est terminée car vous êtes mort, retour à l'écran principale");

            //Open Start screen form
            frmStart startForm = new frmStart();

            //Create a new independant frmStart Thread
            void ThreadProc_frmStart()
            {
                Application.Run(new frmStart());
            }

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc_frmStart));

            t.Start();

            //Close all other form
            foreach (Form form in Application.OpenForms)
            {
                //If the iterated form is not the start form, close it
                if (form.Name != "frmStart")
                {
                    form.Close();
                }
            }
        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Define sounds
            hoverSound = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\sounds\selection1_short.wav" };
            clickSound = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\sounds\click1.wav" };

            //Necessary so the sound doesn't directly play
            hoverSound.controls.stop();
            clickSound.controls.stop();

            //Instanciate new connection
            connection = new ConnectionDB();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmStart());
        }
    }
}