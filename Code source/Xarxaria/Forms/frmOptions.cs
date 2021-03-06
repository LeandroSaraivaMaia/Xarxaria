﻿/**
* \file      frmOptions.cs
* \author    Johan Voland & Leandro Saraiva Maia
* \version   2.0
* \date      December 13. 2018
* \brief     Contains all the options of the game.
*
* \details   This form contains all the options of the game, like the font used, the font size.
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
    public partial class frmOptions : Form
    {
        #region private attributes
        float minimumFontSize = 0.7f;
        float maximumFontSize = 3f;
        #endregion

        #region constructor
        /// <summary>
        /// Options form constructor.
        /// </summary>
        public frmOptions()
        {
            InitializeComponent();

            //Set the text example alignement the actual alignement
            cmbTextAlign.SelectedIndex = (int)Program.horizontalAlignment;
            txtExample.SelectionAlignment = Program.horizontalAlignment;

            //Set the numerical zoom value to the actual zoom
            numPoliceZoom.Value = (decimal)Program.textZoom;
            txtExample.ZoomFactor = Program.textZoom;

            //Set volume bar
            barVolumeMusic.Value = Program.musicsVolume / 10;
            barVolumeEffect.Value = Program.effectsVolume / 10;

            //Wire mouse enter events for sound effect
            cmdContinue.MouseEnter += cmd_MouseEnter;
        }
        #endregion

        #region events
        /// <summary>
        /// The music volume value is changed :
        /// 
        /// Apply volume change to all musics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barVolumeMusic_Scroll(object sender, EventArgs e)
        {
            Program.SetMusicsVolume(barVolumeMusic.Value * 10);
        }

        /// <summary>
        /// The volume value is changed :
        /// 
        /// Apply sound volume change to all sounds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barVolumeEffect_Scroll(object sender, EventArgs e)
        {
            Program.SetEffectsVolume(barVolumeEffect.Value * 10);
        }

        /// <summary>
        /// Click on the continue button :
        /// 
        /// Close the form and go to the parent form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdContinue_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Numerical text zoom value changed :
        /// 
        /// Test if value is valid (limitedSize).
        /// Change the value in the main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numPoliceZoom_ValueChanged(object sender, EventArgs e)
        {
            if ((float)numPoliceZoom.Value < minimumFontSize)
            {
                numPoliceZoom.Value = (decimal)minimumFontSize;
                MessageBox.Show("La taille de la police ne peut pas être plus petite que " + minimumFontSize.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((float)numPoliceZoom.Value > maximumFontSize)
            {
                numPoliceZoom.Value = (decimal)maximumFontSize;
                MessageBox.Show("La taille de la police ne peut pas être plus grande que " + maximumFontSize.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Change the global value for text size
            Program.textZoom = (float)numPoliceZoom.Value;

            //Get all current open forms
            foreach (Form form in Application.OpenForms)
            {
                //If the iterated form is a frmMain form
                if (form.Name == "frmMain")
                {
                    //Cast the iterated form in frmMain object
                    frmMain mainForm = (frmMain)form;

                    //Change the text size
                    mainForm.ZoomFactor = (float)numPoliceZoom.Value;
                }
            }

            //Change the example value for the text size
            txtExample.ZoomFactor = (float)numPoliceZoom.Value;
            txtExample.oldZoomFactor = (float)numPoliceZoom.Value;
        }

        /// <summary>
        /// When the user interract with the txtExample control :
        /// 
        /// Set the active control to the options label.
        /// This avoid the control to be selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtExample_Enter(object sender, EventArgs e)
        {
            ActiveControl = lblOptions;
        }

        /// <summary>
        /// When the alignement method is changed :
        /// 
        /// Change the global alignement value and the example alignement value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTextAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change the global value for text alignement
            Program.horizontalAlignment = (HorizontalAlignment)cmbTextAlign.SelectedIndex;

            //Get the current assembly
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            //Get all current open forms
            foreach (Form form in Application.OpenForms)
            {
                //If the iterated form is a frmMain form
                if (form.Name == "frmMain")
                {
                    //Cast the iterated form in frmMain object
                    frmMain mainForm = (frmMain)form;

                    //Change the text size
                    mainForm.TextAlign = (HorizontalAlignment)cmbTextAlign.SelectedIndex;
                }
            }

            //Change the example value for the text alignement
            txtExample.SelectionAlignment = (HorizontalAlignment)cmbTextAlign.SelectedIndex;
        }
        #endregion

        #region graphic events
        //There is not a doxygen commentary for each events, these are really repetitive
        //When there is a left mouse click on a button, put the pressed image
        //When the mouse leave the button and the left mouse click is released, put the normal button image
        private void cmdContinue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cmdContinue.BackgroundImage = Properties.Resources.Simple_Button_Pressed;
                Program.playClickSound();
            }
        }

        private void cmdContinue_MouseLeave(object sender, EventArgs e)
        {
            cmdContinue.BackgroundImage = Properties.Resources.Simple_Button;
        }
        #endregion

        #region sound events
        /// <summary>
        /// The mouse enter in a button :
        /// 
        /// Play hover sound.
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
