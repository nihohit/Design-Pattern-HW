using System;
using System.Collections.Generic;
using FacebookApplication;
using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    public partial class InboxPage : ApplicationTabPage
    {
        public InboxPage()
        {
            InitializeComponent();
        }

        protected override void m_FacebookApplicationManager_AfterFetch(object i_Sender, EventArgs e)
        {
            friendsFiltersCombo.UpdateFriendsFilters();
        }

        protected override void OnFacebookApplicationLogicManagerChanged()
        {
            friendsFiltersCombo.FacebookApplicationLogicManager = FacebookApplicationLogicManager;
        }

        private void friendsListsCombo_FriendsFiltersChanged(object sender, EventArgs e)
        {
            string usersThatCantBeFilteredMessage;
            IEnumerable<InboxThread> inboxThreads = friendsFiltersCombo.AllFriendsSelected
                ? FacebookApplicationLogicManager.GetAllInboxThreads()
                : FacebookApplicationLogicManager.GetInboxThreadsForSpecificFilter(friendsFiltersCombo.SelectedFriendFilterId.Trim(), out usersThatCantBeFilteredMessage);
            inboxMessagesListBox.UpdateInboxThreads(inboxThreads, FacebookApplicationLogicManager.LoggedInUser.Id);

        }

        private void inboxMessagesListBox_CurrentInboxThreadChanged(object sender, EventArgs e)
        {
            string currentInboxThreadDisplayString = inboxMessagesListBox.SelectedInboxThread == null
                ? string.Empty
                : inboxMessagesListBox.SelectedInboxThread.GetInboxThreadMessagesDisplayString();
            selectedMessageTextBox.Text = currentInboxThreadDisplayString;
        }
    }
}
