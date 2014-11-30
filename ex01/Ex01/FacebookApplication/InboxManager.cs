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
        public struct InboxThreadOnDemandDetails
        {
            public readonly InboxThread r_InboxThread;
            public readonly IEnumerable<FriendList> r_ThreadFriendLists;
            public readonly string r_ThreadFriendListsDisplayName;
            public readonly string r_InboxThreadFriendsNames;

            public InboxThreadOnDemandDetails(InboxThread i_InboxThread, IEnumerable<FriendList> i_ThreadFriendLists,
                string i_ThreadFriendListsDisplayName, string i_InboxThreadFriendsNames)
            {
                r_InboxThread = i_InboxThread;
                r_ThreadFriendLists = i_ThreadFriendLists;
                r_ThreadFriendListsDisplayName = i_ThreadFriendListsDisplayName;
                r_InboxThreadFriendsNames = i_InboxThreadFriendsNames;
            }
        }
        #region members

        private readonly IFriendListsManager r_FriendListsManager;
        private Dictionary<string, InboxThreadOnDemandDetails> m_InboxThreads;

        #endregion members
        #region Properties
        #endregion Properties
        #region constructor

        public InboxManager(IFriendListsManager i_FriendListsManager, TimeSpan? i_MinIntervalBetweenFetchActions = null)
            : base(i_MinIntervalBetweenFetchActions)
        {
            r_FriendListsManager = i_FriendListsManager;
            reset();
        }

        #endregion constructor
        #region public methods
        #region IInboxManager
        public IEnumerable<FriendList> GetRelevantFriendsListsForInboxThread(string i_InboxThreadId)
        {
            InboxThreadOnDemandDetails inboxThreadOnDemandDetails;
            if (!m_InboxThreads.TryGetValue(i_InboxThreadId, out inboxThreadOnDemandDetails))
            {
                throw new ArgumentException(string.Format("Cannot find inbox thread {0}", i_InboxThreadId));
            }

            return inboxThreadOnDemandDetails.r_ThreadFriendLists;
        }

        public string GetInboxThreadFriendsNames(string i_InboxThreadId)
        {
            InboxThreadOnDemandDetails inboxThreadOnDemandDetails;
            if (!m_InboxThreads.TryGetValue(i_InboxThreadId, out inboxThreadOnDemandDetails))
            {
                throw new ArgumentException(string.Format("Cannot find inbox thread {0}", i_InboxThreadId));
            }

            return inboxThreadOnDemandDetails.r_InboxThreadFriendsNames;
        }

        public IEnumerable<InboxThread> GetAllInboxThreads()
        {
            return GetInboxThreadsForSpecificFriendList(null);
        }

        public IEnumerable<InboxThread> GetInboxThreadsForSpecificFriendList(FriendList i_FriendList)
        {
            FacebookObjectCollection<InboxThread> friendListInboxThreads = new FacebookObjectCollection<InboxThread>();
            foreach (string inboxThreadId in m_InboxThreads.Keys)
            {
                IEnumerable<FriendList> friendsLists = (i_FriendList == null) ? null : GetRelevantFriendsListsForInboxThread(inboxThreadId);
                if (i_FriendList == null || friendsLists.Contains(i_FriendList))
                {
                    friendListInboxThreads.Add(m_InboxThreads[inboxThreadId].r_InboxThread);
                }
            }

            return friendListInboxThreads;
        }

        public string GetInboxThreadDisplayString(string i_InboxThreadId)
        {
            string inboxThreadDisplayString = string.Empty;
            InboxThreadOnDemandDetails iInboxThreadOnDemandDetails;
            if (m_InboxThreads.TryGetValue(i_InboxThreadId, out iInboxThreadOnDemandDetails))
            {
                iInboxThreadOnDemandDetails.r_InboxThread.GetInboxThreadMessagesDisplayString();
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

        protected override void ThrowShouldFetchFromFacebookException()
        {
            ThrowShouldFetchFromFacebookException("mailbox");
        }

        #endregion override protected methods
        #region private methods

        private void fetchInbox(User i_LoggedInUser)
        {
            m_InboxThreads.Clear();
            i_LoggedInUser.ValidateUserNotNull();
            r_FriendListsManager.Fetch(i_LoggedInUser);
            FacebookObjectCollection<InboxThread> inboxThreads = i_LoggedInUser.InboxThreads;
            foreach (InboxThread inboxThread in inboxThreads)
            {
                IEnumerable<FriendList> relevantFriendsListsForInboxThread = getRelevantFriendsListsForInboxThread(inboxThread, i_LoggedInUser.Id);
                string threadFriendListsDisplayName = r_FriendListsManager.GetFriendListsDisplayName(relevantFriendsListsForInboxThread);
                string inboxThreadFriendsNames = inboxThread.GetInboxThreadFriendsNames(i_LoggedInUser.Id);
                m_InboxThreads.Add(inboxThread.Id, new InboxThreadOnDemandDetails(inboxThread, relevantFriendsListsForInboxThread, threadFriendListsDisplayName, inboxThreadFriendsNames));
            }
        }

        private IEnumerable<FriendList> getRelevantFriendsListsForInboxThread(InboxThread i_InboxThread, string i_UserLoggedInWhenFetchedId)
        {
            FacebookObjectCollection<FriendList> inboxThreadFriendLists = new FacebookObjectCollection<FriendList>();
            foreach (User friend in i_InboxThread.To)
            {
                if (friend.Id != i_UserLoggedInWhenFetchedId)
                {
                    IEnumerable<FriendList> friendFriendLists =
                        r_FriendListsManager.GetAllFriendListsWhichFriendBelongsTo(friend.Id);
                    foreach (FriendList friendList in friendFriendLists)
                    {
                        if (!inboxThreadFriendLists.Contains(friendList))
                        {
                            inboxThreadFriendLists.Add(friendList);
                        }
                    }
                }
            }

            return inboxThreadFriendLists;
        }

        private void reset()
        {
            if (m_InboxThreads == null)
            {
                m_InboxThreads = new Dictionary<string, InboxThreadOnDemandDetails>();
            }
            else
            {
                m_InboxThreads.Clear();
            }
        }

        #endregion private methods

    }
}
