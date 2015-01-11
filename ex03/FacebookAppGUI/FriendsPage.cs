using System;
using System.Collections.Generic;
using FacebookApplication.Interfaces;
using FacebookApplication;
using FacebookWrapper.ObjectModel;

namespace FacebookAppGUI
{
    public partial class FriendsPage : ApplicationTabPage
    {
        public FriendsPage()
        {
            InitializeComponent();
        }

        protected override Dictionary<eFetchOption, int> GetFetchTypesToFetchWithTheirCollectionLimit()
        {
            Dictionary<eFetchOption, int> typesAndCollectionLimit = new Dictionary<eFetchOption, int>
            {
                {
                    eFetchOption.Friends,
                    Extensions.k_FriendsCollectionLimit
                }
            };
            return typesAndCollectionLimit;
        }

        protected override void facebookApplicationManager_AfterFetch(object sender, FetchEventArgs e)
        {
            if (e.FetchOption == eFetchOption.All || e.FetchOption == eFetchOption.Friends)
            {
                updateFiltersDataSource();
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

        private void updateFriends()
        {
            IFriendFilter friendFilter = iFriendFilterBindingSource.Current as IFriendFilter;
            userBindingSource.DataSource = friendFilter == null ? null : new List<User>(friendFilter.FilterdFriends);
        }

        private void updateFiltersDataSource()
        {
            iFriendFilterBindingSource.DataSource = (FiltersFeatureManager != null) ? new List<IFriendFilter>(FiltersFeatureManager.LoggedInUserFriendsFiltersManager.FriendsFilters) : null;
        }

        private void iFriendFilterBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            updateFriends();
        }
    }
}
