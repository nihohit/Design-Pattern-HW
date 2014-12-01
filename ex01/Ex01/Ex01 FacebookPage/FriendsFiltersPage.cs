using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    public partial class FriendsFiltersPage : ApplicationTabPage
    {
        public FriendsFiltersPage()
        {
            InitializeComponent();
        }

        protected override void m_FacebookApplicationManager_AfterFetch(object i_Sender, EventArgs e)
        {
            friendsListsComboBox.UpdateFriendsLists(
                FacebookApplicationLogicManager.GetRelevantFriendsListsForLoggedinUser());
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
        }

        private void addFilterButton_Click(object sender, EventArgs e)
        {
            User.eGender gender;
            Enum.TryParse<User.eGender>(genderComboBox.SelectedValue.ToString(), out gender);
            FacebookApplicationLogicManager.AddFriendFilter(textBox1.Text, genderCheckBox.Checked, gender,
                ageCheckBox.Checked, Decimal.ToInt32(minAgeNumericUpDown.Value),
                Decimal.ToInt32(maxAgeNumericUpDown.Value), friendsListCheckBox.Checked,
                friendsListsComboBox.SelectedFriendList);

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
