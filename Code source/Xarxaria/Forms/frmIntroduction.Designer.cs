namespace Xarxaria
{
    partial class frmIntroduction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntroduction));
            this.lblIntroduction = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblForce = new System.Windows.Forms.Label();
            this.lblArmor = new System.Windows.Forms.Label();
            this.lblAgility = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmdStartAventure = new System.Windows.Forms.Button();
            this.numHealth = new System.Windows.Forms.NumericUpDown();
            this.numForce = new System.Windows.Forms.NumericUpDown();
            this.numArmor = new System.Windows.Forms.NumericUpDown();
            this.numLuck = new System.Windows.Forms.NumericUpDown();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.numAgility = new System.Windows.Forms.NumericUpDown();
            this.lblLuck = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArmor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgility)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntroduction
            // 
            this.lblIntroduction.AutoSize = true;
            this.lblIntroduction.Location = new System.Drawing.Point(104, 20);
            this.lblIntroduction.Name = "lblIntroduction";
            this.lblIntroduction.Size = new System.Drawing.Size(63, 13);
            this.lblIntroduction.TabIndex = 0;
            this.lblIntroduction.Text = "Introduction";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(40, 229);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(76, 13);
            this.lblPlayerName.TabIndex = 1;
            this.lblPlayerName.Text = "Nom du joueur";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(40, 252);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(68, 13);
            this.lblHealth.TabIndex = 2;
            this.lblHealth.Text = "Points de vie";
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Location = new System.Drawing.Point(40, 276);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(34, 13);
            this.lblForce.TabIndex = 3;
            this.lblForce.Text = "Force";
            // 
            // lblArmor
            // 
            this.lblArmor.AutoSize = true;
            this.lblArmor.Location = new System.Drawing.Point(40, 300);
            this.lblArmor.Name = "lblArmor";
            this.lblArmor.Size = new System.Drawing.Size(40, 13);
            this.lblArmor.TabIndex = 4;
            this.lblArmor.Text = "Armure";
            // 
            // lblAgility
            // 
            this.lblAgility.AutoSize = true;
            this.lblAgility.Location = new System.Drawing.Point(40, 324);
            this.lblAgility.Name = "lblAgility";
            this.lblAgility.Size = new System.Drawing.Size(35, 13);
            this.lblAgility.TabIndex = 5;
            this.lblAgility.Text = "Agilité";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(245, 159);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // cmdStartAventure
            // 
            this.cmdStartAventure.Location = new System.Drawing.Point(43, 386);
            this.cmdStartAventure.Name = "cmdStartAventure";
            this.cmdStartAventure.Size = new System.Drawing.Size(170, 37);
            this.cmdStartAventure.TabIndex = 7;
            this.cmdStartAventure.Text = "Commencer l\'aventure";
            this.cmdStartAventure.UseVisualStyleBackColor = true;
            // 
            // numHealth
            // 
            this.numHealth.Location = new System.Drawing.Point(118, 250);
            this.numHealth.Name = "numHealth";
            this.numHealth.Size = new System.Drawing.Size(37, 20);
            this.numHealth.TabIndex = 8;
            // 
            // numForce
            // 
            this.numForce.Location = new System.Drawing.Point(118, 274);
            this.numForce.Name = "numForce";
            this.numForce.Size = new System.Drawing.Size(37, 20);
            this.numForce.TabIndex = 9;
            // 
            // numArmor
            // 
            this.numArmor.Location = new System.Drawing.Point(118, 298);
            this.numArmor.Name = "numArmor";
            this.numArmor.Size = new System.Drawing.Size(37, 20);
            this.numArmor.TabIndex = 10;
            // 
            // numLuck
            // 
            this.numLuck.Location = new System.Drawing.Point(118, 346);
            this.numLuck.Name = "numLuck";
            this.numLuck.Size = new System.Drawing.Size(37, 20);
            this.numLuck.TabIndex = 11;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(118, 226);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(100, 20);
            this.txtPlayerName.TabIndex = 12;
            this.txtPlayerName.Text = "Godfroyd";
            // 
            // numAgility
            // 
            this.numAgility.Location = new System.Drawing.Point(118, 322);
            this.numAgility.Name = "numAgility";
            this.numAgility.Size = new System.Drawing.Size(37, 20);
            this.numAgility.TabIndex = 13;
            // 
            // lblLuck
            // 
            this.lblLuck.AutoSize = true;
            this.lblLuck.Location = new System.Drawing.Point(40, 348);
            this.lblLuck.Name = "lblLuck";
            this.lblLuck.Size = new System.Drawing.Size(44, 13);
            this.lblLuck.TabIndex = 14;
            this.lblLuck.Text = "Chance";
            // 
            // frmIntroduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 435);
            this.Controls.Add(this.lblLuck);
            this.Controls.Add(this.numAgility);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.numLuck);
            this.Controls.Add(this.numArmor);
            this.Controls.Add(this.numForce);
            this.Controls.Add(this.numHealth);
            this.Controls.Add(this.cmdStartAventure);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblAgility);
            this.Controls.Add(this.lblArmor);
            this.Controls.Add(this.lblForce);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblIntroduction);
            this.Name = "frmIntroduction";
            this.Text = "Xarxaria v1.0 - Introduction";
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArmor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgility)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntroduction;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.Label lblArmor;
        private System.Windows.Forms.Label lblAgility;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button cmdStartAventure;
        private System.Windows.Forms.NumericUpDown numHealth;
        private System.Windows.Forms.NumericUpDown numForce;
        private System.Windows.Forms.NumericUpDown numArmor;
        private System.Windows.Forms.NumericUpDown numLuck;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.NumericUpDown numAgility;
        private System.Windows.Forms.Label lblLuck;
    }
}