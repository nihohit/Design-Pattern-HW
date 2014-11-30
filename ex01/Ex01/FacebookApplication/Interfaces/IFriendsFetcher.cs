using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication.Interfaces
{
    public interface IFriendsFetcher : IFetchable
    {
        #region methods
        IEnumerable<User> GetFriends(IEnumerable<IUsersFilter> i_filters, out Dictionary<Exception, FacebookObjectCollection<User>> o_UsersThatThrowException);
        #endregion methods
    }
}