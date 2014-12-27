using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IFiltersFicherManager
    {
        #region Events

        event EventHandler<FetchEventArgs> AfterFetch;

        event EventHandler FriendFilterAdded;

        event EventHandler FriendFilterRemoved;

        #endregion Events

        #region Properties

        IFriendsFetcher LoggedInUserFriendsFetcher { get; }

        IFriendsFiltersManager LoggedInUserFriendsFiltersManager { get; }

        IInboxManager LoggedInUserInboxManager { get; }

        IFriendListsManager LoggedInUserFriendListsManager { get; }

        #endregion Properties

        #region methods

        void FetchFromFacebook(eFetchOption i_FetchOption);

        void FetchFromFacebook(eFetchOption i_FetchOption, int i_CollectionLimit);

        IEnumerable<User> GetFriends(string i_FilterId, out string o_UsersThatCantBeFilteredMessage);

        IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser();

        FriendList CreateFriendList(string i_Name, IEnumerable<User> i_Members);

        string GetInboxThreadDisplayString(string i_InboxThreadId);

        string GetInboxThreadFriendsNames(string i_InboxThreadId);

        IEnumerable<InboxThread> GetAllInboxThreads();

        IEnumerable<InboxThread> GetInboxThreadsForSpecificFilter(
            string i_FriendFilterId,
            out string o_UsersThatCantBeFilteredMessage);

        string AddFriendFilter(FriendsFilter i_FriendsFilter);

        bool RemoveFriendFilter(string i_FriendFilterId);

        string GetFriendFilterName(string i_FilterId);

        string GetFriendFilterDisplayString(string i_FilterId);

        IEnumerable<string> GetFriendFiltersIds();

        #endregion methods
    }
}
