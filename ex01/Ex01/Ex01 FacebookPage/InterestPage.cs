using System;

namespace Ex01_FacebookPage
{
    using System.Linq;
    using System.Windows.Forms;

    using FacebookApplication;

    public partial class InterestPage : UserControl
    {
        private readonly InterestChecker r_InterestChecker;

        public InterestPage()
        {
            InitializeComponent();
            this.r_InterestChecker = new InterestChecker();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            var results = this.r_InterestChecker.FindInterestedFriendsNames(
                lastInterestDate.Value,
                Convert.ToInt32(itemAmountToCheck.Value)).ToArray();
            interestedFreindsBox.Items.Clear();
            interestedFreindsBox.Items.AddRange(results);
        }
    }
}
