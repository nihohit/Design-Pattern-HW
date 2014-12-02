using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication.Interfaces
{
    public interface IFacebookApplicationManager
    {
        #region Events
        event EventHandler AfterReset;
        event EventHandler AfterLoggin;
        event EventHandler<FetchEventArgs> AfterFetch;
        event EventHandler FriendFilterAdded;
        event EventHandler FriendFilterRemoved;
        #endregion Events
        #region Properties
        User LoggedInUser { get; }
        IFriendsFetcher LoggedInUserFriendsFetcher { get; }
        IFriendsFiltersManager LoggedInUserFriendsFiltersManager { get; }
        IInboxManager LoggedInUserInboxManager { get; }
        IFriendListsManager LoggedInUserFriendListsManager { get; }
        #endregion Properties
        #region methods
        void LoginUser(string i_AppId, params string[] i_Permissions);
        void Reset();
        void FetchFromFacebook(eFetchOption i_FetchOption);
        void FetchFromFacebook(eFetchOption i_FetchOption, int i_CollectionLimit);
        IEnumerable<User> GetFriends(string i_FilterId, out string o_UsersThatCantBeFilteredMessage);
        IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser();
        FriendList CreateFriendList(string i_Name, IEnumerable<User> i_Members);
        string GetInboxThreadDisplayString(string i_InboxThreadId);
        string GetInboxThreadFriendsNames(string i_InboxThreadId);
        IEnumerable<InboxThread> GetAllInboxThreads();
        IEnumerable<InboxThread> GetInboxThreadsForSpecificFilter(string i_FriendFilterId,
            out string o_UsersThatCantBeFilteredMessage);
        string AddFriendFilter(string i_Name, bool i_FilterGender, User.eGender i_Gender,
            bool i_FilterAge, int i_MinAge, int i_MaxAge, bool i_FilterByFriendList, FriendList i_FriendList);
        bool RemoveFriendFilter(string i_FriendFilterId);
        string GetFriendFilterName(string i_FilterId);
        string GetFriendFilterDisplayString(string i_FilterId);
        IEnumerable<string> GetFriendFiltersIds();

        #endregion methods
    }

    public enum eFetchOption
    {
        All,
        Friends,
        FriendsLists,
        Inbox,

    }
}
