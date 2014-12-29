namespace FacebookApplication.Filters
{
    using System;
    using System.Collections.Generic;

    using FacebookApplication.Interfaces;

    using FacebookWrapper.ObjectModel;

    public static class FilterFactory
    {
        #region public methods

        public static IUsersFilter CreateFilter(
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
            if (!(i_FilterAge || i_FilterByFriendList || i_FilterGender))
            {
                throw new ArgumentException("Cannot add empty filter");
            }

            IUsersFilter usersFilter = null;
            if (i_FilterAge)
            {
                usersFilter = createFilter(usersFilter, new UsersAgeFilter(i_MinAge, i_MaxAge, i_AddIfAgeNotVisible));
            }

            if (i_FilterByFriendList)
            {
                usersFilter = createFilter(usersFilter, new UsersFriendListsFilter(i_FriendList, i_FriendsListManager));
            }

            if (i_FilterGender)
            {
                usersFilter = createFilter(usersFilter, new UsersGenderFilter(i_Gender, i_AddIfGenderNotVisible));
            }

            return usersFilter;
        }

        #endregion

        #region private methods

        private static IUsersFilter createFilter(IUsersFilter i_OldFilter, IUsersFilter i_AddedFilter)
        {
            IUsersFilter usersFilter;
            if (i_OldFilter == null)
            {
                usersFilter = null;
            }
            else
            {
                List<IUsersFilter> usersFilters = new List<IUsersFilter>();
                usersFilters.Add(i_OldFilter);
                usersFilters.Add(i_AddedFilter);
                usersFilter = new AdvancedFilter(usersFilters);
            }

            return usersFilter;
        }

        #endregion
    }
}
