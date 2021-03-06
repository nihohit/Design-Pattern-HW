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
            var currentLimit = FacebookService.s_CollectionLimit;
            var finds = findInterestedFriendsNames(i_ShownInterestSince);
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
            var currentActivity = UserWrapper.Instance.AllActivity;

            var currentPosts = currentActivity.Where(i_Post => i_Post.CreatedTime >= i_ShownInterestSince.Date).ToList();
            var usersWhoLikedPosts = currentPosts.SelectMany(i_Post => i_Post.LikedBy);
            var usersWhoCommentedOnPosts =
                currentPosts.SelectMany(
                    i_Post => i_Post.Comments.Select(i_Comment => i_Comment.From)).ToArray();
            var combinedDistinctUsers = usersWhoLikedPosts.Union(usersWhoCommentedOnPosts).Distinct(r_UserComparer);

            // return all distinct users who liked or commented on posts 
            // that were created after the interest time requested.
            return combinedDistinctUsers.Where(i_User => !i_User.Id.Equals(UserWrapper.Instance.Id)).Select(i_User => i_User.Name);
        }

        #endregion private methods
    }
}
