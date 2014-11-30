using System;

namespace Ex01_FacebookPage
{
    using System.Linq;
    using System.Windows.Forms;

    using FacebookApplication;

    using FacebookWrapper.ObjectModel;

    public partial class InterestPage : UserControl
    {
        private InterestChecker m_InterestChecker;

        public InterestPage()
        {
            InitializeComponent();
        }

        public void SetUser(User i_User)
        {
            if (m_InterestChecker != null)
            {
                throw new Exception("Interest checker already initialised.");
            }

            m_InterestChecker = new InterestChecker(i_User);
        }

        private void checkButtonClick(object sender, EventArgs e)
        {
            var results = m_InterestChecker.FindInterestedFriendsNames(lastInterestDate.Value,
                Convert.ToInt32(itemAmountToCheck.Value)).ToArray();
            interestedFreindsBox.Items.Clear();
            interestedFreindsBox.Items.AddRange(results);
        }
    }
}
