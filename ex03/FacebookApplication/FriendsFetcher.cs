using System;
using System.Collections.Generic;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendsFetcher : IFriendsFetcher
    {
        #region members
        private readonly FacebookFetchObject r_FacebookFetchObject;
        private IEnumerable<User> m_Friends;
        #endregion members
        #region Properties
        #endregion Properties
        #region constructor

        public FriendsFetcher(FacebookFetchObject i_FacebookFetchObject)
        {
            m_Friends = null;
            r_FacebookFetchObject = i_FacebookFetchObject;
            r_FacebookFetchObject.AttachFetchFriendsObserver(updateFriends);
        }
        #endregion constructor
        #region public methods

        public void Dispose()
        {
            r_FacebookFetchObject.DetachFetchFriendsObserver(updateFriends);
        }

        #region IFriendsFetcher
        public IEnumerable<User> GetFriends()
        {
            return m_Friends;
        }
        #endregion IFriendsFetcher        
        #endregion public methods
        #region private methods

        private void updateFriends(IEnumerable<User> i_Friends)
        {
            m_Friends = i_Friends;
        }

        #endregion private methods
    }
}
