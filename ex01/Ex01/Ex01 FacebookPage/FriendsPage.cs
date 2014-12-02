using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using FacebookApplication.Interfaces;
using FacebookApplication;

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
            Dictionary<eFetchOption, int> typesAndCollectionLimit = new Dictionary<eFetchOption, int>
                                                                        {
                                                                            {
                                                                                eFetchOption
                                                                                .Friends,
                                                                                Extensions
                                                                                .k_FriendsCollectionLimit
                                                                            }
                                                                        };
            return typesAndCollectionLimit;
        }

        protected override void facebookApplicationManager_AfterFetch(object sender, FetchEventArgs e)
        {
            if (e.FetchOption == eFetchOption.All || e.FetchOption == eFetchOption.Friends)
            {
                friendsFiltersComboBox.UpdateFriendsFilters();
            }

            if (e.FetchOption == eFetchOption.All || e.FetchOption == eFetchOption.Friends)
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
            IEnumerable<User> friends = FacebookApplicationLogicManager.GetFriends(
                friendsFiltersComboBox.SelectedFriendFilterId,
                out usersThatCantBeFilteredMessage);
            friendsListBox.UpdateFriends(friends);
            if (!string.IsNullOrEmpty(usersThatCantBeFilteredMessage))
            {
                usersThatCantBeFilteredMessage.ShowLongMessageBox();
            }
        }
    }
}
