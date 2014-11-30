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
            this.MyProfileViewComments = new System.Windows.Forms.ListBox();
            this.MyProfileCommentBox = new System.Windows.Forms.TextBox();
            this.MyProfileCommentButton = new System.Windows.Forms.Button();
            this.MyProfileLikeButton = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.MyProfileActivityBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NewsFeedTab = new System.Windows.Forms.TabPage();
            this.NewsFeedLikeButton = new System.Windows.Forms.Button();
            this.NewsFeedViewComments = new System.Windows.Forms.ListBox();
            this.NewsFeedCommentBox = new System.Windows.Forms.TextBox();
            this.NewsFeedCommentButton = new System.Windows.Forms.Button();
            this.NewsFeedActivityBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inboxTabPage = new System.Windows.Forms.TabPage();
            this.inboxPage = new Ex01_FacebookPage.InboxPage();
            this.friendsTabPage = new System.Windows.Forms.TabPage();
            this.friendsPage1 = new Ex01_FacebookPage.FriendsPage();
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
            this.MyProfile.SuspendLayout();
            this.ProfileTab.SuspendLayout();
            this.NewsFeedTab.SuspendLayout();
            this.inboxTabPage.SuspendLayout();
            this.friendsTabPage.SuspendLayout();
            this.InterestToolTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestActionsAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestFrequency)).BeginInit();
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
            this.MyProfile.Location = new System.Drawing.Point(3, 14);
            this.MyProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.ProfileTab.Controls.Add(this.StatusTextBox);
            this.ProfileTab.Controls.Add(this.label3);
            this.ProfileTab.Location = new System.Drawing.Point(4, 25);
            this.ProfileTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProfileTab.Name = "ProfileTab";
            this.ProfileTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.MyProfileViewComments.Font = new System.Drawing.Font("Calibri", 9F);
            this.MyProfileViewComments.FormattingEnabled = true;
            this.MyProfileViewComments.ItemHeight = 18;
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
            this.MyProfileActivityBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.MyProfileActivityBox.FormattingEnabled = true;
            this.MyProfileActivityBox.ItemHeight = 21;
            this.MyProfileActivityBox.Location = new System.Drawing.Point(99, 50);
            this.MyProfileActivityBox.Margin = new System.Windows.Forms.Padding(4);
            this.MyProfileActivityBox.Name = "MyProfileActivityBox";
            this.MyProfileActivityBox.Size = new System.Drawing.Size(608, 508);
            this.MyProfileActivityBox.TabIndex = 49;
            this.MyProfileActivityBox.SelectedIndexChanged += new System.EventHandler(this.activityFeedSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "My activity:";
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusTextBox.Location = new System.Drawing.Point(99, 16);
            this.StatusTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(625, 22);
            this.StatusTextBox.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 20);
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
            this.NewsFeedTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewsFeedTab.Name = "NewsFeedTab";
            this.NewsFeedTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewsFeedTab.Size = new System.Drawing.Size(1051, 616);
            this.NewsFeedTab.TabIndex = 1;
            this.NewsFeedTab.Text = "NewsFeed";
            this.NewsFeedTab.UseVisualStyleBackColor = true;
            // 
            // NewsFeedLikeButton
            // 
            this.NewsFeedLikeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedLikeButton.Location = new System.Drawing.Point(907, 544);
            this.NewsFeedLikeButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedLikeButton.Name = "NewsFeedLikeButton";
            this.NewsFeedLikeButton.Size = new System.Drawing.Size(135, 57);
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
            this.NewsFeedViewComments.Font = new System.Drawing.Font("Calibri", 9F);
            this.NewsFeedViewComments.FormattingEnabled = true;
            this.NewsFeedViewComments.ItemHeight = 18;
            this.NewsFeedViewComments.Location = new System.Drawing.Point(747, 27);
            this.NewsFeedViewComments.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedViewComments.Name = "NewsFeedViewComments";
            this.NewsFeedViewComments.Size = new System.Drawing.Size(295, 454);
            this.NewsFeedViewComments.TabIndex = 60;
            this.NewsFeedViewComments.SelectedIndexChanged += new System.EventHandler(this.commentFeedSelectedIndexChanged);
            // 
            // NewsFeedCommentBox
            // 
            this.NewsFeedCommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedCommentBox.Location = new System.Drawing.Point(747, 514);
            this.NewsFeedCommentBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedCommentBox.Name = "NewsFeedCommentBox";
            this.NewsFeedCommentBox.Size = new System.Drawing.Size(295, 22);
            this.NewsFeedCommentBox.TabIndex = 59;
            // 
            // NewsFeedCommentButton
            // 
            this.NewsFeedCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsFeedCommentButton.Location = new System.Drawing.Point(747, 545);
            this.NewsFeedCommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedCommentButton.Name = "NewsFeedCommentButton";
            this.NewsFeedCommentButton.Size = new System.Drawing.Size(135, 57);
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
            this.NewsFeedActivityBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.NewsFeedActivityBox.FormattingEnabled = true;
            this.NewsFeedActivityBox.ItemHeight = 21;
            this.NewsFeedActivityBox.Location = new System.Drawing.Point(107, 20);
            this.NewsFeedActivityBox.Margin = new System.Windows.Forms.Padding(4);
            this.NewsFeedActivityBox.Name = "NewsFeedActivityBox";
            this.NewsFeedActivityBox.Size = new System.Drawing.Size(608, 550);
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
            // ApplicationTabsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 660);
            this.Controls.Add(this.MyProfile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ApplicationTabsForm";
            this.Text = "TabsPage";
            this.MyProfile.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MyProfile;
        private System.Windows.Forms.TabPage ProfileTab;
        private System.Windows.Forms.TabPage NewsFeedTab;
        private System.Windows.Forms.ListBox MyProfileActivityBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StatusTextBox;
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
    }
}