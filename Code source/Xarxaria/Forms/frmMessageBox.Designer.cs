namespace Xarxaria
{
    partial class frmMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBox));
            this.txtMessage = new Xarxaria.RichTextBoxExtension();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Location = new System.Drawing.Point(22, 65);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(292, 300);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.TabStop = false;
            this.txtMessage.Text = "";
            this.txtMessage.ZoomFactor = 1.1F;
            this.txtMessage.Enter += new System.EventHandler(this.txtMessage_Enter);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(57, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Message_Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOk
            // 
            this.cmdOk.BackColor = System.Drawing.Color.Transparent;
            this.cmdOk.BackgroundImage = global::Xarxaria.Properties.Resources.Simple_Button;
            this.cmdOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdOk.FlatAppearance.BorderSize = 0;
            this.cmdOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.cmdOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOk.Font = new System.Drawing.Font("Algerian", 11.25F);
            this.cmdOk.ForeColor = System.Drawing.Color.Gold;
            this.cmdOk.Location = new System.Drawing.Point(128, 386);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(88, 37);
            this.cmdOk.TabIndex = 1;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = false;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            this.cmdOk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdOk_MouseDown);
            this.cmdOk.MouseLeave += new System.EventHandler(this.cmdOk_MouseLeave);
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xarxaria.Properties.Resources.frmMessage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(342, 435);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMessageBox";
            this.Text = "Xarxaria v1.0 - Message";
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBoxExtension txtMessage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button cmdOk;
    }
}