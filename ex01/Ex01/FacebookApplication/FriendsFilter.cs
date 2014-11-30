﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendsFilter : IFriendFilter
    {
        #region members

        private readonly Dictionary<string, User> r_FilteredFriends;
        
        #endregion members
        #region Properties
        #region IFriendFilter

        public string Name { get; private set; }

        public IEnumerable<User> FilterdFriends
        {
            get { return r_FilteredFriends.Values; }
        }

        public IEnumerable<IUsersFilter> UserFilters { get; private set; }
        public string ErrorString { get; private set; }


        #endregion IFriendFilter
        #endregion Properties
        #region constructor

        public FriendsFilter(IEnumerable<IUsersFilter> i_UserFilters)
        {
            UserFilters = i_UserFilters;
            r_FilteredFriends = new Dictionary<string, User>();
        }
        #endregion constructor
        #region public methods

        public void UpdateFriends(IEnumerable<User> i_Friends)
        {
            r_FilteredFriends.Clear();
            ErrorString = string.Empty;
            IEnumerable<User> friends = i_Friends;
            foreach (IUsersFilter filter in UserFilters)
            {
                Dictionary<string, FacebookObjectCollection<User>> friendsThatThrowExceptionWhenTriedToFilterByErrorMessage;
                friends = filter.FilterUsers(friends, out friendsThatThrowExceptionWhenTriedToFilterByErrorMessage);
                if (friendsThatThrowExceptionWhenTriedToFilterByErrorMessage != null)
                {
                    foreach (string errorMessage in friendsThatThrowExceptionWhenTriedToFilterByErrorMessage.Keys)
                    {
                        foreach (User friend in friendsThatThrowExceptionWhenTriedToFilterByErrorMessage[errorMessage])
                        {
                            ErrorString += string.Format("{0} could not be filtered becouse: {1}{2}", friend.Name,
                                errorMessage, Environment.NewLine);
                        }
                    }
                }
            }
            foreach (User friend in friends)
            {
                r_FilteredFriends.Add(friend.Id, friend);
            }
            ErrorString = ErrorString.Trim(Environment.NewLine.ToCharArray());
        }

        #endregion public methods
        #region private methods


        #endregion private methods

        

}
}