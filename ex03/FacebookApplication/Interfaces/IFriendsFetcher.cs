using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IFriendsFetcher 
    {
        #region methods

        IEnumerable<User> GetFriends();

        #endregion methods
    }
}