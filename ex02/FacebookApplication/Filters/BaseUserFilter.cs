using System;
using System.Collections.Generic;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public abstract class BaseUserFilter : IUsersFilter
    {
        #region public methods

        #region IUsersFilter

        public IEnumerable<User> FilterUsers(
            IEnumerable<User> i_Users,
            out Dictionary<string, string> o_UsersThatThrowExceptionNamesByError)
        {
            o_UsersThatThrowExceptionNamesByError = new Dictionary<string, string>();
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
                    string exceptionMessage = string.IsNullOrEmpty(exception.Message) ? "unknown error" : exception.Message;
                    bool firstUserForExceptionMessage = !o_UsersThatThrowExceptionNamesByError.ContainsKey(exception.Message);
                    o_UsersThatThrowExceptionNamesByError[exceptionMessage] = firstUserForExceptionMessage ? user.Name : o_UsersThatThrowExceptionNamesByError[exceptionMessage] + ", " + user.Name;
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
