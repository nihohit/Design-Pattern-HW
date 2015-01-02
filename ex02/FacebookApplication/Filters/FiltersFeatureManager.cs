using System;
using System.Collections.Generic;
using Facebook;
using FacebookApplication.Interfaces;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FiltersFeatureManager : IFiltersFeatureManager
    {
        #region members
        
        #endregion members
        #region Events
        #region IFacebookApplicationManager

        public event EventHandler<FetchEventArgs> AfterFetch;

        public event EventHandler FriendFilterAdded
        {
            add { LoggedInUserFriendsFiltersManager.FilterAdded += value; }
            remove { LoggedInUserFriendsFiltersManager.FilterAdded -= value; }
        }

        public event EventHandler FriendFilterRemoved
        {
            add { LoggedInUserFriendsFiltersManager.FilterRmoved += value; }
            remove { LoggedInUserFriendsFiltersManager.FilterRmoved -= value; }
        }

        #endregion IFacebookApplicationManager
        #endregion Events
        #region Properties
        #region IFacebookApplicationManager

        public IFriendsFetcher LoggedInUserFriendsFetcher { get; private set; }

        public IFriendListsManager LoggedInUserFriendListsManager { get; private set; }

        public IInboxManager LoggedInUserInboxManager { get; private set; }

        public IFriendsFiltersManager LoggedInUserFriendsFiltersManager { get; private set; }

        #endregion IFacebookApplicationManager
        #endregion Properties
        #region constructor

        public FiltersFeatureManager()
        {
            TimeSpan minIntervalBetweenFetchActions = TimeSpan.FromSeconds(30);
            LoggedInUserFriendsFetcher = new FriendsFetcher(minIntervalBetweenFetchActions);
            LoggedInUserFriendListsManager = new FriendListsManager(minIntervalBetweenFetchActions);
            LoggedInUserInboxManager = new InboxManager(minIntervalBetweenFetchActions);
            LoggedInUserFriendsFiltersManager = new FriendsFiltersManager(LoggedInUserFriendsFetcher, minIntervalBetweenFetchActions);
            LoggedInUserFriendsFiltersManager.AddFriendFilter(new FriendsFilter());
        }
        #endregion constructor
        #region public methods
        #region IFacebookApplicationManager

        public void FetchFromFacebook(eFetchOption i_FetchOption)
        {
            FetchFromFacebook(i_FetchOption, -1);
        }

        public void FetchFromFacebook(eFetchOption i_FetchOption, int i_CollectionLimit)
        {
            int origCollectionLimit = FacebookService.s_CollectionLimit;
            if (i_CollectionLimit > 0)
            {
                FacebookService.s_CollectionLimit = i_CollectionLimit;
            }

            if (i_FetchOption == eFetchOption.All || i_FetchOption == eFetchOption.Friends)
            {
                LoggedInUserFriendsFetcher.Fetch();
                LoggedInUserFriendsFiltersManager.Fetch();
            }

            if (i_FetchOption == eFetchOption.All || i_FetchOption == eFetchOption.FriendsLists)
            {
                LoggedInUserFriendListsManager.Fetch();
            }

            if (i_FetchOption == eFetchOption.All || i_FetchOption == eFetchOption.Inbox)
            {
                LoggedInUserInboxManager.Fetch();
            }

            FacebookService.s_CollectionLimit = origCollectionLimit;
            if (AfterFetch != null)
            {
                AfterFetch(this, new FetchEventArgs(i_FetchOption, i_CollectionLimit));
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
            return LoggedInUserInboxManager.GetInboxThreads(null);
        }

        public IEnumerable<InboxThread> GetInboxThreadsForSpecificFilter(string i_FriendFilterName, out string o_UsersThatCantBeFilteredMessage)
        {
            IFriendFilter friendFilter = LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FriendFilterName);
            o_UsersThatCantBeFilteredMessage = friendFilter.ErrorString;
            return LoggedInUserInboxManager.GetInboxThreads(friendFilter);
        }

        public IEnumerable<User> GetFriends(string i_FilterName, out string o_UsersThatCantBeFilteredMessage)
        {
            IEnumerable<User> friends;
            o_UsersThatCantBeFilteredMessage = string.Empty;
            IFriendFilter filter = LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FilterName);
            if (filter == null)
            {
                friends = LoggedInUserFriendsFetcher.GetFriends();
            }
            else
            {
                friends = filter.FilterdFriends;
                o_UsersThatCantBeFilteredMessage = filter.ErrorString;
            }

            return friends;
        }

        public string AddFriendFilter(FriendsFilter i_FriendsFilter)
        {
            i_FriendsFilter.UpdateFriends(LoggedInUserFriendsFetcher.GetFriends());
            return LoggedInUserFriendsFiltersManager.AddFriendFilter(i_FriendsFilter);
        }

        public bool RemoveFriendFilter(string i_FriendFilterId)
        {
            return LoggedInUserFriendsFiltersManager.RemoveFriendFilter(i_FriendFilterId);
        }

        public string GetFriendFilterName(string i_FilterId)
        {
            IFriendFilter filter = LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FilterId);
            return (filter == null) ? null : filter.Name;
        }

        public string GetFriendFilterDisplayString(string i_FilterId)
        {
            IFriendFilter filter = LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FilterId);
            return (filter == null) ? null : filter.ToString();
        }

        public IEnumerable<string> GetFriendFiltersIds()
        {
            return LoggedInUserFriendsFiltersManager.FriendsFiltersIds;
        }

        #endregion IFacebookApplicationManager
        #endregion public methods
        #region private methods
        #endregion private methods
    }
}
