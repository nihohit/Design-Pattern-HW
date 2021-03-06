namespace FacebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using FacebookWrapper.ObjectModel;

    public class BasicFacebookFunctionality
    {
        #region private fields

        private readonly List<Post> r_CurrentActivityFeed = new List<Post>();

        private readonly List<Comment> r_CurrentCommentView = new List<Comment>();

        private GeoPostedItem m_CurrentlySelectedPost;

        private Comment m_CurrentlySelectedComment;

        private TextBox m_CurrentCommentTextBox;

        private ListBox m_CurrentActivityBox;

        private ListBox m_CurrentCommentViewBox;

        private Button m_CurrentLikeButton;

        private Button m_CurrentCommentButton;

        #endregion private fields

        #region general methods

        public void ContextChanged(
            TextBox i_WriteComment,
            ListBox i_Activity,
            ListBox i_CommentsView,
            Button i_LikeButton,
            Button i_CommentButton)
        {
            this.m_CurrentlySelectedPost = null;
            this.m_CurrentlySelectedComment = null;
            this.m_CurrentCommentTextBox = i_WriteComment;
            this.m_CurrentActivityBox = i_Activity;
            this.m_CurrentCommentViewBox = i_CommentsView;
            this.m_CurrentLikeButton = i_LikeButton;
            this.m_CurrentCommentButton = i_CommentButton;
            this.HideContextualObjects();
        }

        public void HideContextualObjects()
        {
            this.m_CurrentCommentTextBox.Hide();
            this.m_CurrentCommentButton.Hide();
            this.m_CurrentLikeButton.Hide();
            this.m_CurrentCommentViewBox.Hide();
        }

        public void CommentSelected()
        {
            this.m_CurrentlySelectedComment = this.r_CurrentCommentView[this.m_CurrentCommentViewBox.SelectedIndex];
        }

        public void Comment()
        {
            string text = this.m_CurrentCommentTextBox.Text;

            Debug.Assert(this.m_CurrentlySelectedPost != null, "post is null");
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            this.m_CurrentlySelectedPost.Comment(text);
            this.ActivitySelected();
        }

        public void ActivitySelected()
        {
            this.m_CurrentlySelectedComment = null;
            this.m_CurrentlySelectedPost = this.r_CurrentActivityFeed[this.m_CurrentActivityBox.SelectedIndex];
            this.m_CurrentCommentTextBox.Show();
            this.m_CurrentCommentTextBox.Clear();
            this.m_CurrentCommentButton.Show();
            this.m_CurrentLikeButton.Show();
            this.m_CurrentCommentViewBox.Show();
            this.m_CurrentCommentViewBox.Items.Clear();
            this.r_CurrentCommentView.Clear();
            this.r_CurrentCommentView.AddRange(this.m_CurrentlySelectedPost.Comments);
            var populateCommentBoxTask = new Task(() => this.populateListBox(this.r_CurrentCommentView, this.m_CurrentCommentViewBox));
            populateCommentBoxTask.Start();
        }

        #endregion general methods

        #region my profile

        public void FetchPosts(IEnumerable<Post> i_Posts)
        {
            this.m_CurrentActivityBox.Items.Clear();
            this.r_CurrentActivityFeed.Clear();
            this.populateCollectionOfPosts(i_Posts, this.r_CurrentActivityFeed);
            this.invokedPopulateListBox(this.r_CurrentActivityFeed, this.m_CurrentActivityBox);
        }

        #endregion

        #region private methods

        #region list boxes

        private void populateListBox<T>(IEnumerable<T> i_Items, ListBox i_Box) where T : PostedItem
        {
            i_Box.Invoke(new Action(() => this.invokedPopulateListBox(i_Items, i_Box)));
        }

        private void invokedPopulateListBox<T>(IEnumerable<T> i_Items, ListBox i_Box) where T : PostedItem
        {
            i_Box.Items.AddRange(
                i_Items.Select(i_Item => "{0}: {1}"
                    .FormatWith(i_Item.From.Name, this.itemToString(i_Item)))
                    .ToArray());
        }

        private string itemToString<T>(T i_Item)
        {
            var comment = i_Item as Comment;
            if (comment != null)
            {
                return comment.Message;
            }

            var post = i_Item as Post;
            if (post != null)
            {
                if (post.Message != null)
                {
                    return post.Message;
                }

                if (post.Caption != null)
                {
                    return post.Caption;
                }

                return string.Format("[{0}]", post.Type);
            }

            var status = i_Item as Status;
            if (status != null)
            {
                if (status.Message != null)
                {
                    return status.Message;
                }
            }

            var checkin = i_Item as Checkin;
            if (checkin != null)
            {
                if (checkin.Message != null)
                {
                    return checkin.Message;
                }
            }

            return i_Item.ToString();
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

        public void Like()
        {
            PostedItem item;
            if (this.m_CurrentlySelectedComment == null)
            {
                Debug.Assert(this.m_CurrentlySelectedPost != null, "item is null");
                item = this.m_CurrentlySelectedPost;
            }
            else
            {
                item = this.m_CurrentlySelectedComment;
            }

            try
            {
                if (UserWrapper.Instance.LikedByUser(item))
                {
                    item.Unlike();
                }
                else
                {
                    item.Like();
                }
            }
            catch (InvalidCastException)
            {
                // The like/unlike actions are faulty and throw exceptions without the try/catch pattern.
            }

            item.ReFetch();
        }

        #endregion

        #endregion
    }
}
