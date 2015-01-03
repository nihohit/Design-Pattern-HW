using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public abstract class AdvancedFilter : IUsersFilter
    {
        protected const string k_All = "All";
        protected const string k_None = "None";

        private readonly List<IUsersFilter> r_UserFilters = new List<IUsersFilter>();

        protected abstract string DisplayForEmptyFilter { get; }
        protected abstract char DisplayFiltersSeperator { get; }

        protected AdvancedFilter(List<IUsersFilter> i_UserFilters)
        {
            if (i_UserFilters != null)
            {
                r_UserFilters = i_UserFilters;
            }
        }

        public IEnumerable<User> FilterUsers(IEnumerable<User> i_Users, out Dictionary<string, List<string>> o_UsersThatThrowExceptionNamesByError)
        {
            o_UsersThatThrowExceptionNamesByError = new Dictionary<string, List<string>>();
            IEnumerable<User> filteredUsers = GetFriendsForEmptyFilter(i_Users);
            Dictionary<string, List<string>> usersThatThrowExceptionNamesByError;
            foreach (IUsersFilter filter in r_UserFilters)
            {
                IEnumerable<User> currFilterFilteredUsers = filter.FilterUsers(i_Users, out usersThatThrowExceptionNamesByError);
                filteredUsers = ApplyAdvancedFilterOperator(filteredUsers, currFilterFilteredUsers);
                if (usersThatThrowExceptionNamesByError != null)
                {
                    foreach (string error in usersThatThrowExceptionNamesByError.Keys)
                    {
                        o_UsersThatThrowExceptionNamesByError[error] = o_UsersThatThrowExceptionNamesByError.ContainsKey(error) ?
                            o_UsersThatThrowExceptionNamesByError[error] : new List<string>();
                        foreach (string userName in usersThatThrowExceptionNamesByError[error])
                        {
                            if (!o_UsersThatThrowExceptionNamesByError[error].Contains(userName))
                            {
                                o_UsersThatThrowExceptionNamesByError[error].Add(userName);
                            }
                        }
                    }
                }
            }

            return filteredUsers;
        }

        protected abstract IEnumerable<User> ApplyAdvancedFilterOperator(IEnumerable<User> i_UsersBeforeCurrentFilter,
            IEnumerable<User> i_UsersAfterCurrentFilter);

        protected abstract IEnumerable<User> GetFriendsForEmptyFilter(IEnumerable<User> i_Users);
                
        public override string ToString()
        {
            string toString = string.Empty;
            if (r_UserFilters == null || r_UserFilters.Count < 1)
            {
                toString = DisplayForEmptyFilter;
            }
            else
            {
                foreach (IUsersFilter userFilter in r_UserFilters)
                {
                    toString += userFilter.ToString() + DisplayFiltersSeperator + " ";
                }

                toString = toString.Trim().Trim(DisplayFiltersSeperator);
            }

            return toString;
        }
    }
}
