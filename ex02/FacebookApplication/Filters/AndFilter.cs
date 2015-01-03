namespace FacebookApplication.Filters
{
    using System.Collections.Generic;
    using System.Linq;

    using FacebookApplication.Interfaces;

    using FacebookWrapper.ObjectModel;

    public class AndFilter : AdvancedFilter
    {
        protected override string DisplayForEmptyFilter
        {
            get { return k_All; }
        }

        protected override char DisplayFiltersSeperator
        {
            get { return ','; }
        }

        public AndFilter(List<IUsersFilter> i_UserFilters)
            : base(i_UserFilters)
        {
        }

        protected override IEnumerable<User> ApplyAdvancedFilterOperator(
            IEnumerable<User> i_UsersBeforeCurrentFilter,
            IEnumerable<User> i_UsersAfterCurrentFilter)
        {
            return (i_UsersBeforeCurrentFilter == null || i_UsersAfterCurrentFilter == null) ?
                new List<User>() : i_UsersBeforeCurrentFilter.Intersect(i_UsersAfterCurrentFilter);
        }

        protected override IEnumerable<User> GetFriendsForEmptyFilter(IEnumerable<User> i_Users)
        {
            return i_Users;
        }
    }
}
