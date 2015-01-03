using System;
using System.Collections.Generic;
using FacebookApplication;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookAppGUI
{
    public partial class InboxPage : ApplicationTabPage
    {
        public InboxPage()
        {
            InitializeComponent();
            this.selectedMessageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inboxThreadDisplayBindingSource, "MessagesDisplayString", true,
                System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty));            
        }

        protected override Dictionary<eFetchOption, int> GetFetchTypesToFetchWithTheirCollectionLimit()
        {
            Dictionary<eFetchOption, int> typesAndCollectionLimit = new Dictionary<eFetchOption, int>
            {
                {
                    eFetchOption.Friends,
                    Extensions.k_FriendsCollectionLimit
                },
                {
                    eFetchOption.Inbox,
                    -1
                }
            };
            return typesAndCollectionLimit;
        }

        protected override void facebookApplicationManager_AfterFetch(object sender, FetchEventArgs e)
        {
            if (e.FetchOption == eFetchOption.All || e.FetchOption == eFetchOption.Friends || e.FetchOption == eFetchOption.Inbox)
            {
                if (e.FetchOption != eFetchOption.Inbox)
                {
                    updateFiltersDataSource();
                }
                else
                {
                    updateInboxThreads();
                }
            }
        }

        protected override void OnFacebookApplicationLogicManagerChanged()
        {
            if (FiltersFeatureManager != null)
            {
                FiltersFeatureManager.FriendFilterAdded += (object sender, EventArgs e) => { updateFiltersDataSource(); };
                FiltersFeatureManager.FriendFilterRemoved += (object sender, EventArgs e) => { updateFiltersDataSource(); };
            }
            updateFiltersDataSource();
        }

        protected override void OnBeforeFacebookApplicationLogicManagerChanging()
        {
            if (FiltersFeatureManager != null)
            {
                FiltersFeatureManager.FriendFilterAdded -= (object sender, EventArgs e) => { updateFiltersDataSource(); };
                FiltersFeatureManager.FriendFilterRemoved -= (object sender, EventArgs e) => { updateFiltersDataSource(); };
            }
        }
        
        private void iFriendFilterBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            updateInboxThreads();
        }

        private void updateFiltersDataSource()
        {
            iFriendFilterBindingSource.DataSource = (FiltersFeatureManager != null) ? new List<IFriendFilter>(FiltersFeatureManager.LoggedInUserFriendsFiltersManager.FriendsFilters) : null;
        }

        private void updateInboxThreads()
        {
            List<InboxThreadDisplay> inboxThreadsDisplay = null;
            IFriendFilter friendFilter = iFriendFilterBindingSource.Current as IFriendFilter;
            if (friendFilter != null)
            {
                string usersThatCantBeFilteredMessage = null;
                IEnumerable<InboxThread> inboxThreads = FiltersFeatureManager.GetInboxThreadsForSpecificFilter(
                    friendFilter.Name.Trim(), out usersThatCantBeFilteredMessage);
                inboxThreadsDisplay = new List<InboxThreadDisplay>();
                foreach (InboxThread inboxThread in inboxThreads)
                {
                    inboxThreadsDisplay.Add(new InboxThreadDisplay(inboxThread, UserWrapper.Instance.Id));
                }
            }

            inboxThreadDisplayBindingSource.DataSource = (inboxThreadsDisplay == null || inboxThreadsDisplay.Count < 1) ?
                typeof(InboxThreadDisplay) : inboxThreadDisplayBindingSource.DataSource = inboxThreadsDisplay;
        }
    }
}
