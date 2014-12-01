using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        string AddFriendFilter(string i_Name, IEnumerable<IUsersFilter> i_UserFilters);
        bool RemoveFriendFilter(string i_FilterId);
        IFriendFilter GetFriendFilter(string i_FilterId);

        #endregion methods
    }
}
