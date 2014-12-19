using System;
using System.Collections.Generic;

namespace FacebookApplication.Interfaces
{
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

        bool RemoveFriendFilter(string i_FilterId);

        IFriendFilter GetFriendFilter(string i_FilterId);

        #endregion methods
    }
}
