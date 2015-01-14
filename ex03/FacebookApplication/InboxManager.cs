using System;
using System.Collections.Generic;
using System.Linq;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class InboxManager : IInboxManager
    {
        #region members

        private readonly Dictionary<string, InboxThread> r_InboxThreads;

        private readonly FacebookFetchObject r_FacebookFetchObject;
        
        #endregion members
        #region Properties
        #endregion Properties
        #region constructor

        public InboxManager(FacebookFetchObject i_FacebookFetchObject)
        {
            r_InboxThreads = new Dictionary<string, InboxThread>();
            r_FacebookFetchObject = i_FacebookFetchObject;
            r_FacebookFetchObject.AttachFetchInboxObserver(updateInboxThreads);
        }

        #endregion constructor
        #region public methods

        public void Dispose()
        {
            r_FacebookFetchObject.DetachFetchInboxObserver(updateInboxThreads);
        }

        #region IInboxManager

        public string GetInboxThreadFriendsNames(string i_InboxThreadId)
        {
            string friendsNames = string.Empty;
            InboxThread inboxThread;
            if (r_InboxThreads.TryGetValue(i_InboxThreadId, out inboxThread))
            {
                friendsNames = inboxThread.GetInboxThreadMessagesDisplayString();
            }

            return friendsNames;
        }

        public IEnumerable<InboxThread> GetInboxThreads(IFriendFilter i_FriendFilter)
        {
            IEnumerable<InboxThread> inboxThreads =
                i_FriendFilter == null ?
                this.r_InboxThreads.Values :
                this.getInboxThreadsForSpecificFriendFilter(i_FriendFilter);

            return inboxThreads;
        }

        public string GetInboxThreadDisplayString(string i_InboxThreadId)
        {
            string inboxThreadDisplayString = string.Empty;
            InboxThread inboxThread;
            if (r_InboxThreads.TryGetValue(i_InboxThreadId, out inboxThread))
            {
                inboxThread.GetInboxThreadMessagesDisplayString();
            }
            else
            {
                throw new ArgumentException(string.Format("Cannot find inbox thread {0}", i_InboxThreadId));
            }

            return inboxThreadDisplayString;
        }

        #endregion IInboxManager
        
        #endregion public methods
        
        #region private methods

        private IEnumerable<InboxThread> getInboxThreadsForSpecificFriendFilter(IFriendFilter i_FriendFilter)
        {
            FacebookObjectCollection<InboxThread> friendListInboxThreads = new FacebookObjectCollection<InboxThread>();
            foreach (InboxThread inboxThread in
                r_InboxThreads.Values.Where(i_InboxThread =>
                    i_InboxThread.To.Any(i_Friend => i_FriendFilter.FilterdFriendsIds.Contains(i_Friend.Id))))
            {
                friendListInboxThreads.Add(inboxThread);
            }

            return friendListInboxThreads;
        }

        private void updateInboxThreads(IEnumerable<InboxThread> i_InboxThreads)
        {
            r_InboxThreads.Clear();
            foreach (InboxThread inboxThread in i_InboxThreads)
            {
                r_InboxThreads.Add(inboxThread.Id, inboxThread);
            }
        }

        #endregion private methods
    }
}
