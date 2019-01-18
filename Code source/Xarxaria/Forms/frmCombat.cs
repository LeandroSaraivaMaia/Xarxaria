/**
* \file      frmCombat.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   1.0
* \date      December 13. 2018
* \brief     Combat form of the game
*
* \details   This form is opened when a combat is asked. It purpose is to enable the player to fight an enemy.
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
    public partial class frmCombat : Form
    {
        #region private attributes
        Bitmap loadedImage;
        Player player;
        Enemy enemy;
        int initStep; //0 = init finished; 1 = Welcome message; 2 = Agility test; 3 = Luck test; 4 = Random
        int delayBetweenMessages = 2500; //ms
        bool isPlayerTurn;
        bool doesPlayerWin;
        Color playerColorLog, enemyColorLog, infoColorLog;
        Random rnd;
        int damageGiven;
        int agilityEvadeChancePercentage = 5; //agilityEvadeChancePercentage * agility_score = %evade chance
        #endregion

        #region public accessors
        public Player GetPlayer { get { return player; } }
        public bool DoesPlayerWin { get { return doesPlayerWin; } }
        #endregion

        #region private accessor
        int DamageGiven { get { return damageGiven; }
            set {
                //If the given value is below 0, put it to 0
                if (value < 0) value = 0;

                damageGiven = value;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// The combat form constructor
        /// </summary>
        /// <param name="idEnemy"></param>
        public frmCombat(int playerId, int enemyId)
        {
            InitializeComponent();
            
            //Get player from database
            player = Program.connection.GetPlayerById(playerId);

            //Get player from database
            enemy = Program.connection.GetEnemyById(enemyId);

            //Disable next turn button (The program needs to define which charcater attacks first)
            cmdNextTurn.Enabled = false;

            //Initialize random
            rnd = new Random();

            //Set color log
            enemyColorLog = Color.DarkRed;
            playerColorLog = Color.DarkGreen;
            infoColorLog = Color.DarkBlue;

            //Update player and enemy labels with caracteristics
            RefreshDisplay();

            //Load enemy image
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = currentDirectory + @"\assets\images\ennemis\" + enemy.Image;
            try
            {
                loadedImage = new Bitmap(imagePath);
            }
            catch
            {
                throw new Exception("Image cannot be loaded, may be an access to an unexisting enemy");
            }
            picEnemy.Image = (Image)loadedImage;

            //Set the enemy as the winner of the fight (In case the user close the form, he looses)
            doesPlayerWin = false;

            //Wire mouse enter events for sound effect
            cmdNextTurn.MouseEnter += cmd_MouseEnter;

            //Wire mouse leave and mouse released event for this form.
            //This form has a button that doesn't redirect to another form, so we need to change the image when the mouse button is released.
            cmdNextTurn.MouseUp += cmd_ButtonImageBackToNormal;
            cmdNextTurn.MouseLeave += cmd_ButtonImageBackToNormal;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Adds text in the log rich text box
        /// </summary>
        /// <param name="text"></param>
        void AddLog(string text)
        {
            txtFightLog.AppendText(text);

            txtFightLog.ScrollToBottom();
        }

        /// <summary>
        /// Adds text in the log rich text box
        /// 
        /// This overload allows-us to change the color and to underline the added text
        /// </summary>
        /// <param name="text"></param>
        void AddLog(string text, Color color, bool isUnderline = false)
        {
            txtFightLog.AppendText(text, color, isUnderline);

            txtFightLog.ScrollToBottom();
        }

        /// <summary>
        /// The player try to attack the enemy (manages evade and damage given)
        /// </summary>
        void PlayerAttack()
        {
            //Test if the enemy avoid the attack
            int enemyEvadeChance = enemy.Agility * agilityEvadeChancePercentage;

            if (enemyEvadeChance >= rnd.Next(1, 100))
            {
                AddLog("\n\nL'ennemi a esquivé votre attaque.", enemyColorLog);
                return;
            }

            //Calculate damage given
            DamageGiven = player.Force - enemy.Armor;

            enemy.SetHp(- DamageGiven);

            AddLog("\n\nVous avez infligé " + DamageGiven + " points de dégâts à l'ennemi.", playerColorLog);
        }

        /// <summary>
        /// The enemy try to attack the player (manages evade and damage given)
        /// </summary>
        void EnemyAttack()
        {
            //Test if the player avoid the attack
            int playerEvadeChance = player.Agility * agilityEvadeChancePercentage;

            if (playerEvadeChance >= rnd.Next(1, 100))
            {
                AddLog("\n\nVous avez esquivé l'attaque de l'ennemi.", playerColorLog);
                return;
            }

            //Calculate damage given
            DamageGiven = enemy.Force - player.Armor;

            player.SetHp(- DamageGiven);

            AddLog("\n\nL'ennemi vous inflige " + DamageGiven + " points de dégâts.", enemyColorLog);
        }

        /// <summary>
        /// Update the values of the player and the enemy
        /// </summary>
        void RefreshDisplay()
        {
            lblPlayerName.Text = player.Name;
            lblPlayerHealth.Text = "HP : " + player.Hp.ToString();
            lblPlayerForce.Text = "Force : " + player.Force.ToString();
            lblPlayerArmor.Text = "Armure : " + player.Armor.ToString();
            lblPlayerAgility.Text = "Agilité : " + player.Agility.ToString();
            lblPlayerLuck.Text = "Chance : " + player.Luck.ToString();

            lblEnemyName.Text = enemy.Name;
            lblEnemyHealth.Text = "HP : " + enemy.Hp.ToString();
            lblEnemyForce.Text = "Force : " + enemy.Force.ToString();
            lblEnemyArmor.Text = "Armure : " + enemy.Armor.ToString();
            lblEnemyAgility.Text = "Agilité : " + enemy.Agility.ToString();
            lblEnemyLuck.Text = "Chance : " + enemy.Luck.ToString();
        }
        #endregion

        #region events
        /// <summary>
        /// Click on the help button :
        /// 
        /// Display informations about the fighting systems
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Un combat se déroule au tour par tour. Le personnage qui a le plus grand score d’agilité commence.\n" +
                "A chaque tour, un personnage attaque l’autre avec le calcul suivant : points attaque - points armures de l’ennemi = pv retiré.\n" +
                "Si les deux personnages ont les mêmes points d’agilité, le personnage avec le plus de points de chance commence.\n" +
                "Si les deux personnages ont le même score de chance, le personnage qui commence est choisi aléatoirement.", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Click on next turn button :
        /// 
        /// Play the next turn where the player and the enemy alternate attack turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNextTurn_Click(object sender, EventArgs e)
        {
            if (isPlayerTurn)
            {
                PlayerAttack();
            }
            else
            {
                EnemyAttack();
            }

            RefreshDisplay();

            //Test if the player is dead
            if (player.Hp <= 0)
            {
                //End the fight
                AddLog("\n\nVous avez été vaincu par l'ennemi \"" + enemy.Name + "\"", enemyColorLog, true);
                MessageBox.Show("Vous avez été vaincu par l'ennemi \"" + enemy.Name + "\"");
                doesPlayerWin = false;
                Close();
            }

            //Test if the enemy is dead
            if (enemy.Hp <= 0)
            {
                //End the fight
                AddLog("\n\nVous avez vaincu l'ennemi \"" + enemy.Name + "\"", playerColorLog, true);
                MessageBox.Show("Vous avez vaincu l'ennemi \"" + enemy.Name + "\"");
                doesPlayerWin = true;
                Close();
            }

            isPlayerTurn = !isPlayerTurn;
        }

        /// <summary>
        /// Event when with have any contact with the logs (Selection or click)
        /// 
        /// The active control is redirected to the player label,
        /// this avoid the logs to be selected and not looking good
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFightLog_Enter(object sender, EventArgs e)
        {
            ActiveControl = lblPlayerName;
        }

        /// <summary>
        /// The program test which character will attack first.
        /// 
        /// First test the agility, if the agility score is the same then
        /// test the chance and if the chance score is the same then
        /// choose a character randomly
        /// </summary>
        public async void DefineWhoAttackFirst()
        {
            void PlayerStartMessage()
            {
                AddLog("\n\nVous attaquez en premier.", playerColorLog);
            }

            void EnemyStartMessage()
            {
                AddLog("\n\nVotre ennemi \"" + enemy.Name + "\" attaque en premier.", enemyColorLog);
            }

            while (true)
            {
                await Task.Delay(delayBetweenMessages);
                switch (initStep)
                {
                    //Initialization finished
                    case 0: return;
                    
                    //Welcome message
                    case 1:
                        AddLog("\nLe personnage avec le plus "); AddLog("grand score d'agilité", infoColorLog, false); AddLog(" commence à attaquer.");
                        initStep++;
                        
                        break;
                    
                    //Agility test
                    case 2:
                        if (player.Agility > enemy.Agility)
                        {
                            PlayerStartMessage();
                            isPlayerTurn = true;
                            cmdNextTurn.Enabled = true;
                            initStep = 0;
                        }
                        else if (player.Agility < enemy.Agility)
                        {
                            EnemyStartMessage();
                            isPlayerTurn = false;
                            cmdNextTurn.Enabled = true;
                            initStep = 0;
                        }
                        else
                        {
                            AddLog("\n\nVous avez le "); AddLog("même score d'agilité", infoColorLog, false); AddLog(" que votre ennemi \"" + enemy.Name + "\" \n" +
                            "Le personnage avec le plus "); AddLog("grand score de chance", infoColorLog, false); AddLog(" commence à attaquer.");
                            initStep++;
                        }
                        break;
                    
                    //Luck test
                    case 3:
                        if (player.Luck > enemy.Luck)
                        {
                            PlayerStartMessage();
                            isPlayerTurn = true;
                            cmdNextTurn.Enabled = true;
                            initStep = 0;
                        }
                        else if (player.Luck < enemy.Luck)
                        {
                            EnemyStartMessage();
                            isPlayerTurn = false;
                            cmdNextTurn.Enabled = true;
                            initStep = 0;
                        }
                        else
                        {
                            AddLog("\n\nVous avez le "); AddLog("même score de chance", infoColorLog, false); AddLog(" que votre ennemi \"" + enemy.Name + "\" \n" +
                            "Le personnage qui attaque en premier sera "); AddLog("tiré au sort.", infoColorLog, false);
                            initStep++;
                        }
                        break;

                    //Random test
                    case 4:
                        if (rnd.Next(0, 2) == 0)
                        {
                            PlayerStartMessage();
                            isPlayerTurn = true;
                            initStep = 0;
                        }
                        else
                        {
                            EnemyStartMessage();
                            isPlayerTurn = false;
                            initStep = 0;
                        }

                        cmdNextTurn.Enabled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// The form load :
        /// 
        /// Initiate the combat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCombat_Load(object sender, EventArgs e)
        {
            AddLog("Vous êtes en combat contre \"" + enemy.Name + "\"\n", Color.Black, true);

            initStep = 1;

            DefineWhoAttackFirst();
        }
        #endregion

        #region graphic events
        //There is not a doxagen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image
        private void cmdNextTurn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdNextTurn.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        /// <summary>
        /// When the button is "unclicked" (mouse released) or the mouse leave the button :
        /// 
        /// Put the button "not clicked" image
        /// 
        /// This form has a button that doesn't redirect to another form, so we need to change the image when the mouse button is released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_ButtonImageBackToNormal(object sender, EventArgs e)
        {
            cmdNextTurn.BackgroundImage = Properties.Resources.Simple_Button;
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
