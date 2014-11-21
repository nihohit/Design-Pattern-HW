using System;
using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using FacebookWrapper.ObjectModel;
    using System.Collections.Generic;

    public partial class TabsPage : Form
    {
        private readonly User r_User;
        private FacebookObjectCollection<GeoPostedItem> m_currentActivityFeed;
        private GeoPostedItem m_currentlySelectedItem;

        public TabsPage(User user)
        {
            InitializeComponent();
            this.Shown += (sender, args) => fetchNewsFeed();

            this.r_User = user;
            this.MyProfileCommentBox.Hide();
            this.MyProfileCommentButton.Hide();
            this.MyProfileLikebutton.Hide();
        }

        private void textBoxStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            this.r_User.PostStatus(textBoxStatus.Text);
            var fetchItemsTask = new Task(this.fetchNewsFeed);
            fetchItemsTask.Start();
        }

        private void fetchNewsFeed()
        {
            myActivityFeed.Refresh();
            m_currentActivityFeed = r_User.GetActivity();
            foreach (var activity in m_currentActivityFeed)
            {
                var post = activity as Post;
                if (post != null)
                {
                    if (post.Message != null)
                    {
                        myActivityFeed.Items.Add(post.Message);
                    }
                    else if (post.Caption != null)
                    {
                        myActivityFeed.Items.Add(post.Caption);
                    }
                    continue;
                }

                var status = activity as Status;
                if (status != null)
                {
                    if (status.Message != null)
                    {
                        myActivityFeed.Items.Add(status.Message);
                    }
                    continue;
                }

                var checkin = activity as Checkin;
                if (checkin != null)
                {
                    if (checkin.Message != null)
                    {
                        myActivityFeed.Items.Add(checkin.Message);
                    }
                    continue;
                }
            }
        }

        private void myActivityFeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_currentlySelectedItem = m_currentActivityFeed[myActivityFeed.SelectedIndex];
            this.MyProfileCommentBox.Show();
            this.MyProfileCommentButton.Show();
            this.MyProfileLikebutton.Show();
        }

        private void tabSwitch(object sender, EventArgs e)
        {
            m_currentlySelectedItem = null;
            this.MyProfileCommentBox.Hide();
            this.MyProfileCommentButton.Hide();
            this.MyProfileLikebutton.Hide();
        }

        private void MyProfileCommentButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(m_currentlySelectedItem != null);
            if (string.IsNullOrEmpty(MyProfileCommentBox.Text))
            {
                return;
            }
            m_currentlySelectedItem.Comment(MyProfileCommentBox.Text);
        }

        private void MyProfileLikebutton_Click(object sender, EventArgs e)
        {
            Debug.Assert(m_currentlySelectedItem != null);
            m_currentlySelectedItem.Like();
        }
    }
}
