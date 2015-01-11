using System.Collections.Generic;

using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IUsersFilter
    {
        #region methods
        IEnumerable<User> FilterUsers(
            IEnumerable<User> i_Users,
            out Dictionary<string, List<string>> i_UsersThatThrowExceptionNamesByError);
        #endregion Properties
    }
}
