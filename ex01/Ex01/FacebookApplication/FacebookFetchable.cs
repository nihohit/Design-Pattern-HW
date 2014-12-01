using System;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public abstract class FacebookFetchable : IFetchable
    {
        #region members

        private readonly Action<User> r_FetchAction;

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
        public void Fetch(User i_LoggedInUser)
        {
            TimeSpan timePassedFromLastFetch = FetchedTime == null ? TimeSpan.MaxValue : DateTime.UtcNow - (DateTime)FetchedTime;
            if (ForcedFetch || (MinIntervalBetweenFetchActions <= timePassedFromLastFetch))
            {
                ResetFetchDetails();
                i_LoggedInUser.ReFetch();
                if (r_FetchAction != null)
                {
                    r_FetchAction(i_LoggedInUser);
                }

                FetchedTime = DateTime.UtcNow;
                UserLoggedInWhenFetched = i_LoggedInUser;
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

        protected virtual void ThrowShouldFetchFromFacebookException()
        {
            ThrowShouldFetchFromFacebookException(null);
        }

        protected void ThrowShouldFetchFromFacebookException(string i_NameOfSpecificInfoToFetch)
        {
            string msg = string.Format(
                "Need to fetch {0} from facebook",
                string.IsNullOrEmpty(i_NameOfSpecificInfoToFetch) ? " information" : i_NameOfSpecificInfoToFetch);
            throw new ApplicationException(msg);
        }

        protected virtual void OnFetched(EventArgs e)
        {
            if (Fetched != null)
            {
                Fetched.Invoke(this, e);
            }
        }

        protected abstract void FacebookFetch(User i_LoggedInUser);

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
