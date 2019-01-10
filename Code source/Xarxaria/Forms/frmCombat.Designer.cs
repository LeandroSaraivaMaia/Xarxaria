namespace Xarxaria
{
    partial class frmCombat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCombat));
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblPlayerHealth = new System.Windows.Forms.Label();
            this.lblPlayerForce = new System.Windows.Forms.Label();
            this.lblPlayerArmor = new System.Windows.Forms.Label();
            this.lblEnemy = new System.Windows.Forms.Label();
            this.lblEnemyHealth = new System.Windows.Forms.Label();
            this.lblEnemyForce = new System.Windows.Forms.Label();
            this.lblEnemyArmor = new System.Windows.Forms.Label();
            this.lblPlayerAgility = new System.Windows.Forms.Label();
            this.lblPlayerLuck = new System.Windows.Forms.Label();
            this.lblEnemyAgility = new System.Windows.Forms.Label();
            this.lblEnemyLuck = new System.Windows.Forms.Label();
            this.cmdNextTurn = new System.Windows.Forms.Button();
            this.picEnemy = new System.Windows.Forms.PictureBox();
            this.richTextBoxExtension1 = new Xarxaria.RichTextBoxExtension();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayer
            // 
            this.lblPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPlayer.Location = new System.Drawing.Point(41, 276);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(167, 51);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "Vous";
            this.lblPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerHealth
            // 
            this.lblPlayerHealth.AutoSize = true;
            this.lblPlayerHealth.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerHealth.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPlayerHealth.Location = new System.Drawing.Point(68, 327);
            this.lblPlayerHealth.Name = "lblPlayerHealth";
            this.lblPlayerHealth.Size = new System.Drawing.Size(58, 16);
            this.lblPlayerHealth.TabIndex = 0;
            this.lblPlayerHealth.Text = "PV : XX";
            // 
            // lblPlayerForce
            // 
            this.lblPlayerForce.AutoSize = true;
            this.lblPlayerForce.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerForce.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPlayerForce.Location = new System.Drawing.Point(68, 352);
            this.lblPlayerForce.Name = "lblPlayerForce";
            this.lblPlayerForce.Size = new System.Drawing.Size(85, 16);
            this.lblPlayerForce.TabIndex = 0;
            this.lblPlayerForce.Text = "Force : XX";
            // 
            // lblPlayerArmor
            // 
            this.lblPlayerArmor.AutoSize = true;
            this.lblPlayerArmor.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerArmor.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPlayerArmor.Location = new System.Drawing.Point(68, 378);
            this.lblPlayerArmor.Name = "lblPlayerArmor";
            this.lblPlayerArmor.Size = new System.Drawing.Size(100, 16);
            this.lblPlayerArmor.TabIndex = 0;
            this.lblPlayerArmor.Text = "Armure : XX";
            // 
            // lblEnemy
            // 
            this.lblEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnemy.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemy.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblEnemy.Location = new System.Drawing.Point(239, 276);
            this.lblEnemy.Name = "lblEnemy";
            this.lblEnemy.Size = new System.Drawing.Size(114, 51);
            this.lblEnemy.TabIndex = 0;
            this.lblEnemy.Text = "Ennemi";
            this.lblEnemy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnemyHealth
            // 
            this.lblEnemyHealth.AutoSize = true;
            this.lblEnemyHealth.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyHealth.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblEnemyHealth.Location = new System.Drawing.Point(247, 327);
            this.lblEnemyHealth.Name = "lblEnemyHealth";
            this.lblEnemyHealth.Size = new System.Drawing.Size(58, 16);
            this.lblEnemyHealth.TabIndex = 0;
            this.lblEnemyHealth.Text = "PV : XX";
            // 
            // lblEnemyForce
            // 
            this.lblEnemyForce.AutoSize = true;
            this.lblEnemyForce.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyForce.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblEnemyForce.Location = new System.Drawing.Point(247, 352);
            this.lblEnemyForce.Name = "lblEnemyForce";
            this.lblEnemyForce.Size = new System.Drawing.Size(85, 16);
            this.lblEnemyForce.TabIndex = 0;
            this.lblEnemyForce.Text = "Force : XX";
            // 
            // lblEnemyArmor
            // 
            this.lblEnemyArmor.AutoSize = true;
            this.lblEnemyArmor.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyArmor.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblEnemyArmor.Location = new System.Drawing.Point(247, 378);
            this.lblEnemyArmor.Name = "lblEnemyArmor";
            this.lblEnemyArmor.Size = new System.Drawing.Size(100, 16);
            this.lblEnemyArmor.TabIndex = 0;
            this.lblEnemyArmor.Text = "Armure : XX";
            // 
            // lblPlayerAgility
            // 
            this.lblPlayerAgility.AutoSize = true;
            this.lblPlayerAgility.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerAgility.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPlayerAgility.Location = new System.Drawing.Point(68, 403);
            this.lblPlayerAgility.Name = "lblPlayerAgility";
            this.lblPlayerAgility.Size = new System.Drawing.Size(97, 16);
            this.lblPlayerAgility.TabIndex = 0;
            this.lblPlayerAgility.Text = "Agilité : XX";
            // 
            // lblPlayerLuck
            // 
            this.lblPlayerLuck.AutoSize = true;
            this.lblPlayerLuck.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerLuck.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPlayerLuck.Location = new System.Drawing.Point(68, 428);
            this.lblPlayerLuck.Name = "lblPlayerLuck";
            this.lblPlayerLuck.Size = new System.Drawing.Size(96, 16);
            this.lblPlayerLuck.TabIndex = 0;
            this.lblPlayerLuck.Text = "Chance : XX";
            // 
            // lblEnemyAgility
            // 
            this.lblEnemyAgility.AutoSize = true;
            this.lblEnemyAgility.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyAgility.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblEnemyAgility.Location = new System.Drawing.Point(247, 403);
            this.lblEnemyAgility.Name = "lblEnemyAgility";
            this.lblEnemyAgility.Size = new System.Drawing.Size(97, 16);
            this.lblEnemyAgility.TabIndex = 0;
            this.lblEnemyAgility.Text = "Agilité : XX";
            // 
            // lblEnemyLuck
            // 
            this.lblEnemyLuck.AutoSize = true;
            this.lblEnemyLuck.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemyLuck.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblEnemyLuck.Location = new System.Drawing.Point(247, 428);
            this.lblEnemyLuck.Name = "lblEnemyLuck";
            this.lblEnemyLuck.Size = new System.Drawing.Size(96, 16);
            this.lblEnemyLuck.TabIndex = 0;
            this.lblEnemyLuck.Text = "Chance : XX";
            // 
            // cmdNextTurn
            // 
            this.cmdNextTurn.BackColor = System.Drawing.Color.Transparent;
            this.cmdNextTurn.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdNextTurn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdNextTurn.FlatAppearance.BorderSize = 0;
            this.cmdNextTurn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdNextTurn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdNextTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNextTurn.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdNextTurn.ForeColor = System.Drawing.Color.Gold;
            this.cmdNextTurn.Location = new System.Drawing.Point(124, 448);
            this.cmdNextTurn.Name = "cmdNextTurn";
            this.cmdNextTurn.Size = new System.Drawing.Size(142, 45);
            this.cmdNextTurn.TabIndex = 1;
            this.cmdNextTurn.Text = "Prochain tour";
            this.cmdNextTurn.UseVisualStyleBackColor = false;
            this.cmdNextTurn.Click += new System.EventHandler(this.cmdNextTurn_Click);
            // 
            // picEnemy
            // 
            this.picEnemy.BackColor = System.Drawing.Color.AntiqueWhite;
            this.picEnemy.Location = new System.Drawing.Point(41, 17);
            this.picEnemy.Name = "picEnemy";
            this.picEnemy.Size = new System.Drawing.Size(312, 157);
            this.picEnemy.TabIndex = 0;
            this.picEnemy.TabStop = false;
            // 
            // richTextBoxExtension1
            // 
            this.richTextBoxExtension1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.richTextBoxExtension1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxExtension1.Location = new System.Drawing.Point(41, 180);
            this.richTextBoxExtension1.Name = "richTextBoxExtension1";
            this.richTextBoxExtension1.Size = new System.Drawing.Size(312, 93);
            this.richTextBoxExtension1.TabIndex = 2;
            this.richTextBoxExtension1.Text = "log de combat";
            this.richTextBoxExtension1.ZoomFactor = 1.3F;
            // 
            // frmCombat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.frmCombat;
            this.ClientSize = new System.Drawing.Size(397, 502);
            this.Controls.Add(this.richTextBoxExtension1);
            this.Controls.Add(this.lblEnemyLuck);
            this.Controls.Add(this.lblEnemyAgility);
            this.Controls.Add(this.lblPlayerLuck);
            this.Controls.Add(this.lblPlayerAgility);
            this.Controls.Add(this.cmdNextTurn);
            this.Controls.Add(this.lblEnemyArmor);
            this.Controls.Add(this.lblEnemyForce);
            this.Controls.Add(this.lblEnemyHealth);
            this.Controls.Add(this.lblEnemy);
            this.Controls.Add(this.lblPlayerArmor);
            this.Controls.Add(this.lblPlayerForce);
            this.Controls.Add(this.lblPlayerHealth);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.picEnemy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCombat";
            this.Text = "Xarxaria v1.0 - Combat";
            ((System.ComponentModel.ISupportInitialize)(this.picEnemy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picEnemy;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblPlayerHealth;
        private System.Windows.Forms.Label lblPlayerForce;
        private System.Windows.Forms.Label lblPlayerArmor;
        private System.Windows.Forms.Label lblEnemy;
        private System.Windows.Forms.Label lblEnemyHealth;
        private System.Windows.Forms.Label lblEnemyForce;
        private System.Windows.Forms.Label lblEnemyArmor;
        private System.Windows.Forms.Button cmdNextTurn;
        private System.Windows.Forms.Label lblPlayerAgility;
        private System.Windows.Forms.Label lblPlayerLuck;
        private System.Windows.Forms.Label lblEnemyAgility;
        private System.Windows.Forms.Label lblEnemyLuck;
        private RichTextBoxExtension richTextBoxExtension1;
    }
}