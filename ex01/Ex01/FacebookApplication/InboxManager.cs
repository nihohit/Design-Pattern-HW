using System.Linq;
using FacebookApplication.Interfaces;
using System;
using System.Collections.Generic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class InboxManager : FacebookFetchable, IInboxManager
    {
        #region members

        private readonly Dictionary<string, InboxThread> r_InboxThreads;

        #endregion members
        #region Properties
        #endregion Properties
        #region constructor

        public InboxManager(TimeSpan? i_MinIntervalBetweenFetchActions = null)
            : base(i_MinIntervalBetweenFetchActions)
        {
            r_InboxThreads = new Dictionary<string, InboxThread>();
        }

        #endregion constructor
        #region public methods
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
            IEnumerable<InboxThread> inboxThreads;
            if (i_FriendFilter == null)
            {
                inboxThreads = r_InboxThreads.Values;
            }
            else
            {
                inboxThreads = getInboxThreadsForSpecificFriendFilter(i_FriendFilter);
            }

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
        #region override

        public override void ResetFetchDetails()
        {
            reset();
            base.ResetFetchDetails();
        }

        #endregion override
        #endregion public methods
        #region override protected methods

        protected override void FacebookFetch(User i_LoggedInUser)
        {
            fetchInbox(i_LoggedInUser);
        }
        
        #endregion override protected methods
        #region private methods

        private IEnumerable<InboxThread> getInboxThreadsForSpecificFriendFilter(IFriendFilter i_FriendFilter)
        {
            FacebookObjectCollection<InboxThread> friendListInboxThreads = new FacebookObjectCollection<InboxThread>();
            foreach (InboxThread inboxThread in r_InboxThreads.Values)
            {
                foreach (User friend in inboxThread.To)
                {
                    if (i_FriendFilter.FilterdFriendsIds.Contains(friend.Id))
                    {
                        friendListInboxThreads.Add(inboxThread);
                        break;
                    }
                }
            }
            
            return friendListInboxThreads;
        }

        private void fetchInbox(User i_LoggedInUser)
        {
            r_InboxThreads.Clear();
            i_LoggedInUser.ValidateUserNotNull();
            FacebookObjectCollection<InboxThread> inboxThreads = i_LoggedInUser.InboxThreads;
            foreach (InboxThread inboxThread in inboxThreads)
            {
                r_InboxThreads.Add(inboxThread.Id, inboxThread);
            }
        }

        private void reset()
        {
            r_InboxThreads.Clear();
        }

        #endregion private methods
        
    }
}
