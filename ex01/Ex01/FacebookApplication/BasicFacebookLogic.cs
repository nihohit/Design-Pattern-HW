using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    using System.Linq;

    using FacebookApplication;

    public class BasicFacebookLogic
    {
        #region private fields

        private readonly List<Post> r_CurrentActivityFeed = new List<Post>();

        private readonly List<Comment> r_CurrentCommentView = new List<Comment>();

        private readonly User r_User;

        private GeoPostedItem m_CurrentlySelectedPost;

        private Comment m_CurrentlySelectedComment;

        private TextBox m_CurrentCommentTextBox;

        private ListBox m_CurrentActivityBox;

        private ListBox m_CurrentCommentViewBox;

        private Button m_CurrentLikeButton;

        private Button m_CurrentCommentButton;

        #endregion private fields

        #region constructors

        public BasicFacebookLogic(User i_User)
        {
            r_User = i_User;
        }

        #endregion constructors

        #region general methods

        public void ContextChanged(
            TextBox i_WriteComment,
            ListBox i_Activity,
            ListBox i_CommentsView,
            Button i_LikeButton,
            Button i_CommentButton)
        {
            m_CurrentlySelectedPost = null;
            m_CurrentlySelectedComment = null;
            m_CurrentCommentTextBox = i_WriteComment;
            m_CurrentActivityBox = i_Activity;
            m_CurrentCommentViewBox = i_CommentsView;
            m_CurrentLikeButton = i_LikeButton;
            m_CurrentCommentButton = i_CommentButton;
            this.HideContextualObjects();
        }

        public void HideContextualObjects()
        {
            m_CurrentCommentTextBox.Hide();
            m_CurrentCommentButton.Hide();
            m_CurrentLikeButton.Hide();
            m_CurrentCommentViewBox.Hide();
        }

        public void CommentSelected()
        {
            m_CurrentlySelectedComment = r_CurrentCommentView[m_CurrentCommentViewBox.SelectedIndex];
        }

        public void Comment()
        {
            string text = m_CurrentCommentTextBox.Text;

            Debug.Assert(m_CurrentlySelectedPost != null, "post is null");
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            m_CurrentlySelectedPost.Comment(text);
            ActivitySelected();
        }

        public void ActivitySelected()
        {
            m_CurrentlySelectedComment = null;
            m_CurrentlySelectedPost = r_CurrentActivityFeed[m_CurrentActivityBox.SelectedIndex];
            m_CurrentCommentTextBox.Show();
            m_CurrentCommentTextBox.Clear();
            m_CurrentCommentButton.Show();
            m_CurrentLikeButton.Show();
            m_CurrentCommentViewBox.Show();
            m_CurrentCommentViewBox.Items.Clear();
            r_CurrentCommentView.Clear();
            r_CurrentCommentView.AddRange(m_CurrentlySelectedPost.Comments);
            var populateCommentBoxTask = new Task(() => populateListBox(r_CurrentCommentView, m_CurrentCommentViewBox));
            populateCommentBoxTask.Start();
        }

        #endregion general methods

        #region my profile

        public void FetchPosts(IEnumerable<Post> i_Posts)
        {
            m_CurrentActivityBox.Items.Clear();
            r_CurrentActivityFeed.Clear();
            populateCollectionOfPosts(i_Posts, r_CurrentActivityFeed);
            invokedPopulateListBox(r_CurrentActivityFeed, m_CurrentActivityBox);
        }

        #endregion

        #region private methods

        private bool likedByUser(PostedItem i_Item)
        {
            return i_Item.LikedBy.Find(i_User => i_User.Id == r_User.Id) != null;
        }

        #region list boxes

        private void populateListBox<T>(IEnumerable<T> i_Items, ListBox i_Box) where T : PostedItem
        {
            i_Box.Invoke(new Action(() => invokedPopulateListBox(i_Items, i_Box)));
        }

        private void invokedPopulateListBox<T>(IEnumerable<T> i_Items, ListBox i_Box) where T : PostedItem
        {
            i_Box.Items.AddRange(
                i_Items.Select(i_Item => "{0}: {1}"
                    .FormatWith(i_Item.From.Name, itemToString(i_Item)))
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
            if (m_CurrentlySelectedComment == null)
            {
                Debug.Assert(m_CurrentlySelectedPost != null, "item is null");
                item = m_CurrentlySelectedPost;
            }
            else
            {
                item = m_CurrentlySelectedComment;
            }

            try
            {
                if (likedByUser(item))
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
