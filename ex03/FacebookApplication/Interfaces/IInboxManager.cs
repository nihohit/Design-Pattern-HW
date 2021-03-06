using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IInboxManager 
    {
        #region methods

        string GetInboxThreadFriendsNames(string i_InboxThreadId);

        IEnumerable<InboxThread> GetInboxThreads(IFriendFilter i_FriendFilter);

        string GetInboxThreadDisplayString(string i_InboxThreadId);

        #endregion methods
    }
}
