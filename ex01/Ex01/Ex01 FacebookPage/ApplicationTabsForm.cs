using System;
using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using FacebookWrapper.ObjectModel;
using FacebookApplication.Interfaces;

    public partial class ApplicationTabsForm : Form
    {
        private readonly IFacebookApplicationManager r_FacebookApplicationManager;
        private readonly User r_User;
        private readonly List<Post> r_CurrentActivityFeed = new List<Post>();
        private GeoPostedItem m_CurrentlySelectedPost;
        private Comment m_CurrentlySelectedComment;

        public ApplicationTabsForm(IFacebookApplicationManager i_FacebookApplicationManager)
        {
            InitializeComponent();
            r_FacebookApplicationManager = i_FacebookApplicationManager;
            updateFacebookApplicationManagerInRelevantControls(i_FacebookApplicationManager);
            this.Shown += (i_Sender, i_Args) => fetchFromFacebook();
            this.Shown += (i_Sender, i_Args) => fetchNewsFeed();

            this.r_User = r_FacebookApplicationManager.LoggedInUser;
            tabSwitch(null, null);
        }

        private void updateFacebookApplicationManagerInRelevantControls(IFacebookApplicationManager i_FacebookApplicationManager)
        {
            inboxPage.FacebookApplicationLogicManager = i_FacebookApplicationManager;
            friendsPage1.FacebookApplicationLogicManager = i_FacebookApplicationManager;
        }

        private void buttonSetStatusClick(object i_Sender, EventArgs i_EventArgs)
        {
            this.r_User.PostStatus(textBoxStatus.Text);
            var fetchItemsTask = new Task(this.fetchNewsFeed);
            fetchItemsTask.Start();
        }

        private void fetchFromFacebook()
        {
            r_FacebookApplicationManager.FetchFromFacebook();
        }

        private void fetchNewsFeed()
        {
            MyProfileActivityFeed.Items.Clear();
            this.r_CurrentActivityFeed.Clear();
            populateCollectionOfPosts(r_User.Posts, this.r_CurrentActivityFeed);
            invokedPopulateListBox(this.r_CurrentActivityFeed, MyProfileActivityFeed);
        }

        private void myActivityFeedSelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            this.m_CurrentlySelectedPost = this.r_CurrentActivityFeed[MyProfileActivityFeed.SelectedIndex];
            this.MyProfileCommentBox.Show();
            MyProfileCommentBox.Clear();
            this.MyProfileCommentButton.Show();
            chooseLikeButtonToDisplay();
            MyProfileViewComments.Show();
            MyProfileViewComments.Items.Clear();
            var populateCommentBoxTask = new Task(() => populateListBox(this.m_CurrentlySelectedPost.Comments, MyProfileViewComments));
            populateCommentBoxTask.Start();
        }

        private void tabSwitch(object i_Sender, EventArgs i_EventArgs)
        {
            this.m_CurrentlySelectedPost = null;
            this.MyProfileCommentBox.Hide();
            this.MyProfileCommentButton.Hide();
            this.MyProfileLikebutton.Hide();
            this.MyProfileViewComments.Hide();
            myProfileUnlikeButton.Hide();
        }

        private void myProfileCommentButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            Debug.Assert(this.m_CurrentlySelectedPost != null, "item is null");
            if (string.IsNullOrEmpty(MyProfileCommentBox.Text))
            {
                return;
            }

            this.m_CurrentlySelectedPost.Comment(MyProfileCommentBox.Text);
        }

        private void myProfileLikebuttonClick(object i_Sender, EventArgs i_EventArgs)
        {
            PostedItem item;
            if (m_CurrentlySelectedComment == null)
            {
                Debug.Assert(this.m_CurrentlySelectedPost != null, "item is null");
                item = this.m_CurrentlySelectedPost;
            }
            else
            {
                item = m_CurrentlySelectedComment;
            }
            Debug.Assert(!item.LikedBy.Contains(r_User), "item already liked by user");
            bool check = item.Like();
            MyProfileLikebutton.Hide();
            myProfileUnlikeButton.Show();
        }

        private void myProfileUnlikeButtonClick(object sender, EventArgs e)
        {
            PostedItem item;
            if (m_CurrentlySelectedComment == null)
            {
                Debug.Assert(this.m_CurrentlySelectedPost != null, "item is null");
                item = this.m_CurrentlySelectedPost;
            }
            else
            {
                item = m_CurrentlySelectedComment;
            }
            Debug.Assert(item.LikedBy.Contains(r_User), "item not liked by user");
            bool check = item.Unlike();
            MyProfileLikebutton.Show();
            myProfileUnlikeButton.Hide();
        }

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

        private bool likedByUser(PostedItem item)
        {
            return item.LikedBy.Contains(r_User);
        }

        private void chooseLikeButtonToDisplay()
        {
            PostedItem item;
            if (m_CurrentlySelectedComment == null)
            {
                if (m_CurrentlySelectedPost == null)
                {
                    MyProfileLikebutton.Hide();
                    myProfileUnlikeButton.Hide();
                    return;
                }
                item = this.m_CurrentlySelectedPost;
            }
            else
            {
                item = m_CurrentlySelectedComment;
            }
            if (this.likedByUser(item))
            {
                MyProfileLikebutton.Hide();
                myProfileUnlikeButton.Show();
            }
            else
            {
                MyProfileLikebutton.Show();
                myProfileUnlikeButton.Hide();
            }
        }

    }
}
