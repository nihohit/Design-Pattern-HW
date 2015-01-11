namespace FacebookApplication.Filters
{
    using System.Collections.Generic;

    using FacebookApplication.Interfaces;

    using FacebookWrapper.ObjectModel;

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
                this.r_UserFilters = i_UserFilters;
            }
        }

        public IEnumerable<User> FilterUsers(IEnumerable<User> i_Users, out Dictionary<string, List<string>> i_UsersThatThrowExceptionNamesByError)
        {
            i_UsersThatThrowExceptionNamesByError = new Dictionary<string, List<string>>();
            IEnumerable<User> filteredUsers = this.GetFriendsForEmptyFilter(i_Users);
            foreach (IUsersFilter filter in this.r_UserFilters)
            {
                Dictionary<string, List<string>> usersThatThrowExceptionNamesByError;
                IEnumerable<User> currFilterFilteredUsers = filter.FilterUsers(i_Users, out usersThatThrowExceptionNamesByError);
                filteredUsers = this.ApplyAdvancedFilterOperator(filteredUsers, currFilterFilteredUsers);
                if (usersThatThrowExceptionNamesByError != null)
                {
                    foreach (string error in usersThatThrowExceptionNamesByError.Keys)
                    {
                        i_UsersThatThrowExceptionNamesByError[error] = i_UsersThatThrowExceptionNamesByError.ContainsKey(error) ?
                            i_UsersThatThrowExceptionNamesByError[error] : new List<string>();
                        foreach (string userName in usersThatThrowExceptionNamesByError[error])
                        {
                            if (!i_UsersThatThrowExceptionNamesByError[error].Contains(userName))
                            {
                                i_UsersThatThrowExceptionNamesByError[error].Add(userName);
                            }
                        }
                    }
                }
            }

            return filteredUsers;
        }

        protected abstract IEnumerable<User> ApplyAdvancedFilterOperator(
            IEnumerable<User> i_UsersBeforeCurrentFilter,
            IEnumerable<User> i_UsersAfterCurrentFilter);

        protected abstract IEnumerable<User> GetFriendsForEmptyFilter(IEnumerable<User> i_Users);

        public override string ToString()
        {
            string toString = string.Empty;
            if (this.r_UserFilters == null || this.r_UserFilters.Count < 1)
            {
                toString = this.DisplayForEmptyFilter;
            }
            else
            {
                foreach (IUsersFilter userFilter in this.r_UserFilters)
                {
                    toString += userFilter.ToString() + this.DisplayFiltersSeperator + " ";
                }

                toString = toString.Trim().Trim(this.DisplayFiltersSeperator);
            }

            return toString;
        }
    }
}
