using System;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public abstract class FacebookFetchable : IFetchable
    {
        #region members

        private readonly Action r_FetchAction;

        #endregion members
        #region Events
        #region IFetchable

        public event EventHandler Fetched;

        #endregion IFetchable
        #endregion Events
        #region Properties
        #region IFetchable

        public DateTime? FetchedTime { get; private set; }

        public User UserLoggedInWhenFetched { get; private set; }

        public TimeSpan? MinIntervalBetweenFetchActions { get; private set; }

        public bool ForcedFetch
        {
            get
            {
                return MinIntervalBetweenFetchActions == null;
            }
        }

        #endregion IFetchable
        #endregion Properties
        #region constructor

        protected FacebookFetchable(TimeSpan? i_MinIntervalBetweenFetchActions)
        {
            MinIntervalBetweenFetchActions = i_MinIntervalBetweenFetchActions;
            r_FetchAction = FacebookFetch;
            reset();
        }

        #endregion constructor
        #region public methods
        #region IFetchable
        public void Fetch()
        {
            TimeSpan timePassedFromLastFetch = FetchedTime == null ? TimeSpan.MaxValue : DateTime.UtcNow - (DateTime)FetchedTime;
            if (ForcedFetch || (MinIntervalBetweenFetchActions <= timePassedFromLastFetch))
            {
                ResetFetchDetails();
                UserWrapper.Instance.ReFetch();
                if (r_FetchAction != null)
                {
                    r_FetchAction();
                }

                FetchedTime = DateTime.UtcNow;
                OnFetched(new EventArgs());
            }
        }

        public virtual void ResetFetchDetails()
        {
            reset();
        }

        #endregion IFetchable
        #endregion public methods
        #region protected methods

        protected virtual void OnFetched(EventArgs e)
        {
            if (Fetched != null)
            {
                Fetched.Invoke(this, e);
            }
        }

        protected abstract void FacebookFetch();

        #endregion protected methods
        #region private methods
        private void reset()
        {
            FetchedTime = null;
            UserLoggedInWhenFetched = null;
        }
        #endregion private methods
    }
}
