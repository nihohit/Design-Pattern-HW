﻿using System;
using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using FacebookWrapper.ObjectModel;

    public partial class TabsPage : Form
    {
        private readonly User r_User;
        private readonly List<Post> r_CurrentActivityFeed = new List<Post>();
        private readonly List<Comment> r_CurrentCommentView = new List<Comment>();
        private GeoPostedItem m_CurrentlySelectedPost;
        private Comment m_CurrentlySelectedComment;

        private TextBox m_CurrentCommentTextBox;

        private ListBox m_CurrentActivityBox;
        private ListBox m_CurrentCommentViewBox;

        private Button m_CurrentLikeButton;
        private Button m_CurrentUnlikeButton;
        private Button m_CurrentCommentButton;

        public List<Post> CurrentActivityFeed
        {
            get
            {
                return r_CurrentActivityFeed;
            }
        }

        #region general

        public TabsPage(User i_User)
        {
            InitializeComponent();

            r_User = i_User;
            switchToProfile();
            hideRelevantBoxes();
        }

        private void tabIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            m_CurrentlySelectedPost = null;
            m_CurrentlySelectedComment = null;
            switch (MyProfile.SelectedTab.TabIndex)
            {
                case 0:
                    switchToProfile();
                    break;
                case 1:
                    switchToNewsFeed();
                    break;
                default:
                    return;
            }

            hideRelevantBoxes();
        }

        private void hideRelevantBoxes()
        {
            m_CurrentCommentTextBox.Hide();
            m_CurrentCommentButton.Hide();
            m_CurrentLikeButton.Hide();
            m_CurrentUnlikeButton.Hide();
            m_CurrentCommentViewBox.Hide();
        }

        private void commentButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            string text = m_CurrentCommentTextBox.Text;

            Debug.Assert(m_CurrentlySelectedPost != null, "post is null");
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            m_CurrentlySelectedPost.Comment(text);
        }

        private void likeButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            PostedItem item;
            if (m_CurrentlySelectedComment == null)
            {
                Debug.Assert(m_CurrentlySelectedPost != null, "item is null");
                item = m_CurrentlySelectedPost;
            }
            else
            {
                item = m_CurrentlySelectedComment;
            }

            Debug.Assert(!item.LikedBy.Contains(r_User), "item already liked by user");
            item.Like();
            MyProfileLikeButton.Hide();
            myProfileUnlikeButton.Show();
        }

        private void unlikeButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            PostedItem item;
            if (m_CurrentlySelectedComment == null)
            {
                Debug.Assert(m_CurrentlySelectedPost != null, "item is null");
                item = m_CurrentlySelectedPost;
            }
            else
            {
                item = m_CurrentlySelectedComment;
            }

            Debug.Assert(item.LikedBy.Contains(r_User), "item not liked by user");
            item.Unlike();
            MyProfileLikeButton.Show();
            myProfileUnlikeButton.Hide();
        }
        #region list boxes

        private void populateListBox<T>(IEnumerable<T> i_Items, ListBox i_Box) where T : PostedItem
        {
            i_Box.Invoke(new Action(() => invokedPopulateListBox(i_Items, i_Box)));
        }

        private void invokedPopulateListBox<T>(IEnumerable<T> i_Items, ListBox i_Box) where T : PostedItem
        {
            foreach (var activity in i_Items)
            {
                var comment = activity as Comment;
                if (comment != null)
                {
                    i_Box.Items.Add(comment.Message);
                    continue;
                }

                var post = activity as Post;
                if (post != null)
                {
                    if (post.Message != null)
                    {
                        i_Box.Items.Add(post.Message);
                    }
                    else if (post.Caption != null)
                    {
                        i_Box.Items.Add(post.Caption);
                    }
                    else
                    {
                        i_Box.Items.Add(string.Format("[{0}]", post.Type));
                    }

                    continue;
                }

                var status = activity as Status;
                if (status != null)
                {
                    if (status.Message != null)
                    {
                        i_Box.Items.Add(status.Message);
                    }

                    continue;
                }

                var checkin = activity as Checkin;
                if (checkin != null)
                {
                    if (checkin.Message != null)
                    {
                        i_Box.Items.Add(checkin.Message);
                    }

                    continue;
                }

                i_Box.Items.Add(activity);
            }
        }

        private void populateCollectionOfPosts(IEnumerable<Post> i_Posts, ICollection<Post> i_Collection)
        {
            foreach (var post in i_Posts)
            {
                if (post.Message != null)
                {
                    i_Collection.Add(post);
                }
                else if (post.Caption != null)
                {
                    i_Collection.Add(post);
                }
            }
        }

        #endregion

        private bool likedByUser(PostedItem i_Item)
        {
            return i_Item.LikedBy.Contains(r_User);
        }

        private void chooseLikeButtonToDisplay()
        {
            PostedItem item;
            if (m_CurrentlySelectedComment == null)
            {
                if (m_CurrentlySelectedPost == null)
                {
                    m_CurrentLikeButton.Hide();
                    m_CurrentUnlikeButton.Hide();
                    return;
                }

                item = m_CurrentlySelectedPost;
            }
            else
            {
                item = m_CurrentlySelectedComment;
            }

            if (likedByUser(item))
            {
                m_CurrentLikeButton.Hide();
                m_CurrentUnlikeButton.Show();
            }
            else
            {
                m_CurrentLikeButton.Show();
                m_CurrentUnlikeButton.Hide();
            }
        }

        private void activityFeedSelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            m_CurrentlySelectedComment = null;
            m_CurrentlySelectedPost = r_CurrentActivityFeed[m_CurrentActivityBox.SelectedIndex];
            m_CurrentCommentTextBox.Show();
            m_CurrentCommentTextBox.Clear();
            m_CurrentCommentButton.Show();
            chooseLikeButtonToDisplay();
            m_CurrentCommentViewBox.Show();
            m_CurrentCommentViewBox.Items.Clear();
            r_CurrentCommentView.Clear();
            r_CurrentCommentView.AddRange(m_CurrentlySelectedPost.Comments);
            var populateCommentBoxTask = new Task(() => populateListBox(r_CurrentCommentView, m_CurrentCommentViewBox));
            populateCommentBoxTask.Start();
        }

        private void commentFeedSelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            m_CurrentlySelectedComment = r_CurrentCommentView[m_CurrentCommentViewBox.SelectedIndex];
            chooseLikeButtonToDisplay();
        }

        #endregion

        #region my profile

        private void buttonSetStatusClick(object i_Sender, EventArgs i_EventArgs)
        {
            r_User.PostStatus(textBoxStatus.Text);
            textBoxStatus.Clear();
            var fetchItemsTask = new Task(fetchMyPosts);
            fetchItemsTask.Start();
        }

        private void fetchMyPosts()
        {
            MyProfileActivityBox.Items.Clear();
            r_CurrentActivityFeed.Clear();
            populateCollectionOfPosts(r_User.Posts, r_CurrentActivityFeed);
            invokedPopulateListBox(r_CurrentActivityFeed, MyProfileActivityBox);
        }

        private void switchToProfile()
        {
            m_CurrentCommentTextBox = MyProfileCommentBox;
            m_CurrentActivityBox = MyProfileActivityBox;
            m_CurrentCommentButton = MyProfileCommentButton;
            m_CurrentLikeButton = MyProfileLikeButton;
            m_CurrentUnlikeButton = myProfileUnlikeButton;
            m_CurrentCommentViewBox = MyProfileViewComments;
            fetchMyPosts();
        }

        #endregion

        #region newsfeed

        private void fetchNewsFeed()
        {
            NewsFeedActivityBox.Items.Clear();
            r_CurrentActivityFeed.Clear();
            populateCollectionOfPosts(r_User.NewsFeed, r_CurrentActivityFeed);
            invokedPopulateListBox(r_CurrentActivityFeed, NewsFeedActivityBox);
        }

        private void switchToNewsFeed()
        {
            m_CurrentCommentTextBox = NewsFeedCommentBox;
            m_CurrentActivityBox = NewsFeedActivityBox;
            m_CurrentCommentButton = NewsFeedCommentButton;
            m_CurrentLikeButton = NewsFeedLikeButton;
            m_CurrentUnlikeButton = NewsFeedUnlikeButton;
            m_CurrentCommentViewBox = NewsFeedViewComments;
            fetchNewsFeed();
        }

        #endregion
    }
}
