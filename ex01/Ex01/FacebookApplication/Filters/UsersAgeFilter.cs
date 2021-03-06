using System;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class UsersAgeFilter : BaseUserFilter
    {
        #region members

        private readonly bool r_AddWithoutVisibleAge;

        #endregion members

        #region Properties

        public int MinAge { get; private set; }

        public int MaxAge { get; private set; }

        #endregion Properties

        #region constructor

        public UsersAgeFilter(int i_MinAge, int i_MaxAge, bool i_AddIfAgeNotVisible)
        {
            MinAge = i_MinAge;
            MaxAge = i_MaxAge;
            this.r_AddWithoutVisibleAge = i_AddIfAgeNotVisible;
        }

        #endregion constructor

        #region override methods

        protected override bool MantianConstrain(User i_User)
        {
            if (i_User.Birthday == null)
            {
                if (this.r_AddWithoutVisibleAge)
                {
                    return true;
                }

                throw new FacebookOAuthException("Cannot see user age");
            }

            DateTime birthday = DateTime.Parse(i_User.Birthday);
            int age = DateTime.Today.Year - birthday.Year;
            return (MinAge <= age) && (age <= MaxAge);
        }

        public override string ToString()
        {
            return string.Format("Age between {0} to {1}{2}", MinAge, MaxAge, this.r_AddWithoutVisibleAge ? " or age is not defined" : string.Empty);
        }

        #endregion
    }
}
