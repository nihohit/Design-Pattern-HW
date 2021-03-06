using System.Collections.Generic;
using System.Linq;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class UsersFriendListsFilter : BaseUserFilter
    {
        #region members

        private readonly IFriendListsManager r_FriendListsManager;
        #endregion members

        #region Properties

        public FriendList FriendListBelongsTo { get; private set; }

        #endregion Properties

        #region constructor

        public UsersFriendListsFilter(FriendList i_FriendList, IFriendListsManager i_FriendListsManager)
        {
            r_FriendListsManager = i_FriendListsManager;
            FriendListBelongsTo = i_FriendList;
        }

        #endregion constructor

        #region override methods

        protected override bool MantianConstrain(User i_User)
        {
            IEnumerable<string> frindBelongToListsIds =
                r_FriendListsManager.GetAllFriendListsWhichFriendBelongsTo(i_User.Id);

            return frindBelongToListsIds.Contains(FriendListBelongsTo.Id);
        }
        
        public override string ToString()
        {
            return string.Format("Belongs to {0}", FriendListBelongsTo.Name);
        }
        #endregion 
    }
}
