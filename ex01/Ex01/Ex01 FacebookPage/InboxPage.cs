using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            friendsListsCombo.UpdateFriendsLists(FacebookApplicationLogicManager.GetRelevantFriendsListsForLoggedinUser());
        }

        private void friendsListsCombo_FriendsListChanged(object sender, EventArgs e)
        {
            IEnumerable<InboxThread> inboxThreads = friendsListsCombo.AllFriendsSelected
                ? FacebookApplicationLogicManager.GetAllInboxThreads()
                : FacebookApplicationLogicManager.GetInboxThreadsForSpecificFriendList(friendsListsCombo.SelectedFriendList);
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
