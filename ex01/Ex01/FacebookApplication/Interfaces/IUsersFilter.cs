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
        FacebookObjectCollection<User> FilterUsers(FacebookObjectCollection<User> i_Users, out Dictionary<Exception, FacebookObjectCollection<User>> o_UsersThatThrowException);
        #endregion Properties
    }
}
