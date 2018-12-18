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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayer));
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
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPlayerName.Location = new System.Drawing.Point(89, 9);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(109, 16);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "NomDuJoueur";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.BackColor = System.Drawing.Color.Transparent;
            this.lblHealth.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblHealth.Location = new System.Drawing.Point(38, 93);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(106, 16);
            this.lblHealth.TabIndex = 0;
            this.lblHealth.Text = "Points de vie";
            // 
            // lblForce
            // 
            this.lblForce.AutoSize = true;
            this.lblForce.BackColor = System.Drawing.Color.Transparent;
            this.lblForce.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblForce.Location = new System.Drawing.Point(38, 106);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(53, 16);
            this.lblForce.TabIndex = 0;
            this.lblForce.Text = "Force";
            // 
            // lblArmor
            // 
            this.lblArmor.AutoSize = true;
            this.lblArmor.BackColor = System.Drawing.Color.Transparent;
            this.lblArmor.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblArmor.Location = new System.Drawing.Point(38, 134);
            this.lblArmor.Name = "lblArmor";
            this.lblArmor.Size = new System.Drawing.Size(68, 16);
            this.lblArmor.TabIndex = 0;
            this.lblArmor.Text = "Armure";
            // 
            // lblLuck
            // 
            this.lblLuck.AutoSize = true;
            this.lblLuck.BackColor = System.Drawing.Color.Transparent;
            this.lblLuck.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblLuck.Location = new System.Drawing.Point(38, 148);
            this.lblLuck.Name = "lblLuck";
            this.lblLuck.Size = new System.Drawing.Size(64, 16);
            this.lblLuck.TabIndex = 0;
            this.lblLuck.Text = "Chance";
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstItems.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 16;
            this.lstItems.Location = new System.Drawing.Point(42, 174);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(190, 192);
            this.lstItems.TabIndex = 2;
            // 
            // cmdPlayerContinue
            // 
            this.cmdPlayerContinue.BackColor = System.Drawing.Color.Transparent;
            this.cmdPlayerContinue.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdPlayerContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdPlayerContinue.FlatAppearance.BorderSize = 0;
            this.cmdPlayerContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdPlayerContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdPlayerContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPlayerContinue.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdPlayerContinue.ForeColor = System.Drawing.Color.Gold;
            this.cmdPlayerContinue.Location = new System.Drawing.Point(81, 37);
            this.cmdPlayerContinue.Name = "cmdPlayerContinue";
            this.cmdPlayerContinue.Size = new System.Drawing.Size(117, 42);
            this.cmdPlayerContinue.TabIndex = 1;
            this.cmdPlayerContinue.Text = "Continuer";
            this.cmdPlayerContinue.UseVisualStyleBackColor = false;
            this.cmdPlayerContinue.Click += new System.EventHandler(this.cmdPlayerContinue_Click);
            this.cmdPlayerContinue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdPlayerContinue_MouseDown);
            this.cmdPlayerContinue.MouseLeave += new System.EventHandler(this.cmdPlayerContinue_MouseLeave);
            // 
            // lblAgility
            // 
            this.lblAgility.AutoSize = true;
            this.lblAgility.BackColor = System.Drawing.Color.Transparent;
            this.lblAgility.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblAgility.Location = new System.Drawing.Point(38, 120);
            this.lblAgility.Name = "lblAgility";
            this.lblAgility.Size = new System.Drawing.Size(65, 16);
            this.lblAgility.TabIndex = 0;
            this.lblAgility.Text = "Agilité";
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.Inventaire;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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