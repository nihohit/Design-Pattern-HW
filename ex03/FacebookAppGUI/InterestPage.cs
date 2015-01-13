using System;

namespace FacebookAppGUI
{
    using System.Linq;
    using System.Threading.Tasks;
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
            checkInterest().Start();
        }

        private Task checkInterest()
        {
            return new Task(
                () =>
                {
                    string[] results =
                        this.r_InterestChecker.FindInterestedFriendsNames(
                            lastInterestDate.Value,
                            () => UserWrapper.Instance.AllActivity(Convert.ToInt32(itemAmountToCheck.Value)))
                            .ToArray();
                    interestedFreindsBox.Invoke(new Action(() => 
                        {
                            interestedFreindsBox.Items.Clear();
                            interestedFreindsBox.Items.AddRange(results);
                        }));
                });
        }
    }
}
