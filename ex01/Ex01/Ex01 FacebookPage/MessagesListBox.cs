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
        private InboxThread[] m_InboxThreads;
        public event EventHandler CurrentInboxThreadChanged;
        public InboxThread SelectedInboxThread { get; private set; }
        public string UserIdThatInboxBelongsTo { get; private set; }
        
        public MessagesListBox()
        {
            InitializeComponent();
            SelectedInboxThread = null;
            m_InboxThreads = null;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox.SelectedIndex;
            SelectedInboxThread = (selectedIndex == -1) ? null : m_InboxThreads[selectedIndex];

            if (CurrentInboxThreadChanged != null)
            {
                CurrentInboxThreadChanged(this, new EventArgs());
            }
        }

        public void UpdateInboxThreads(IEnumerable<InboxThread> i_InboxThreads, string i_UserIdThatInboxBelongsTo)
        {
            UserIdThatInboxBelongsTo = i_UserIdThatInboxBelongsTo;
            m_InboxThreads = i_InboxThreads == null ? null : new InboxThread[i_InboxThreads.Count()];
            listBox.Items.Clear();
            int i = 0;
            foreach (InboxThread inboxThread in i_InboxThreads)
            {
                m_InboxThreads[i] = inboxThread;
                listBox.Items.Insert(i, getInboxThreadDisplayName(inboxThread));
                i++;
            }
        }

        private string getInboxThreadDisplayName(InboxThread i_InboxThread)
        {
            FacebookObjectCollection<FacebookWrapper.ObjectModel.Message> messages = i_InboxThread.Messages;
            FacebookWrapper.ObjectModel.Message lastMessage = (messages == null || messages.Count < 1) ? null : messages[messages.Count - 1];
            string lastMessageText = lastMessage == null ? string.Empty : lastMessage.Text;
            lastMessageText = string.IsNullOrEmpty(lastMessageText) ? "< message in unsupported format >" : lastMessageText; ////icon can return null
            string lastMessageDisplayString = (lastMessage == null)
                ? " "
                : string.Format("{0}\tlast message: {1}", Environment.NewLine, lastMessage.GetMessageDisplayString());
            string inboxThreadDisplayName = string.Format("Converstion with {0}{1}", i_InboxThread.GetInboxThreadFriendsNames(UserIdThatInboxBelongsTo), lastMessageDisplayString);
            return inboxThreadDisplayName;
        }
    }
}
