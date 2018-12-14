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
            this.lstSaveFile = new System.Windows.Forms.ListBox();
            this.cmdChooseSave = new System.Windows.Forms.Button();
            this.lblChooseSave = new System.Windows.Forms.Label();
            this.cmdGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSaveFile
            // 
            this.lstSaveFile.FormattingEnabled = true;
            this.lstSaveFile.Location = new System.Drawing.Point(30, 54);
            this.lstSaveFile.Name = "lstSaveFile";
            this.lstSaveFile.Size = new System.Drawing.Size(252, 147);
            this.lstSaveFile.TabIndex = 1;
            this.lstSaveFile.SelectedIndexChanged += new System.EventHandler(this.lstSaveFile_SelectedIndexChanged);
            // 
            // cmdChooseSave
            // 
            this.cmdChooseSave.Location = new System.Drawing.Point(117, 207);
            this.cmdChooseSave.Name = "cmdChooseSave";
            this.cmdChooseSave.Size = new System.Drawing.Size(165, 33);
            this.cmdChooseSave.TabIndex = 3;
            this.cmdChooseSave.Text = "Sélectionner cette sauvegarde";
            this.cmdChooseSave.UseVisualStyleBackColor = true;
            this.cmdChooseSave.Click += new System.EventHandler(this.cmdChooseSave_Click);
            // 
            // lblChooseSave
            // 
            this.lblChooseSave.AutoSize = true;
            this.lblChooseSave.Location = new System.Drawing.Point(27, 22);
            this.lblChooseSave.Name = "lblChooseSave";
            this.lblChooseSave.Size = new System.Drawing.Size(136, 13);
            this.lblChooseSave.TabIndex = 0;
            this.lblChooseSave.Text = "Choissisez une sauvegarde";
            // 
            // cmdGoBack
            // 
            this.cmdGoBack.Location = new System.Drawing.Point(30, 207);
            this.cmdGoBack.Name = "cmdGoBack";
            this.cmdGoBack.Size = new System.Drawing.Size(81, 33);
            this.cmdGoBack.TabIndex = 2;
            this.cmdGoBack.Text = "Retour";
            this.cmdGoBack.UseVisualStyleBackColor = true;
            this.cmdGoBack.Click += new System.EventHandler(this.cmdGoBack_Click);
            // 
            // frmLoadPlayerSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 252);
            this.Controls.Add(this.cmdGoBack);
            this.Controls.Add(this.lblChooseSave);
            this.Controls.Add(this.cmdChooseSave);
            this.Controls.Add(this.lstSaveFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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