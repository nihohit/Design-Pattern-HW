using System;
using System.Collections.Generic;
using Facebook;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendListsManager : FacebookFetchable, IFriendListsManager
    {
        #region members

        private readonly Dictionary<string, FriendList> r_FriendsListsForLoggedinUser;

        private readonly Dictionary<string, List<string>> r_FriendsListsByFriendsIds;

        #endregion members

        #region Properties

        #endregion Properties

        #region constructor

        public FriendListsManager(TimeSpan? i_MinIntervalBetweenFetchActions)
            : base(i_MinIntervalBetweenFetchActions)
        {
            r_FriendsListsByFriendsIds = new Dictionary<string, List<string>>();
            r_FriendsListsForLoggedinUser = new Dictionary<string, FriendList>();
        }

        #endregion constructor

        #region public methods

        #region IFriendListsManager

        public IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser()
        {
            return r_FriendsListsForLoggedinUser.Values;
        }

        public IEnumerable<string> GetAllFriendListsWhichFriendBelongsTo(string i_FriendId)
        {
            List<string> friendsListsFriendBelongsToIds;
            if (!r_FriendsListsByFriendsIds.TryGetValue(i_FriendId, out friendsListsFriendBelongsToIds))
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

        #endregion override protected methods

        #region private methods

        private void reset()
        {
            r_FriendsListsByFriendsIds.Clear();
            r_FriendsListsForLoggedinUser.Clear();
        }

        private void fetchFriendLists(User i_LoggedInUser)
        {
            FacebookObjectCollection<FriendList> friendsListsForLoggedinUser = i_LoggedInUser.FriendLists;
            string friendsListWithFetchError = null;
            foreach (FriendList friendList in friendsListsForLoggedinUser)
            {
                if (friendList.Members == null)
                {
                    friendsListWithFetchError = friendsListWithFetchError ?? "Could not Fetch members of:";
                    friendsListWithFetchError += " " + friendList.Name + ",";
                    continue;
                }

                r_FriendsListsForLoggedinUser.Add(friendList.Id, friendList);
                foreach (User friend in friendList.Members)
                {
                    List<string> friendsListsIds;
                    if (!r_FriendsListsByFriendsIds.TryGetValue(friend.Id, out friendsListsIds))
                    {
                        friendsListsIds = new List<string>();
                        r_FriendsListsByFriendsIds.Add(friend.Id, friendsListsIds);
                    }

                    friendsListsIds.Add(friendList.Id);
                }
            }

            if (friendsListWithFetchError != null)
            {
                throw new FacebookApiException(friendsListWithFetchError);
            }
        }

        #endregion private methods
    }
}
