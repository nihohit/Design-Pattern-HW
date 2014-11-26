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
            this.MyProfileViewComments = new System.Windows.Forms.ListBox();
            this.MyProfileCommentBox = new System.Windows.Forms.TextBox();
            this.MyProfileCommentButton = new System.Windows.Forms.Button();
            this.MyProfileLikeButton = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.MyProfileActivityBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NewsFeedTab = new System.Windows.Forms.TabPage();
            this.NewsFeedLikeButton = new System.Windows.Forms.Button();
            this.NewsFeedViewComments = new System.Windows.Forms.ListBox();
            this.NewsFeedCommentBox = new System.Windows.Forms.TextBox();
            this.NewsFeedCommentButton = new System.Windows.Forms.Button();
            this.NewsFeedActivityBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InterestSetterTab = new System.Windows.Forms.TabPage();
            this.FriendsViewBox = new System.Windows.Forms.ListBox();
            this.FriendsLabel = new System.Windows.Forms.Label();
            this.MyProfile.SuspendLayout();
            this.ProfileTab.SuspendLayout();
            this.NewsFeedTab.SuspendLayout();
            this.InterestSetterTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyProfile
            // 
            this.MyProfile.Controls.Add(this.ProfileTab);
            this.MyProfile.Controls.Add(this.NewsFeedTab);
            this.MyProfile.Controls.Add(this.InterestSetterTab);
            this.MyProfile.Location = new System.Drawing.Point(2, 13);
            this.MyProfile.Name = "MyProfile";
            this.MyProfile.SelectedIndex = 0;
            this.MyProfile.Size = new System.Drawing.Size(1059, 645);
            this.MyProfile.TabIndex = 0;
            this.MyProfile.SelectedIndexChanged += new System.EventHandler(this.tabIndexChanged);
            // 
            // ProfileTab
            // 
            this.ProfileTab.Controls.Add(this.MyProfileViewComments);
            this.ProfileTab.Controls.Add(this.MyProfileCommentBox);
            this.ProfileTab.Controls.Add(this.MyProfileCommentButton);
            this.ProfileTab.Controls.Add(this.MyProfileLikeButton);
            this.ProfileTab.Controls.Add(this.buttonSetStatus);
            this.ProfileTab.Controls.Add(this.MyProfileActivityBox);
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
            // MyProfileViewComments
            // 
            this.MyProfileViewComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileViewComments.DisplayMember = "name";
            this.MyProfileViewComments.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfileViewComments.FormattingEnabled = true;
            this.MyProfileViewComments.ItemHeight = 24;
            this.MyProfileViewComments.Location = new System.Drawing.Point(732, 48);
            this.MyProfileViewComments.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileViewComments.Name = "MyProfileViewComments";
            this.MyProfileViewComments.Size = new System.Drawing.Size(295, 436);
            this.MyProfileViewComments.TabIndex = 54;
            this.MyProfileViewComments.SelectedIndexChanged += new System.EventHandler(this.commentFeedSelectedIndexChanged);
            // 
            // MyProfileCommentBox
            // 
            this.MyProfileCommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileCommentBox.Location = new System.Drawing.Point(732, 494);
            this.MyProfileCommentBox.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileCommentBox.Name = "MyProfileCommentBox";
            this.MyProfileCommentBox.Size = new System.Drawing.Size(295, 22);
            this.MyProfileCommentBox.TabIndex = 53;
            // 
            // MyProfileCommentButton
            // 
            this.MyProfileCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileCommentButton.Location = new System.Drawing.Point(732, 537);
            this.MyProfileCommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileCommentButton.Name = "MyProfileCommentButton";
            this.MyProfileCommentButton.Size = new System.Drawing.Size(131, 53);
            this.MyProfileCommentButton.TabIndex = 52;
            this.MyProfileCommentButton.Text = "Comment";
            this.MyProfileCommentButton.UseVisualStyleBackColor = true;
            this.MyProfileCommentButton.Click += new System.EventHandler(this.commentButtonClick);
            // 
            // MyProfileLikeButton
            // 
            this.MyProfileLikeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileLikeButton.Location = new System.Drawing.Point(895, 537);
            this.MyProfileLikeButton.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileLikeButton.Name = "MyProfileLikeButton";
            this.MyProfileLikeButton.Size = new System.Drawing.Size(132, 53);
            this.MyProfileLikeButton.TabIndex = 51;
            this.MyProfileLikeButton.Text = "Like";
            this.MyProfileLikeButton.UseVisualStyleBackColor = true;
            this.MyProfileLikeButton.Click += new System.EventHandler(this.likeButtonClick);
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
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatusClick);
            // 
            // MyProfileActivityBox
            // 
            this.MyProfileActivityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProfileActivityBox.DisplayMember = "name";
            this.MyProfileActivityBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfileActivityBox.FormattingEnabled = true;
            this.MyProfileActivityBox.ItemHeight = 24;
            this.MyProfileActivityBox.Location = new System.Drawing.Point(99, 51);
            this.MyProfileActivityBox.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileActivityBox.Name = "MyProfileActivityBox";
            this.MyProfileActivityBox.Size = new System.Drawing.Size(608, 532);
            this.MyProfileActivityBox.TabIndex = 49;
            this.MyProfileActivityBox.SelectedIndexChanged += new System.EventHandler(this.activityFeedSelectedIndexChanged);
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
            this.NewsFeedTab.Controls.Add(this.NewsFeedLikeButton);
            this.NewsFeedTab.Controls.Add(this.NewsFeedViewComments);
            this.NewsFeedTab.Controls.Add(this.NewsFeedCommentBox);
            this.NewsFeedTab.Controls.Add(this.NewsFeedCommentButton);
            this.NewsFeedTab.Controls.Add(this.NewsFeedActivityBox);
            this.NewsFeedTab.Controls.Add(this.label2);
            this.NewsFeedTab.Location = new System.Drawing.Point(4, 25);
            this.NewsFeedTab.Name = "NewsFeedTab";
            this.NewsFeedTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewsFeedTab.Size = new System.Drawing.Size(1051, 616);
            this.NewsFeedTab.TabIndex = 1;
            this.NewsFeedTab.Text = "NewsFeed";
            this.NewsFeedTab.UseVisualStyleBackColor = true;
            // 
            // NewsFeedLikeButton
            // 
            this.NewsFeedLikeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedLikeButton.Location = new System.Drawing.Point(906, 544);
            this.NewsFeedLikeButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedLikeButton.Name = "NewsFeedLikeButton";
            this.NewsFeedLikeButton.Size = new System.Drawing.Size(135, 56);
            this.NewsFeedLikeButton.TabIndex = 62;
            this.NewsFeedLikeButton.Text = "Like";
            this.NewsFeedLikeButton.UseVisualStyleBackColor = true;
            this.NewsFeedLikeButton.Click += new System.EventHandler(this.likeButtonClick);
            // 
            // NewsFeedViewComments
            // 
            this.NewsFeedViewComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedViewComments.DisplayMember = "name";
            this.NewsFeedViewComments.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewsFeedViewComments.FormattingEnabled = true;
            this.NewsFeedViewComments.ItemHeight = 24;
            this.NewsFeedViewComments.Location = new System.Drawing.Point(746, 27);
            this.NewsFeedViewComments.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedViewComments.Name = "NewsFeedViewComments";
            this.NewsFeedViewComments.Size = new System.Drawing.Size(295, 484);
            this.NewsFeedViewComments.TabIndex = 60;
            this.NewsFeedViewComments.SelectedIndexChanged += new System.EventHandler(this.commentFeedSelectedIndexChanged);
            // 
            // NewsFeedCommentBox
            // 
            this.NewsFeedCommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedCommentBox.Location = new System.Drawing.Point(746, 515);
            this.NewsFeedCommentBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedCommentBox.Name = "NewsFeedCommentBox";
            this.NewsFeedCommentBox.Size = new System.Drawing.Size(295, 22);
            this.NewsFeedCommentBox.TabIndex = 59;
            // 
            // NewsFeedCommentButton
            // 
            this.NewsFeedCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedCommentButton.Location = new System.Drawing.Point(746, 545);
            this.NewsFeedCommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedCommentButton.Name = "NewsFeedCommentButton";
            this.NewsFeedCommentButton.Size = new System.Drawing.Size(135, 56);
            this.NewsFeedCommentButton.TabIndex = 58;
            this.NewsFeedCommentButton.Text = "Comment";
            this.NewsFeedCommentButton.UseVisualStyleBackColor = true;
            this.NewsFeedCommentButton.Click += new System.EventHandler(this.commentButtonClick);
            // 
            // NewsFeedActivityBox
            // 
            this.NewsFeedActivityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedActivityBox.DisplayMember = "name";
            this.NewsFeedActivityBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewsFeedActivityBox.FormattingEnabled = true;
            this.NewsFeedActivityBox.ItemHeight = 24;
            this.NewsFeedActivityBox.Location = new System.Drawing.Point(107, 20);
            this.NewsFeedActivityBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedActivityBox.Name = "NewsFeedActivityBox";
            this.NewsFeedActivityBox.Size = new System.Drawing.Size(608, 580);
            this.NewsFeedActivityBox.TabIndex = 57;
            this.NewsFeedActivityBox.SelectedIndexChanged += new System.EventHandler(this.activityFeedSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "My news feed:";
            // 
            // InterestSetterTab
            // 
            this.InterestSetterTab.Controls.Add(this.FriendsViewBox);
            this.InterestSetterTab.Controls.Add(this.FriendsLabel);
            this.InterestSetterTab.Location = new System.Drawing.Point(4, 25);
            this.InterestSetterTab.Name = "InterestSetterTab";
            this.InterestSetterTab.Padding = new System.Windows.Forms.Padding(3);
            this.InterestSetterTab.Size = new System.Drawing.Size(1051, 616);
            this.InterestSetterTab.TabIndex = 2;
            this.InterestSetterTab.Text = "InterestSetter";
            this.InterestSetterTab.UseVisualStyleBackColor = true;
            // 
            // FriendsViewBox
            // 
            this.FriendsViewBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FriendsViewBox.DisplayMember = "name";
            this.FriendsViewBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FriendsViewBox.FormattingEnabled = true;
            this.FriendsViewBox.ItemHeight = 24;
            this.FriendsViewBox.Location = new System.Drawing.Point(20, 28);
            this.FriendsViewBox.Margin = new System.Windows.Forms.Padding(4);
            this.FriendsViewBox.Name = "FriendsViewBox";
            this.FriendsViewBox.Size = new System.Drawing.Size(270, 532);
            this.FriendsViewBox.TabIndex = 51;
            // 
            // FriendsLabel
            // 
            this.FriendsLabel.AutoSize = true;
            this.FriendsLabel.Location = new System.Drawing.Point(17, 7);
            this.FriendsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FriendsLabel.Name = "FriendsLabel";
            this.FriendsLabel.Size = new System.Drawing.Size(59, 17);
            this.FriendsLabel.TabIndex = 50;
            this.FriendsLabel.Text = "Friends:";
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
            this.NewsFeedTab.ResumeLayout(false);
            this.NewsFeedTab.PerformLayout();
            this.InterestSetterTab.ResumeLayout(false);
            this.InterestSetterTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MyProfile;
        private System.Windows.Forms.TabPage ProfileTab;
        private System.Windows.Forms.TabPage NewsFeedTab;
        private System.Windows.Forms.ListBox MyProfileActivityBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.TextBox MyProfileCommentBox;
        private System.Windows.Forms.Button MyProfileCommentButton;
        private System.Windows.Forms.Button MyProfileLikeButton;
        private System.Windows.Forms.ListBox MyProfileViewComments;
        private System.Windows.Forms.ListBox NewsFeedViewComments;
        private System.Windows.Forms.TextBox NewsFeedCommentBox;
        private System.Windows.Forms.Button NewsFeedCommentButton;
        private System.Windows.Forms.ListBox NewsFeedActivityBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NewsFeedLikeButton;
        private System.Windows.Forms.Button MyProfileShareButton;
        private System.Windows.Forms.TabPage InterestTab;
        private System.Windows.Forms.TabPage InterestSetterTab;
        private System.Windows.Forms.ListBox FriendsViewBox;
        private System.Windows.Forms.Label FriendsLabel;
    }
}