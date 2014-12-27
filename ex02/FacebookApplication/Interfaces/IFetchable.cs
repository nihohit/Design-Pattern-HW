using System;
using FacebookWrapper.ObjectModel;

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

        void Fetch();

        void ResetFetchDetails();

        #endregion methods
    }
}
