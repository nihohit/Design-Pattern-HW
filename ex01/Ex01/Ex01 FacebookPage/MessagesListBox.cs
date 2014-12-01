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

        private void insertInboxThread(int i, InboxThread i_InboxThread)
        {
            listBox.Items.Insert(i, getInboxThreadDisplayName(i_InboxThread));
        }

        private string getInboxThreadDisplayName(InboxThread i_InboxThread)
        {
            string inboxThreadDisplayName = string.Format("Converstion with {0}", i_InboxThread.GetInboxThreadFriendsNames(UserIdThatInboxBelongsTo));
            return inboxThreadDisplayName;
        }
    }
}
