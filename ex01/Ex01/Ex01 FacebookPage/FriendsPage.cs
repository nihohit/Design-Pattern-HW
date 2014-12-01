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

        protected override void m_FacebookApplicationManager_AfterFetch(object i_Sender, EventArgs e)
        {
            friendsFiltersComboBox.UpdateFriendsFilters();
        }

        protected override void OnFacebookApplicationLogicManagerChanged()
        {
            friendsFiltersComboBox.FacebookApplicationLogicManager = FacebookApplicationLogicManager;
        }

        private void friendsFiltersComboBox_FriendsFiltersChanged(object sender, EventArgs e)
        {
            string usersThatCantBeFilteredMessage;
            IEnumerable<User> friends = FacebookApplicationLogicManager.GetFriends(friendsFiltersComboBox.SelectedFriendFilterId,
                out usersThatCantBeFilteredMessage);
            friendsListBox.UpdateFriends(friends);

        }

        private void friendsListBox_CurrentFriendChanged(object sender, EventArgs e)
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
    }
}
