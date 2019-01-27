/**
* \file      Program.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      November 11. 2018
* \brief     Main entry of the program.
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
        static WMPLib.WindowsMediaPlayer fightMusic;
        #endregion

        #region public static attributes
        public static int musicsVolume = 100; //0 to 100
        public static int effectsVolume = 100; //0 to 100
        public static HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
        public static float textZoom = 1.4f;
        public enum actionId { pageChange, changeItem, changePlayerHp, setPlayerForce, changePlayerArmor, changePlayerAgility, changePlayerLuck, displayMessage, enemyFight, changePlayerForce };
        public enum musicId { ambiance, battle, boss, drake };
        public static ConnectionDB connection;
        #endregion

        #region public methods
        /// <summary>
        /// Set the volume of the musics.
        /// </summary>
        /// <param name="volumeValue"></param>
        public static void SetMusicsVolume(int volumeValue)
        {
            //Store the musics volume value
            musicsVolume = volumeValue;

            ambianceMusic.settings.volume = volumeValue;
            if (fightMusic != null) fightMusic.settings.volume = volumeValue;
        }

        /// <summary>
        /// Set the volume of the effects.
        /// </summary>
        /// <param name="volumeValue"></param>
        public static void SetEffectsVolume(int volumeValue)
        {
            //Store the effects volume value
            effectsVolume = volumeValue;

            clickSound.settings.volume = volumeValue;
            hoverSound.settings.volume = volumeValue;
        }

        /// <summary>
        /// Change the music by stopping the old music and playing a new music.
        /// 
        /// The ambiance music is never stopped. instead it is juste muted.
        /// This makes it possible not to have the ambiance music replay after every fight.
        /// </summary>
        /// <param name="id"></param>
        public static void changeMusic(musicId id)
        {
            //Mute all current music
            if (fightMusic != null) fightMusic.settings.mute = true;
            ambianceMusic.settings.mute = true;

            //Play the choosen music or unmute it
            switch (id)
            {
                case musicId.ambiance:
                    //Unmute ambiance music and mute fight music
                    ambianceMusic.settings.mute = false;
                    if (fightMusic != null) fightMusic.settings.mute = true;
                    break;
                case musicId.battle:
                    fightMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Small_battle.mp3" };
                    fightMusic.settings.setMode("loop", true);
                    fightMusic.settings.mute = false;
                    break;
                case musicId.boss:
                    fightMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Boss_battle.mp3" };
                    fightMusic.settings.setMode("loop", true);
                    fightMusic.settings.mute = false;
                    break;
                case musicId.drake:
                    fightMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Drake_battle.mp3" };
                    fightMusic.settings.setMode("loop", true);
                    fightMusic.settings.mute = false;
                    break;
                default: throw new Exception("Unknow musicId");
            }
        }

        /// <summary>
        /// Show a message with a specific form.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void showMessage(string message, string title)
        {
            frmMessageBox messageForm = new frmMessageBox(message, title);

            messageForm.ShowDialog();
        }

        /// <summary>
        /// Play the hover sound when the mouse goes on a button.
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
        /// Play the click sound when the user click on a button.
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

        #region infinite loop
        /// <summary>
        /// Every second :
        /// 
        /// Check if the music is looping.
        /// </summary>
        static async void infiniteLoop()
        {
            while (true)
            {
                await Task.Delay(1000);
                try
                {
                    //The ambiance music stops (the music goes back to position 0 when finished to play)
                    if (ambianceMusic.controls.currentPosition == 0)
                    {
                        //Replay ambiance music
                        ambianceMusic.controls.stop();
                        ambianceMusic.controls.play();
                    }

                    //There is a fight music
                    if (fightMusic != null)
                        //The fight music stops (the music goes back to position 0 when finished to play)
                        if (fightMusic.controls.currentPosition == 0)
                        {
                            //Replay fight music
                            fightMusic.controls.stop();
                            fightMusic.controls.play();
                        }
                }
                catch
                {
                    Console.WriteLine("Unknown exception for looping the sound (Program.cs => infiniteLoop())");
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
            //Define ambiance music
            ambianceMusic = new WMPLib.WindowsMediaPlayer { URL = Environment.CurrentDirectory + @"\assets\musics\Ambiance.mp3" };

            //Check if the music is stopped every seconds
            infiniteLoop();

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