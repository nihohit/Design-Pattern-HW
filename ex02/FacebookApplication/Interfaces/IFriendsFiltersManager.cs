using System;
using System.Collections.Generic;

namespace FacebookApplication.Interfaces
{
    using FacebookApplication.Filters;

    public interface IFriendsFiltersManager : IFetchable
    {
        #region Properties

        IEnumerable<IFriendFilter> FriendsFilters { get; }

        IEnumerable<string> FriendsFiltersIds { get; }

        #endregion
        #region events

        event EventHandler FilterAdded;

        event EventHandler FilterRmoved;

        #endregion events
        #region methods

        string AddFriendFilter(FriendsFilter i_FriendsFilter);

        bool RemoveFriendFilter(string i_FilterName);

        IFriendFilter GetFriendFilter(string i_FilterName);

        #endregion methods
    }
}
