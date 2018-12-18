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
            this.picEnemy = new System.Windows.Forms.PictureBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblPlayerHealth = new System.Windows.Forms.Label();
            this.lblPlayerForce = new System.Windows.Forms.Label();
            this.lblPlayerArmor = new System.Windows.Forms.Label();
            this.lblEnemy = new System.Windows.Forms.Label();
            this.lblEnemyHealth = new System.Windows.Forms.Label();
            this.lblEnemyForce = new System.Windows.Forms.Label();
            this.lblEnemyArmor = new System.Windows.Forms.Label();
            this.cmdNextTurn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemy)).BeginInit();
            this.SuspendLayout();
            // 
            // picEnemy
            // 
            this.picEnemy.Location = new System.Drawing.Point(41, 24);
            this.picEnemy.Name = "picEnemy";
            this.picEnemy.Size = new System.Drawing.Size(312, 157);
            this.picEnemy.TabIndex = 0;
            this.picEnemy.TabStop = false;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(77, 234);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(31, 13);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "Vous";
            // 
            // lblPlayerHealth
            // 
            this.lblPlayerHealth.AutoSize = true;
            this.lblPlayerHealth.Location = new System.Drawing.Point(77, 261);
            this.lblPlayerHealth.Name = "lblPlayerHealth";
            this.lblPlayerHealth.Size = new System.Drawing.Size(44, 13);
            this.lblPlayerHealth.TabIndex = 0;
            this.lblPlayerHealth.Text = "PV : XX";
            // 
            // lblPlayerForce
            // 
            this.lblPlayerForce.AutoSize = true;
            this.lblPlayerForce.Location = new System.Drawing.Point(77, 288);
            this.lblPlayerForce.Name = "lblPlayerForce";
            this.lblPlayerForce.Size = new System.Drawing.Size(57, 13);
            this.lblPlayerForce.TabIndex = 0;
            this.lblPlayerForce.Text = "Force : XX";
            // 
            // lblPlayerArmor
            // 
            this.lblPlayerArmor.AutoSize = true;
            this.lblPlayerArmor.Location = new System.Drawing.Point(77, 315);
            this.lblPlayerArmor.Name = "lblPlayerArmor";
            this.lblPlayerArmor.Size = new System.Drawing.Size(63, 13);
            this.lblPlayerArmor.TabIndex = 0;
            this.lblPlayerArmor.Text = "Armure : XX";
            // 
            // lblEnemy
            // 
            this.lblEnemy.AutoSize = true;
            this.lblEnemy.Location = new System.Drawing.Point(250, 234);
            this.lblEnemy.Name = "lblEnemy";
            this.lblEnemy.Size = new System.Drawing.Size(42, 13);
            this.lblEnemy.TabIndex = 0;
            this.lblEnemy.Text = "Ennemi";
            // 
            // lblEnemyHealth
            // 
            this.lblEnemyHealth.AutoSize = true;
            this.lblEnemyHealth.Location = new System.Drawing.Point(250, 261);
            this.lblEnemyHealth.Name = "lblEnemyHealth";
            this.lblEnemyHealth.Size = new System.Drawing.Size(44, 13);
            this.lblEnemyHealth.TabIndex = 0;
            this.lblEnemyHealth.Text = "PV : XX";
            // 
            // lblEnemyForce
            // 
            this.lblEnemyForce.AutoSize = true;
            this.lblEnemyForce.Location = new System.Drawing.Point(250, 288);
            this.lblEnemyForce.Name = "lblEnemyForce";
            this.lblEnemyForce.Size = new System.Drawing.Size(57, 13);
            this.lblEnemyForce.TabIndex = 0;
            this.lblEnemyForce.Text = "Force : XX";
            // 
            // lblEnemyArmor
            // 
            this.lblEnemyArmor.AutoSize = true;
            this.lblEnemyArmor.Location = new System.Drawing.Point(250, 315);
            this.lblEnemyArmor.Name = "lblEnemyArmor";
            this.lblEnemyArmor.Size = new System.Drawing.Size(63, 13);
            this.lblEnemyArmor.TabIndex = 0;
            this.lblEnemyArmor.Text = "Armure : XX";
            // 
            // cmdNextTurn
            // 
            this.cmdNextTurn.Location = new System.Drawing.Point(146, 362);
            this.cmdNextTurn.Name = "cmdNextTurn";
            this.cmdNextTurn.Size = new System.Drawing.Size(102, 35);
            this.cmdNextTurn.TabIndex = 1;
            this.cmdNextTurn.Text = "Prochain tour";
            this.cmdNextTurn.UseVisualStyleBackColor = true;
            // 
            // frmCombat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 410);
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
    }
}