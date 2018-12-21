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
            catch (Exception e)
            {
                Console.WriteLine("Problem to play hover sound, exception message :\n" + e.Message);
            }
            
        }

        public static void playClickSound()
        {
            try
            {
                clickSound.controls.stop();
                clickSound.controls.play();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem to play click sound, exception message :\n" + e.Message);
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
            Console.WriteLine(Environment.CurrentDirectory + @"assets\sounds\selection1_short.wav");

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