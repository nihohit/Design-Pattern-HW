using Facebook;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class UsersGenderFilter : BaseUserFilter
    {
        #region members

        private readonly bool r_AddIfCantSeeGender;

        #endregion members

        #region Properties

        public User.eGender Gender { get; private set; }

        #endregion Properties

        #region constructor

        public UsersGenderFilter(User.eGender i_Gender, bool i_AddIfCantSeeGender)
        {
            Gender = i_Gender;
            this.r_AddIfCantSeeGender = i_AddIfCantSeeGender;
        }

        #endregion constructor

        #region override methods

        protected override bool MantianConstrain(User i_User)
        {
            if (i_User.Gender == null)
            {
                if (this.r_AddIfCantSeeGender)
                {
                    return true;
                }

                throw new FacebookOAuthException("Cannot see user gender");
            }

            return i_User.Gender == Gender;
        }

        public override string ToString()
        {
            return Gender.ToString() + (this.r_AddIfCantSeeGender ? " or gender is not defined" : string.Empty);
        }

        #endregion
    }
}
