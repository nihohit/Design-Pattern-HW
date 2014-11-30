using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication.Interfaces
{
    public interface IFetchable
    {
        #region Properties

        bool ForcedFetch { get; }
        TimeSpan? MinIntervalBetweenFetchActions { get; }
        DateTime? FetchedTime { get; }
        User UserLoggedInWhenFetched { get; }

        #endregion Properties
        #region Events

        event EventHandler Fetched;

        #endregion Events
        #region methods

        void Fetch(User i_LoggedInUser);
        void ResetFetchDetails();

        #endregion methods
    }
}
