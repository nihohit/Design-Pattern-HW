using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IInboxManager : IFetchable
    {
        #region methods
        IEnumerable<FriendList> GetRelevantFriendsListsForInboxThread(string i_InboxThreadId);
        string GetInboxThreadFriendsNames(string i_InboxThreadId);
        IEnumerable<InboxThread> GetAllInboxThreads();
        IEnumerable<InboxThread> GetInboxThreadsForSpecificFriendList(FriendList i_FriendList);
        string GetInboxThreadDisplayString(string i_InboxThreadId);
        #endregion methods
    }
}
