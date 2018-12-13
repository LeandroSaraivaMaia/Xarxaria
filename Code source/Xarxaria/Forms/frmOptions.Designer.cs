namespace Xarxaria
{
    partial class frmOptions
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
            this.cmdContinue = new System.Windows.Forms.Button();
            this.lblPoliceSize = new System.Windows.Forms.Label();
            this.lblPoliceName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPoliceSize = new System.Windows.Forms.NumericUpDown();
            this.comboPoliceName = new System.Windows.Forms.ComboBox();
            this.lblOptions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPoliceSize)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdContinue
            // 
            this.cmdContinue.Location = new System.Drawing.Point(45, 42);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(122, 34);
            this.cmdContinue.TabIndex = 2;
            this.cmdContinue.Text = "Continuer";
            this.cmdContinue.UseVisualStyleBackColor = true;
            // 
            // lblPoliceSize
            // 
            this.lblPoliceSize.AutoSize = true;
            this.lblPoliceSize.Location = new System.Drawing.Point(15, 100);
            this.lblPoliceSize.Name = "lblPoliceSize";
            this.lblPoliceSize.Size = new System.Drawing.Size(73, 13);
            this.lblPoliceSize.TabIndex = 3;
            this.lblPoliceSize.Text = "Taille du texte";
            // 
            // lblPoliceName
            // 
            this.lblPoliceName.AutoSize = true;
            this.lblPoliceName.Location = new System.Drawing.Point(15, 129);
            this.lblPoliceName.Name = "lblPoliceName";
            this.lblPoliceName.Size = new System.Drawing.Size(82, 13);
            this.lblPoliceName.TabIndex = 4;
            this.lblPoliceName.Text = "Police d\'écriture";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // numPoliceSize
            // 
            this.numPoliceSize.Location = new System.Drawing.Point(103, 98);
            this.numPoliceSize.Name = "numPoliceSize";
            this.numPoliceSize.Size = new System.Drawing.Size(54, 20);
            this.numPoliceSize.TabIndex = 6;
            // 
            // comboPoliceName
            // 
            this.comboPoliceName.FormattingEnabled = true;
            this.comboPoliceName.Location = new System.Drawing.Point(103, 126);
            this.comboPoliceName.Name = "comboPoliceName";
            this.comboPoliceName.Size = new System.Drawing.Size(90, 21);
            this.comboPoliceName.TabIndex = 7;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(85, 9);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(43, 13);
            this.lblOptions.TabIndex = 8;
            this.lblOptions.Text = "Options";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 174);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.comboPoliceName);
            this.Controls.Add(this.numPoliceSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPoliceName);
            this.Controls.Add(this.lblPoliceSize);
            this.Controls.Add(this.cmdContinue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOptions";
            this.Text = "Xarxaria v1.0 - Options";
            ((System.ComponentModel.ISupportInitialize)(this.numPoliceSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Label lblPoliceSize;
        private System.Windows.Forms.Label lblPoliceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPoliceSize;
        private System.Windows.Forms.ComboBox comboPoliceName;
        private System.Windows.Forms.Label lblOptions;
    }
}