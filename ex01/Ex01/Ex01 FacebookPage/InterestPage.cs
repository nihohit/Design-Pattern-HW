using System;

namespace Ex01_FacebookPage
{
    using System.Linq;

    using FacebookApplication;

    using FacebookWrapper.ObjectModel;

    public partial class InterestPage : ApplicationTabPage
    {
        private InterestChecker m_InterestChecker;

        public InterestPage()
        {
            InitializeComponent();
        }

        protected override void m_FacebookApplicationManager_AfterFetch(object sender, EventArgs e)
        {
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
