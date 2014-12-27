using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookApplication;
using FacebookWrapper.ObjectModel;

namespace FacebookAppGUI
{
    public partial class MessagesListBox : UserControl
    {
        private readonly ListItemsContainer<InboxThread> r_ListItemsContainer;

        public event EventHandler CurrentInboxThreadChanged
        {
            add { r_ListItemsContainer.CurrentItemChanged += value; }
            remove { r_ListItemsContainer.CurrentItemChanged -= value; }
        }

        public InboxThread SelectedInboxThread
        {
            get { return r_ListItemsContainer.SelectedItem; }
        }

        public string UserIdThatInboxBelongsTo { get; private set; }

        public MessagesListBox()
        {
            InitializeComponent();
            r_ListItemsContainer = new ListItemsContainer<InboxThread>(insertInboxThread, () => listBox.Items.Clear());
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_ListItemsContainer.ChangeSelectedItem(listBox.SelectedIndex);
        }

        public void UpdateInboxThreads(IEnumerable<InboxThread> i_InboxThreads, string i_UserIdThatInboxBelongsTo)
        {
            UserIdThatInboxBelongsTo = i_UserIdThatInboxBelongsTo;
            r_ListItemsContainer.UpdateItems(i_InboxThreads);
        }

        private void insertInboxThread(int i_Index, InboxThread i_InboxThread)
        {
            listBox.Items.Insert(i_Index, getInboxThreadDisplayName(i_InboxThread));
        }

        private string getInboxThreadDisplayName(InboxThread i_InboxThread)
        {
            string inboxThreadDisplayName = string.Format("Converstion with {0}", i_InboxThread.GetInboxThreadFriendsNames(UserIdThatInboxBelongsTo));
            return inboxThreadDisplayName;
        }
    }
}
