using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication.Interfaces
{
    public interface IUsersFilter
    {
        #region methods
        IEnumerable<User> FilterUsers(IEnumerable<User> i_Users, out Dictionary<string, FacebookObjectCollection<User>> o_UsersThatThrowExceptionByErrorMessgae);
        #endregion Properties
    }
}
