using FacebookWrapper.ObjectModel;
using System.Collections.Generic;

namespace FacebookApplication.Interfaces
{
    public interface IUsersFilter
    {        
        #region methods
        IEnumerable<User> FilterUsers(
            IEnumerable<User> i_Users,
            out Dictionary<string, List<string>> o_UsersThatThrowExceptionNamesByError);
        #endregion Properties
    }
}
