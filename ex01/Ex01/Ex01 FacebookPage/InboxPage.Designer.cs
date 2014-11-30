namespace Ex01_FacebookPage
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
            this.friendsListsCombo = new Ex01_FacebookPage.FriendsListsComboBox();
            this.inboxMessagesListBox = new Ex01_FacebookPage.MessagesListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectedMessageTextBox = new System.Windows.Forms.TextBox();
            this.massagesLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // friendsListsCombo
            // 
            this.friendsListsCombo.Location = new System.Drawing.Point(3, 3);
            this.friendsListsCombo.Name = "friendsListsCombo";
            this.friendsListsCombo.Size = new System.Drawing.Size(394, 21);
            this.friendsListsCombo.TabIndex = 55;
            this.friendsListsCombo.FriendsListChanged += new System.EventHandler(this.friendsListsCombo_FriendsListChanged);
            // 
            // inboxMessagesListBox
            // 
            this.inboxMessagesListBox.AutoScroll = true;
            this.inboxMessagesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inboxMessagesListBox.Location = new System.Drawing.Point(3, 3);
            this.inboxMessagesListBox.Name = "inboxMessagesListBox";
            this.inboxMessagesListBox.Size = new System.Drawing.Size(181, 163);
            this.inboxMessagesListBox.TabIndex = 56;
            this.inboxMessagesListBox.CurrentInboxThreadChanged += new System.EventHandler(this.inboxMessagesListBox_CurrentInboxThreadChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.inboxMessagesListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectedMessageTextBox, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 169);
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // selectedMessageTextBox
            // 
            this.selectedMessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedMessageTextBox.Location = new System.Drawing.Point(210, 3);
            this.selectedMessageTextBox.Multiline = true;
            this.selectedMessageTextBox.Name = "selectedMessageTextBox";
            this.selectedMessageTextBox.ReadOnly = true;
            this.selectedMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.selectedMessageTextBox.Size = new System.Drawing.Size(181, 163);
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
            // InboxPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.massagesLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.friendsListsCombo);
            this.Name = "InboxPage";
            this.Controls.SetChildIndex(this.friendsListsCombo, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.massagesLabel, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FriendsListsComboBox friendsListsCombo;
        private MessagesListBox inboxMessagesListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox selectedMessageTextBox;
        private System.Windows.Forms.Label massagesLabel;


    }
}
