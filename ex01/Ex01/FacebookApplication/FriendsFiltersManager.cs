﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendsFiltersManager : FacebookFetchable, IFriendsFiltersManager
    {
        #region members

        private readonly Dictionary<string, IFriendFilter> r_Filters;
        private readonly IFriendsFetcher r_FriendsFetcher;
        private int m_CurrentId;

        #endregion members
        #region events (IFriendsFiltersManager)

        public event EventHandler FilterAdded;

        public event EventHandler FilterRmoved;

        #endregion events
        #region Properties (IFriendsFiltersManager)

        public IEnumerable<IFriendFilter> FriendsFilters
        {
            get { return r_Filters.Values; }
        }

        public IEnumerable<string> FriendsFiltersIds
        {
            get { return r_Filters.Keys; }
        }

        #endregion Properties
        #region constructor

        public FriendsFiltersManager(IFriendsFetcher i_FriendsFetcher, TimeSpan? i_MinIntervalBetweenFetchActions)
            : base(i_MinIntervalBetweenFetchActions)
        {
            r_FriendsFetcher = i_FriendsFetcher;
            r_Filters = new Dictionary<string, IFriendFilter>();
            m_CurrentId = 0;
        }

        #endregion constructor
        #region public methods
        #region IFriendFilterManager
        public string AddFriendFilter(string i_Name, IEnumerable<IUsersFilter> i_UserFilters)
        {
            IFriendFilter filter = new FriendsFilter(i_Name, i_UserFilters);
            string filterId = m_CurrentId.ToString();
            r_Filters.Add(filterId, filter);
            m_CurrentId++;
            if (FilterAdded != null)
            {
                FilterAdded(this, new EventArgs());
            }

            return filterId;
        }

        public bool RemoveFriendFilter(string i_FilterId)
        {
            bool removed = r_Filters.Remove(i_FilterId);
            if (removed && FilterRmoved != null)
            {
                FilterRmoved(this, new EventArgs());
            }

            return removed;
        }

        public IFriendFilter GetFriendFilter(string i_FilterId)
        {
            IFriendFilter friendFilter = null;
            if (!string.IsNullOrEmpty(i_FilterId))
            {
                r_Filters.TryGetValue(i_FilterId, out friendFilter);
            }

            return friendFilter;
        }
        #endregion
        #endregion
        #region override protected methods

        protected override void FacebookFetch(User i_LoggedInUser)
        {
            r_FriendsFetcher.Fetch(i_LoggedInUser);
            IEnumerable<User> friends = r_FriendsFetcher.GetFriends();
            foreach (IFriendFilter friendFilter in r_Filters.Values)
            {
                friendFilter.UpdateFriends(friends);
            }
        }

        protected override void ThrowShouldFetchFromFacebookException()
        {
            ThrowShouldFetchFromFacebookException("friends");
        }

        #endregion override protected methods
        #region private methods
        #endregion private methods
    }
}
