namespace Xarxaria
{
    partial class frmPlayer
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
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblForce = new System.Windows.Forms.Label();
            this.lblArmor = new System.Windows.Forms.Label();
            this.lblLuck = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.cmdPlayerContinue = new System.Windows.Forms.Button();
            this.lblAgility = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(99, 9);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(75, 13);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "NomDuJoueur";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(50, 93);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(68, 13);
            this.lblHealth.TabIndex = 1;
            this.lblHealth.Text = "Points de vie";
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.Location = new System.Drawing.Point(50, 106);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(34, 13);
            this.lblForce.TabIndex = 2;
            this.lblForce.Text = "Force";
            // 
            // lblArmor
            // 
            this.lblArmor.AutoSize = true;
            this.lblArmor.Location = new System.Drawing.Point(50, 134);
            this.lblArmor.Name = "lblArmor";
            this.lblArmor.Size = new System.Drawing.Size(40, 13);
            this.lblArmor.TabIndex = 3;
            this.lblArmor.Text = "Armure";
            // 
            // lblLuck
            // 
            this.lblLuck.AutoSize = true;
            this.lblLuck.Location = new System.Drawing.Point(50, 148);
            this.lblLuck.Name = "lblLuck";
            this.lblLuck.Size = new System.Drawing.Size(44, 13);
            this.lblLuck.TabIndex = 4;
            this.lblLuck.Text = "Chance";
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(42, 174);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(190, 199);
            this.lstItems.TabIndex = 2;
            // 
            // cmdPlayerContinue
            // 
            this.cmdPlayerContinue.Location = new System.Drawing.Point(81, 37);
            this.cmdPlayerContinue.Name = "cmdPlayerContinue";
            this.cmdPlayerContinue.Size = new System.Drawing.Size(106, 34);
            this.cmdPlayerContinue.TabIndex = 1;
            this.cmdPlayerContinue.Text = "Continuer";
            this.cmdPlayerContinue.UseVisualStyleBackColor = true;
            this.cmdPlayerContinue.Click += new System.EventHandler(this.cmdPlayerContinue_Click);
            // 
            // lblAgility
            // 
            this.lblAgility.AutoSize = true;
            this.lblAgility.Location = new System.Drawing.Point(50, 120);
            this.lblAgility.Name = "lblAgility";
            this.lblAgility.Size = new System.Drawing.Size(35, 13);
            this.lblAgility.TabIndex = 5;
            this.lblAgility.Text = "Agilité";
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 385);
            this.Controls.Add(this.lblAgility);
            this.Controls.Add(this.cmdPlayerContinue);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.lblLuck);
            this.Controls.Add(this.lblArmor);
            this.Controls.Add(this.lblForce);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblPlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPlayer";
            this.Text = "Xarxaria v1.0 - NomDuJoueur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.Label lblArmor;
        private System.Windows.Forms.Label lblLuck;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button cmdPlayerContinue;
        private System.Windows.Forms.Label lblAgility;
    }
}