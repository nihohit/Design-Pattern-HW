using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class UsersGenderFilter : IUsersFilter
    {
        #region members
        #endregion members
        #region Properties
        public User.eGender Gender { get; private set; }
        #endregion Properties
        #region constructor

        public UsersGenderFilter(User.eGender i_Gender)
        {
            Gender = i_Gender;
        }
        #endregion constructor
        #region public methods
        #region IUsersFilter
        public FacebookObjectCollection<User> FilterUsers(FacebookObjectCollection<User> i_Users, out Dictionary<Exception, FacebookObjectCollection<User>> o_UsersThatThrowException)
        {
            o_UsersThatThrowException = new Dictionary<Exception, FacebookObjectCollection<User>>();
            FacebookObjectCollection<User> filteredUsers = new FacebookObjectCollection<User>();
            foreach (User user in i_Users)
            {
                try
                {
                    if (user.Gender == Gender)
                    {
                        filteredUsers.Add(user);
                    }
                }
                catch (Exception exception)
                {
                    FacebookObjectCollection<User> usersThatThrowException;
                    if (!o_UsersThatThrowException.TryGetValue(exception, out usersThatThrowException))
                    {
                        usersThatThrowException = new FacebookObjectCollection<User>();
                        o_UsersThatThrowException.Add(exception, usersThatThrowException);
                    }

                    usersThatThrowException.Add(user);
                }
            }

            return filteredUsers;
        }
        #endregion IUsersFilter
        #endregion public methods
        #region private methods
        #endregion private methods
        
    }
}
