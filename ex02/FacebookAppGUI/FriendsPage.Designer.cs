namespace FacebookAppGUI
{
    partial class FriendsPage
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
            this.friendsFiltersComboBox = new FacebookAppGUI.FriendsFiltersComboBox();
            this.friendsListBox = new FacebookAppGUI.FriendsListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // friendsFiltersComboBox
            // 
            this.friendsFiltersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendsFiltersComboBox.FacebookApplicationLogicManager = null;
            this.friendsFiltersComboBox.LabelText = "Filter :";
            this.friendsFiltersComboBox.Location = new System.Drawing.Point(4, 6);
            this.friendsFiltersComboBox.Name = "friendsFiltersComboBox";
            this.friendsFiltersComboBox.Size = new System.Drawing.Size(386, 21);
            this.friendsFiltersComboBox.TabIndex = 0;
            this.friendsFiltersComboBox.FriendsFiltersChanged += new System.EventHandler(this.friendsFiltersComboBox_FriendsFiltersChanged);
            // 
            // friendsListBox
            // 
            this.friendsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendsListBox.Location = new System.Drawing.Point(0, 0);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(238, 184);
            this.friendsListBox.TabIndex = 55;
            this.friendsListBox.CurrentFriendChanged += new System.EventHandler(this.friendsListBox_CurrentFriendChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 33);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.friendsListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxFriend);
            this.splitContainer1.Size = new System.Drawing.Size(387, 184);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 56;
            // 
            // pictureBoxFriend
            // 
            this.pictureBoxFriend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFriend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxFriend.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFriend.Name = "pictureBoxFriend";
            this.pictureBoxFriend.Size = new System.Drawing.Size(145, 184);
            this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFriend.TabIndex = 43;
            this.pictureBoxFriend.TabStop = false;
            // 
            // FriendsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.friendsFiltersComboBox);
            this.Name = "FriendsPage";
            this.Controls.SetChildIndex(this.friendsFiltersComboBox, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FriendsFiltersComboBox friendsFiltersComboBox;
        private FriendsListBox friendsListBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxFriend;
    }
}
