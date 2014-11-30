using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    public static class Extensions
    {
        public static void ValidateUserNotNull(this User i_LoggedInUser)
        {
            if (i_LoggedInUser == null)
            {
                throw new NullReferenceException("Logged in user is missing");
            }
        }

        public static string GetMessageDisplayString(this Message i_Message)
        {
            string messageDisplayString = string.Empty;
            if (i_Message.Text == null)
            {
                messageDisplayString = GetUnsupportedFormatMessageDisplayString(i_Message.CreatedTime);
            }
            else
            {
                messageDisplayString = string.Format("[{0}] {1}", i_Message.CreatedTime, i_Message.Text);
            }
            return messageDisplayString;
        }

        public static string GetUnsupportedFormatMessageDisplayString(DateTime? i_CreatedTime)
        {
            return string.Format("[{0}] {1}", i_CreatedTime == null ? "???" : i_CreatedTime.ToString(), "< message in unsupported format >");
        }

        public static string GetInboxThreadMessagesDisplayString(this InboxThread i_InboxThread)
        {
            string inboxThreadDisplayString = string.Empty;
            FacebookObjectCollection<Message> messages = i_InboxThread.Messages;
            if (i_InboxThread.m_Messages == null || messages.Count == 0)
            {
                inboxThreadDisplayString = GetUnsupportedFormatMessageDisplayString(i_InboxThread.UpdatedTime);
            }
            else
            {
                foreach (Message message in messages)
                {
                    inboxThreadDisplayString += message.GetMessageDisplayString() + Environment.NewLine;
                }    
            }
            
            return inboxThreadDisplayString.Trim(Environment.NewLine.ToCharArray());
        }

        public static string GetInboxThreadFriendsNames(this InboxThread i_InboxThread, string i_UserIdThatInboxBelongsTo)
        {
            string inboxThreadFriendsNames = string.Empty;
            foreach (User friend in i_InboxThread.To)
            {
                if (i_UserIdThatInboxBelongsTo != friend.Id)
                {
                    inboxThreadFriendsNames += " " + friend.Name + ",";
                }
            }

            inboxThreadFriendsNames = inboxThreadFriendsNames.Trim(',');
            return inboxThreadFriendsNames.Trim();
        }
    }
}
