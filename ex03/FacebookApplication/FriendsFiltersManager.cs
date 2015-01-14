using System;
using System.Collections.Generic;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    using FacebookApplication.Filters;

    public class FriendsFiltersManager : IFriendsFiltersManager
    {
        #region members

        private readonly Dictionary<string, IFriendFilter> r_Filters;
        private readonly FacebookFetchObject r_FacebookFetchObject;
        
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

        public FriendsFiltersManager(FacebookFetchObject i_FacebookFetchObject)
        {
            r_Filters = new Dictionary<string, IFriendFilter>();
            r_FacebookFetchObject = i_FacebookFetchObject;
            r_FacebookFetchObject.AttachFetchFriendsObserver(updateFriends);
        }

        #endregion constructor
        #region public methods
        
        public void Dispose()
        {
            r_FacebookFetchObject.DetachFetchFriendsObserver(updateFriends);
        }

        #region IFriendFilterManager
        public string AddFriendFilter(FriendsFilter i_FriendsFilter)
        {
            string name = i_FriendsFilter.Name;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Filter name not valid");
            }

            if (r_Filters.ContainsKey(name))
            {
                throw new ArgumentException("Filter already exist");
            }

            r_Filters.Add(name, i_FriendsFilter);
            if (FilterAdded != null)
            {
                FilterAdded(this, new EventArgs());
            }

            return name;
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
        
        #region private methods
        
        private void updateFriends(IEnumerable<User> i_Friends)
        {
            foreach (IFriendFilter friendFilter in r_Filters.Values)
            {
                friendFilter.UpdateFriends(i_Friends);
            }
        }
        
        #endregion private methods
    }
}
