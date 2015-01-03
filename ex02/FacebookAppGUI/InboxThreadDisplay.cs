using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookApplication;

namespace FacebookAppGUI
{
    // This class is Adapter of the InboxThread class
    public class InboxThreadDisplay
    {
        #region members

        private readonly InboxThread r_InboxThread;

        private readonly string r_UserIdThatInboxBelongsTo;

        private const string k_MessageDisplayStringPrefix = "Converstion with ";
        
        #endregion

        #region Properties
 
        public string InboxThreadDisplayName { get; private set;}
        
        public string MessagesDisplayString { get; private set;}
        
        #endregion

        #region constractur

        public InboxThreadDisplay(InboxThread i_InboxThread, string i_UserIdThatInboxBelongsTo)
        {
            r_InboxThread = i_InboxThread;
            r_UserIdThatInboxBelongsTo = i_UserIdThatInboxBelongsTo;
            InboxThreadDisplayName = getInboxThreadDisplayName();
            MessagesDisplayString = i_InboxThread.GetInboxThreadMessagesDisplayString();
        }

        #endregion

        #region private methods

        private string getInboxThreadDisplayName()
        {
            FacebookObjectCollection<User> friends;
            return "Converstion with " + r_InboxThread.GetInboxThreadFriendsNames(r_UserIdThatInboxBelongsTo, out friends);
        }

        #endregion private methods
    }
}
