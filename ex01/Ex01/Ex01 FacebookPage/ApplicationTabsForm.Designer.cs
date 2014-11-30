﻿namespace Ex01_FacebookPage
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
            this.myProfile = new System.Windows.Forms.TabControl();
            this.ProfileTab = new System.Windows.Forms.TabPage();
            this.myProfileViewComments = new System.Windows.Forms.ListBox();
            this.myProfileCommentBox = new System.Windows.Forms.TextBox();
            this.myProfileCommentButton = new System.Windows.Forms.Button();
            this.myProfileLikeButton = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.myProfileActivityBox = new System.Windows.Forms.ListBox();
            this.myActivityLabel = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.postStatusLabel = new System.Windows.Forms.Label();
            this.NewsFeedTab = new System.Windows.Forms.TabPage();
            this.newsFeedLikeButton = new System.Windows.Forms.Button();
            this.newsFeedViewComments = new System.Windows.Forms.ListBox();
            this.newsFeedCommentBox = new System.Windows.Forms.TextBox();
            this.newsFeedCommentButton = new System.Windows.Forms.Button();
            this.newsFeedActivityBox = new System.Windows.Forms.ListBox();
            this.newsfeedLabel = new System.Windows.Forms.Label();
            this.inboxTabPage = new System.Windows.Forms.TabPage();
            this.friendsTabPage = new System.Windows.Forms.TabPage();
            this.InterestToolTab = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.InterestSetterTimeBoundLabel = new System.Windows.Forms.Label();
            this.InterestedFriendsViewBox = new System.Windows.Forms.ListBox();
            this.InterestedFriendsLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.InterestActionsAmount = new System.Windows.Forms.NumericUpDown();
            this.InterestFrequency = new System.Windows.Forms.NumericUpDown();
            this.FrequencyOfInterestLabel = new System.Windows.Forms.Label();
            this.InterestAmountLabel = new System.Windows.Forms.Label();
            this.FriendsViewBox = new System.Windows.Forms.ListBox();
            this.FriendsLabel = new System.Windows.Forms.Label();
            this.interestCheckTab = new System.Windows.Forms.TabPage();
            this.inboxPage = new Ex01_FacebookPage.InboxPage();
            this.friendsPage1 = new Ex01_FacebookPage.FriendsPage();
            this.interestPage = new Ex01_FacebookPage.InterestPage();
            this.myProfile.SuspendLayout();
            this.ProfileTab.SuspendLayout();
            this.NewsFeedTab.SuspendLayout();
            this.inboxTabPage.SuspendLayout();
            this.friendsTabPage.SuspendLayout();
            this.InterestToolTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestActionsAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestFrequency)).BeginInit();
            this.interestCheckTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // myProfile
            // 
            this.myProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myProfile.Controls.Add(this.ProfileTab);
            this.myProfile.Controls.Add(this.NewsFeedTab);
            this.myProfile.Controls.Add(this.inboxTabPage);
            this.myProfile.Controls.Add(this.friendsTabPage);
            this.myProfile.Controls.Add(this.interestCheckTab);
            this.myProfile.Location = new System.Drawing.Point(3, 14);
            this.myProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.myProfile.Name = "myProfile";
            this.myProfile.SelectedIndex = 0;
            this.myProfile.Size = new System.Drawing.Size(1059, 645);
            this.myProfile.TabIndex = 0;
            this.myProfile.SelectedIndexChanged += new System.EventHandler(this.tabIndexChanged);
            // 
            // ProfileTab
            // 
            this.ProfileTab.Controls.Add(this.myProfileViewComments);
            this.ProfileTab.Controls.Add(this.myProfileCommentBox);
            this.ProfileTab.Controls.Add(this.myProfileCommentButton);
            this.ProfileTab.Controls.Add(this.myProfileLikeButton);
            this.ProfileTab.Controls.Add(this.buttonSetStatus);
            this.ProfileTab.Controls.Add(this.myProfileActivityBox);
            this.ProfileTab.Controls.Add(this.myActivityLabel);
            this.ProfileTab.Controls.Add(this.statusTextBox);
            this.ProfileTab.Controls.Add(this.postStatusLabel);
            this.ProfileTab.Location = new System.Drawing.Point(4, 25);
            this.ProfileTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProfileTab.Name = "ProfileTab";
            this.ProfileTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProfileTab.Size = new System.Drawing.Size(1051, 616);
            this.ProfileTab.TabIndex = 0;
            this.ProfileTab.Text = "My Profile";
            this.ProfileTab.UseVisualStyleBackColor = true;
            // 
            // myProfileViewComments
            // 
            this.myProfileViewComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myProfileViewComments.DisplayMember = "name";
            this.myProfileViewComments.Font = new System.Drawing.Font("Calibri", 9F);
            this.myProfileViewComments.FormattingEnabled = true;
            this.myProfileViewComments.ItemHeight = 18;
            this.myProfileViewComments.Location = new System.Drawing.Point(732, 48);
            this.myProfileViewComments.Margin = new System.Windows.Forms.Padding(4);
            this.myProfileViewComments.Name = "myProfileViewComments";
            this.myProfileViewComments.Size = new System.Drawing.Size(295, 436);
            this.myProfileViewComments.TabIndex = 54;
            this.myProfileViewComments.SelectedIndexChanged += new System.EventHandler(this.commentFeedSelectedIndexChanged);
            // 
            // myProfileCommentBox
            // 
            this.myProfileCommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myProfileCommentBox.Location = new System.Drawing.Point(732, 494);
            this.myProfileCommentBox.Margin = new System.Windows.Forms.Padding(4);
            this.myProfileCommentBox.Name = "myProfileCommentBox";
            this.myProfileCommentBox.Size = new System.Drawing.Size(295, 22);
            this.myProfileCommentBox.TabIndex = 53;
            // 
            // myProfileCommentButton
            // 
            this.myProfileCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myProfileCommentButton.Location = new System.Drawing.Point(732, 537);
            this.myProfileCommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.myProfileCommentButton.Name = "myProfileCommentButton";
            this.myProfileCommentButton.Size = new System.Drawing.Size(131, 53);
            this.myProfileCommentButton.TabIndex = 52;
            this.myProfileCommentButton.Text = "Comment";
            this.myProfileCommentButton.UseVisualStyleBackColor = true;
            this.myProfileCommentButton.Click += new System.EventHandler(this.commentButtonClick);
            // 
            // myProfileLikeButton
            // 
            this.myProfileLikeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myProfileLikeButton.Location = new System.Drawing.Point(895, 537);
            this.myProfileLikeButton.Margin = new System.Windows.Forms.Padding(4);
            this.myProfileLikeButton.Name = "myProfileLikeButton";
            this.myProfileLikeButton.Size = new System.Drawing.Size(132, 53);
            this.myProfileLikeButton.TabIndex = 51;
            this.myProfileLikeButton.Text = "Like";
            this.myProfileLikeButton.UseVisualStyleBackColor = true;
            this.myProfileLikeButton.Click += new System.EventHandler(this.likeButtonClick);
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
            // myProfileActivityBox
            // 
            this.myProfileActivityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myProfileActivityBox.DisplayMember = "name";
            this.myProfileActivityBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.myProfileActivityBox.FormattingEnabled = true;
            this.myProfileActivityBox.ItemHeight = 21;
            this.myProfileActivityBox.Location = new System.Drawing.Point(99, 50);
            this.myProfileActivityBox.Margin = new System.Windows.Forms.Padding(4);
            this.myProfileActivityBox.Name = "myProfileActivityBox";
            this.myProfileActivityBox.Size = new System.Drawing.Size(608, 508);
            this.myProfileActivityBox.TabIndex = 49;
            this.myProfileActivityBox.SelectedIndexChanged += new System.EventHandler(this.activityFeedSelectedIndexChanged);
            // 
            // myActivityLabel
            // 
            this.myActivityLabel.AutoSize = true;
            this.myActivityLabel.Location = new System.Drawing.Point(7, 50);
            this.myActivityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myActivityLabel.Name = "myActivityLabel";
            this.myActivityLabel.Size = new System.Drawing.Size(77, 17);
            this.myActivityLabel.TabIndex = 48;
            this.myActivityLabel.Text = "My activity:";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTextBox.Location = new System.Drawing.Point(99, 16);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(625, 22);
            this.statusTextBox.TabIndex = 47;
            // 
            // postStatusLabel
            // 
            this.postStatusLabel.AutoSize = true;
            this.postStatusLabel.Location = new System.Drawing.Point(5, 20);
            this.postStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postStatusLabel.Name = "postStatusLabel";
            this.postStatusLabel.Size = new System.Drawing.Size(84, 17);
            this.postStatusLabel.TabIndex = 46;
            this.postStatusLabel.Text = "Post Status:";
            // 
            // NewsFeedTab
            // 
            this.NewsFeedTab.Controls.Add(this.newsFeedLikeButton);
            this.NewsFeedTab.Controls.Add(this.newsFeedViewComments);
            this.NewsFeedTab.Controls.Add(this.newsFeedCommentBox);
            this.NewsFeedTab.Controls.Add(this.newsFeedCommentButton);
            this.NewsFeedTab.Controls.Add(this.newsFeedActivityBox);
            this.NewsFeedTab.Controls.Add(this.newsfeedLabel);
            this.NewsFeedTab.Location = new System.Drawing.Point(4, 25);
            this.NewsFeedTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewsFeedTab.Name = "NewsFeedTab";
            this.NewsFeedTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewsFeedTab.Size = new System.Drawing.Size(1051, 616);
            this.NewsFeedTab.TabIndex = 1;
            this.NewsFeedTab.Text = "NewsFeed";
            this.NewsFeedTab.UseVisualStyleBackColor = true;
            // 
            // newsFeedLikeButton
            // 
            this.newsFeedLikeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newsFeedLikeButton.Location = new System.Drawing.Point(907, 544);
            this.newsFeedLikeButton.Margin = new System.Windows.Forms.Padding(4);
            this.newsFeedLikeButton.Name = "newsFeedLikeButton";
            this.newsFeedLikeButton.Size = new System.Drawing.Size(135, 57);
            this.newsFeedLikeButton.TabIndex = 62;
            this.newsFeedLikeButton.Text = "Like";
            this.newsFeedLikeButton.UseVisualStyleBackColor = true;
            this.newsFeedLikeButton.Click += new System.EventHandler(this.likeButtonClick);
            // 
            // newsFeedViewComments
            // 
            this.newsFeedViewComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newsFeedViewComments.DisplayMember = "name";
            this.newsFeedViewComments.Font = new System.Drawing.Font("Calibri", 9F);
            this.newsFeedViewComments.FormattingEnabled = true;
            this.newsFeedViewComments.ItemHeight = 18;
            this.newsFeedViewComments.Location = new System.Drawing.Point(747, 27);
            this.newsFeedViewComments.Margin = new System.Windows.Forms.Padding(4);
            this.newsFeedViewComments.Name = "newsFeedViewComments";
            this.newsFeedViewComments.Size = new System.Drawing.Size(295, 454);
            this.newsFeedViewComments.TabIndex = 60;
            this.newsFeedViewComments.SelectedIndexChanged += new System.EventHandler(this.commentFeedSelectedIndexChanged);
            // 
            // newsFeedCommentBox
            // 
            this.newsFeedCommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newsFeedCommentBox.Location = new System.Drawing.Point(747, 514);
            this.newsFeedCommentBox.Margin = new System.Windows.Forms.Padding(4);
            this.newsFeedCommentBox.Name = "newsFeedCommentBox";
            this.newsFeedCommentBox.Size = new System.Drawing.Size(295, 22);
            this.newsFeedCommentBox.TabIndex = 59;
            // 
            // newsFeedCommentButton
            // 
            this.newsFeedCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newsFeedCommentButton.Location = new System.Drawing.Point(747, 545);
            this.newsFeedCommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.newsFeedCommentButton.Name = "newsFeedCommentButton";
            this.newsFeedCommentButton.Size = new System.Drawing.Size(135, 57);
            this.newsFeedCommentButton.TabIndex = 58;
            this.newsFeedCommentButton.Text = "Comment";
            this.newsFeedCommentButton.UseVisualStyleBackColor = true;
            this.newsFeedCommentButton.Click += new System.EventHandler(this.commentButtonClick);
            // 
            // newsFeedActivityBox
            // 
            this.newsFeedActivityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newsFeedActivityBox.DisplayMember = "name";
            this.newsFeedActivityBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.newsFeedActivityBox.FormattingEnabled = true;
            this.newsFeedActivityBox.ItemHeight = 21;
            this.newsFeedActivityBox.Location = new System.Drawing.Point(107, 20);
            this.newsFeedActivityBox.Margin = new System.Windows.Forms.Padding(4);
            this.newsFeedActivityBox.Name = "newsFeedActivityBox";
            this.newsFeedActivityBox.Size = new System.Drawing.Size(608, 550);
            this.newsFeedActivityBox.TabIndex = 57;
            this.newsFeedActivityBox.SelectedIndexChanged += new System.EventHandler(this.activityFeedSelectedIndexChanged);
            // 
            // newsfeedLabel
            // 
            this.newsfeedLabel.AutoSize = true;
            this.newsfeedLabel.Location = new System.Drawing.Point(7, 20);
            this.newsfeedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newsfeedLabel.Name = "newsfeedLabel";
            this.newsfeedLabel.Size = new System.Drawing.Size(98, 17);
            this.newsfeedLabel.TabIndex = 56;
            this.newsfeedLabel.Text = "My news feed:";
            // 
            // inboxTabPage
            // 
            this.inboxTabPage.Controls.Add(this.inboxPage);
            this.inboxTabPage.Location = new System.Drawing.Point(4, 25);
            this.inboxTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inboxTabPage.Name = "inboxTabPage";
            this.inboxTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inboxTabPage.Size = new System.Drawing.Size(1051, 616);
            this.inboxTabPage.TabIndex = 2;
            this.inboxTabPage.Text = "Messages";
            this.inboxTabPage.UseVisualStyleBackColor = true;
            // 
            // friendsTabPage
            // 
            this.friendsTabPage.Controls.Add(this.friendsPage1);
            this.friendsTabPage.Location = new System.Drawing.Point(4, 25);
            this.friendsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.friendsTabPage.Name = "friendsTabPage";
            this.friendsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.friendsTabPage.Size = new System.Drawing.Size(1051, 616);
            this.friendsTabPage.TabIndex = 3;
            this.friendsTabPage.Text = "Friends";
            this.friendsTabPage.UseVisualStyleBackColor = true;
            // 
            // InterestToolTab
            // 
            this.InterestToolTab.Controls.Add(this.comboBox2);
            this.InterestToolTab.Controls.Add(this.numericUpDown1);
            this.InterestToolTab.Controls.Add(this.InterestSetterTimeBoundLabel);
            this.InterestToolTab.Controls.Add(this.InterestedFriendsViewBox);
            this.InterestToolTab.Controls.Add(this.InterestedFriendsLabel);
            this.InterestToolTab.Controls.Add(this.comboBox1);
            this.InterestToolTab.Controls.Add(this.InterestActionsAmount);
            this.InterestToolTab.Controls.Add(this.InterestFrequency);
            this.InterestToolTab.Controls.Add(this.FrequencyOfInterestLabel);
            this.InterestToolTab.Controls.Add(this.InterestAmountLabel);
            this.InterestToolTab.Controls.Add(this.FriendsViewBox);
            this.InterestToolTab.Controls.Add(this.FriendsLabel);
            this.InterestToolTab.Location = new System.Drawing.Point(4, 25);
            this.InterestToolTab.Name = "InterestToolTab";
            this.InterestToolTab.Padding = new System.Windows.Forms.Padding(3);
            this.InterestToolTab.Size = new System.Drawing.Size(1051, 616);
            this.InterestToolTab.TabIndex = 2;
            this.InterestToolTab.Text = "Interest Tool";
            this.InterestToolTab.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Days",
            "Weeks",
            "Months",
            "Years"});
            this.comboBox2.Location = new System.Drawing.Point(637, 89);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 62;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(500, 89);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 61;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // InterestSetterTimeBoundLabel
            // 
            this.InterestSetterTimeBoundLabel.AutoSize = true;
            this.InterestSetterTimeBoundLabel.Location = new System.Drawing.Point(317, 89);
            this.InterestSetterTimeBoundLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InterestSetterTimeBoundLabel.Name = "InterestSetterTimeBoundLabel";
            this.InterestSetterTimeBoundLabel.Size = new System.Drawing.Size(180, 17);
            this.InterestSetterTimeBoundLabel.TabIndex = 60;
            this.InterestSetterTimeBoundLabel.Text = "In items from how long ago:";
            // 
            // InterestedFriendsViewBox
            // 
            this.InterestedFriendsViewBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InterestedFriendsViewBox.DisplayMember = "name";
            this.InterestedFriendsViewBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterestedFriendsViewBox.FormattingEnabled = true;
            this.InterestedFriendsViewBox.ItemHeight = 24;
            this.InterestedFriendsViewBox.Location = new System.Drawing.Point(774, 28);
            this.InterestedFriendsViewBox.Margin = new System.Windows.Forms.Padding(4);
            this.InterestedFriendsViewBox.Name = "InterestedFriendsViewBox";
            this.InterestedFriendsViewBox.Size = new System.Drawing.Size(270, 508);
            this.InterestedFriendsViewBox.TabIndex = 59;
            // 
            // InterestedFriendsLabel
            // 
            this.InterestedFriendsLabel.AutoSize = true;
            this.InterestedFriendsLabel.Location = new System.Drawing.Point(771, 7);
            this.InterestedFriendsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InterestedFriendsLabel.Name = "InterestedFriendsLabel";
            this.InterestedFriendsLabel.Size = new System.Drawing.Size(257, 17);
            this.InterestedFriendsLabel.TabIndex = 58;
            this.InterestedFriendsLabel.Text = "Friends Who Expressed Interest In You:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days"});
            this.comboBox1.Location = new System.Drawing.Point(637, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 57;
            // 
            // InterestActionsAmount
            // 
            this.InterestActionsAmount.Location = new System.Drawing.Point(500, 28);
            this.InterestActionsAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InterestActionsAmount.Name = "InterestActionsAmount";
            this.InterestActionsAmount.Size = new System.Drawing.Size(120, 22);
            this.InterestActionsAmount.TabIndex = 56;
            this.InterestActionsAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // InterestFrequency
            // 
            this.InterestFrequency.Location = new System.Drawing.Point(500, 61);
            this.InterestFrequency.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.InterestFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InterestFrequency.Name = "InterestFrequency";
            this.InterestFrequency.Size = new System.Drawing.Size(120, 22);
            this.InterestFrequency.TabIndex = 54;
            this.InterestFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrequencyOfInterestLabel
            // 
            this.FrequencyOfInterestLabel.AutoSize = true;
            this.FrequencyOfInterestLabel.Location = new System.Drawing.Point(317, 61);
            this.FrequencyOfInterestLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FrequencyOfInterestLabel.Name = "FrequencyOfInterestLabel";
            this.FrequencyOfInterestLabel.Size = new System.Drawing.Size(149, 17);
            this.FrequencyOfInterestLabel.TabIndex = 53;
            this.FrequencyOfInterestLabel.Text = "Frequency Of Interest:";
            // 
            // InterestAmountLabel
            // 
            this.InterestAmountLabel.AutoSize = true;
            this.InterestAmountLabel.Location = new System.Drawing.Point(317, 28);
            this.InterestAmountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InterestAmountLabel.Name = "InterestAmountLabel";
            this.InterestAmountLabel.Size = new System.Drawing.Size(176, 17);
            this.InterestAmountLabel.TabIndex = 52;
            this.InterestAmountLabel.Text = "Amount Of Interest Actions";
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
            this.FriendsViewBox.Size = new System.Drawing.Size(270, 508);
            this.FriendsViewBox.TabIndex = 51;
            // 
            // FriendsLabel
            // 
            this.FriendsLabel.Location = new System.Drawing.Point(0, 0);
            this.FriendsLabel.Name = "FriendsLabel";
            this.FriendsLabel.Size = new System.Drawing.Size(100, 23);
            this.FriendsLabel.TabIndex = 63;
            // 
            // interestCheckTab
            // 
            this.interestCheckTab.Controls.Add(this.interestPage);
            this.interestCheckTab.Location = new System.Drawing.Point(4, 25);
            this.interestCheckTab.Name = "interestCheckTab";
            this.interestCheckTab.Padding = new System.Windows.Forms.Padding(3);
            this.interestCheckTab.Size = new System.Drawing.Size(1051, 616);
            this.interestCheckTab.TabIndex = 4;
            this.interestCheckTab.Text = "Interest Check";
            this.interestCheckTab.UseVisualStyleBackColor = true;
            // 
            // inboxPage
            // 
            this.inboxPage.AutoScroll = true;
            this.inboxPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inboxPage.FacebookApplicationLogicManager = null;
            this.inboxPage.Location = new System.Drawing.Point(3, 2);
            this.inboxPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inboxPage.Name = "inboxPage";
            this.inboxPage.Size = new System.Drawing.Size(1045, 612);
            this.inboxPage.TabIndex = 0;
            // 
            // friendsPage1
            // 
            this.friendsPage1.AutoScroll = true;
            this.friendsPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendsPage1.FacebookApplicationLogicManager = null;
            this.friendsPage1.Location = new System.Drawing.Point(3, 2);
            this.friendsPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.friendsPage1.Name = "friendsPage1";
            this.friendsPage1.Size = new System.Drawing.Size(1045, 612);
            this.friendsPage1.TabIndex = 0;
            // 
            // interestPage
            // 
            this.interestPage.AutoScroll = true;
            this.interestPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interestPage.FacebookApplicationLogicManager = null;
            this.interestPage.Location = new System.Drawing.Point(3, 3);
            this.interestPage.Margin = new System.Windows.Forms.Padding(4);
            this.interestPage.Name = "interestPage";
            this.interestPage.Size = new System.Drawing.Size(1045, 610);
            this.interestPage.TabIndex = 0;
            // 
            // ApplicationTabsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.myProfile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ApplicationTabsForm";
            this.Text = "TabsPage";
            this.myProfile.ResumeLayout(false);
            this.ProfileTab.ResumeLayout(false);
            this.ProfileTab.PerformLayout();
            this.NewsFeedTab.ResumeLayout(false);
            this.NewsFeedTab.PerformLayout();
            this.inboxTabPage.ResumeLayout(false);
            this.friendsTabPage.ResumeLayout(false);
            this.InterestToolTab.ResumeLayout(false);
            this.InterestToolTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestActionsAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestFrequency)).EndInit();
            this.interestCheckTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ProfileTab;
        private System.Windows.Forms.TabPage NewsFeedTab;
        private System.Windows.Forms.ListBox myProfileActivityBox;
        private System.Windows.Forms.Label myActivityLabel;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label postStatusLabel;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.TextBox myProfileCommentBox;
        private System.Windows.Forms.Button myProfileCommentButton;
        private System.Windows.Forms.Button myProfileLikeButton;
        private System.Windows.Forms.ListBox myProfileViewComments;
        private System.Windows.Forms.ListBox newsFeedViewComments;
        private System.Windows.Forms.TextBox newsFeedCommentBox;
        private System.Windows.Forms.Button newsFeedCommentButton;
        private System.Windows.Forms.ListBox newsFeedActivityBox;
        private System.Windows.Forms.Label newsfeedLabel;
        private System.Windows.Forms.Button newsFeedLikeButton;
        private System.Windows.Forms.TabPage InterestToolTab;
        private System.Windows.Forms.ListBox FriendsViewBox;
        private System.Windows.Forms.Label FriendsLabel;
        private System.Windows.Forms.Label FrequencyOfInterestLabel;
        private System.Windows.Forms.Label InterestAmountLabel;
        private System.Windows.Forms.NumericUpDown InterestActionsAmount;
        private System.Windows.Forms.NumericUpDown InterestFrequency;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox InterestedFriendsViewBox;
        private System.Windows.Forms.Label InterestedFriendsLabel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label InterestSetterTimeBoundLabel;
        private System.Windows.Forms.TabPage inboxTabPage;
        private System.Windows.Forms.TabPage friendsTabPage;
        private InboxPage inboxPage;
        private FriendsPage friendsPage1;
        private System.Windows.Forms.TabPage interestCheckTab;
        protected System.Windows.Forms.TabControl myProfile;
        private InterestPage interestPage;
    }
}