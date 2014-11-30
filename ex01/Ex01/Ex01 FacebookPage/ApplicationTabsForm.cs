using System;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using FacebookApplication.Interfaces;

namespace Ex01_FacebookPage
{
    public partial class ApplicationTabsForm : Form
    {
        private readonly IFacebookApplicationManager r_FacebookApplicationManager;
        private readonly User r_User;

        private readonly BasicFacebookLogic r_Logic;

        private readonly List<User> r_FriendsList = new List<User>();

        #endregion

        #region general

        public ApplicationTabsForm(IFacebookApplicationManager i_FacebookApplicationManager)
        {
            InitializeComponent();
            r_FacebookApplicationManager = i_FacebookApplicationManager;
            updateFacebookApplicationManagerInRelevantControls(i_FacebookApplicationManager);
            r_Logic = new BasicFacebookLogic(r_FacebookApplicationManager.LoggedInUser);
            r_User = r_FacebookApplicationManager.LoggedInUser;
            switchToProfile();
        }

        private void updateFacebookApplicationManagerInRelevantControls(IFacebookApplicationManager i_FacebookApplicationManager)
        {
            inboxPage.FacebookApplicationLogicManager = i_FacebookApplicationManager;
            friendsPage1.FacebookApplicationLogicManager = i_FacebookApplicationManager;
        }

        private void fetchFromFacebook()
        {
            r_FacebookApplicationManager.FetchFromFacebook();
        }

        private void tabIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            switch (MyProfile.SelectedTab.TabIndex)
            {
                case 0:
                    this.switchToProfile();
                    break;
                case 1:
                    switchToNewsFeed();
                    break;
                case 2:
                    FriendsViewBox.Invoke(new Action(fetchFriendList));
                    break;
                default:
                return;
            }
        }

        private void commentButtonClick(object i_Sender, EventArgs i_EventArgs)
            {
            r_Logic.Comment();
        }

        private void likeButtonClick(object i_Sender, EventArgs i_EventArgs)
            {
            r_Logic.Like();
        }

        private void activityFeedSelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            r_Logic.ActivitySelected();
        }

        private void commentFeedSelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
            {
            r_Logic.CommentSelected();
                }

        #endregion

        #region my profile

        private void buttonSetStatusClick(object i_Sender, EventArgs i_EventArgs)
                    {
            r_User.PostStatus(StatusTextBox.Text);
            StatusTextBox.Clear();
            r_Logic.FetchPosts(r_User.Posts);
                    }

        private void switchToProfile()
                {
            r_Logic.ContextChanged(
                MyProfileCommentBox,
                MyProfileActivityBox,
                MyProfileViewComments,
                MyProfileLikeButton,
                MyProfileCommentButton);
            r_Logic.FetchPosts(r_User.Posts);
                    }

        #endregion

        #region Newsfeed

        private void switchToNewsFeed()
                {
            r_Logic.ContextChanged(
                NewsFeedCommentBox,
                NewsFeedActivityBox,
                NewsFeedViewComments,
                NewsFeedLikeButton,
                NewsFeedCommentButton);
            r_Logic.FetchPosts(r_User.NewsFeed);
        }

        #endregion

        #region interest setter

        private void fetchFriendList()
        {
            FriendsViewBox.Items.Clear();
            r_FriendsList.Clear();
            r_FriendsList.AddRange(r_User.Friends);
            foreach (var friend in r_FriendsList)
            {
                FriendsViewBox.Items.Add(friend.Name);
            }
        }

        #endregion
    }
}
