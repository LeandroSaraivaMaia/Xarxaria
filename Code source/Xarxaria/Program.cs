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
        static WMPLib.WindowsMediaPlayer actualMusic;
        #endregion

        #region public static attributes
        public static int musicsVolume = 100;
        public static int effectsVolume = 100;
        public static HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
        public static float textZoom = 1.4f;
        public enum actionId { pageChange, changeItem, changePlayerHp, setPlayerForce, changePlayerArmor, changePlayerAgility, changePlayerLuck, displayMessage, enemyFight, changePlayerForce};
        public enum musicId { ambiance, battle, boss, drake};
        public static ConnectionDB connection;
        #endregion

        #region public methods
        /// <summary>
        /// Set the volume of the musics
        /// </summary>
        /// <param name="volumeValue"></param>
        public static void SetMusicsVolume(int volumeValue)
        {
            musicsVolume = volumeValue;

            ambianceMusic.settings.volume = volumeValue;
            if (actualMusic != null) actualMusic.settings.volume = volumeValue;
        }

        /// <summary>
        /// Set the volume of the effects
        /// </summary>
        /// <param name="volumeValue"></param>
        public static void SetEffectsVolume(int volumeValue)
        {
            effectsVolume = volumeValue;

            clickSound.settings.volume = volumeValue;
            hoverSound.settings.volume = volumeValue;
        }

        /// <summary>
        /// Change the music by stopping the old music and playing a new music
        /// </summary>
        /// <param name="id"></param>
        public static void changeMusic(musicId id)
        {
            if (actualMusic != null) actualMusic.settings.mute = true;
            ambianceMusic.settings.mute = true;

            //Play the choosen music
            switch (id)
            {
                case musicId.ambiance:
                    ambianceMusic.settings.mute = false;
                    ambianceMusic.settings.setMode("loop", true);
                    break;
                case musicId.battle:
                    actualMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Small_battle.mp3" };
                    actualMusic.settings.setMode("loop", true);
                    actualMusic.settings.mute = false;
                    break;
                case musicId.boss:
                    actualMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Boss_battle.mp3" };
                    actualMusic.settings.setMode("loop", true);
                    actualMusic.settings.mute = false;
                    break;
                case musicId.drake:
                    actualMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Drake_battle.mp3" };
                    actualMusic.settings.setMode("loop", true);
                    actualMusic.settings.mute = false;
                    break;
                default: throw new Exception("Unknow musicId");
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
            //Define ambiance music
            ambianceMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Ambiance.mp3" };
            ambianceMusic.settings.setMode("loop", true);

            //Define sounds
            hoverSound = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\sounds\hover.wav" };
            clickSound = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\sounds\click.wav" };

            //Stop the sounds so the audio doesn't directly play
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