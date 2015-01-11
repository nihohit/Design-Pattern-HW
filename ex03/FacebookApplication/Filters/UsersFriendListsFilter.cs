namespace FacebookApplication.Filters
{
    using System.Collections.Generic;
    using System.Linq;

    using FacebookApplication.Interfaces;

    using FacebookWrapper.ObjectModel;

    public class UsersFriendListsFilter : BaseUserFilter
    {
        #region members

        private readonly FriendList r_FriendListBelongsTo;

        private readonly IFriendListsManager r_FriendListsManager;

        #endregion members

        #region constructor

        public UsersFriendListsFilter(FriendList i_FriendList, IFriendListsManager i_FriendListsManager)
        {
            this.r_FriendListsManager = i_FriendListsManager;
            this.r_FriendListBelongsTo = i_FriendList;
        }

        #endregion constructor

        #region override methods

        protected override bool MantianConstrain(User i_User)
        {
            IEnumerable<string> frindBelongToListsIds =
                this.r_FriendListsManager.GetAllFriendListsWhichFriendBelongsTo(i_User.Id);

            return frindBelongToListsIds.Contains(this.r_FriendListBelongsTo.Id);
        }

        public override string ToString()
        {
            return string.Format("Belongs to {0}", this.r_FriendListBelongsTo.Name);
        }
        #endregion
    }
}
