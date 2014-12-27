namespace FacebookAppGUI
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
            this.linkUpdateFromFacebook.Location = new System.Drawing.Point(0, 273);
            this.linkUpdateFromFacebook.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkUpdateFromFacebook.Name = "linkUpdateFromFacebook";
            this.linkUpdateFromFacebook.Size = new System.Drawing.Size(183, 35);
            this.linkUpdateFromFacebook.TabIndex = 54;
            this.linkUpdateFromFacebook.TabStop = true;
            this.linkUpdateFromFacebook.Text = "Fetch from facebook\r\n(This may take a few minutes)";
            this.linkUpdateFromFacebook.UseCompatibleTextRendering = true;
            this.linkUpdateFromFacebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdateFromFacebook_LinkClicked);
            // 
            // ApplicationTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.linkUpdateFromFacebook);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ApplicationTabPage";
            this.Size = new System.Drawing.Size(533, 308);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkUpdateFromFacebook;




    }
}
