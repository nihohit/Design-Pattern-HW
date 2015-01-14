using System;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using FacebookWrapper;
using Facebook;

namespace FacebookApplication
{
    public class FacebookFetchObject
    {
        #region members
        private readonly Dictionary<eFetchOption, DateTime?> r_FetchedTimes;
        private readonly Dictionary<eFetchOption, Action> r_FetchAndNotifyDelegates;
        private string m_FetchErrorString = null;
        #endregion members
        #region Events
        private event Action<IEnumerable<FriendList>> m_FetchFriendsListsDelegates;
        private event Action<IEnumerable<User>> m_FetchFriendsDelegates;
        private event Action<IEnumerable<InboxThread>> m_FetchInboxDelegates;
        #endregion Events
        #region Properties
        #region IFetchable

        public TimeSpan? MinIntervalBetweenFetchActions { get; private set; }

        public bool ForcedFetch
        {
            get
            {
                return MinIntervalBetweenFetchActions == null;
            }
        }

        #endregion IFetchable
        #endregion Properties
        #region constructor

        public FacebookFetchObject(TimeSpan? i_MinIntervalBetweenFetchActions)
        {
            MinIntervalBetweenFetchActions = i_MinIntervalBetweenFetchActions;
            r_FetchedTimes = new Dictionary<eFetchOption,DateTime?>();
            r_FetchAndNotifyDelegates = new Dictionary<eFetchOption, Action>();            
            initFetchAndNotifyDelegates();
        }

        #endregion constructor
        #region public methods
        #region IFetchable
        
        public void AttachFetchFriendsObserver(Action<IEnumerable<User>> i_ObserverDelegate)
        {
            m_FetchFriendsDelegates += i_ObserverDelegate;
        }

        public void DetachFetchFriendsObserver(Action<IEnumerable<User>> i_ObserverDelegate)
        {
            m_FetchFriendsDelegates -= i_ObserverDelegate;
        }

        public void AttachFetchFriendsListsObserver(Action<IEnumerable<FriendList>> i_ObserverDelegate)
        {
            m_FetchFriendsListsDelegates += i_ObserverDelegate;
        }

        public void DetachFetchFriendsListsObserver(Action<IEnumerable<FriendList>> i_ObserverDelegate)
        {
            m_FetchFriendsListsDelegates -= i_ObserverDelegate;
        }

        public void AttachFetchInboxObserver(Action<IEnumerable<InboxThread>> i_ObserverDelegate)
        {
            m_FetchInboxDelegates += i_ObserverDelegate;
        }

        public void DetachFetchInboxObserver(Action<IEnumerable<InboxThread>> i_ObserverDelegate)
        {
            m_FetchInboxDelegates -= i_ObserverDelegate;
        }

        public void FetchFromFacebook(eFetchOption i_FetchOption, int i_CollectionLimit)
        {           
            m_FetchErrorString = null;
            int origCollectionLimit = FacebookService.s_CollectionLimit;
            if (i_CollectionLimit != -1)
            {
                FacebookService.s_CollectionLimit = i_CollectionLimit;
            }

            UserWrapper.Instance.ReFetch();
            fetchAndNotify(i_FetchOption);
            FacebookService.s_CollectionLimit = origCollectionLimit;             
            if (m_FetchErrorString != null)
            {
                throw new FacebookApiException(m_FetchErrorString);
            }
        }
                
        #endregion IFetchable
        #endregion public methods
        #region protected methods

        #endregion protected methods
        #region private methods

        private void fetchAndNotify(eFetchOption i_FetchOption)
        {
            if (i_FetchOption == eFetchOption.All)
            {
                foreach (eFetchOption fetchOption in (eFetchOption[]) Enum.GetValues(typeof(eFetchOption)))
                {
                    if (fetchOption != eFetchOption.All)
                    {
                        fetchAndNotify(fetchOption);
                    }
                }
            }
            else 
            {
                bool fetch = ForcedFetch || ( MinIntervalBetweenFetchActions <= calculateTimePassedFromLastFetch(i_FetchOption) );
                if (fetch)
                {
                    updateFetchTime(i_FetchOption);
                    Action fetchAndNotifyAction = null;
                    if (r_FetchAndNotifyDelegates.TryGetValue(i_FetchOption, out fetchAndNotifyAction) && fetchAndNotifyAction != null)
                    {
                        fetchAndNotifyAction();
                    }
                }
            }        
        }
                 
        private IEnumerable<FriendList> fetchFriendLists()
        {
            List<FriendList> friendsListsForLoggedinUser = new List<FriendList>();
            string friendsListWithFetchError = null;
            foreach (FriendList friendList in UserWrapper.Instance.FriendLists)
            {
                if (friendList.Members == null)
                {
                    friendsListWithFetchError = friendsListWithFetchError ?? "Could not Fetch members of:";
                    friendsListWithFetchError += " " + friendList.Name + ",";
                    continue;
                }

                friendsListsForLoggedinUser.Add(friendList);
            }

            if (!string.IsNullOrEmpty(friendsListWithFetchError))
            {
                m_FetchErrorString += friendsListWithFetchError.Trim(',') + Environment.NewLine;
            }

            return friendsListsForLoggedinUser;
        }

        private IEnumerable<User> fetchFriends()
        {
           return UserWrapper.Instance.Friends;
        }

        private IEnumerable<InboxThread> fetchInbox()
        {
            return UserWrapper.Instance.InboxThreads;
        }

        private TimeSpan calculateTimePassedFromLastFetch(eFetchOption i_FetchOption)
        {
            TimeSpan timePassedFromLastFetch;
            DateTime? fetchedTime;
            if (!r_FetchedTimes.TryGetValue(i_FetchOption, out fetchedTime) || fetchedTime == null)
            {
                timePassedFromLastFetch = TimeSpan.MaxValue;
            }
            else
            {
                timePassedFromLastFetch = DateTime.UtcNow - (DateTime)fetchedTime;
            }
            
            return timePassedFromLastFetch;
        }

        private void updateFetchTime(eFetchOption i_FetchOption)
        {
            r_FetchedTimes[i_FetchOption] = DateTime.UtcNow;
        }

        private void initFetchAndNotifyDelegates()
        {
            r_FetchAndNotifyDelegates[eFetchOption.Friends] = () =>
            {                
                if (m_FetchFriendsDelegates != null)
                {
                    IEnumerable<User> friends = fetchFriends();
                    m_FetchFriendsDelegates.Invoke(friends);
                }
            };

            r_FetchAndNotifyDelegates[eFetchOption.FriendsLists] = () =>
            {
                if (m_FetchFriendsListsDelegates != null)
                {
                    IEnumerable<FriendList> friendsLists = fetchFriendLists();                
                    m_FetchFriendsListsDelegates(friendsLists);
                }
            };

            r_FetchAndNotifyDelegates[eFetchOption.Inbox] = () =>
            {
                if (m_FetchInboxDelegates != null)
                {
                    IEnumerable<InboxThread> inboxThreads = fetchInbox();
                    m_FetchInboxDelegates(inboxThreads);
                }
            };        
        }
                
        #endregion private methods
    }
}
