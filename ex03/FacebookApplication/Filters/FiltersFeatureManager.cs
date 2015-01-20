namespace FacebookApplication.Filters
{
    using System;
    using System.Collections.Generic;

    using FacebookApplication.Interfaces;

    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;

    public class FiltersFeatureManager : IFiltersFeatureManager
    {
        #region members

        private readonly FacebookFetchObject r_FacebookFetchObject;

        #endregion members
        #region Events
        #region IFacebookApplicationManager

        public event EventHandler<FetchEventArgs> AfterFetch;

        public event EventHandler FriendFilterAdded
        {
            add { this.LoggedInUserFriendsFiltersManager.FilterAdded += value; }
            remove { this.LoggedInUserFriendsFiltersManager.FilterAdded -= value; }
        }

        public event EventHandler FriendFilterRemoved
        {
            add { this.LoggedInUserFriendsFiltersManager.FilterRmoved += value; }
            remove { this.LoggedInUserFriendsFiltersManager.FilterRmoved -= value; }
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
            r_FacebookFetchObject = new FacebookFetchObject(minIntervalBetweenFetchActions);
            this.LoggedInUserFriendListsManager = new FriendListsManager(r_FacebookFetchObject);
            this.LoggedInUserInboxManager = new InboxManager(r_FacebookFetchObject);
            this.LoggedInUserFriendsFetcher = new FriendsFetcher(r_FacebookFetchObject);
            this.LoggedInUserFriendsFiltersManager = new FriendsFiltersManager(r_FacebookFetchObject);
            this.LoggedInUserFriendsFiltersManager.AddFriendFilter(new FriendsFilter());
        }
        #endregion constructor
        #region public methods
        #region IFacebookApplicationManager

        public void FetchFromFacebook(eFetchOption i_FetchOption)
        {
            this.FetchFromFacebook(i_FetchOption, -1);
        }

        public void FetchFromFacebook(eFetchOption i_FetchOption, int i_CollectionLimit)
        {
            r_FacebookFetchObject.FetchFromFacebook(i_FetchOption, i_CollectionLimit);
            if (this.AfterFetch != null)
            {
                this.AfterFetch(this, new FetchEventArgs(i_FetchOption, i_CollectionLimit));
            }
        }

        public IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser()
        {
            return this.LoggedInUserFriendListsManager.GetRelevantFriendsListsForLoggedinUser();
        }

        public string GetInboxThreadFriendsNames(string i_InboxThreadId)
        {
            return this.LoggedInUserInboxManager.GetInboxThreadFriendsNames(i_InboxThreadId);
        }

        public string GetInboxThreadDisplayString(string i_InboxThreadId)
        {
            return this.LoggedInUserInboxManager.GetInboxThreadDisplayString(i_InboxThreadId);
        }

        public IEnumerable<InboxThread> GetAllInboxThreads()
        {
            return this.LoggedInUserInboxManager.GetInboxThreads(null);
        }

        public IEnumerable<InboxThread> GetInboxThreadsForSpecificFilter(string i_FriendFilterName, out string o_UsersThatCantBeFilteredMessage)
        {
            IFriendFilter friendFilter = this.LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FriendFilterName);
            o_UsersThatCantBeFilteredMessage = friendFilter.ErrorString;
            return this.LoggedInUserInboxManager.GetInboxThreads(friendFilter);
        }

        public IEnumerable<User> GetFriends(string i_FilterName, out string o_UsersThatCantBeFilteredMessage)
        {
            IEnumerable<User> friends;
            o_UsersThatCantBeFilteredMessage = string.Empty;
            IFriendFilter filter = this.LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FilterName);
            if (filter == null)
            {
                friends = this.LoggedInUserFriendsFetcher.GetFriends();
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
            i_FriendsFilter.UpdateFriends(this.LoggedInUserFriendsFetcher.GetFriends());
            return this.LoggedInUserFriendsFiltersManager.AddFriendFilter(i_FriendsFilter);
        }

        public bool RemoveFriendFilter(string i_FriendFilterId)
        {
            return this.LoggedInUserFriendsFiltersManager.RemoveFriendFilter(i_FriendFilterId);
        }

        public string GetFriendFilterName(string i_FilterId)
        {
            IFriendFilter filter = this.LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FilterId);
            return (filter == null) ? null : filter.Name;
        }

        public string GetFriendFilterDisplayString(string i_FilterId)
        {
            IFriendFilter filter = this.LoggedInUserFriendsFiltersManager.GetFriendFilter(i_FilterId);
            return (filter == null) ? null : filter.ToString();
        }

        public IEnumerable<string> GetFriendFiltersIds()
        {
            return this.LoggedInUserFriendsFiltersManager.FriendsFiltersIds;
        }

        #endregion IFacebookApplicationManager
        #endregion public methods
        #region private methods
        #endregion private methods
    }
}
