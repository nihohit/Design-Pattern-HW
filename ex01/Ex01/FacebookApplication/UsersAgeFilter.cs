using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication
{
    public class UsersAgeFilter : BaseUserFilter
    {
        #region members

        #endregion members

        #region Properties

        public int MinAge { get; private set; }
        public int MaxAge { get; private set; }

        #endregion Properties

        #region constructor

        public UsersAgeFilter(int i_MinAge, int i_MaxAge)
        {
            MinAge = i_MinAge;
            MaxAge = i_MaxAge;
        }

        #endregion constructor

        #region override methods

        protected override bool MantianConstrain(User i_User)
        {
            DateTime birthday = DateTime.Parse(i_User.Birthday);
            int age = DateTime.Today.Year - birthday.Year;
            return (MinAge <= age) && (age <= MaxAge);
        }

        public override string ToString()
        {
            return string.Format("Age between {0} to {1}", MinAge, MaxAge);
        }

        #endregion 
    }
}
