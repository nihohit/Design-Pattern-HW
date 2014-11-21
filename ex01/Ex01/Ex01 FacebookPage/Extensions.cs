using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01_FacebookPage
{
    using FacebookWrapper.ObjectModel;

    #region Extensions

    public static class Extensions
    {
        public static FacebookObjectCollection<GeoPostedItem> GetActivity(this User i_User)
        {
            var activities = new FacebookObjectCollection<GeoPostedItem>();

            foreach (var post in i_User.Posts)
            {
                activities.Add(post);
            }

            foreach (var status in i_User.Statuses)
            {
                activities.Add(status);
            }

            return activities;
        }
    }

    #endregion Extensions
}
