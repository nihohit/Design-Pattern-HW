namespace Ex01_FacebookPage
{
    partial class TabsPage
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
            this.MyProfile = new System.Windows.Forms.TabControl();
            this.ProfileTab = new System.Windows.Forms.TabPage();
            this.NewsFeed = new System.Windows.Forms.TabPage();
            this.MyProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyProfile
            // 
            this.MyProfile.Controls.Add(this.ProfileTab);
            this.MyProfile.Controls.Add(this.NewsFeed);
            this.MyProfile.Location = new System.Drawing.Point(2, 13);
            this.MyProfile.Name = "MyProfile";
            this.MyProfile.SelectedIndex = 0;
            this.MyProfile.Size = new System.Drawing.Size(1046, 645);
            this.MyProfile.TabIndex = 0;
            // 
            // ProfileTab
            // 
            this.ProfileTab.Location = new System.Drawing.Point(4, 25);
            this.ProfileTab.Name = "ProfileTab";
            this.ProfileTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProfileTab.Size = new System.Drawing.Size(1038, 616);
            this.ProfileTab.TabIndex = 0;
            this.ProfileTab.Text = "My Profile";
            this.ProfileTab.UseVisualStyleBackColor = true;
            // 
            // NewsFeed
            // 
            this.NewsFeed.Location = new System.Drawing.Point(4, 25);
            this.NewsFeed.Name = "NewsFeed";
            this.NewsFeed.Padding = new System.Windows.Forms.Padding(3);
            this.NewsFeed.Size = new System.Drawing.Size(1038, 616);
            this.NewsFeed.TabIndex = 1;
            this.NewsFeed.Text = "NewsFeed";
            this.NewsFeed.UseVisualStyleBackColor = true;
            // 
            // TabsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.MyProfile);
            this.Name = "TabsPage";
            this.Text = "TabsPage";
            this.Load += new System.EventHandler(this.TabsPage_Load);
            this.MyProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MyProfile;
        private System.Windows.Forms.TabPage ProfileTab;
        private System.Windows.Forms.TabPage NewsFeed;
    }
}