using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication.Interfaces
{
    public interface IFriendsFiltersManager : IFetchable
    {
        #region methods

        string AddFriendFilter(string i_Name, int i_MinAge, int i_MaxAge, User.eGender i_Gender);
        string RemoveFriendFilter(string i_FilterId);
        IFriendFilter GetFriendFilter(string i_FilterId);

        #endregion methods
    }
}
