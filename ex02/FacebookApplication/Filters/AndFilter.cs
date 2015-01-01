using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookApplication
{
    public class AndFilter : AdvancedFilter
    {
        public AndFilter(List<IUsersFilter> i_UserFilters) : base(i_UserFilters) { }

        protected override IEnumerable<User> ApplyCurrentFilter(Interfaces.IUsersFilter i_Filter, IEnumerable<User> i_Users,
            IEnumerable<User> i_UsersAfterPreviousFiltersApplied, out Dictionary<string, List<string>> o_UsersThatThrowExceptionNamesByError)
        {
            return i_Filter.FilterUsers(i_UsersAfterPreviousFiltersApplied, out o_UsersThatThrowExceptionNamesByError);
        }
        
        protected override string GetDisplayWhenNoFilters()
        {
            return AdvancedFilter.k_All;
        }

        protected override string GetDisplayStringForToString(IUsersFilter i_Filter)
        {
            return i_Filter + ", ";
        }

        protected override string TrimDisplayString(string i_DisplayString)
        {
            return i_DisplayString.Trim().Trim(',');
        }

        protected override IEnumerable<User> GetFriendsBeforeFilterApplied(IEnumerable<User> i_Users)
        {
            return i_Users;
        }
    }
}
