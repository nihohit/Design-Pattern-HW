using System;
using System.Collections.Generic;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public abstract class BaseUserFilter : IUsersFilter
    {
        protected BaseUserFilter() 
        { 
        }

        #region public methods

        #region IUsersFilter

        public IEnumerable<User> FilterUsers(
            IEnumerable<User> i_Users,
            out Dictionary<string, List<string>> o_UsersThatThrowExceptionNamesByError)
        {
            o_UsersThatThrowExceptionNamesByError = new Dictionary<string, List<string>>();
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
                    o_UsersThatThrowExceptionNamesByError[exceptionMessage] = firstUserForExceptionMessage ? new List<string>() : o_UsersThatThrowExceptionNamesByError[exceptionMessage];
                    if (!o_UsersThatThrowExceptionNamesByError[exceptionMessage].Contains(user.Name))
                    {
                        o_UsersThatThrowExceptionNamesByError[exceptionMessage].Add(user.Name);
                    }
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
