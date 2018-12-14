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
            this.lblMenu = new System.Windows.Forms.Label();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdOptions = new System.Windows.Forms.Button();
            this.cmdGoToStartScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Location = new System.Drawing.Point(102, 9);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(34, 13);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Menu";
            // 
            // cmdContinue
            // 
            this.cmdContinue.Location = new System.Drawing.Point(59, 51);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(121, 34);
            this.cmdContinue.TabIndex = 1;
            this.cmdContinue.Text = "Continuer";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(59, 91);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(121, 34);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Sauvegarder";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdOptions
            // 
            this.cmdOptions.Location = new System.Drawing.Point(59, 131);
            this.cmdOptions.Name = "cmdOptions";
            this.cmdOptions.Size = new System.Drawing.Size(121, 34);
            this.cmdOptions.TabIndex = 3;
            this.cmdOptions.Text = "Options";
            this.cmdOptions.UseVisualStyleBackColor = true;
            this.cmdOptions.Click += new System.EventHandler(this.cmdOptions_Click);
            // 
            // cmdGoToStartScreen
            // 
            this.cmdGoToStartScreen.Location = new System.Drawing.Point(59, 171);
            this.cmdGoToStartScreen.Name = "cmdGoToStartScreen";
            this.cmdGoToStartScreen.Size = new System.Drawing.Size(121, 34);
            this.cmdGoToStartScreen.TabIndex = 4;
            this.cmdGoToStartScreen.Text = "Retour à l\'écran titre";
            this.cmdGoToStartScreen.UseVisualStyleBackColor = true;
            this.cmdGoToStartScreen.Click += new System.EventHandler(this.cmdGoToStartScreen_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 217);
            this.Controls.Add(this.cmdGoToStartScreen);
            this.Controls.Add(this.cmdOptions);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.lblMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMenu";
            this.Text = "Xarxaria v1.0 - Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdOptions;
        private System.Windows.Forms.Button cmdGoToStartScreen;
    }
}