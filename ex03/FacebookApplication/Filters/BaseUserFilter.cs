namespace FacebookApplication.Filters
{
    using System;
    using System.Collections.Generic;

    using FacebookApplication.Interfaces;

    using FacebookWrapper.ObjectModel;

    public abstract class BaseUserFilter : IUsersFilter
    {
        #region public methods

        #region IUsersFilter

        public IEnumerable<User> FilterUsers(
            IEnumerable<User> i_Users,
            out Dictionary<string, List<string>> i_UsersThatThrowExceptionNamesByError)
        {
            i_UsersThatThrowExceptionNamesByError = new Dictionary<string, List<string>>();
            FacebookObjectCollection<User> filteredUsers = new FacebookObjectCollection<User>();
            foreach (User user in i_Users)
            {
                try
                {
                    if (this.MantianConstrain(user))
                    {
                        filteredUsers.Add(user);
                    }
                }
                catch (Exception exception)
                {
                    string exceptionMessage = string.IsNullOrEmpty(exception.Message) ? "unknown error" : exception.Message;
                    bool firstUserForExceptionMessage = !i_UsersThatThrowExceptionNamesByError.ContainsKey(exception.Message);
                    i_UsersThatThrowExceptionNamesByError[exceptionMessage] = firstUserForExceptionMessage ? new List<string>() : i_UsersThatThrowExceptionNamesByError[exceptionMessage];
                    if (!i_UsersThatThrowExceptionNamesByError[exceptionMessage].Contains(user.Name))
                    {
                        i_UsersThatThrowExceptionNamesByError[exceptionMessage].Add(user.Name);
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
