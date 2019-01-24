/**
* \file      Program.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      November 11. 2018
* \brief     Main entry of the program
*
* \details   This is the main entry of the program.
* It contains useful variable like action id and connection DB.
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
        static WMPLib.WindowsMediaPlayer ambianceMusic;
        static WMPLib.WindowsMediaPlayer battleMusic;
        static WMPLib.WindowsMediaPlayer bossMusic;
        static WMPLib.WindowsMediaPlayer drakeMusic;
        #endregion

        #region public static attributes
        public static int volume = 100;
        public static HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
        public static float textZoom = 1.4f;
        public enum actionId { pageChange, changeItem, changePlayerHp, setPlayerForce, changePlayerArmor, changePlayerAgility, changePlayerLuck, displayMessage, enemyFight};
        public enum musicId { ambiance, battle, boss, drake};
        public static ConnectionDB connection;
        #endregion

        #region public methods
        public static void SetVolume(int volumeValue)
        {
            volume = volumeValue;

            ambianceMusic.settings.volume = volumeValue;
            battleMusic.settings.volume = volumeValue;
            bossMusic.settings.volume = volumeValue;
            drakeMusic.settings.volume = volumeValue;
            clickSound.settings.volume = volumeValue;
            hoverSound.settings.volume = volumeValue;
        }


        /// <summary>
        /// Change the music by stopping the old music and playing a new music
        /// </summary>
        /// <param name="id"></param>
        public static void changeMusic(musicId id)
        {
            try
            {
                //Stop all music
                ambianceMusic.controls.stop();
                battleMusic.controls.stop();
                bossMusic.controls.stop();
                drakeMusic.controls.stop();

                //Play the choosen music
                switch (id)
                {
                    case musicId.ambiance:
                        ambianceMusic.controls.play();
                        break;
                    case musicId.battle:
                        battleMusic.controls.play();
                        break;
                    case musicId.boss:
                        bossMusic.controls.play();
                        break;
                    case musicId.drake:
                        drakeMusic.controls.play();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Unknown error to play music with id" + (int)id);
            }
        }

        /// <summary>
        /// Show a message with a specific form
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void showMessage(string message, string title)
        {
            frmMessageBox messageForm = new frmMessageBox(message, title);

            messageForm.ShowDialog();
        }

        /// <summary>
        /// Play the hover sound when the mous goes on a button
        /// </summary>
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

        /// <summary>
        /// Play the click sound when the mous goes on a button
        /// </summary>
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
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Define sounds
            hoverSound = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\sounds\hover.wav" };
            clickSound = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\sounds\click.wav" };

            //Define musics
            ambianceMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Ambiance.mp3" };
            battleMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Small_battle.mp3" };
            bossMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Boss_battle.mp3" };
            drakeMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Drake_battle.mp3" };

            //Set the music to loop
            ambianceMusic.settings.setMode("loop", true);
            battleMusic.settings.setMode("loop", true);
            bossMusic.settings.setMode("loop", true);
            drakeMusic.settings.setMode("loop", true);

            //Stop the sounds so the audio doesn't directly play
            hoverSound.controls.stop();
            clickSound.controls.stop();

            //Set the ambiance music
            changeMusic(musicId.ambiance);

            //Instanciate new connection
            connection = new ConnectionDB();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmStart());
        }
    }
}