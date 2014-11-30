using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class FriendsFiltersManager : FacebookFetchable, IFriendsFiltersManager
    {
        #region members

        private readonly Dictionary<string, IFriendFilter> r_Filters;
        private readonly IFriendsFetcher r_FriendsFetcher;

        #endregion members
        #region Properties
        
        #endregion Properties
        #region constructor

        public FriendsFiltersManager(IFriendsFetcher i_FriendsFetcher, TimeSpan? i_MinIntervalBetweenFetchActions)
            : base(i_MinIntervalBetweenFetchActions)
        {
            r_FriendsFetcher = i_FriendsFetcher;
            r_Filters = new Dictionary<string, IFriendFilter>();
        }

        #endregion constructor
        #region public methods
        #region IFriendFilterManager
        public string AddFriendFilter(string i_Name, int i_MinAge, int i_MaxAge, FacebookWrapper.ObjectModel.User.eGender i_Gender)
        {
            throw new NotImplementedException();
        }

        public string RemoveFriendFilter(string i_FilterId)
        {
            throw new NotImplementedException();
        }

        public IFriendFilter GetFriendFilter(string i_FilterId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        #region override protected methods

        protected override void FacebookFetch(User i_LoggedInUser)
        {
            r_FriendsFetcher.Fetch(i_LoggedInUser);
            IEnumerable<User> friends = r_FriendsFetcher.GetFriends();
            foreach (IFriendFilter friendFilter in r_Filters.Values)
            {
                friendFilter.UpdateFriends(friends);
            }
        }

        protected override void ThrowShouldFetchFromFacebookException()
        {
            ThrowShouldFetchFromFacebookException("friends lists");
        }

        #endregion override protected methods
        #region private methods
        #endregion private methods


    }
}
