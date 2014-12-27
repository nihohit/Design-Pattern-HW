 ﻿using System;
using System.Windows.Forms;
using FacebookApplication.Interfaces;

namespace FacebookAppGUI
{
    using FacebookApplication;

    public partial class FormApplicationTabs : Form
    {
        #region fields

        private readonly BasicFacebookFunctionality r_BasicfacebookFunctionality;

        public FormApplicationTabs(IFiltersFicherManager i_FacebookApplicationManager)
        {
            InitializeComponent();
            updateFacebookApplicationManagerInRelevantControls(i_FacebookApplicationManager);
            this.r_BasicfacebookFunctionality = new BasicFacebookFunctionality();
            switchToProfile();
        }

        private void updateFacebookApplicationManagerInRelevantControls(
            IFiltersFicherManager i_FacebookApplicationManager)
        {
            inboxPage.FacebookApplicationLogicManager = i_FacebookApplicationManager;
            friendsPage1.FacebookApplicationLogicManager = i_FacebookApplicationManager;
            friendsFiltersPage.FacebookApplicationLogicManager = i_FacebookApplicationManager;
        }

        private void tab_IndexChanged(object sender, EventArgs e)
        {
            switch (myProfile.SelectedTab.TabIndex)
            {
                case 0:
                    this.switchToProfile();
                    break;
                case 1:
                    switchToNewsFeed();
                    break;
                default:
                    return;
            }
        }

        private void commentButton_Click(object sender, EventArgs e)
        {
            this.r_BasicfacebookFunctionality.Comment();
        }

        private void likeButton_Click(object sender, EventArgs e)
        {
            this.r_BasicfacebookFunctionality.Like();
        }

        private void activityFeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.r_BasicfacebookFunctionality.ActivitySelected();
        }

        private void commentFeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.r_BasicfacebookFunctionality.CommentSelected();
        }

        #endregion

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            if (UserWrapper.Instance.PostStatus(statusTextBox.Text))
            {
                statusTextBox.Clear();
                this.r_BasicfacebookFunctionality.FetchPosts(UserWrapper.Instance.Posts);
            }
        }

        private void switchToProfile()
        {
            this.r_BasicfacebookFunctionality.ContextChanged(
                myProfileCommentBox,
                myProfileActivityBox,
                myProfileViewComments,
                myProfileLikeButton,
                myProfileCommentButton);
            this.r_BasicfacebookFunctionality.FetchPosts(UserWrapper.Instance.Posts);
        }

        private void switchToNewsFeed()
        {
            this.r_BasicfacebookFunctionality.ContextChanged(
                newsFeedCommentBox,
                newsFeedActivityBox,
                newsFeedViewComments,
                newsFeedLikeButton,
                newsFeedCommentButton);
            this.r_BasicfacebookFunctionality.FetchPosts(UserWrapper.Instance.NewsFeed);
        }
    }
}