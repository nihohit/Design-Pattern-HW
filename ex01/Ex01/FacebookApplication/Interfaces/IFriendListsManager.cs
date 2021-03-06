using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Interfaces
{
    public interface IFriendListsManager : IFetchable
    {
        #region methods

        IEnumerable<FriendList> GetRelevantFriendsListsForLoggedinUser();

        IEnumerable<string> GetAllFriendListsWhichFriendBelongsTo(string i_FriendId);

        string GetFriendListsDisplayName(IEnumerable<FriendList> i_FriendLists);

        FriendList CreateFriendList(string i_Name, IEnumerable<User> i_Members);

        #endregion methods
    }
}
