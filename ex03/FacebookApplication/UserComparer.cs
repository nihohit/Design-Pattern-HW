using System.Collections.Generic;

namespace FacebookApplication
{
    using FacebookWrapper.ObjectModel;

    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User i_FirstUser, User i_SecondUser)
        {
            return i_FirstUser == i_SecondUser
                   || (i_FirstUser != null && i_SecondUser != null && i_FirstUser.Id == i_SecondUser.Id);
        }

        public int GetHashCode(User i_User)
        {
            return i_User.Id.GetHashCode() ^ i_User.Name.GetHashCode();
        }
    }
}
