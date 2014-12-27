using System.Collections.Generic;

using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IFriendFilter
    {
        #region properties

        string Name { get; }

        IEnumerable<IUsersFilter> UserFilters { get; }

        IEnumerable<User> FilterdFriends { get; }

        IEnumerable<string> FilterdFriendsIds { get; }

        string ErrorString { get; }

        #endregion properties

        #region methods

        void UpdateFriends(IEnumerable<User> i_Friends);

        #endregion methods
    }
}
