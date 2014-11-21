namespace Ex01_FacebookPage
{
    using System.Windows.Forms.VisualStyles;

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
            this.MyProfileCommentBox = new System.Windows.Forms.TextBox();
            this.MyProfileCommentButton = new System.Windows.Forms.Button();
            this.MyProfileLikebutton = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.myActivityFeed = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NewsFeedTab = new System.Windows.Forms.TabPage();
            this.MyProfile.SuspendLayout();
            this.ProfileTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyProfile
            // 
            this.MyProfile.Controls.Add(this.ProfileTab);
            this.MyProfile.Controls.Add(this.NewsFeedTab);
            this.MyProfile.Location = new System.Drawing.Point(2, 13);
            this.MyProfile.Name = "MyProfile";
            this.MyProfile.SelectedIndex = 0;
            this.MyProfile.Size = new System.Drawing.Size(1059, 645);
            this.MyProfile.TabIndex = 0;
            this.MyProfile.Deselected += this.tabSwitch;
            // 
            // ProfileTab
            // 
            this.ProfileTab.Controls.Add(this.MyProfileCommentBox);
            this.ProfileTab.Controls.Add(this.MyProfileCommentButton);
            this.ProfileTab.Controls.Add(this.MyProfileLikebutton);
            this.ProfileTab.Controls.Add(this.buttonSetStatus);
            this.ProfileTab.Controls.Add(this.myActivityFeed);
            this.ProfileTab.Controls.Add(this.label1);
            this.ProfileTab.Controls.Add(this.textBoxStatus);
            this.ProfileTab.Controls.Add(this.label3);
            this.ProfileTab.Location = new System.Drawing.Point(4, 25);
            this.ProfileTab.Name = "ProfileTab";
            this.ProfileTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProfileTab.Size = new System.Drawing.Size(1051, 616);
            this.ProfileTab.TabIndex = 0;
            this.ProfileTab.Text = "My Profile";
            this.ProfileTab.UseVisualStyleBackColor = true;
            // 
            // MyProfileCommentBox
            // 
            this.MyProfileCommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileCommentBox.Location = new System.Drawing.Point(732, 444);
            this.MyProfileCommentBox.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileCommentBox.Name = "MyProfileCommentBox";
            this.MyProfileCommentBox.Size = new System.Drawing.Size(295, 22);
            this.MyProfileCommentBox.TabIndex = 53;
            // 
            // MyProfileCommentButton
            // 
            this.MyProfileCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileCommentButton.Location = new System.Drawing.Point(743, 474);
            this.MyProfileCommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileCommentButton.Name = "MyProfileCommentButton";
            this.MyProfileCommentButton.Size = new System.Drawing.Size(100, 28);
            this.MyProfileCommentButton.TabIndex = 52;
            this.MyProfileCommentButton.Text = "Comment";
            this.MyProfileCommentButton.UseVisualStyleBackColor = true;
            this.MyProfileCommentButton.Click += new System.EventHandler(this.MyProfileCommentButton_Click);
            // 
            // MyProfileLikebutton
            // 
            this.MyProfileLikebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileLikebutton.Location = new System.Drawing.Point(927, 474);
            this.MyProfileLikebutton.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileLikebutton.Name = "MyProfileLikebutton";
            this.MyProfileLikebutton.Size = new System.Drawing.Size(100, 28);
            this.MyProfileLikebutton.TabIndex = 51;
            this.MyProfileLikebutton.Text = "Like";
            this.MyProfileLikebutton.UseVisualStyleBackColor = true;
            this.MyProfileLikebutton.Click += new System.EventHandler(this.MyProfileLikebutton_Click);
            // 
            // buttonSetStatus
            // 
            this.buttonSetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetStatus.Location = new System.Drawing.Point(743, 16);
            this.buttonSetStatus.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.Size = new System.Drawing.Size(100, 28);
            this.buttonSetStatus.TabIndex = 50;
            this.buttonSetStatus.Text = "Post";
            this.buttonSetStatus.UseVisualStyleBackColor = true;
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatus_Click);
            // 
            // myActivityFeed
            // 
            this.myActivityFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myActivityFeed.DisplayMember = "name";
            this.myActivityFeed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myActivityFeed.FormattingEnabled = true;
            this.myActivityFeed.ItemHeight = 24;
            this.myActivityFeed.Location = new System.Drawing.Point(99, 51);
            this.myActivityFeed.Margin = new System.Windows.Forms.Padding(4);
            this.myActivityFeed.Name = "myActivityFeed";
            this.myActivityFeed.Size = new System.Drawing.Size(594, 484);
            this.myActivityFeed.TabIndex = 49;
            this.myActivityFeed.SelectedIndexChanged += new System.EventHandler(this.myActivityFeed_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "My activity:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(99, 16);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(625, 22);
            this.textBoxStatus.TabIndex = 47;
            this.textBoxStatus.TextChanged += new System.EventHandler(this.textBoxStatus_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Post Status:";
            // 
            // NewsFeedTab
            // 
            this.NewsFeedTab.Location = new System.Drawing.Point(4, 25);
            this.NewsFeedTab.Name = "NewsFeedTab";
            this.NewsFeedTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewsFeedTab.Size = new System.Drawing.Size(1051, 616);
            this.NewsFeedTab.TabIndex = 1;
            this.NewsFeedTab.Text = "NewsFeed";
            this.NewsFeedTab.UseVisualStyleBackColor = true;
            // 
            // TabsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.MyProfile);
            this.Name = "TabsPage";
            this.Text = "TabsPage";
            this.MyProfile.ResumeLayout(false);
            this.ProfileTab.ResumeLayout(false);
            this.ProfileTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MyProfile;
        private System.Windows.Forms.TabPage ProfileTab;
        private System.Windows.Forms.TabPage NewsFeedTab;
        private System.Windows.Forms.ListBox myActivityFeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.TextBox MyProfileCommentBox;
        private System.Windows.Forms.Button MyProfileCommentButton;
        private System.Windows.Forms.Button MyProfileLikebutton;
    }
}