using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacebookApplication
{
    public static class FilterFactory
    {
        #region public methods

        public static FriendsFilter CreateFilter(
            string i_Name, 
            bool i_FilterGender, 
            User.eGender i_Gender, 
            bool i_AddIfGenderNotVisible, 
            bool i_FilterAge, 
            int i_MinAge, 
            int i_MaxAge, 
            bool i_AddIfAgeNotVisible, 
            bool i_FilterByFriendList, 
            FriendList i_FriendList,
            IFriendListsManager i_FriendsListManager)
        {
            var usersFilters = new List<IUsersFilter>();

            if (string.IsNullOrEmpty(i_Name))
            {
                throw new ArgumentException("Missing filter name");
            }

            if (!(i_FilterAge || i_FilterByFriendList || i_FilterGender))
            {
                throw new ArgumentException("Cannot add empty filter");
            }

            if (i_FilterAge)
            {
                usersFilters.Add(new UsersAgeFilter(i_MinAge, i_MaxAge, i_AddIfAgeNotVisible));
            }

            if (i_FilterByFriendList)
            {
                usersFilters.Add(new UsersFriendListsFilter(i_FriendList, i_FriendsListManager));
            }

            if (i_FilterGender)
            {
                usersFilters.Add(new UsersGenderFilter(i_Gender, i_AddIfGenderNotVisible));
            }

            return new FriendsFilter(i_Name, usersFilters);
        }

        #endregion

        #region private methods

        #endregion
    }
}
