using System;
using System.Collections.Generic;

namespace FacebookApplication
{
    using FacebookWrapper.ObjectModel;

    public class UserWrapper
    {
        #region private fields

        private readonly object r_Lock = new object();

        private User m_User;

        #endregion private fields

        #region properties

        public static UserWrapper Instance
        {
            get
            {
                return Singleton<UserWrapper>.Instance;
            }
        }

        public IEnumerable<Post> Posts
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        return new Post[0];
                    }

                    return m_User.Posts;
                }
            }
        }

        public IEnumerable<Post> NewsFeed
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        return new Post[0];
                    }

                    return m_User.NewsFeed;
                }
            }
        }

        public IEnumerable<PostedItem> AllActivity
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        return new PostedItem[0];
                    }

                    var currentActivity = new List<PostedItem>();
                    currentActivity.AddRange(m_User.WallPosts);
                    currentActivity.AddRange(m_User.Posts);
                    currentActivity.AddRange(m_User.PostedLinks);
                    currentActivity.AddRange(m_User.Statuses);
                    currentActivity.AddRange(m_User.Albums);
                    currentActivity.AddRange(m_User.Videos);
                    return currentActivity;
                }
            }
        }

        public FacebookObjectCollection<User> Friends
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        throw new ArgumentNullException("User");
                    }

                    return m_User.Friends;
                }
            }
        }

        public FacebookObjectCollection<FriendList> FriendLists
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        throw new ArgumentNullException("User");
                    }

                    return m_User.FriendLists;
                }
            }
        }

        public FacebookObjectCollection<InboxThread> InboxThreads
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        throw new ArgumentNullException("User");
                    }

                    return m_User.InboxThreads;
                }
            }
        }

        public string Id
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        return string.Empty;
                    }

                    return m_User.Id;
                }
            }
        }

        #endregion properties

        #region constructors

        private UserWrapper()
        {
        }

        #endregion constructors

        #region public methods

        public void LoginUser(User i_User)
        {
            lock (r_Lock)
            {
                m_User = i_User;
            }
        }

        public bool LikedByUser(PostedItem i_Item)
        {
            lock (r_Lock)
            {
                return i_Item.LikedBy.Find(i_User => i_User.Id == m_User.Id) != null;
            }
        }

        public bool PostStatus(string i_Status)
        {
            try
            {
                lock (r_Lock)
                {
                    if (!string.IsNullOrWhiteSpace(i_Status) && m_User != null)
                    {
                        m_User.PostStatus(i_Status);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
                return false;
            }

            return true;
        }

        public void ReFetch()
        {
            lock (r_Lock)
            {
                m_User.ReFetch();
            }
        }

        #endregion public methods
    }
}
