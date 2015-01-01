﻿namespace FacebookAppGUI
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageNormalPictureBox = new System.Windows.Forms.PictureBox();
            this.iFiltersFeatureManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iFriendFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iFriendFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFiltersFeatureManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFriendFilterBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.imageNormalPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(678, 224);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 56;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.userBindingSource;
            this.listBox1.DisplayMember = "Name";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(319, 224);
            this.listBox1.TabIndex = 56;
            this.listBox1.ValueMember = "ImageNormal";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // imageNormalPictureBox
            // 
            this.imageNormalPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.userBindingSource, "ImageNormal", true));
            this.imageNormalPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageNormalPictureBox.Location = new System.Drawing.Point(0, 0);
            this.imageNormalPictureBox.Name = "imageNormalPictureBox";
            this.imageNormalPictureBox.Size = new System.Drawing.Size(355, 224);
            this.imageNormalPictureBox.TabIndex = 44;
            this.imageNormalPictureBox.TabStop = false;
            // 
            // iFiltersFeatureManagerBindingSource
            // 
            this.iFiltersFeatureManagerBindingSource.DataSource = typeof(FacebookApplication.Interfaces.IFiltersFeatureManager);
            this.iFiltersFeatureManagerBindingSource.CurrentItemChanged += new System.EventHandler(this.iFiltersFeatureManagerBindingSource_CurrentItemChanged);
            // 
            // iFriendFilterBindingSource
            // 
            this.iFriendFilterBindingSource.DataSource = typeof(FacebookApplication.Interfaces.IFriendFilter);
            this.iFriendFilterBindingSource.CurrentChanged += new System.EventHandler(this.iFriendFilterBindingSource_CurrentChanged);
            // 
            // iFriendFilterComboBox
            // 
            this.iFriendFilterComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iFriendFilterComboBox.DataSource = this.iFriendFilterBindingSource;
            this.iFriendFilterComboBox.DisplayMember = "Name";
            this.iFriendFilterComboBox.FormattingEnabled = true;
            this.iFriendFilterComboBox.Location = new System.Drawing.Point(45, 6);
            this.iFriendFilterComboBox.Name = "iFriendFilterComboBox";
            this.iFriendFilterComboBox.Size = new System.Drawing.Size(636, 21);
            this.iFriendFilterComboBox.TabIndex = 57;
            this.iFriendFilterComboBox.ValueMember = "FilterdFriends";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Filter:";
            // 
            // FriendsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iFriendFilterComboBox);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FriendsPage";
            this.Size = new System.Drawing.Size(711, 307);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.iFriendFilterComboBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFiltersFeatureManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFriendFilterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource iFiltersFeatureManagerBindingSource;
        private System.Windows.Forms.BindingSource iFriendFilterBindingSource;
        private System.Windows.Forms.ComboBox iFriendFilterComboBox;
        private System.Windows.Forms.PictureBox imageNormalPictureBox;
        private System.Windows.Forms.Label label1;
    }
}
