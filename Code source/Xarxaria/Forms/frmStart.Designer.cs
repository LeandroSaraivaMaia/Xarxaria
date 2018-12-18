namespace Xarxaria
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.cmdNewGame = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.cmdOptions = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdNewGame
            // 
            this.cmdNewGame.BackColor = System.Drawing.Color.Transparent;
            this.cmdNewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdNewGame.BackgroundImage")));
            this.cmdNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdNewGame.FlatAppearance.BorderSize = 0;
            this.cmdNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNewGame.Font = new System.Drawing.Font("Algerian", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewGame.ForeColor = System.Drawing.Color.Gold;
            this.cmdNewGame.Location = new System.Drawing.Point(71, 386);
            this.cmdNewGame.Name = "cmdNewGame";
            this.cmdNewGame.Size = new System.Drawing.Size(162, 52);
            this.cmdNewGame.TabIndex = 1;
            this.cmdNewGame.Text = "Nouvelle partie";
            this.cmdNewGame.UseVisualStyleBackColor = false;
            this.cmdNewGame.Click += new System.EventHandler(this.cmdNewGame_Click);
            this.cmdNewGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdNewGame_MouseDown);
            this.cmdNewGame.MouseLeave += new System.EventHandler(this.cmdNewGame_MouseLeave);
            // 
            // cmdLoad
            // 
            this.cmdLoad.BackColor = System.Drawing.Color.Transparent;
            this.cmdLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdLoad.BackgroundImage")));
            this.cmdLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdLoad.FlatAppearance.BorderSize = 0;
            this.cmdLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLoad.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdLoad.ForeColor = System.Drawing.Color.Gold;
            this.cmdLoad.Location = new System.Drawing.Point(239, 386);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(162, 52);
            this.cmdLoad.TabIndex = 2;
            this.cmdLoad.Text = "Chargement d\'une partie";
            this.cmdLoad.UseVisualStyleBackColor = false;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            this.cmdLoad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdLoad_MouseDown);
            this.cmdLoad.MouseLeave += new System.EventHandler(this.cmdLoad_MouseLeave);
            // 
            // cmdQuit
            // 
            this.cmdQuit.BackColor = System.Drawing.Color.Transparent;
            this.cmdQuit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdQuit.BackgroundImage")));
            this.cmdQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdQuit.FlatAppearance.BorderSize = 0;
            this.cmdQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuit.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdQuit.ForeColor = System.Drawing.Color.Gold;
            this.cmdQuit.Location = new System.Drawing.Point(575, 386);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(162, 52);
            this.cmdQuit.TabIndex = 4;
            this.cmdQuit.Text = "Quitter";
            this.cmdQuit.UseVisualStyleBackColor = false;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            this.cmdQuit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdQuit_MouseDown);
            this.cmdQuit.MouseLeave += new System.EventHandler(this.cmdQuit_MouseLeave);
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
            this.cmdOptions.Location = new System.Drawing.Point(407, 386);
            this.cmdOptions.Name = "cmdOptions";
            this.cmdOptions.Size = new System.Drawing.Size(162, 52);
            this.cmdOptions.TabIndex = 3;
            this.cmdOptions.Text = "Options";
            this.cmdOptions.UseVisualStyleBackColor = false;
            this.cmdOptions.Click += new System.EventHandler(this.cmdOptions_Click);
            this.cmdOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdOptions_MouseDown);
            this.cmdOptions.MouseLeave += new System.EventHandler(this.cmdOptions_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Xarxaria.Properties.Resources.logo_sans_fond_min_V2;
            this.pictureBox1.Location = new System.Drawing.Point(277, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 312);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.StartScreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmdOptions);
            this.Controls.Add(this.cmdQuit);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.cmdNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStart";
            this.Text = "Xarxaria v1.0";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdNewGame;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdQuit;
        private System.Windows.Forms.Button cmdOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}