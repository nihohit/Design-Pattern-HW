using System;
using System.Collections.Generic;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    using System.Threading.Tasks;

    public class UserWrapper
    {
        #region private fields

        private readonly object r_Lock = new object();

        private User m_User;

        #endregion private fields

        #region Events

        public event EventHandler BeforeLoggin;

        public event EventHandler AfterLoggin;

        #endregion Events

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
                if (m_User == null)
                {
                    lock (r_Lock)
                    {
                        if (m_User == null)
                        {
                            return new Post[0];
                        }
                    }
                }

                return m_User.Posts;
            }
        }

        public IEnumerable<Post> NewsFeed
        {
            get
            {
                if (m_User == null)
                {
                    lock (r_Lock)
                    {
                        if (m_User == null)
                        {
                            return new Post[0];
                        }
                    }
                }

                return m_User.NewsFeed;
            }
        }

        public IEnumerable<IEnumerable<PostedItem>> AllActivityStreams
        {
            get
            {
                lock (r_Lock)
                {
                    if (m_User == null)
                    {
                        return new IEnumerable<PostedItem>[0];
                    }

                    List<IEnumerable<PostedItem>> currentActivity = new List<IEnumerable<PostedItem>>();
                    currentActivity.Add(m_User.WallPosts);
                    currentActivity.Add(m_User.Posts);
                    currentActivity.Add(m_User.PostedLinks);
                    currentActivity.Add(m_User.Statuses);
                    currentActivity.Add(m_User.Albums);
                    currentActivity.Add(m_User.Videos);
                    return currentActivity;
                }
            }
        }

        public FacebookObjectCollection<User> Friends
        {
            get
            {
                if (m_User == null)
                {
                    lock (r_Lock)
                    {
                        if (m_User == null)
                        {
                            throw new ArgumentNullException("m_User");
                        }
                    }
                }

                return m_User.Friends;
            }
        }

        public FacebookObjectCollection<FriendList> FriendLists
        {
            get
            {
                if (m_User == null)
                {
                    lock (r_Lock)
                    {
                        if (m_User == null)
                        {
                            throw new ArgumentNullException("m_User");
                        }
                    }
                }

                return m_User.FriendLists;
            }
        }

        public FacebookObjectCollection<InboxThread> InboxThreads
        {
            get
            {
                if (m_User == null)
                {
                    lock (r_Lock)
                    {
                        if (m_User == null)
                        {
                            throw new ArgumentNullException("m_User");
                        }
                    }
                }

                return m_User.InboxThreads;
            }
        }

        public string Id
        {
            get
            {
                string returnValue = string.Empty;
                lock (r_Lock)
                {
                    if (m_User != null)
                    {
                        returnValue = m_User.Id;
                    }
                }

                return returnValue;
            }
        }

        #endregion properties

        #region constructors

        private UserWrapper()
        {
        }

        #endregion constructors

        #region public methods

        public void LoginUser(string i_AppId, params string[] i_Permissions)
        {
            if (BeforeLoggin != null)
            {
                BeforeLoggin(this, new EventArgs());
            }

            lock (r_Lock)
            {
                m_User = null;
                LoginResult result = FacebookService.Login(i_AppId, i_Permissions);
                if (!string.IsNullOrEmpty(result.AccessToken))
                {
                    m_User = result.LoggedInUser;
                }
                else
                {
                    throw new FacebookOAuthException(result.ErrorMessage);
                }
            }

            if (AfterLoggin != null)
            {
                AfterLoggin(this, new EventArgs());
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

            ReFetch();

            return true;
        }

        public Task<bool> PostStatusAsync(string i_Status)
        {
            return new Task<bool>(() => this.PostStatus(i_Status));
        }

        public void ReFetch()
        {
            lock (r_Lock)
            {
                m_User.ReFetch();
            }
        }

        public IEnumerable<PostedItem> AllActivity(int i_AmountOfItemsFromEachStream)
        {
            int currentLimit = FacebookService.s_CollectionLimit;
            FacebookService.s_CollectionLimit = i_AmountOfItemsFromEachStream;
            ReFetch();
            var iteratorCreator = new UserActivityIteratorCreator(AllActivityStreams);
            FacebookService.s_CollectionLimit = currentLimit;
            return iteratorCreator;
        }

        #endregion public methods
    }
}
