namespace Xarxaria
{
    partial class frmMain
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
            this.cmdMenu = new System.Windows.Forms.Button();
            this.cmdPlayer = new System.Windows.Forms.Button();
            this.lblPageID = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picPage = new System.Windows.Forms.PictureBox();
            this.txtPage = new Xarxaria.RichTextBoxExtension();
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdMenu
            // 
            this.cmdMenu.Location = new System.Drawing.Point(411, 584);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(139, 36);
            this.cmdMenu.TabIndex = 7;
            this.cmdMenu.Text = "Menu";
            this.cmdMenu.UseVisualStyleBackColor = true;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            // 
            // cmdPlayer
            // 
            this.cmdPlayer.Location = new System.Drawing.Point(12, 584);
            this.cmdPlayer.Name = "cmdPlayer";
            this.cmdPlayer.Size = new System.Drawing.Size(139, 36);
            this.cmdPlayer.TabIndex = 5;
            this.cmdPlayer.Text = "Feuille de personnage";
            this.cmdPlayer.UseVisualStyleBackColor = true;
            this.cmdPlayer.Click += new System.EventHandler(this.cmdPlayer_Click);
            // 
            // lblPageID
            // 
            this.lblPageID.AutoSize = true;
            this.lblPageID.Location = new System.Drawing.Point(261, 593);
            this.lblPageID.Name = "lblPageID";
            this.lblPageID.Size = new System.Drawing.Size(69, 13);
            this.lblPageID.TabIndex = 9;
            this.lblPageID.Text = "Id de la page";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(249, 19);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(81, 13);
            this.lblPageTitle.TabIndex = 8;
            this.lblPageTitle.Text = "Titre de la page";
            // 
            // picPage
            // 
            this.picPage.Location = new System.Drawing.Point(12, 55);
            this.picPage.Name = "picPage";
            this.picPage.Size = new System.Drawing.Size(538, 234);
            this.picPage.TabIndex = 4;
            this.picPage.TabStop = false;
            // 
            // txtPage
            // 
            this.txtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPage.Location = new System.Drawing.Point(12, 295);
            this.txtPage.Name = "txtPage";
            this.txtPage.ReadOnly = true;
            this.txtPage.Size = new System.Drawing.Size(538, 272);
            this.txtPage.TabIndex = 0;
            this.txtPage.Text = "";
            this.txtPage.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtPage_LinkClicked);
            this.txtPage.Enter += new System.EventHandler(this.txtPage_Enter);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 632);
            this.Controls.Add(this.cmdMenu);
            this.Controls.Add(this.cmdPlayer);
            this.Controls.Add(this.lblPageID);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.picPage);
            this.Controls.Add(this.txtPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "Xarxaria v1.0 - Main";
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdMenu;
        private System.Windows.Forms.Button cmdPlayer;
        private System.Windows.Forms.Label lblPageID;
        private System.Windows.Forms.Label lblPageTitle;
        private RichTextBoxExtension txtPage;
        private System.Windows.Forms.PictureBox picPage;
    }
}

