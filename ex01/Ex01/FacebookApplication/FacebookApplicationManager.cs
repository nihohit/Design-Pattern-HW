using Facebook;
using FacebookApplication.Interfaces;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication
{
    public class FacebookApplicationManager : IFacebookApplicationManager
    {
        #region members
        #endregion members
        #region Events
        #region IFacebookApplicationManager
        public event EventHandler AfterReset;
        public event EventHandler AfterLoggin;
        public event EventHandler AfterFetch;
        #endregion IFacebookApplicationManager
        #endregion Events
        #region Properties
        #region IFacebookApplicationManager

        public User LoggedInUser { get; private set; }

        public IFriendsFetcher LoggedInUserFriendsFetcher { get; private set; }

        public IFriendListsManager LoggedInUserFriendListsManager { get; private set; }

        public IInboxManager LoggedInUserInboxManager { get; private set; }

        #endregion IFacebookApplicationManager
        #endregion Properties
        #region constructor

        public FacebookApplicationManager()
        {
            TimeSpan minIntervalBetweenFetchActions = TimeSpan.FromSeconds(10);
            LoggedInUser = null;
            LoggedInUserFriendsFetcher = new FriendsFetcher(minIntervalBetweenFetchActions);
            LoggedInUserFriendListsManager = new FriendListsManager(minIntervalBetweenFetchActions);
            LoggedInUserInboxManager = new InboxManager(LoggedInUserFriendListsManager, minIntervalBetweenFetchActions);
        }
        #endregion constructor
        #region public methods
        #region IFacebookApplicationManager
        public void LoginUser(string i_AppId, params string[] i_Permissions)
        {
            Reset();
            LoginResult result = FacebookService.Login(i_AppId, i_Permissions);
            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                LoggedInUser = result.LoggedInUser;

            }
            else
            {
                throw new FacebookOAuthException(result.ErrorMessage);
            }

            FetchFromFacebook();
            if (AfterLoggin != null)
            {
                AfterLoggin(this, new EventArgs());
            }
        }

        public void Reset()
        {
            LoggedInUser = null;
            LoggedInUserFriendListsManager.ResetFetchDetails();
            if (AfterReset != null)
            {
                AfterReset(this, new EventArgs());
            }
        }

        public void FetchFromFacebook()
        {
            int friendsCollectionLimit = 1000;
            int origCollectionLimit = FacebookService.s_CollectionLimit;
            FacebookService.s_CollectionLimit = friendsCollectionLimit;
            LoggedInUserFriendsFetcher.Fetch(LoggedInUser);
            LoggedInUserFriendListsManager.Fetch(LoggedInUser);
            FacebookService.s_CollectionLimit = origCollectionLimit;
            LoggedInUserInboxManager.Fetch(LoggedInUser);
            if (AfterFetch != null)
            {
                AfterFetch(this, new EventArgs());
            }
        }

        public FriendList CreateFriendList(string i_Name, IEnumerable<User> i_Members)
        {
            return LoggedInUserFriendListsManager.CreateFriendList(i_Name, i_Members);
        }

        public IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser()
        {
            return LoggedInUserFriendListsManager.GetRelevantFriendsListsForLoggedinUser();
        }
        
        public string GetInboxThreadFriendsNames(string i_InboxThreadId)
        {
            return LoggedInUserInboxManager.GetInboxThreadFriendsNames(i_InboxThreadId);
        }
        
        public string GetInboxThreadDisplayString(string i_InboxThreadId)
        {
            return LoggedInUserInboxManager.GetInboxThreadDisplayString(i_InboxThreadId);
        }

        public IEnumerable<InboxThread> GetAllInboxThreads()
        {
            return LoggedInUserInboxManager.GetAllInboxThreads();
        }

        public IEnumerable<InboxThread> GetInboxThreadsForSpecificFriendList(FriendList i_FriendList)
        {
            return LoggedInUserInboxManager.GetInboxThreadsForSpecificFriendList(i_FriendList);
        }

        public IEnumerable<User> GetFriends(IEnumerable<IUsersFilter> i_filters, out Dictionary<Exception, FacebookObjectCollection<User>> o_UsersThatThrowException)
        {
            return LoggedInUserFriendsFetcher.GetFriends(i_filters, out o_UsersThatThrowException);
        }
        #endregion IFacebookApplicationManager
        #endregion public methods
        #region private methods
        #endregion private methods
    }
}
