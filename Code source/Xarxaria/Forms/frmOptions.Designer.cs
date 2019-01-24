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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.cmdContinue = new System.Windows.Forms.Button();
            this.lblPoliceSize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPoliceZoom = new System.Windows.Forms.NumericUpDown();
            this.lblOptions = new System.Windows.Forms.Label();
            this.cmbTextAlign = new System.Windows.Forms.ComboBox();
            this.lblTextAlign = new System.Windows.Forms.Label();
            this.txtExample = new Xarxaria.RichTextBoxExtension();
            this.lblVolume = new System.Windows.Forms.Label();
            this.barVolume = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.numPoliceZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdContinue
            // 
            this.cmdContinue.BackColor = System.Drawing.Color.Transparent;
            this.cmdContinue.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdContinue.FlatAppearance.BorderSize = 0;
            this.cmdContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdContinue.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdContinue.ForeColor = System.Drawing.Color.Gold;
            this.cmdContinue.Location = new System.Drawing.Point(70, 38);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(117, 50);
            this.cmdContinue.TabIndex = 1;
            this.cmdContinue.Text = "Continuer";
            this.cmdContinue.UseVisualStyleBackColor = false;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            this.cmdContinue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdContinue_MouseDown);
            this.cmdContinue.MouseLeave += new System.EventHandler(this.cmdContinue_MouseLeave);
            // 
            // lblPoliceSize
            // 
            this.lblPoliceSize.AutoSize = true;
            this.lblPoliceSize.BackColor = System.Drawing.Color.Transparent;
            this.lblPoliceSize.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblPoliceSize.Location = new System.Drawing.Point(10, 134);
            this.lblPoliceSize.Name = "lblPoliceSize";
            this.lblPoliceSize.Size = new System.Drawing.Size(130, 16);
            this.lblPoliceSize.TabIndex = 0;
            this.lblPoliceSize.Text = "Taille du texte";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // numPoliceZoom
            // 
            this.numPoliceZoom.BackColor = System.Drawing.Color.AntiqueWhite;
            this.numPoliceZoom.DecimalPlaces = 2;
            this.numPoliceZoom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPoliceZoom.Location = new System.Drawing.Point(147, 134);
            this.numPoliceZoom.Name = "numPoliceZoom";
            this.numPoliceZoom.Size = new System.Drawing.Size(54, 20);
            this.numPoliceZoom.TabIndex = 3;
            this.numPoliceZoom.ValueChanged += new System.EventHandler(this.numPoliceZoom_ValueChanged);
            // 
            // lblOptions
            // 
            this.lblOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOptions.BackColor = System.Drawing.Color.Transparent;
            this.lblOptions.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblOptions.Location = new System.Drawing.Point(13, 9);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(227, 30);
            this.lblOptions.TabIndex = 0;
            this.lblOptions.Text = "Options";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTextAlign
            // 
            this.cmbTextAlign.BackColor = System.Drawing.Color.AntiqueWhite;
            this.cmbTextAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTextAlign.FormattingEnabled = true;
            this.cmbTextAlign.Items.AddRange(new object[] {
            "Gauche",
            "Droite",
            "Centré"});
            this.cmbTextAlign.Location = new System.Drawing.Point(147, 94);
            this.cmbTextAlign.Name = "cmbTextAlign";
            this.cmbTextAlign.Size = new System.Drawing.Size(93, 21);
            this.cmbTextAlign.TabIndex = 2;
            this.cmbTextAlign.SelectedIndexChanged += new System.EventHandler(this.cmbTextAlign_SelectedIndexChanged);
            // 
            // lblTextAlign
            // 
            this.lblTextAlign.AutoSize = true;
            this.lblTextAlign.BackColor = System.Drawing.Color.Transparent;
            this.lblTextAlign.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblTextAlign.Location = new System.Drawing.Point(9, 95);
            this.lblTextAlign.Name = "lblTextAlign";
            this.lblTextAlign.Size = new System.Drawing.Size(120, 32);
            this.lblTextAlign.TabIndex = 0;
            this.lblTextAlign.Text = "Alignement du\r\ntexte";
            // 
            // txtExample
            // 
            this.txtExample.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtExample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExample.Location = new System.Drawing.Point(13, 210);
            this.txtExample.Name = "txtExample";
            this.txtExample.Size = new System.Drawing.Size(225, 132);
            this.txtExample.TabIndex = 0;
            this.txtExample.TabStop = false;
            this.txtExample.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque urna velit, pret" +
    "ium aliquet erat vitae, pellentesque sodales leo. In volutpat. ";
            this.txtExample.Enter += new System.EventHandler(this.txtExample_Enter);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.BackColor = System.Drawing.Color.Transparent;
            this.lblVolume.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.lblVolume.Location = new System.Drawing.Point(41, 172);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(63, 16);
            this.lblVolume.TabIndex = 8;
            this.lblVolume.Text = "Volume";
            // 
            // barVolume
            // 
            this.barVolume.Location = new System.Drawing.Point(114, 159);
            this.barVolume.Name = "barVolume";
            this.barVolume.Size = new System.Drawing.Size(104, 45);
            this.barVolume.TabIndex = 4;
            this.barVolume.Value = 5;
            this.barVolume.Scroll += new System.EventHandler(this.barVolume_Scroll);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.frmOptions;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(252, 354);
            this.Controls.Add(this.barVolume);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.txtExample);
            this.Controls.Add(this.lblTextAlign);
            this.Controls.Add(this.cmbTextAlign);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.numPoliceZoom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPoliceSize);
            this.Controls.Add(this.cmdContinue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOptions";
            this.Text = "Xarxaria v1.0 - Options";
            ((System.ComponentModel.ISupportInitialize)(this.numPoliceZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Label lblPoliceSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPoliceZoom;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.ComboBox cmbTextAlign;
        private System.Windows.Forms.Label lblTextAlign;
        private RichTextBoxExtension txtExample;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar barVolume;
    }
}