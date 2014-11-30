using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendListsManager : FacebookFetchable, IFriendListsManager
    {
        #region members

        private Dictionary<string, FriendList> m_friendsListsForLoggedinUser;
        private Dictionary<string, FacebookObjectCollection<FriendList>> m_friendsListsByFriendsIds;

        #endregion members

        #region Properties

        #endregion Properties

        #region constructor

        public FriendListsManager(TimeSpan? i_MinIntervalBetweenFetchActions)
            : base(i_MinIntervalBetweenFetchActions)
        {
            reset();
        }

        #endregion constructor

        #region public methods

        #region IFriendListsManager

        public IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser()
        {
            if (m_friendsListsForLoggedinUser == null)
            {
                ThrowShouldFetchFromFacebookException();
            }

            return m_friendsListsForLoggedinUser.Values;
        }

        public IEnumerable<FriendList> GetAllFriendListsWhichFriendBelongsTo(string i_FriendId)
        {
            if (m_friendsListsByFriendsIds == null)
            {
                ThrowShouldFetchFromFacebookException();
            }

            FacebookObjectCollection<FriendList> friendsListsFriendBelongsTo;
            if (!m_friendsListsByFriendsIds.TryGetValue(i_FriendId, out friendsListsFriendBelongsTo))
            {
                friendsListsFriendBelongsTo = new FacebookObjectCollection<FriendList>(0);
            }

            return friendsListsFriendBelongsTo;
        }

        public string GetFriendListsDisplayName(IEnumerable<FriendList> i_FriendLists)
        {
            string friendListsDisplayName = string.Empty;
            foreach (FriendList friendList in i_FriendLists)
            {
                friendListsDisplayName += " " + friendList.Name + ",";
            }

            friendListsDisplayName = friendListsDisplayName.Trim(',');
            return friendListsDisplayName.Trim();
        }

        public FriendList CreateFriendList(string i_Name, IEnumerable<User> i_Members)
        {
            UserLoggedInWhenFetched.ValidateUserNotNull();
            FriendList friendList = UserLoggedInWhenFetched.CreateFriendList(i_Name);
            friendList.AddMemeber(i_Members);
            return friendList;
        }

        #endregion IFriendsFetcher

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
            fetchFriendLists(i_LoggedInUser);
        }

        protected override void ThrowShouldFetchFromFacebookException()
        {
            ThrowShouldFetchFromFacebookException("friends lists");
        }

        #endregion override protected methods

        #region private methods

        private void reset()
        {
            m_friendsListsByFriendsIds = null;
            m_friendsListsForLoggedinUser = null;
        }

        private void fetchFriendLists(User i_LoggedInUser)
        {
            FacebookObjectCollection<FriendList> friendsListsForLoggedinUser = i_LoggedInUser.FriendLists;
            m_friendsListsForLoggedinUser = new Dictionary<string, FriendList>();
            m_friendsListsByFriendsIds = new Dictionary<string, FacebookObjectCollection<FriendList>>();
            foreach (FriendList friendList in friendsListsForLoggedinUser)
            {
                m_friendsListsForLoggedinUser.Add(friendList.Id, friendList);
                foreach (User friend in friendList.Members)
                {
                    FacebookObjectCollection<FriendList> friendsLists;
                    if (!m_friendsListsByFriendsIds.TryGetValue(friend.Id, out friendsLists))
                    {
                        friendsLists = new FacebookObjectCollection<FriendList>();
                        m_friendsListsByFriendsIds.Add(friend.Id, friendsLists);
                    }

                    friendsLists.Add(friendList);
                }
            }
        }

        #endregion private methods
    }
}
