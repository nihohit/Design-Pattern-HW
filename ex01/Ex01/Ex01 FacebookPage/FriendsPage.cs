using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookApplication;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    public partial class FriendsPage : ApplicationTabPage
    {
        public FriendsPage()
        {
            InitializeComponent();
        }
        
        protected override Dictionary<eFetchOption, int> GetFetchTypesToFetchWithTheirCollectionLimit()
        {
            Dictionary<eFetchOption, int> typesAndCollectionLimit = new Dictionary<eFetchOption, int>();
            typesAndCollectionLimit.Add(FacebookApplication.Interfaces.eFetchOption.Friends, Extensions.sc_FriendsCollectionLimit);
            return typesAndCollectionLimit;
        }

        protected override void m_FacebookApplicationManager_AfterFetch(object i_Sender, FetchEventArgs e)
        {
            if (e.r_FetchOption == eFetchOption.All || e.r_FetchOption == eFetchOption.Friends)
            {
                friendsFiltersComboBox.UpdateFriendsFilters();
            }

            if (e.r_FetchOption == eFetchOption.All || e.r_FetchOption == eFetchOption.Friends)
            {
                friendsFiltersComboBox.UpdateFriendsFilters();
            }
        }

        protected override void OnFacebookApplicationLogicManagerChanged()
        {
            friendsFiltersComboBox.FacebookApplicationLogicManager = FacebookApplicationLogicManager;
        }

        private void friendsFiltersComboBox_FriendsFiltersChanged(object sender, EventArgs e)
        {
            updateFriendsList();
        }

        private void friendsListBox_CurrentFriendChanged(object sender, EventArgs e)
        {
            updatePictureBoxFriend();
        }

        private void updatePictureBoxFriend()
        {
            User selectedFriend = friendsListBox.SelectedFriend;
            if (selectedFriend != null && selectedFriend.PictureNormalURL != null)
            {
                pictureBoxFriend.LoadAsync(selectedFriend.PictureNormalURL);
            }
            else
            {
                pictureBoxFriend.Image = pictureBoxFriend.ErrorImage;
            }
        }

        private void updateFriendsList()
        {
            string usersThatCantBeFilteredMessage = null;
            IEnumerable<User> friends = FacebookApplicationLogicManager.GetFriends(friendsFiltersComboBox.SelectedFriendFilterId,
                out usersThatCantBeFilteredMessage);
            friendsListBox.UpdateFriends(friends);
            if (!string.IsNullOrEmpty(usersThatCantBeFilteredMessage))
            {
               usersThatCantBeFilteredMessage.ShowLongMessageBox();
            }
        }
    }
}
