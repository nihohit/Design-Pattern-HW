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
            this.components = new System.ComponentModel.Container();
            this.selectedMessageTextBox = new System.Windows.Forms.TextBox();
            this.massagesLabel = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.inboxThreadDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iFriendFilterComboBox = new System.Windows.Forms.ComboBox();
            this.iFriendFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iFiltersFeatureManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inboxThreadDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFriendFilterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFiltersFeatureManagerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedMessageTextBox
            // 
            this.selectedMessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedMessageTextBox.Location = new System.Drawing.Point(0, 0);
            this.selectedMessageTextBox.Multiline = true;
            this.selectedMessageTextBox.Name = "selectedMessageTextBox";
            this.selectedMessageTextBox.ReadOnly = true;
            this.selectedMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.selectedMessageTextBox.Size = new System.Drawing.Size(407, 282);
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
            this.splitContainer.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.selectedMessageTextBox);
            this.splitContainer.Size = new System.Drawing.Size(632, 282);
            this.splitContainer.SplitterDistance = 221;
            this.splitContainer.TabIndex = 61;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.inboxThreadDisplayBindingSource;
            this.listBox1.DisplayMember = "InboxThreadDisplayName";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(221, 282);
            this.listBox1.TabIndex = 57;
            this.listBox1.ValueMember = "InboxThreadDisplayName";
            // 
            // inboxThreadDisplayBindingSource
            // 
            this.inboxThreadDisplayBindingSource.DataSource = typeof(FacebookAppGUI.InboxThreadDisplay);
            // 
            // iFriendFilterComboBox
            // 
            this.iFriendFilterComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iFriendFilterComboBox.DataSource = this.iFriendFilterBindingSource;
            this.iFriendFilterComboBox.DisplayMember = "Name";
            this.iFriendFilterComboBox.FormattingEnabled = true;
            this.iFriendFilterComboBox.Location = new System.Drawing.Point(234, 7);
            this.iFriendFilterComboBox.Name = "iFriendFilterComboBox";
            this.iFriendFilterComboBox.Size = new System.Drawing.Size(401, 21);
            this.iFriendFilterComboBox.TabIndex = 62;
            this.iFriendFilterComboBox.ValueMember = "FilterdFriends";
            // 
            // iFriendFilterBindingSource
            // 
            this.iFriendFilterBindingSource.DataSource = typeof(FacebookApplication.Interfaces.IFriendFilter);
            this.iFriendFilterBindingSource.CurrentChanged += new System.EventHandler(this.iFriendFilterBindingSource_CurrentChanged);
            this.iFriendFilterBindingSource.CurrentItemChanged += new System.EventHandler(this.iFriendFilterBindingSource_CurrentChanged);
            // 
            // iFiltersFeatureManagerBindingSource
            // 
            this.iFiltersFeatureManagerBindingSource.DataSource = typeof(FacebookApplication.Interfaces.IFiltersFeatureManager);
            this.iFiltersFeatureManagerBindingSource.CurrentItemChanged += new System.EventHandler(this.iFiltersFeatureManagerBindingSource_CurrentItemChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show conversation that include a member in:";
            // 
            // InboxPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iFriendFilterComboBox);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.massagesLabel);
            this.Name = "InboxPage";
            this.Size = new System.Drawing.Size(658, 375);
            this.Controls.SetChildIndex(this.massagesLabel, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.Controls.SetChildIndex(this.iFriendFilterComboBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inboxThreadDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFriendFilterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFiltersFeatureManagerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox selectedMessageTextBox;
        private System.Windows.Forms.Label massagesLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox iFriendFilterComboBox;
        private System.Windows.Forms.BindingSource iFriendFilterBindingSource;
        private System.Windows.Forms.BindingSource iFiltersFeatureManagerBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource inboxThreadDisplayBindingSource;


    }
}
