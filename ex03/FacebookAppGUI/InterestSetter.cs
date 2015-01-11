using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01_FacebookPage
{
    public class InterestSetter
    {
        #region fields

        private int m_remainingAmount;

        private readonly TimeSpan r_timeBetweenLikes;

        private readonly DateTime r_earliestItemsToLike;

        public User TargetOfIntereset { get; private set; }

        #endregion

        #region constructors

        public InterestSetter(User target, int amountOfLikes, TimeSpan timeBetweenLikes, DateTime earliestItems)
        {
            m_remainingAmount = amountOfLikes;
            TargetOfIntereset = target;
            r_timeBetweenLikes = timeBetweenLikes;
            r_earliestItemsToLike = earliestItems;
        }

        #endregion

        #region public methods

        public void StartInterestTask()
        {
            var item = GetRandomUnLikedItem();
        }

        #endregion

        #region private methods
        
        private PostedItem GetRandomUnLikedItem()
        {
            List<PostedItem> items = new List<PostedItem>();



            return items.FirstOrDefault();
        }

        #endregion
    }
}
