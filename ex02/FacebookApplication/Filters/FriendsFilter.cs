namespace FacebookApplication.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FacebookApplication.Interfaces;

    using FacebookWrapper.ObjectModel;

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
            get { return this.r_FilteredFriends.Keys; }
        }

        public IEnumerable<User> FilterdFriends
        {
            get { return this.r_FilteredFriends.Values; }
        }

        public string ErrorString { get; private set; }

        #endregion IFriendFilter
        #endregion Properties
        #region constructor

        public FriendsFilter(
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
            this.r_UsersFilter = UsersFilterFactory.CreateFilter(
                i_FilterGender,
                i_Gender,
                i_AddIfGenderNotVisible,
                i_FilterAge,
                i_MinAge,
                i_MaxAge,
                i_AddIfAgeNotVisible,
                i_FilterByFriendList,
                i_FriendList,
                i_FriendsListManager);
            this.Name = this.r_UsersFilter.ToString();
            this.r_FilteredFriends = new Dictionary<string, User>();
        }
        #endregion constructor
        #region public methods

        public void UpdateFriends(IEnumerable<User> i_Friends)
        {
            this.r_FilteredFriends.Clear();
            this.ErrorString = string.Empty;
            IEnumerable<User> friends = i_Friends;
            if (i_Friends != null && i_Friends.Count() > 1)
            {
                Dictionary<string, List<string>> usersThatThrowExceptionNamesByError;
                friends = this.r_UsersFilter.FilterUsers(friends, out usersThatThrowExceptionNamesByError);
                if (usersThatThrowExceptionNamesByError != null)
                {
                    foreach (string errorMessage in usersThatThrowExceptionNamesByError.Keys)
                    {
                        this.ErrorString += string.Format(
                                "{0} couldn't be filtered because: {1}{2}",
                                usersThatThrowExceptionNamesByError[errorMessage],
                                errorMessage,
                                Environment.NewLine);
                    }
                }

                foreach (User friend in friends)
                {
                    this.r_FilteredFriends.Add(friend.Id, friend);
                }

                this.ErrorString = this.ErrorString.Trim(Environment.NewLine.ToCharArray());
            }
        }

        public override string ToString()
        {
            return string.Format("'{0}': ", this.Name) + this.r_UsersFilter;
        }

        #endregion public methods
    }
}
