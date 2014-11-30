using System.Collections.ObjectModel;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication.Interfaces
{
    public interface IFriendFilter
    {
        #region properties

        string Name { get; }
        IEnumerable<IUsersFilter> UserFilters { get; }
        IEnumerable<User> FilterdFriends { get; }
        string ErrorString { get; }

        #endregion properties
        #region methods

        void UpdateFriends(IEnumerable<User> i_Friends);
        
        #endregion methods
    }
}
