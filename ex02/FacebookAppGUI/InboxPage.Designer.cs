namespace FacebookAppGUI
{
    partial class InboxPage
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
            this.inboxMessagesListBox = new FacebookAppGUI.MessagesListBox();
            this.selectedMessageTextBox = new System.Windows.Forms.TextBox();
            this.massagesLabel = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.friendsFiltersCombo = new FacebookAppGUI.FriendsFiltersComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // inboxMessagesListBox
            // 
            this.inboxMessagesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inboxMessagesListBox.Location = new System.Drawing.Point(0, 0);
            this.inboxMessagesListBox.Name = "inboxMessagesListBox";
            this.inboxMessagesListBox.Size = new System.Drawing.Size(217, 296);
            this.inboxMessagesListBox.TabIndex = 56;
            this.inboxMessagesListBox.CurrentInboxThreadChanged += new System.EventHandler(this.inboxMessagesListBox_CurrentInboxThreadChanged);
            // 
            // selectedMessageTextBox
            // 
            this.selectedMessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedMessageTextBox.Location = new System.Drawing.Point(0, 0);
            this.selectedMessageTextBox.Multiline = true;
            this.selectedMessageTextBox.Name = "selectedMessageTextBox";
            this.selectedMessageTextBox.ReadOnly = true;
            this.selectedMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.selectedMessageTextBox.Size = new System.Drawing.Size(431, 296);
            this.selectedMessageTextBox.TabIndex = 59;
            // 
            // massagesLabel
            // 
            this.massagesLabel.AutoSize = true;
            this.massagesLabel.Location = new System.Drawing.Point(3, 32);
            this.massagesLabel.Name = "massagesLabel";
            this.massagesLabel.Size = new System.Drawing.Size(188, 13);
            this.massagesLabel.TabIndex = 60;
            this.massagesLabel.Text = "(click on convertion to view it\'s details)";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(3, 48);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.inboxMessagesListBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.selectedMessageTextBox);
            this.splitContainer.Size = new System.Drawing.Size(652, 296);
            this.splitContainer.SplitterDistance = 217;
            this.splitContainer.TabIndex = 61;
            // 
            // friendsFiltersCombo
            // 
            this.friendsFiltersCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendsFiltersCombo.FacebookApplicationLogicManager = null;
            this.friendsFiltersCombo.LabelText = "Show conversation that include a member in:";
            this.friendsFiltersCombo.Location = new System.Drawing.Point(3, 3);
            this.friendsFiltersCombo.Name = "friendsFiltersCombo";
            this.friendsFiltersCombo.Size = new System.Drawing.Size(653, 21);
            this.friendsFiltersCombo.TabIndex = 55;
            this.friendsFiltersCombo.FriendsFiltersChanged += new System.EventHandler(this.friendsListsCombo_FriendsFiltersChanged);
            // 
            // InboxPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.massagesLabel);
            this.Controls.Add(this.friendsFiltersCombo);
            this.Name = "InboxPage";
            this.Size = new System.Drawing.Size(658, 377);
            this.Controls.SetChildIndex(this.friendsFiltersCombo, 0);
            this.Controls.SetChildIndex(this.massagesLabel, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MessagesListBox inboxMessagesListBox;
        private System.Windows.Forms.TextBox selectedMessageTextBox;
        private System.Windows.Forms.Label massagesLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private FriendsFiltersComboBox friendsFiltersCombo;


    }
}
