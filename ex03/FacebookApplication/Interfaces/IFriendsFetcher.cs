using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IFriendsFetcher : IFetchable
    {
        #region methods

        IEnumerable<User> GetFriends();

        #endregion methods
    }
}