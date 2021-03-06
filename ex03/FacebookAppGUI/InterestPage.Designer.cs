namespace FacebookAppGUI
{
    partial class InterestPage
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
            this.lastInterestDate = new System.Windows.Forms.DateTimePicker();
            this.interestedFreindsBox = new System.Windows.Forms.ListBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.Label();
            this.itemAmountToCheck = new System.Windows.Forms.NumericUpDown();
            this.warningLabel = new System.Windows.Forms.Label();
            this.checkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemAmountToCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // lastInterestDate
            // 
            this.lastInterestDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lastInterestDate.Location = new System.Drawing.Point(158, 22);
            this.lastInterestDate.Name = "lastInterestDate";
            this.lastInterestDate.Size = new System.Drawing.Size(102, 22);
            this.lastInterestDate.TabIndex = 0;
            this.lastInterestDate.Value = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            // 
            // interestedFreindsBox
            // 
            this.interestedFreindsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interestedFreindsBox.DisplayMember = "name";
            this.interestedFreindsBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.interestedFreindsBox.FormattingEnabled = true;
            this.interestedFreindsBox.ItemHeight = 21;
            this.interestedFreindsBox.Location = new System.Drawing.Point(267, 22);
            this.interestedFreindsBox.Margin = new System.Windows.Forms.Padding(4);
            this.interestedFreindsBox.Name = "interestedFreindsBox";
            this.interestedFreindsBox.Size = new System.Drawing.Size(257, 361);
            this.interestedFreindsBox.TabIndex = 55;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(3, 22);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(149, 17);
            this.fromLabel.TabIndex = 56;
            this.fromLabel.Text = "Interest in posts since:";
            // 
            // amountBox
            // 
            this.amountBox.AutoSize = true;
            this.amountBox.Location = new System.Drawing.Point(3, 51);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(252, 17);
            this.amountBox.TabIndex = 57;
            this.amountBox.Text = "Amount of posts of each kind to check:";
            // 
            // itemAmountToCheck
            // 
            this.itemAmountToCheck.Location = new System.Drawing.Point(6, 88);
            this.itemAmountToCheck.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.itemAmountToCheck.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.itemAmountToCheck.Name = "itemAmountToCheck";
            this.itemAmountToCheck.Size = new System.Drawing.Size(47, 22);
            this.itemAmountToCheck.TabIndex = 58;
            this.itemAmountToCheck.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(68, 90);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(166, 17);
            this.warningLabel.TabIndex = 59;
            this.warningLabel.Text = "(Can affect performance)";
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(6, 117);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(100, 29);
            this.checkButton.TabIndex = 60;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "This check takes a couple of seconds.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 62;
            this.label2.Text = "Please be patient.";
            // 
            // InterestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.itemAmountToCheck);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.interestedFreindsBox);
            this.Controls.Add(this.lastInterestDate);
            this.Name = "InterestPage";
            this.Size = new System.Drawing.Size(548, 405);
            ((System.ComponentModel.ISupportInitialize)(this.itemAmountToCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker lastInterestDate;
        private System.Windows.Forms.ListBox interestedFreindsBox;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label amountBox;
        private System.Windows.Forms.NumericUpDown itemAmountToCheck;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
