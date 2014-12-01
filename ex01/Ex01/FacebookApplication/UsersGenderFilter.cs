using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class UsersGenderFilter : BaseUserFilter
    {
        #region members

        #endregion members

        #region Properties

        public User.eGender Gender { get; private set; }

        #endregion Properties


        #region constructor

        public UsersGenderFilter(User.eGender i_Gender)
        {
            Gender = i_Gender;
        }

        #endregion constructor

        #region override methods

        protected override bool MantianConstrain(User i_User)
        {
            return i_User.Gender == Gender;
        }
        
        public override string ToString()
        {
            return Gender.ToString();
        }

        #endregion
    }
}
