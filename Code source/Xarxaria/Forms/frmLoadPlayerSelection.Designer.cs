namespace Xarxaria
{
    partial class frmLoadPlayerSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadPlayerSelection));
            this.lstSaveFile = new System.Windows.Forms.ListBox();
            this.cmdChooseSave = new System.Windows.Forms.Button();
            this.lblChooseSave = new System.Windows.Forms.Label();
            this.cmdGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSaveFile
            // 
            this.lstSaveFile.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lstSaveFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSaveFile.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lstSaveFile.FormattingEnabled = true;
            this.lstSaveFile.ItemHeight = 16;
            this.lstSaveFile.Location = new System.Drawing.Point(30, 54);
            this.lstSaveFile.Name = "lstSaveFile";
            this.lstSaveFile.Size = new System.Drawing.Size(252, 128);
            this.lstSaveFile.TabIndex = 1;
            this.lstSaveFile.SelectedIndexChanged += new System.EventHandler(this.lstSaveFile_SelectedIndexChanged);
            // 
            // cmdChooseSave
            // 
            this.cmdChooseSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdChooseSave.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdChooseSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdChooseSave.FlatAppearance.BorderSize = 0;
            this.cmdChooseSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdChooseSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdChooseSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdChooseSave.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdChooseSave.ForeColor = System.Drawing.Color.Gold;
            this.cmdChooseSave.Location = new System.Drawing.Point(141, 199);
            this.cmdChooseSave.Name = "cmdChooseSave";
            this.cmdChooseSave.Size = new System.Drawing.Size(165, 49);
            this.cmdChooseSave.TabIndex = 3;
            this.cmdChooseSave.Text = "Sélectionner cette sauvegarde";
            this.cmdChooseSave.UseVisualStyleBackColor = false;
            this.cmdChooseSave.Click += new System.EventHandler(this.cmdChooseSave_Click);
            this.cmdChooseSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdChooseSave_MouseDown);
            this.cmdChooseSave.MouseLeave += new System.EventHandler(this.cmdChooseSave_MouseLeave);
            // 
            // lblChooseSave
            // 
            this.lblChooseSave.AutoSize = true;
            this.lblChooseSave.BackColor = System.Drawing.Color.Transparent;
            this.lblChooseSave.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblChooseSave.Location = new System.Drawing.Point(27, 22);
            this.lblChooseSave.Name = "lblChooseSave";
            this.lblChooseSave.Size = new System.Drawing.Size(218, 16);
            this.lblChooseSave.TabIndex = 0;
            this.lblChooseSave.Text = "Choissisez une sauvegarde";
            // 
            // cmdGoBack
            // 
            this.cmdGoBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdGoBack.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdGoBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdGoBack.FlatAppearance.BorderSize = 0;
            this.cmdGoBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdGoBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGoBack.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdGoBack.ForeColor = System.Drawing.Color.Gold;
            this.cmdGoBack.Location = new System.Drawing.Point(12, 199);
            this.cmdGoBack.Name = "cmdGoBack";
            this.cmdGoBack.Size = new System.Drawing.Size(123, 49);
            this.cmdGoBack.TabIndex = 2;
            this.cmdGoBack.Text = "Retour";
            this.cmdGoBack.UseVisualStyleBackColor = false;
            this.cmdGoBack.Click += new System.EventHandler(this.cmdGoBack_Click);
            this.cmdGoBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdGoBack_MouseDown);
            this.cmdGoBack.MouseLeave += new System.EventHandler(this.cmdGoBack_MouseLeave);
            // 
            // frmLoadPlayerSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.Parchemin3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(318, 252);
            this.Controls.Add(this.cmdGoBack);
            this.Controls.Add(this.lblChooseSave);
            this.Controls.Add(this.cmdChooseSave);
            this.Controls.Add(this.lstSaveFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoadPlayerSelection";
            this.Text = "Xarxaria v1.0 - Choisir sauvegarde";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSaveFile;
        private System.Windows.Forms.Button cmdChooseSave;
        private System.Windows.Forms.Label lblChooseSave;
        private System.Windows.Forms.Button cmdGoBack;
    }
}