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
        event EventHandler AfterFetch;
        #endregion Events
        #region Properties
        User LoggedInUser { get; }
        IFriendsFetcher LoggedInUserFriendsFetcher { get; }
        IFriendListsManager LoggedInUserFriendListsManager { get; }
        IInboxManager LoggedInUserInboxManager { get; }
        #endregion Properties
        #region methods
        void LoginUser(string i_AppId, params string[] i_Permissions);
        void Reset();
        void FetchFromFacebook();
        IEnumerable<User> GetFriends(string i_FilterId, out string o_UsersThatCantBeFilteredMessage);
        IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser();
        FriendList CreateFriendList(string i_Name, IEnumerable<User> i_Members);
        string GetInboxThreadDisplayString(string i_InboxThreadId);
        string GetInboxThreadFriendsNames(string i_InboxThreadId);
        IEnumerable<InboxThread> GetAllInboxThreads();
        IEnumerable<InboxThread> GetInboxThreadsForSpecificFriendList(FriendList i_FriendList);
        
        #endregion methods
    }
}
