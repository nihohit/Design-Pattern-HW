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
        private Dictionary<string, List<string>> m_friendsListsByFriendsIds;

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

        public IEnumerable<string> GetAllFriendListsWhichFriendBelongsTo(string i_FriendId)
        {
            if (m_friendsListsByFriendsIds == null)
            {
                ThrowShouldFetchFromFacebookException();
            }

            List<string> friendsListsFriendBelongsToIds;
            if (!m_friendsListsByFriendsIds.TryGetValue(i_FriendId, out friendsListsFriendBelongsToIds))
            {
                friendsListsFriendBelongsToIds = new List<string>(0);
            }

            return friendsListsFriendBelongsToIds;
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
            m_friendsListsByFriendsIds = new Dictionary<string, List<string>>();
            foreach (FriendList friendList in friendsListsForLoggedinUser)
            {
                m_friendsListsForLoggedinUser.Add(friendList.Id, friendList);
                foreach (User friend in friendList.Members)
                {
                    List<string> friendsListsIds;
                    if (!m_friendsListsByFriendsIds.TryGetValue(friend.Id, out friendsListsIds))
                    {
                        friendsListsIds = new List<string>();
                        m_friendsListsByFriendsIds.Add(friend.Id, friendsListsIds);
                    }

                    friendsListsIds.Add(friendList.Id);
                }
            }
        }

        #endregion private methods
    }
}
