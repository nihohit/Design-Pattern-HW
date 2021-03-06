using System;
using System.Collections.Generic;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendsFetcher : FacebookFetchable, IFriendsFetcher
    {
        #region members

        private FacebookObjectCollection<User> m_Friends;
        #endregion members
        #region Properties
        #endregion Properties
        #region constructor

        public FriendsFetcher(TimeSpan? i_MinIntervalBetweenFetchActions)
            : base(i_MinIntervalBetweenFetchActions)
        {
            reset();
        }
        #endregion constructor
        #region public methods
        #region IFriendsFetcher
        public IEnumerable<User> GetFriends()
        {
            return m_Friends;
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

        protected override void FacebookFetch()
        {
            fetchFriends();
        }
        
        #endregion override protected methods
        #region private methods

        private void fetchFriends()
        {
            m_Friends = UserWrapper.Instance.Friends;
        }

        private void reset()
        {
            m_Friends = null;
        }

        #endregion private methods
    }
}
