namespace FacebookApplication.Filters
{
    using System;

    using Facebook;

    using FacebookWrapper.ObjectModel;

    public class UsersAgeFilter : BaseUserFilter
    {
        #region members

        private readonly bool r_AddWithoutVisibleAge;

        #endregion members

        #region Properties

        private int MinAge { get; set; }

        private int MaxAge { get; set; }

        #endregion Properties

        #region constructor

        public UsersAgeFilter(int i_MinAge, int i_MaxAge, bool i_AddIfAgeNotVisible)
        {
            this.MinAge = i_MinAge;
            this.MaxAge = i_MaxAge;
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
            return (this.MinAge <= age) && (age <= this.MaxAge);
        }

        public override string ToString()
        {
            return string.Format("Age between {0} to {1}{2}", this.MinAge, this.MaxAge, this.r_AddWithoutVisibleAge ? " or age is not defined" : string.Empty);
        }

        #endregion
    }
}
