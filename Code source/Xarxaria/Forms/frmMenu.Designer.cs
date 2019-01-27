namespace Xarxaria
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.lblMenu = new System.Windows.Forms.Label();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdOptions = new System.Windows.Forms.Button();
            this.cmdGoToStartScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMenu
            // 
            this.lblMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblMenu.Location = new System.Drawing.Point(12, 9);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(226, 25);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Menu";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdContinue
            // 
            this.cmdContinue.BackColor = System.Drawing.Color.Transparent;
            this.cmdContinue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdContinue.BackgroundImage")));
            this.cmdContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdContinue.FlatAppearance.BorderSize = 0;
            this.cmdContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdContinue.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdContinue.ForeColor = System.Drawing.Color.Gold;
            this.cmdContinue.Location = new System.Drawing.Point(46, 37);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(165, 46);
            this.cmdContinue.TabIndex = 1;
            this.cmdContinue.Text = "Continuer";
            this.cmdContinue.UseVisualStyleBackColor = false;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            this.cmdContinue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdContinue_MouseDown);
            this.cmdContinue.MouseLeave += new System.EventHandler(this.cmdContinue_MouseLeave);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSave.BackgroundImage")));
            this.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdSave.FlatAppearance.BorderSize = 0;
            this.cmdSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdSave.ForeColor = System.Drawing.Color.Gold;
            this.cmdSave.Location = new System.Drawing.Point(46, 89);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(165, 46);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Sauvegarder";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            this.cmdSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdSave_MouseDown);
            this.cmdSave.MouseLeave += new System.EventHandler(this.cmdSave_MouseLeave);
            // 
            // cmdOptions
            // 
            this.cmdOptions.BackColor = System.Drawing.Color.Transparent;
            this.cmdOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdOptions.BackgroundImage")));
            this.cmdOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdOptions.FlatAppearance.BorderSize = 0;
            this.cmdOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOptions.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdOptions.ForeColor = System.Drawing.Color.Gold;
            this.cmdOptions.Location = new System.Drawing.Point(46, 141);
            this.cmdOptions.Name = "cmdOptions";
            this.cmdOptions.Size = new System.Drawing.Size(165, 46);
            this.cmdOptions.TabIndex = 3;
            this.cmdOptions.Text = "Options";
            this.cmdOptions.UseVisualStyleBackColor = false;
            this.cmdOptions.Click += new System.EventHandler(this.cmdOptions_Click);
            this.cmdOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdOptions_MouseDown);
            this.cmdOptions.MouseLeave += new System.EventHandler(this.cmdOptions_MouseLeave);
            // 
            // cmdGoToStartScreen
            // 
            this.cmdGoToStartScreen.BackColor = System.Drawing.Color.Transparent;
            this.cmdGoToStartScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdGoToStartScreen.BackgroundImage")));
            this.cmdGoToStartScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdGoToStartScreen.FlatAppearance.BorderSize = 0;
            this.cmdGoToStartScreen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdGoToStartScreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdGoToStartScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGoToStartScreen.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdGoToStartScreen.ForeColor = System.Drawing.Color.Gold;
            this.cmdGoToStartScreen.Location = new System.Drawing.Point(46, 193);
            this.cmdGoToStartScreen.Name = "cmdGoToStartScreen";
            this.cmdGoToStartScreen.Size = new System.Drawing.Size(165, 46);
            this.cmdGoToStartScreen.TabIndex = 4;
            this.cmdGoToStartScreen.Text = "Retour à l\'écran titre";
            this.cmdGoToStartScreen.UseVisualStyleBackColor = false;
            this.cmdGoToStartScreen.Click += new System.EventHandler(this.cmdGoToStartScreen_Click);
            this.cmdGoToStartScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdGoToStartScreen_MouseDown);
            this.cmdGoToStartScreen.MouseLeave += new System.EventHandler(this.cmdGoToStartScreen_MouseLeave);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.frmMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(250, 251);
            this.Controls.Add(this.cmdGoToStartScreen);
            this.Controls.Add(this.cmdOptions);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.lblMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.Text = "Xarxaria v2.0 - Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdOptions;
        private System.Windows.Forms.Button cmdGoToStartScreen;
    }
}