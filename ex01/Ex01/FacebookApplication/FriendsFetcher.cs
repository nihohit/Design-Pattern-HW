﻿using FacebookApplication.Interfaces;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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

        protected override void FacebookFetch(User i_LoggedInUser)
        {
            fetchFriends(i_LoggedInUser);
        }
        
        #endregion override protected methods
        #region private methods

        private void fetchFriends(User i_LoggedInUser)
        {
            m_Friends = i_LoggedInUser.Friends;
        }

        private void reset()
        {
            m_Friends = null;
        }

        #endregion private methods
        
    }
}
