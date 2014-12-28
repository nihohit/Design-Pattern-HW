using System;
using System.Collections.Generic;
using System.Linq;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendsFilter : IFriendFilter
    {
        #region members

        private readonly Dictionary<string, User> r_FilteredFriends;
        private readonly IUsersFilter r_UsersFilter;
        #endregion members
        #region Properties
        #region IFriendFilter

        public string Name { get; private set; }

        public IEnumerable<string> FilterdFriendsIds
        {
            get { return r_FilteredFriends.Keys; }
        }

        public IEnumerable<User> FilterdFriends
        {
            get { return r_FilteredFriends.Values; }
        }

        public string ErrorString { get; private set; }

        #endregion IFriendFilter
        #endregion Properties
        #region constructor

        public FriendsFilter(string i_Name, IUsersFilter i_UsersFilter)
        {
            if (string.IsNullOrEmpty(i_Name))
            {
                throw new ArgumentException("Missing filter name");
            }

            if (i_UsersFilter == null)
            {
                throw new ArgumentException("Missing users filter");
            }

            Name = i_Name;
            r_UsersFilter = i_UsersFilter;
            r_FilteredFriends = new Dictionary<string, User>();
        }
        #endregion constructor
        #region public methods

        public void UpdateFriends(IEnumerable<User> i_Friends)
        {
            r_FilteredFriends.Clear();
            ErrorString = string.Empty;
            IEnumerable<User> friends = i_Friends;
            if (i_Friends != null && i_Friends.Count() > 1)
            {
                Dictionary<string, string> usersThatThrowExceptionNamesByError;
                friends = r_UsersFilter.FilterUsers(friends, out usersThatThrowExceptionNamesByError);
                if (usersThatThrowExceptionNamesByError != null)
                {
                    foreach (string errorMessage in usersThatThrowExceptionNamesByError.Keys)
                    {
                        ErrorString += string.Format(
                                "{0} couldn't be filtered because: {1}{2}",
                                usersThatThrowExceptionNamesByError[errorMessage],
                                errorMessage,
                                Environment.NewLine);
                    }
                }
            }

            foreach (User friend in friends)
            {
                r_FilteredFriends.Add(friend.Id, friend);
            }

            ErrorString = ErrorString.Trim(Environment.NewLine.ToCharArray());
        }

        public override string ToString()
        {
            return string.Format("'{0}': ", Name) + r_UsersFilter.ToString();            
        }
        #endregion public methods
    }
}
