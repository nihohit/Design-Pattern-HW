namespace FacebookAppGUI
{
    partial class FriendsFiltersPage
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
            this.filtersListBox = new System.Windows.Forms.ListBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.genderCheckBox = new System.Windows.Forms.CheckBox();
            this.ageCheckBox = new System.Windows.Forms.CheckBox();
            this.friendsListCheckBox = new System.Windows.Forms.CheckBox();
            this.addFilterButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.friendsListsComboBox = new FacebookAppGUI.FriendsListsComboBox();
            this.filterNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addIfAgeNotVisible = new System.Windows.Forms.CheckBox();
            this.addIfGenderNotVisible = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxAgeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAgeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // filtersListBox
            // 
            this.filtersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersListBox.FormattingEnabled = true;
            this.filtersListBox.Location = new System.Drawing.Point(4, 155);
            this.filtersListBox.Name = "filtersListBox";
            this.filtersListBox.Size = new System.Drawing.Size(457, 56);
            this.filtersListBox.TabIndex = 55;
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Location = new System.Drawing.Point(79, 32);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(265, 21);
            this.genderComboBox.TabIndex = 59;
            this.genderComboBox.Text = "Male";
            // 
            // genderCheckBox
            // 
            this.genderCheckBox.AutoSize = true;
            this.genderCheckBox.Checked = true;
            this.genderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.genderCheckBox.Location = new System.Drawing.Point(3, 34);
            this.genderCheckBox.Name = "genderCheckBox";
            this.genderCheckBox.Size = new System.Drawing.Size(61, 17);
            this.genderCheckBox.TabIndex = 58;
            this.genderCheckBox.Text = "Gender";
            this.genderCheckBox.UseVisualStyleBackColor = true;
            this.genderCheckBox.CheckedChanged += new System.EventHandler(this.genderCheckBox_CheckedChanged);
            // 
            // ageCheckBox
            // 
            this.ageCheckBox.AutoSize = true;
            this.ageCheckBox.Checked = true;
            this.ageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ageCheckBox.Location = new System.Drawing.Point(4, 68);
            this.ageCheckBox.Name = "ageCheckBox";
            this.ageCheckBox.Size = new System.Drawing.Size(48, 17);
            this.ageCheckBox.TabIndex = 60;
            this.ageCheckBox.Text = "Age ";
            this.ageCheckBox.UseVisualStyleBackColor = true;
            this.ageCheckBox.CheckedChanged += new System.EventHandler(this.ageCheckBox_CheckedChanged);
            // 
            // friendsListCheckBox
            // 
            this.friendsListCheckBox.AutoSize = true;
            this.friendsListCheckBox.Checked = true;
            this.friendsListCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.friendsListCheckBox.Location = new System.Drawing.Point(3, 103);
            this.friendsListCheckBox.Name = "friendsListCheckBox";
            this.friendsListCheckBox.Size = new System.Drawing.Size(76, 17);
            this.friendsListCheckBox.TabIndex = 62;
            this.friendsListCheckBox.Text = "Member of";
            this.friendsListCheckBox.UseVisualStyleBackColor = true;
            this.friendsListCheckBox.CheckedChanged += new System.EventHandler(this.friendsListCheckBox_CheckedChanged);
            // 
            // addFilterButton
            // 
            this.addFilterButton.Location = new System.Drawing.Point(3, 126);
            this.addFilterButton.Name = "addFilterButton";
            this.addFilterButton.Size = new System.Drawing.Size(97, 23);
            this.addFilterButton.TabIndex = 64;
            this.addFilterButton.Text = "Add filter";
            this.addFilterButton.UseVisualStyleBackColor = true;
            this.addFilterButton.Click += new System.EventHandler(this.addFilterButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.maxAgeNumericUpDown);
            this.panel1.Controls.Add(this.minAgeNumericUpDown);
            this.panel1.Location = new System.Drawing.Point(79, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 34);
            this.panel1.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "years";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "years to :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "from :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "from :";
            // 
            // maxAgeNumericUpDown
            // 
            this.maxAgeNumericUpDown.Location = new System.Drawing.Point(144, 8);
            this.maxAgeNumericUpDown.Name = "maxAgeNumericUpDown";
            this.maxAgeNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.maxAgeNumericUpDown.TabIndex = 1;
            this.maxAgeNumericUpDown.Value = new decimal(new int[] {
            38,
            0,
            0,
            0});
            // 
            // minAgeNumericUpDown
            // 
            this.minAgeNumericUpDown.Location = new System.Drawing.Point(42, 8);
            this.minAgeNumericUpDown.Name = "minAgeNumericUpDown";
            this.minAgeNumericUpDown.Size = new System.Drawing.Size(40, 20);
            this.minAgeNumericUpDown.TabIndex = 0;
            this.minAgeNumericUpDown.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // friendsListsComboBox
            // 
            this.friendsListsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendsListsComboBox.LabelText = "";
            this.friendsListsComboBox.Location = new System.Drawing.Point(79, 99);
            this.friendsListsComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.friendsListsComboBox.Name = "friendsListsComboBox";
            this.friendsListsComboBox.Size = new System.Drawing.Size(382, 21);
            this.friendsListsComboBox.TabIndex = 66;
            // 
            // filterNameTextBox
            // 
            this.filterNameTextBox.Location = new System.Drawing.Point(79, 6);
            this.filterNameTextBox.Name = "filterNameTextBox";
            this.filterNameTextBox.Size = new System.Drawing.Size(265, 20);
            this.filterNameTextBox.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Filter Name :";
            // 
            // addIfAgeNotVisible
            // 
            this.addIfAgeNotVisible.AutoSize = true;
            this.addIfAgeNotVisible.Checked = true;
            this.addIfAgeNotVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addIfAgeNotVisible.Location = new System.Drawing.Point(350, 59);
            this.addIfAgeNotVisible.Name = "addIfAgeNotVisible";
            this.addIfAgeNotVisible.Size = new System.Drawing.Size(103, 17);
            this.addIfAgeNotVisible.TabIndex = 71;
            this.addIfAgeNotVisible.Text = "Add if not visible";
            this.addIfAgeNotVisible.UseVisualStyleBackColor = true;
            // 
            // addIfGenderNotVisible
            // 
            this.addIfGenderNotVisible.AutoSize = true;
            this.addIfGenderNotVisible.Checked = true;
            this.addIfGenderNotVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addIfGenderNotVisible.Location = new System.Drawing.Point(350, 32);
            this.addIfGenderNotVisible.Name = "addIfGenderNotVisible";
            this.addIfGenderNotVisible.Size = new System.Drawing.Size(103, 17);
            this.addIfGenderNotVisible.TabIndex = 72;
            this.addIfGenderNotVisible.Text = "Add if not visible";
            this.addIfGenderNotVisible.UseVisualStyleBackColor = true;
            // 
            // FriendsFiltersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addIfGenderNotVisible);
            this.Controls.Add(this.addIfAgeNotVisible);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.filterNameTextBox);
            this.Controls.Add(this.friendsListsComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addFilterButton);
            this.Controls.Add(this.friendsListCheckBox);
            this.Controls.Add(this.ageCheckBox);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.genderCheckBox);
            this.Controls.Add(this.filtersListBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FriendsFiltersPage";
            this.Size = new System.Drawing.Size(470, 250);
            this.Load += new System.EventHandler(this.friendsFiltersPage_Load);
            this.Controls.SetChildIndex(this.filtersListBox, 0);
            this.Controls.SetChildIndex(this.genderCheckBox, 0);
            this.Controls.SetChildIndex(this.genderComboBox, 0);
            this.Controls.SetChildIndex(this.ageCheckBox, 0);
            this.Controls.SetChildIndex(this.friendsListCheckBox, 0);
            this.Controls.SetChildIndex(this.addFilterButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.friendsListsComboBox, 0);
            this.Controls.SetChildIndex(this.filterNameTextBox, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.addIfAgeNotVisible, 0);
            this.Controls.SetChildIndex(this.addIfGenderNotVisible, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxAgeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAgeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox filtersListBox;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.CheckBox genderCheckBox;
        private System.Windows.Forms.CheckBox ageCheckBox;
        private System.Windows.Forms.CheckBox friendsListCheckBox;
        private System.Windows.Forms.Button addFilterButton;
        private System.Windows.Forms.Panel panel1;
        private FriendsListsComboBox friendsListsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxAgeNumericUpDown;
        private System.Windows.Forms.NumericUpDown minAgeNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filterNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox addIfAgeNotVisible;
        private System.Windows.Forms.CheckBox addIfGenderNotVisible;
    }
}
