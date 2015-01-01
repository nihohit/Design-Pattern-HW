using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public static class UsersFilterFactory
    {
        #region public methods

        public static IUsersFilter CreateFilter(
            bool i_FilterGender = false,
            User.eGender i_Gender = User.eGender.female,
            bool i_AddIfGenderNotVisible = true,
            bool i_FilterAge = false,
            int i_MinAge = 0,
            int i_MaxAge = 0,
            bool i_AddIfAgeNotVisible = true,
            bool i_FilterByFriendList = false,
            FriendList i_FriendList = null,
            IFriendListsManager i_FriendsListManager = null)
        {
            List<IUsersFilter> usersFilters = new List<IUsersFilter>();
            if (i_FilterGender)
            {
                usersFilters.Add(new UsersGenderFilter(i_Gender, i_AddIfGenderNotVisible));
            }

            if (i_FilterAge)
            {
                usersFilters.Add(new UsersAgeFilter(i_MinAge, i_MaxAge, i_AddIfAgeNotVisible));
            }

            if (i_FilterByFriendList)
            {
                usersFilters.Add(new UsersFriendListsFilter(i_FriendList, i_FriendsListManager));
            }

            IUsersFilter usersFilter = (usersFilters != null) && (usersFilters.Count == 1) ?
                usersFilters[0] : new AndFilter(usersFilters);
            return usersFilter;
        }

        #endregion

        #region private methods
        #endregion
    }
}
