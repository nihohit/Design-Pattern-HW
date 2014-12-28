using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication.Filters
{
    public class AdvancedFilter : IUsersFilter
    {
        private readonly List<IUsersFilter> r_UserFilters = new List<IUsersFilter>();
        
        public AdvancedFilter(List<IUsersFilter> i_UserFilters)
        {
            r_UserFilters = i_UserFilters;            
        }

        public IEnumerable<User> FilterUsers(IEnumerable<User> i_Users, out Dictionary<string, string> o_UsersThatThrowExceptionNamesByError)
        {
            o_UsersThatThrowExceptionNamesByError = new Dictionary<string, string>();
            IEnumerable<User> filteredUsers = i_Users;
            Dictionary<string, string> usersThatThrowExceptionNamesByError;
            foreach (IUsersFilter filter in r_UserFilters)
            {
                filteredUsers = filter.FilterUsers(filteredUsers, out usersThatThrowExceptionNamesByError);
                if (usersThatThrowExceptionNamesByError != null)
                {
                    foreach (string usersNames in usersThatThrowExceptionNamesByError.Keys)
                    {
                        o_UsersThatThrowExceptionNamesByError[usersNames] = o_UsersThatThrowExceptionNamesByError.ContainsKey(usersNames) ?
                            o_UsersThatThrowExceptionNamesByError[usersNames] + ", " : string.Empty;
                        o_UsersThatThrowExceptionNamesByError[usersNames] += usersThatThrowExceptionNamesByError[usersNames];
                    }
                }
            }

            return filteredUsers;
        }

        public override string ToString()
        {
            string displayString = string.Empty;
            foreach (IUsersFilter userFilter in r_UserFilters)
            {
                displayString += userFilter + ", ";
            }

            return displayString.Trim().Trim(',');
        }
    }
}
