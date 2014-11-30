using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication
{
    public abstract class BaseUserFilter : IUsersFilter
    {

        #region constructor

        public BaseUserFilter()
        {
        }

        #endregion constructor

        #region public methods

        #region IUsersFilter

        public IEnumerable<User> FilterUsers(IEnumerable<User> i_Users,
            out Dictionary<string, FacebookObjectCollection<User>> o_UsersThatThrowException)
        {
            o_UsersThatThrowException = new Dictionary<string, FacebookObjectCollection<User>>();
            FacebookObjectCollection<User> filteredUsers = new FacebookObjectCollection<User>();
            foreach (User user in i_Users)
            {
                try
                {
                    if (MantianConstrain(user))
                    {
                        filteredUsers.Add(user);
                    }
                }
                catch (Exception exception)
                {
                    FacebookObjectCollection<User> usersThatThrowException;
                    if (!o_UsersThatThrowException.TryGetValue(exception.Message, out usersThatThrowException))
                    {
                        usersThatThrowException = new FacebookObjectCollection<User>();
                        o_UsersThatThrowException.Add(
                            string.IsNullOrEmpty(exception.Message) ? "unknown error" : exception.Message,
                            usersThatThrowException);
                    }

                    usersThatThrowException.Add(user);
                }
            }

            return filteredUsers;
        }

        #endregion IUsersFilter

        #endregion public methods

        #region protected methods
        
        protected abstract bool MantianConstrain(User i_User);

        #endregion
    }
}
