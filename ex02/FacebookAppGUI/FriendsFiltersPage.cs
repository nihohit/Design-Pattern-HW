using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookApplication;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookAppGUI
{
    public partial class FriendsFiltersPage : ApplicationTabPage
    {
        public FriendsFiltersPage()
        {
            InitializeComponent();
        }

        protected override Dictionary<eFetchOption, int> GetFetchTypesToFetchWithTheirCollectionLimit()
        {
            Dictionary<eFetchOption, int> typesAndCollectionLimit = new Dictionary<eFetchOption, int> { { eFetchOption.FriendsLists, -1 } };
            return typesAndCollectionLimit;
        }

        protected override void facebookApplicationManager_AfterFetch(object sender, FetchEventArgs e)
        {
            if (e.FetchOption == eFetchOption.All || e.FetchOption == eFetchOption.FriendsLists)
            {
                friendsListsComboBox.UpdateFriendsLists(
                    FiltersFeatureManager.GetRelevantFriendsListsForLoggedinUser());
            }
        }

        protected override void OnFacebookApplicationLogicManagerChanged()
        {
            iFiltersFeatureManagerBindingSource.DataSource = FiltersFeatureManager;
            if (FiltersFeatureManager != null)
            {
                FiltersFeatureManager.FriendFilterAdded += (object sender, EventArgs e) => { iFriendFilterBindingSource.DataSource = (FiltersFeatureManager != null) ? new List<IFriendFilter>(FiltersFeatureManager.LoggedInUserFriendsFiltersManager.FriendsFilters) : null; };
                FiltersFeatureManager.FriendFilterRemoved += (object sender, EventArgs e) => { iFriendFilterBindingSource.DataSource = (FiltersFeatureManager != null) ? new List<IFriendFilter>(FiltersFeatureManager.LoggedInUserFriendsFiltersManager.FriendsFilters) : null; };
            }
        }

        protected override void OnBeforeFacebookApplicationLogicManagerChanging()
        {
            IFiltersFeatureManager oldFiltersFeatureManager =
                iFiltersFeatureManagerBindingSource.DataSource as IFiltersFeatureManager;
            if (oldFiltersFeatureManager != null)
            {
                oldFiltersFeatureManager.FriendFilterAdded -= (object sender, EventArgs e) => { iFriendFilterBindingSource.DataSource = (FiltersFeatureManager != null) ? new List<IFriendFilter>(FiltersFeatureManager.LoggedInUserFriendsFiltersManager.FriendsFilters) : null; };
                oldFiltersFeatureManager.FriendFilterRemoved -= (object sender, EventArgs e) => { iFriendFilterBindingSource.DataSource = (FiltersFeatureManager != null) ? new List<IFriendFilter>(FiltersFeatureManager.LoggedInUserFriendsFiltersManager.FriendsFilters) : null; };
            }
        }

        private void genderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            genderComboBox.Enabled = genderCheckBox.Checked;
        }

        private void friendsFiltersPage_Load(object sender, EventArgs e)
        {
            genderComboBox.DataSource = Enum.GetValues(typeof(User.eGender));
            genderCheckBox.Checked = false;
            ageCheckBox.Checked = false;
            friendsListCheckBox.Checked = false;
        }

        private void addFilterButton_Click(object sender, EventArgs e)
        {
            if (friendsListCheckBox.Checked && friendsListsComboBox.SelectedFriendList == null)
            {
                MessageBox.Show(@"Choose Friend List. (if empty fetch from facebook with the link on page buttom)");
            }
            else
            {
                User.eGender gender;
                Enum.TryParse(genderComboBox.SelectedValue.ToString(), out gender);
                try
                {
                    FriendsFilter newFilter = new FriendsFilter(genderCheckBox.Checked,
                                                   gender,
                                                   addIfGenderNotVisible.Checked,
                                                   ageCheckBox.Checked,
                                                   decimal.ToInt32(minAgeNumericUpDown.Value),
                                                   decimal.ToInt32(maxAgeNumericUpDown.Value),
                                                   addIfAgeNotVisible.Checked,
                                                   friendsListCheckBox.Checked,
                                                   friendsListsComboBox.SelectedFriendList,
                                                   FiltersFeatureManager.LoggedInUserFriendListsManager);

                    FiltersFeatureManager.AddFriendFilter(newFilter);
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

        private void updateFiltersDataSource()
        {
            iFriendFilterBindingSource.DataSource = (FiltersFeatureManager != null) ? new List<IFriendFilter>(FiltersFeatureManager.LoggedInUserFriendsFiltersManager.FriendsFilters) : null;
        }

        private void iFiltersFeatureManagerBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            updateFiltersDataSource();
        }

    }
}
