using FacebookApplication.Interfaces;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FacebookApplication
{
    public class FriendsFetcher : FacebookFetchable, IFriendsFetcher
    {
        #region members

        private FacebookObjectCollection<User> m_Friends;
        #endregion members
        #region Properties
        #endregion Properties
        #region constructor

        public FriendsFetcher(TimeSpan? i_MinIntervalBetweenFetchActions)
            : base(i_MinIntervalBetweenFetchActions)
        {
            reset();
        }
        #endregion constructor
        #region public methods
        #region IFriendsFetcher
        public IEnumerable<User> GetFriends(IEnumerable<IUsersFilter> i_filters, out Dictionary<Exception, FacebookObjectCollection<User>> o_UsersThatThrowException)
        {
            o_UsersThatThrowException = new Dictionary<Exception, FacebookObjectCollection<User>>();
            FacebookObjectCollection<User> friends = new FacebookObjectCollection<User>(m_Friends.Count);
            foreach (User user in m_Friends)
            {
                friends.Add(user);
            }

            if (i_filters != null)
            {
                foreach (IUsersFilter filter in i_filters)
                {
                    Dictionary<Exception, FacebookObjectCollection<User>> usersThatThrowExceptionWhenFiltered;
                    friends = filter.FilterUsers(friends, out usersThatThrowExceptionWhenFiltered);
                    if (usersThatThrowExceptionWhenFiltered != null && usersThatThrowExceptionWhenFiltered.Count > 0)
                    {
                        foreach (Exception exception in usersThatThrowExceptionWhenFiltered.Keys)
                        {
                            FacebookObjectCollection<User> usersThrowsThisSpecificException;
                            if (!o_UsersThatThrowException.TryGetValue(exception, out usersThrowsThisSpecificException))
                            {
                                usersThrowsThisSpecificException = usersThatThrowExceptionWhenFiltered[exception];
                            }
                            else
                            {
                                foreach (User user in usersThatThrowExceptionWhenFiltered[exception])
                                {
                                    usersThrowsThisSpecificException.Add(user);
                                }
                            }
                        }
                    }
                }
            }

            return friends;
        }
        #endregion IFriendsFetcher
        #region override

        public override void ResetFetchDetails()
        {
            reset();
            base.ResetFetchDetails();
        }

        #endregion override
        #endregion public methods
        #region override protected methods

        protected override void FacebookFetch(User i_LoggedInUser)
        {
            fetchFriends(i_LoggedInUser);
        }

        protected override void ThrowShouldFetchFromFacebookException()
        {
            ThrowShouldFetchFromFacebookException("friends");
        }

        #endregion override protected methods
        #region private methods

        private void fetchFriends(User i_LoggedInUser)
        {
            m_Friends = i_LoggedInUser.Friends;
        }

        private void reset()
        {
            m_Friends = null;
        }

        #endregion private methods
        
    }
}
