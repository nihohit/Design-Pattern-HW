using System;
using System.Collections.Generic;
using FacebookApplication;
using FacebookWrapper.ObjectModel;
using FacebookApplication.Interfaces;

namespace Ex01_FacebookPage
{
    public partial class InboxPage : ApplicationTabPage
    {
        public InboxPage()
        {
            InitializeComponent();
        }

        protected override Dictionary<eFetchOption, int> GetFetchTypesToFetchWithTheirCollectionLimit()
        {
            var typesAndCollectionLimit = new Dictionary<eFetchOption, int>
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
                    friendsFiltersCombo.UpdateFriendsFilters();
                }

                updateInboxList();
            }
        }

        protected override void OnFacebookApplicationLogicManagerChanged()
        {
            friendsFiltersCombo.FacebookApplicationLogicManager = FacebookApplicationLogicManager;
        }

        private void friendsListsCombo_FriendsFiltersChanged(object sender, EventArgs e)
        {
            updateInboxList();
        }

        private void inboxMessagesListBox_CurrentInboxThreadChanged(object sender, EventArgs e)
        {
            updateSelectedMessageTextBox();
        }

        private void updateSelectedMessageTextBox()
        {
            string currentInboxThreadDisplayString = inboxMessagesListBox.SelectedInboxThread == null
                ? string.Empty
                : inboxMessagesListBox.SelectedInboxThread.GetInboxThreadMessagesDisplayString();
            selectedMessageTextBox.Text = currentInboxThreadDisplayString;
        }

        private void updateInboxList()
        {
            string usersThatCantBeFilteredMessage = null;
            IEnumerable<InboxThread> inboxThreads = friendsFiltersCombo.AllFriendsSelected
                ? FacebookApplicationLogicManager.GetAllInboxThreads()
                : FacebookApplicationLogicManager.GetInboxThreadsForSpecificFilter(friendsFiltersCombo.SelectedFriendFilterId.Trim(), out usersThatCantBeFilteredMessage);
            inboxMessagesListBox.UpdateInboxThreads(inboxThreads, UserWrapper.Instance.Id);
            updateSelectedMessageTextBox();
            if (!string.IsNullOrEmpty(usersThatCantBeFilteredMessage))
            {
                usersThatCantBeFilteredMessage.ShowLongMessageBox();
            }
        }
    }
}
