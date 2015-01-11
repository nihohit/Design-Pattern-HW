using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public class InterestChecker
    {
        #region private fields

        private readonly IEqualityComparer<User> r_UserComparer = new UserComparer();

        #endregion private fields

        #region public methods

        public IEnumerable<string> FindInterestedFriendsNames(DateTime i_ShownInterestSince, int i_AmountOfEntriesToCheck)
        {
            int currentLimit = FacebookService.s_CollectionLimit;
            IEnumerable<string> finds = findInterestedFriendsNames(i_ShownInterestSince);
            FacebookService.s_CollectionLimit = currentLimit;
            return finds;
        }

        public Task<IEnumerable<string>> FindInterestedFriendsNames(DateTime i_ShownInterestSince)
        {
            return new Task<IEnumerable<string>>(() => findInterestedFriendsNames(i_ShownInterestSince));
        }

        #endregion public methods

        #region private methods

        private IEnumerable<string> findInterestedFriendsNames(DateTime i_ShownInterestSince)
        {
            UserWrapper.Instance.ReFetch();
            IEnumerable<PostedItem> currentActivity = UserWrapper.Instance.AllActivity;

            List<PostedItem> currentPosts = currentActivity.Where(i_Post => i_Post.CreatedTime >= i_ShownInterestSince.Date).ToList();
            IEnumerable<User> usersWhoLikedPosts = currentPosts.SelectMany(i_Post => i_Post.LikedBy);
            IEnumerable<User> usersWhoCommentedOnPosts =
                currentPosts.SelectMany(
                    i_Post => i_Post.Comments.Select(i_Comment => i_Comment.From)).ToArray();
            IEnumerable<User> combinedDistinctUsers = usersWhoLikedPosts.Union(usersWhoCommentedOnPosts).Distinct(r_UserComparer);

            // return all distinct users who liked or commented on posts 
            // that were created after the interest time requested.
            return combinedDistinctUsers.Where(i_User => !i_User.Id.Equals(UserWrapper.Instance.Id)).Select(i_User => i_User.Name);
        }

        #endregion private methods
    }
}
