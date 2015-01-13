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

        public IEnumerable<string> FindInterestedFriendsNames(DateTime i_ShownInterestSince, Func<IEnumerable<PostedItem>> i_ActivityStream)
        {
            var posts = i_ActivityStream();
            List<PostedItem> currentPosts = posts.Where(i_Post => i_Post.CreatedTime >= i_ShownInterestSince.Date).ToList();
            IEnumerable<User> usersWhoLikedPosts = currentPosts.SelectMany(i_Post => i_Post.LikedBy);
            IEnumerable<User> usersWhoCommentedOnPosts =
                currentPosts.SelectMany(
                    i_Post => i_Post.Comments.Select(i_Comment => i_Comment.From)).ToArray();
            IEnumerable<User> combinedDistinctUsers = usersWhoLikedPosts.Union(usersWhoCommentedOnPosts).Distinct(r_UserComparer);

            // return all distinct users who liked or commented on posts 
            // that were created after the interest time requested.
            return combinedDistinctUsers.Where(i_User => !i_User.Id.Equals(UserWrapper.Instance.Id)).Select(i_User => i_User.Name);
        }

        #endregion public methods
    }
}
