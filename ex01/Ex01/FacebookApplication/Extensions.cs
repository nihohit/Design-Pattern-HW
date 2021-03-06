using System;
using FacebookWrapper.ObjectModel;

namespace FacebookApplication
{
    using System.Windows.Forms;

    using Message = FacebookWrapper.ObjectModel.Message;

    public static class Extensions
    {
        public static string FormatWith(this string i_Str, params object[] i_FormattingInfo)
        {
            return string.Format(i_Str, i_FormattingInfo);
        }

        public static void ValidateUserNotNull(this User i_LoggedInUser)
        {
            if (i_LoggedInUser == null)
            {
                throw new NullReferenceException("Logged in user is missing");
            }
        }

        public static string GetMessageDisplayString(this Message i_Message)
        {
            string messageDisplayString =
                i_Message.Text == null ?
                    GetUnsupportedFormatMessageDisplayString(i_Message.CreatedTime) :
                    string.Format("[{0}] {1}", i_Message.CreatedTime, i_Message.Text);

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

        public static string GetInboxThreadFriendsNames(
            this InboxThread i_InboxThread,
            string i_UserIdThatInboxBelongsTo,
            out FacebookObjectCollection<User> o_Friends)
        {
            o_Friends = new FacebookObjectCollection<User>();
            string inboxThreadFriendsNames = string.Empty;
            foreach (User friend in i_InboxThread.To)
            {
                if (i_UserIdThatInboxBelongsTo != friend.Id)
                {
                    o_Friends.Add(friend);
                    inboxThreadFriendsNames += " " + friend.Name + ",";
                }
            }

            inboxThreadFriendsNames = inboxThreadFriendsNames.Trim(',');
            return inboxThreadFriendsNames.Trim();
        }

        public static string GetInboxThreadFriendsNames(this InboxThread i_InboxThread, string i_UserIdThatInboxBelongsTo)
        {
            FacebookObjectCollection<User> friends;
            return i_InboxThread.GetInboxThreadFriendsNames(i_UserIdThatInboxBelongsTo, out friends);
        }

        public static bool LikedByUser(this PostedItem i_Item, string i_UserId)
        {
            return i_Item.LikedBy.Find(i_User => i_User.Id == i_UserId) != null;
        }

        public static DialogResult ShowErrorMessageBox(this Exception i_Exception, string i_Caption = "Error")
        {
            return MessageBox.Show(i_Exception.Message, i_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
