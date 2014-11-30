namespace Ex01_FacebookPage
{
    partial class ApplicationTabPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkUpdateFromFacebook = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkUpdateFromFacebook
            // 
            this.linkUpdateFromFacebook.AutoSize = true;
            this.linkUpdateFromFacebook.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linkUpdateFromFacebook.LinkArea = new System.Windows.Forms.LinkArea(0, 19);
            this.linkUpdateFromFacebook.Location = new System.Drawing.Point(0, 220);
            this.linkUpdateFromFacebook.Name = "linkUpdateFromFacebook";
            this.linkUpdateFromFacebook.Size = new System.Drawing.Size(155, 30);
            this.linkUpdateFromFacebook.TabIndex = 54;
            this.linkUpdateFromFacebook.TabStop = true;
            this.linkUpdateFromFacebook.Text = "Fetch from facebook\r\n(This may take a few minutes)";
            this.linkUpdateFromFacebook.UseCompatibleTextRendering = true;
            this.linkUpdateFromFacebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdateFromFacebook_LinkClicked);
            // 
            // ApplicationTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.linkUpdateFromFacebook);
            this.Name = "ApplicationTabPage";
            this.Size = new System.Drawing.Size(400, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkUpdateFromFacebook;




    }
}
