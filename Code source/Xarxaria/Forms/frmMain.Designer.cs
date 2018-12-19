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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdMenu = new System.Windows.Forms.Button();
            this.cmdPlayer = new System.Windows.Forms.Button();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picPage = new System.Windows.Forms.PictureBox();
            this.txtPage = new Xarxaria.RichTextBoxExtension();
            this.cmdDebug = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdMenu
            // 
            this.cmdMenu.BackColor = System.Drawing.Color.Transparent;
            this.cmdMenu.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdMenu.FlatAppearance.BorderSize = 0;
            this.cmdMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMenu.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdMenu.ForeColor = System.Drawing.Color.Gold;
            this.cmdMenu.Location = new System.Drawing.Point(398, 573);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(152, 47);
            this.cmdMenu.TabIndex = 2;
            this.cmdMenu.Text = "Menu";
            this.cmdMenu.UseVisualStyleBackColor = false;
            this.cmdMenu.Click += new System.EventHandler(this.cmdMenu_Click);
            this.cmdMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdMenu_MouseDown);
            this.cmdMenu.MouseLeave += new System.EventHandler(this.cmdMenu_MouseLeave);
            // 
            // cmdPlayer
            // 
            this.cmdPlayer.BackColor = System.Drawing.Color.Transparent;
            this.cmdPlayer.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdPlayer.FlatAppearance.BorderSize = 0;
            this.cmdPlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdPlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPlayer.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdPlayer.ForeColor = System.Drawing.Color.Gold;
            this.cmdPlayer.Location = new System.Drawing.Point(12, 573);
            this.cmdPlayer.Name = "cmdPlayer";
            this.cmdPlayer.Size = new System.Drawing.Size(151, 47);
            this.cmdPlayer.TabIndex = 1;
            this.cmdPlayer.Text = "Feuille de personnage";
            this.cmdPlayer.UseVisualStyleBackColor = false;
            this.cmdPlayer.Click += new System.EventHandler(this.cmdPlayer_Click);
            this.cmdPlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdPlayer_MouseDown);
            this.cmdPlayer.MouseLeave += new System.EventHandler(this.cmdPlayer_MouseLeave);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPageTitle.Location = new System.Drawing.Point(224, 18);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(138, 16);
            this.lblPageTitle.TabIndex = 0;
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
            this.txtPage.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPage.Location = new System.Drawing.Point(12, 295);
            this.txtPage.Name = "txtPage";
            this.txtPage.ReadOnly = true;
            this.txtPage.Size = new System.Drawing.Size(538, 272);
            this.txtPage.TabIndex = 0;
            this.txtPage.TabStop = false;
            this.txtPage.Text = "";
            this.txtPage.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtPage_LinkClicked);
            this.txtPage.Enter += new System.EventHandler(this.txtPage_Enter);
            // 
            // cmdDebug
            // 
            this.cmdDebug.Location = new System.Drawing.Point(12, 11);
            this.cmdDebug.Name = "cmdDebug";
            this.cmdDebug.Size = new System.Drawing.Size(75, 23);
            this.cmdDebug.TabIndex = 5;
            this.cmdDebug.Text = "debug";
            this.cmdDebug.UseVisualStyleBackColor = true;
            this.cmdDebug.Click += new System.EventHandler(this.cmdDebug_Click);
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(93, 13);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(100, 20);
            this.txtDebug.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.Parchemin4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 632);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.cmdDebug);
            this.Controls.Add(this.cmdMenu);
            this.Controls.Add(this.cmdPlayer);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.picPage);
            this.Controls.Add(this.txtPage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Xarxaria v1.0 - Main";
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdMenu;
        private System.Windows.Forms.Button cmdPlayer;
        private System.Windows.Forms.Label lblPageTitle;
        private RichTextBoxExtension txtPage;
        private System.Windows.Forms.PictureBox picPage;
        private System.Windows.Forms.Button cmdDebug;
        private System.Windows.Forms.TextBox txtDebug;
    }
}

