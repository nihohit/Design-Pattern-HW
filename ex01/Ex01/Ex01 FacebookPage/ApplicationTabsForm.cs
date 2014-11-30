 ﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using FacebookApplication.Interfaces;

namespace Ex01_FacebookPage
{
    public partial class ApplicationTabsForm : Form
    {
        #region fields

        private readonly IFacebookApplicationManager r_FacebookApplicationManager;
        private readonly User r_User;
        private readonly BasicFacebookFunctionality r_BasicfacebookFunctionality;

        public ApplicationTabsForm(IFacebookApplicationManager i_FacebookApplicationManager)
        {
            InitializeComponent();
            r_FacebookApplicationManager = i_FacebookApplicationManager;
            updateFacebookApplicationManagerInRelevantControls(i_FacebookApplicationManager);
            this.r_BasicfacebookFunctionality = new BasicFacebookFunctionality(i_FacebookApplicationManager.LoggedInUser);
            r_User = i_FacebookApplicationManager.LoggedInUser;
            interestPage.SetUser(r_User);
            switchToProfile();
        }

        private void updateFacebookApplicationManagerInRelevantControls(
            IFacebookApplicationManager i_FacebookApplicationManager)
        {
            inboxPage.FacebookApplicationLogicManager = i_FacebookApplicationManager;
            friendsPage1.FacebookApplicationLogicManager = i_FacebookApplicationManager;
            this.interestPage.FacebookApplicationLogicManager = i_FacebookApplicationManager;
        }

        private void tabIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            switch (myProfile.SelectedTab.TabIndex)
            {
                case 0:
                    this.switchToProfile();
                    break;
                case 1:
                    switchToNewsFeed();
                    break;
                case 2:
                    //inboxPage.FacebookApplicationLogicManager = i_FacebookApplicationManager;
                    break;
                case 3:
                    //friendsPage1.FacebookApplicationLogicManager = i_FacebookApplicationManager;
                    break;
                default:
                    return;
            }
        }

        private void commentButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            this.r_BasicfacebookFunctionality.Comment();
        }

        private void likeButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            this.r_BasicfacebookFunctionality.Like();
        }

        private void activityFeedSelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            this.r_BasicfacebookFunctionality.ActivitySelected();
        }

        private void commentFeedSelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            this.r_BasicfacebookFunctionality.CommentSelected();
        }

        #endregion

        private void buttonSetStatusClick(object i_Sender, EventArgs i_EventArgs)
        {
            r_User.PostStatus(statusTextBox.Text);
            statusTextBox.Clear();
            this.r_BasicfacebookFunctionality.FetchPosts(r_User.Posts);
        }

        private void switchToProfile()
        {
            this.r_BasicfacebookFunctionality.ContextChanged(
                myProfileCommentBox,
                myProfileActivityBox,
                myProfileViewComments,
                myProfileLikeButton,
                myProfileCommentButton);
            this.r_BasicfacebookFunctionality.FetchPosts(r_User.Posts);
        }



        #region newsfeed

        #region Newsfeed

        private void switchToNewsFeed()
        {
            this.r_BasicfacebookFunctionality.ContextChanged(
                newsFeedCommentBox,
                newsFeedActivityBox,
                newsFeedViewComments,
                newsFeedLikeButton,
                newsFeedCommentButton);
            this.r_BasicfacebookFunctionality.FetchPosts(r_User.NewsFeed);
        }

        #endregion
        #endregion
    }
}