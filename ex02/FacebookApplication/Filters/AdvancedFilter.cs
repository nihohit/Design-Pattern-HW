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
        public static string k_All = "All";
        public static string k_None = "None";

        private readonly List<IUsersFilter> r_UserFilters = new List<IUsersFilter>();
        
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
            IEnumerable<User> filteredUsers = GetFriendsBeforeFilterApplied(i_Users);
            Dictionary<string, List<string>> usersThatThrowExceptionNamesByError;
            foreach (IUsersFilter filter in r_UserFilters)
            {
                filteredUsers = ApplyCurrentFilter(filter, i_Users, filteredUsers, out usersThatThrowExceptionNamesByError);
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

        protected abstract IEnumerable<User> ApplyCurrentFilter(IUsersFilter i_Filter, IEnumerable<User> i_Users,
            IEnumerable<User> i_UsersAfterPreviousFiltersApplied,
            out Dictionary<string, List<string>> o_UsersThatThrowExceptionNamesByError);

        protected abstract IEnumerable<User> GetFriendsBeforeFilterApplied(IEnumerable<User> i_Users);

        protected abstract string GetDisplayWhenNoFilters();

        protected abstract string GetDisplayStringForToString(IUsersFilter i_Filter);

        protected abstract string TrimDisplayString(string i_DisplayString);

        public override string ToString()
        {
            string toString = string.Empty;
            if (r_UserFilters == null || r_UserFilters.Count < 1)
            {
                toString = GetDisplayWhenNoFilters();
            }
            else
            {
                foreach (IUsersFilter userFilter in r_UserFilters)
                {
                    toString += GetDisplayStringForToString(userFilter);
                }

                toString = TrimDisplayString(toString);
            }

            return toString;
        }
    }
}
