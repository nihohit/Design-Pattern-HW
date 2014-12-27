using FacebookWrapper.ObjectModel;
using System.Collections.Generic;

namespace FacebookApplication.Interfaces
{
    public interface IUsersFilter
    {
        #region methods
        IEnumerable<User> FilterUsers(
            IEnumerable<User> i_Users,
            out Dictionary<string, FacebookObjectCollection<User>> o_UsersThatThrowExceptionByErrorMessgae);
        #endregion Properties
    }
}
