namespace Ex01_FacebookPage
{
    using System.Windows.Forms.VisualStyles;

    partial class ApplicationTabsForm
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
            this.myProfileUnlikeButton = new System.Windows.Forms.Button();
            this.MyProfileViewComments = new System.Windows.Forms.ListBox();
            this.MyProfileCommentBox = new System.Windows.Forms.TextBox();
            this.MyProfileCommentButton = new System.Windows.Forms.Button();
            this.MyProfileLikebutton = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.MyProfileActivityFeed = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NewsFeedTab = new System.Windows.Forms.TabPage();
            this.inboxTabPage = new System.Windows.Forms.TabPage();
            this.inboxPage = new Ex01_FacebookPage.InboxPage();
            this.friendsTabPage = new System.Windows.Forms.TabPage();
            this.friendsPage1 = new Ex01_FacebookPage.FriendsPage();
            this.MyProfile.SuspendLayout();
            this.ProfileTab.SuspendLayout();
            this.inboxTabPage.SuspendLayout();
            this.friendsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyProfile
            // 
            this.MyProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfile.Controls.Add(this.ProfileTab);
            this.MyProfile.Controls.Add(this.NewsFeedTab);
            this.MyProfile.Controls.Add(this.inboxTabPage);
            this.MyProfile.Controls.Add(this.friendsTabPage);
            this.MyProfile.Location = new System.Drawing.Point(2, 11);
            this.MyProfile.Margin = new System.Windows.Forms.Padding(2);
            this.MyProfile.Name = "MyProfile";
            this.MyProfile.SelectedIndex = 0;
            this.MyProfile.Size = new System.Drawing.Size(794, 524);
            this.MyProfile.TabIndex = 0;
            // 
            // ProfileTab
            // 
            this.ProfileTab.Controls.Add(this.myProfileUnlikeButton);
            this.ProfileTab.Controls.Add(this.MyProfileViewComments);
            this.ProfileTab.Controls.Add(this.MyProfileCommentBox);
            this.ProfileTab.Controls.Add(this.MyProfileCommentButton);
            this.ProfileTab.Controls.Add(this.MyProfileLikebutton);
            this.ProfileTab.Controls.Add(this.buttonSetStatus);
            this.ProfileTab.Controls.Add(this.MyProfileActivityFeed);
            this.ProfileTab.Controls.Add(this.label1);
            this.ProfileTab.Controls.Add(this.textBoxStatus);
            this.ProfileTab.Controls.Add(this.label3);
            this.ProfileTab.Location = new System.Drawing.Point(4, 22);
            this.ProfileTab.Margin = new System.Windows.Forms.Padding(2);
            this.ProfileTab.Name = "ProfileTab";
            this.ProfileTab.Padding = new System.Windows.Forms.Padding(2);
            this.ProfileTab.Size = new System.Drawing.Size(786, 498);
            this.ProfileTab.TabIndex = 0;
            this.ProfileTab.Text = "My Profile";
            this.ProfileTab.UseVisualStyleBackColor = true;
            // 
            // myProfileUnlikeButton
            // 
            this.myProfileUnlikeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myProfileUnlikeButton.Location = new System.Drawing.Point(695, 385);
            this.myProfileUnlikeButton.Name = "myProfileUnlikeButton";
            this.myProfileUnlikeButton.Size = new System.Drawing.Size(75, 23);
            this.myProfileUnlikeButton.TabIndex = 55;
            this.myProfileUnlikeButton.Text = "Unlike";
            this.myProfileUnlikeButton.UseVisualStyleBackColor = true;
            this.myProfileUnlikeButton.Click += new System.EventHandler(this.myProfileUnlikeButtonClick);
            // 
            // MyProfileViewComments
            // 
            this.MyProfileViewComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileViewComments.DisplayMember = "name";
            this.MyProfileViewComments.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfileViewComments.FormattingEnabled = true;
            this.MyProfileViewComments.ItemHeight = 19;
            this.MyProfileViewComments.Location = new System.Drawing.Point(549, 39);
            this.MyProfileViewComments.Name = "MyProfileViewComments";
            this.MyProfileViewComments.Size = new System.Drawing.Size(222, 308);
            this.MyProfileViewComments.TabIndex = 54;
            // 
            // MyProfileCommentBox
            // 
            this.MyProfileCommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileCommentBox.Location = new System.Drawing.Point(549, 361);
            this.MyProfileCommentBox.Name = "MyProfileCommentBox";
            this.MyProfileCommentBox.Size = new System.Drawing.Size(222, 20);
            this.MyProfileCommentBox.TabIndex = 53;
            // 
            // MyProfileCommentButton
            // 
            this.MyProfileCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileCommentButton.Location = new System.Drawing.Point(557, 385);
            this.MyProfileCommentButton.Name = "MyProfileCommentButton";
            this.MyProfileCommentButton.Size = new System.Drawing.Size(75, 23);
            this.MyProfileCommentButton.TabIndex = 52;
            this.MyProfileCommentButton.Text = "Comment";
            this.MyProfileCommentButton.UseVisualStyleBackColor = true;
            this.MyProfileCommentButton.Click += new System.EventHandler(this.myProfileCommentButtonClick);
            // 
            // MyProfileLikebutton
            // 
            this.MyProfileLikebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileLikebutton.Location = new System.Drawing.Point(695, 385);
            this.MyProfileLikebutton.Name = "MyProfileLikebutton";
            this.MyProfileLikebutton.Size = new System.Drawing.Size(75, 23);
            this.MyProfileLikebutton.TabIndex = 51;
            this.MyProfileLikebutton.Text = "Like";
            this.MyProfileLikebutton.UseVisualStyleBackColor = true;
            this.MyProfileLikebutton.Click += new System.EventHandler(this.myProfileLikebuttonClick);
            // 
            // buttonSetStatus
            // 
            this.buttonSetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetStatus.Location = new System.Drawing.Point(557, 13);
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.Size = new System.Drawing.Size(75, 23);
            this.buttonSetStatus.TabIndex = 50;
            this.buttonSetStatus.Text = "Post";
            this.buttonSetStatus.UseVisualStyleBackColor = true;
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatusClick);
            // 
            // MyProfileActivityFeed
            // 
            this.MyProfileActivityFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileActivityFeed.DisplayMember = "name";
            this.MyProfileActivityFeed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfileActivityFeed.FormattingEnabled = true;
            this.MyProfileActivityFeed.ItemHeight = 19;
            this.MyProfileActivityFeed.Location = new System.Drawing.Point(74, 41);
            this.MyProfileActivityFeed.Name = "MyProfileActivityFeed";
            this.MyProfileActivityFeed.Size = new System.Drawing.Size(457, 384);
            this.MyProfileActivityFeed.TabIndex = 49;
            this.MyProfileActivityFeed.SelectedIndexChanged += new System.EventHandler(this.myActivityFeedSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "My activity:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(74, 13);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(470, 20);
            this.textBoxStatus.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Post Status:";
            // 
            // NewsFeedTab
            // 
            this.NewsFeedTab.Location = new System.Drawing.Point(4, 22);
            this.NewsFeedTab.Margin = new System.Windows.Forms.Padding(2);
            this.NewsFeedTab.Name = "NewsFeedTab";
            this.NewsFeedTab.Padding = new System.Windows.Forms.Padding(2);
            this.NewsFeedTab.Size = new System.Drawing.Size(786, 498);
            this.NewsFeedTab.TabIndex = 1;
            this.NewsFeedTab.Text = "NewsFeed";
            this.NewsFeedTab.UseVisualStyleBackColor = true;
            // 
            // inboxTabPage
            // 
            this.inboxTabPage.Controls.Add(this.inboxPage);
            this.inboxTabPage.Location = new System.Drawing.Point(4, 22);
            this.inboxTabPage.Name = "inboxTabPage";
            this.inboxTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.inboxTabPage.Size = new System.Drawing.Size(786, 498);
            this.inboxTabPage.TabIndex = 2;
            this.inboxTabPage.Text = "Messages";
            this.inboxTabPage.UseVisualStyleBackColor = true;
            // 
            // inboxPage
            // 
            this.inboxPage.AutoScroll = true;
            this.inboxPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inboxPage.FacebookApplicationLogicManager = null;
            this.inboxPage.Location = new System.Drawing.Point(3, 3);
            this.inboxPage.Name = "inboxPage";
            this.inboxPage.Size = new System.Drawing.Size(780, 492);
            this.inboxPage.TabIndex = 0;
            // 
            // friendsTabPage
            // 
            this.friendsTabPage.Controls.Add(this.friendsPage1);
            this.friendsTabPage.Location = new System.Drawing.Point(4, 22);
            this.friendsTabPage.Name = "friendsTabPage";
            this.friendsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.friendsTabPage.Size = new System.Drawing.Size(786, 498);
            this.friendsTabPage.TabIndex = 3;
            this.friendsTabPage.Text = "Friends";
            this.friendsTabPage.UseVisualStyleBackColor = true;
            // 
            // friendsPage1
            // 
            this.friendsPage1.AutoScroll = true;
            this.friendsPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendsPage1.FacebookApplicationLogicManager = null;
            this.friendsPage1.Location = new System.Drawing.Point(3, 3);
            this.friendsPage1.Name = "friendsPage1";
            this.friendsPage1.Size = new System.Drawing.Size(780, 492);
            this.friendsPage1.TabIndex = 0;
            // 
            // ApplicationTabsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 536);
            this.Controls.Add(this.MyProfile);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ApplicationTabsForm";
            this.Text = "TabsPage";
            this.MyProfile.ResumeLayout(false);
            this.ProfileTab.ResumeLayout(false);
            this.ProfileTab.PerformLayout();
            this.inboxTabPage.ResumeLayout(false);
            this.friendsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MyProfile;
        private System.Windows.Forms.TabPage ProfileTab;
        private System.Windows.Forms.TabPage NewsFeedTab;
        private System.Windows.Forms.ListBox MyProfileActivityFeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.TextBox MyProfileCommentBox;
        private System.Windows.Forms.Button MyProfileCommentButton;
        private System.Windows.Forms.Button MyProfileLikebutton;
        private System.Windows.Forms.ListBox MyProfileViewComments;
        private System.Windows.Forms.Button myProfileUnlikeButton;
        private System.Windows.Forms.TabPage inboxTabPage;
        private System.Windows.Forms.TabPage friendsTabPage;
        private InboxPage inboxPage;
        private FriendsPage friendsPage1;
    }
}