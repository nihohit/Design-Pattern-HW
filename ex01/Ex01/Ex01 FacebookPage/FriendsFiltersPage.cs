using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookApplication;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    public partial class FriendsFiltersPage : ApplicationTabPage
    {
        public FriendsFiltersPage()
        {
            InitializeComponent();
        }
        
        protected override Dictionary<eFetchOption, int> GetFetchTypesToFetchWithTheirCollectionLimit()
        {
            Dictionary<eFetchOption, int> typesAndCollectionLimit = new Dictionary<eFetchOption, int>();
            typesAndCollectionLimit.Add(FacebookApplication.Interfaces.eFetchOption.FriendsLists, -1);
            return typesAndCollectionLimit;
        }
        
        protected override void m_FacebookApplicationManager_AfterFetch(object i_Sender, FetchEventArgs e)
        {
            if (e.r_FetchOption == eFetchOption.All || e.r_FetchOption == eFetchOption.FriendsLists)
            {
                friendsListsComboBox.UpdateFriendsLists(
                    FacebookApplicationLogicManager.GetRelevantFriendsListsForLoggedinUser());
            }
        }

        protected override void OnFacebookApplicationLogicManagerChanged()
        {
            friendsListsComboBox.UpdateFriendsLists(
                FacebookApplicationLogicManager.GetRelevantFriendsListsForLoggedinUser());
            FacebookApplicationLogicManager.FriendFilterAdded += FacebookApplicationLogicManager_CheckedChanged;
        }

        protected override void OnBeforeFacebookApplicationLogicManagerChanging()
        {
            FacebookApplicationLogicManager.FriendFilterAdded -= FacebookApplicationLogicManager_CheckedChanged;
        }

        private void genderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            genderComboBox.Enabled = genderCheckBox.Checked;
        }

        private void FriendsFiltersPage_Load(object sender, EventArgs e)
        {
            genderComboBox.DataSource = Enum.GetValues(typeof(User.eGender));
            genderCheckBox.Checked = false;
            ageCheckBox.Checked = false;
            friendsListCheckBox.Checked = false;
        }

        private void addFilterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filterNameTextBox.Text))
            {
                MessageBox.Show("Enter filter name");
            }
            else if (friendsListCheckBox.Checked && friendsListsComboBox.SelectedFriendList == null)
            {
                MessageBox.Show("Choose Friend List. (if empty fetch from facebook with the link on page buttom)");
            }
            else if (!friendsListCheckBox.Checked && !genderCheckBox.Checked && !ageCheckBox.Checked)
            {
                MessageBox.Show("Choose a filter");
            }
            else
            {
                User.eGender gender;
                Enum.TryParse<User.eGender>(genderComboBox.SelectedValue.ToString(), out gender);
                try
                {
                    FacebookApplicationLogicManager.AddFriendFilter(
                        filterNameTextBox.Text, 
                        genderCheckBox.Checked, 
                        gender,
                        ageCheckBox.Checked,
                        decimal.ToInt32(minAgeNumericUpDown.Value),
                        decimal.ToInt32(maxAgeNumericUpDown.Value), 
                        friendsListCheckBox.Checked,
                        friendsListsComboBox.SelectedFriendList);
                }
                catch (Exception exception)
                {
                    exception.ShowErrorMessageBox();
                }
            }
        }

        private void ageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = ageCheckBox.Checked;
        }

        private void friendsListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            friendsListsComboBox.Enabled = friendsListCheckBox.Checked;
        }

        private void FacebookApplicationLogicManager_CheckedChanged(object sender, EventArgs e)
        {
            updateFiltersLists();
        }

        private void updateFiltersLists()
        {
            filtersListBox.Items.Clear();
            foreach (string friendFiltersId in FacebookApplicationLogicManager.GetFriendFiltersIds())
            {
                filtersListBox.Items.Add(FacebookApplicationLogicManager.GetFriendFilterDisplayString(friendFiltersId));
            }
        }
    }
}
