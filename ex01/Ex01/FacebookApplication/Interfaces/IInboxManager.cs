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
        string GetInboxThreadFriendsNames(string i_InboxThreadId);
        IEnumerable<InboxThread> GetInboxThreads(IFriendFilter i_FriendFilter);
        string GetInboxThreadDisplayString(string i_InboxThreadId);
        #endregion methods
    }
}
