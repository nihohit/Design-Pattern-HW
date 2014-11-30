using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication
{
    public class UsersFreindListsFilter : BaseUserFilter
    {
        #region members

        #endregion members

        #region Properties

        public FriendList FriendListBelongsTo { get; private set; }
        public int MaxAge { get; private set; }

        #endregion Properties

        #region constructor

        public UsersFreindListsFilter(FriendList i_FriendList)
        {
            FriendListBelongsTo = i_FriendList;
        }

        #endregion constructor

        #region override methods

        protected override bool MantianConstrain(User i_User)
        {
            return FriendListBelongsTo.Members.Contains(i_User);
        }

        #endregion 
    }
}
