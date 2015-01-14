using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IFriendListsManager
    {
        #region methods

        IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser();

        IEnumerable<string> GetAllFriendListsWhichFriendBelongsTo(string i_FriendId);

        string GetFriendListsDisplayName(IEnumerable<FriendList> i_FriendLists);

        #endregion methods
    }
}
