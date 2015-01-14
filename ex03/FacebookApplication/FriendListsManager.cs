using System;
using System.Collections.Generic;
using Facebook;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendListsManager : IFriendListsManager
    {
        #region members

        private readonly Dictionary<string, FriendList> r_FriendsListsForLoggedinUser;

        private readonly Dictionary<string, List<string>> r_FriendsListsByFriendsIds;

        private readonly FacebookFetchObject r_FacebookFetchObject;
        
        #endregion members

        #region Properties

        #endregion Properties

        #region constructor

        public FriendListsManager(FacebookFetchObject i_FacebookFetchObject)
        {
            r_FriendsListsByFriendsIds = new Dictionary<string, List<string>>();
            r_FriendsListsForLoggedinUser = new Dictionary<string, FriendList>();
            r_FacebookFetchObject = i_FacebookFetchObject;
            r_FacebookFetchObject.AttachFetchFriendsListsObserver(updateFriendLists);
        }

        #endregion constructor

        #region public methods

        public void Dispose()
        {
            r_FacebookFetchObject.DetachFetchFriendsListsObserver(updateFriendLists);
        }

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
        
        #endregion IFriendsFetcher

        #endregion public methods
        
        #region private methods
                
        private void updateFriendLists(IEnumerable<FriendList> i_FriendsListsForLoggedinUser)
        {
            foreach (FriendList friendList in i_FriendsListsForLoggedinUser)
            {
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
        }

        #endregion private methods
    }
}
