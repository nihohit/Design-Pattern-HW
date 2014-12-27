using System.Windows.Forms;

namespace FacebookAppGUI
{
    using System;

    public static class Extensions
    {
        public const int k_FriendsCollectionLimit = 1000;

        public delegate string GetIdReturnDisplayNameDelegate<T>(T i_Item) where T : class;

        public static void FetchAndShowWaitWindow(this IWin32Window i_Win32Window, Action i_FetchActionMethod, string i_FetchTypeDisplayString = "information")
        {
            FormFetchingFromFacebook fetchingFromFacebookForm = new FormFetchingFromFacebook(i_FetchActionMethod, i_FetchTypeDisplayString);
            fetchingFromFacebookForm.ShowDialog(i_Win32Window);
        }

        public static void ShowLongMessageBox(this string i_Message, string i_Caption = "Message")
        {
            FormLongMessageToUser longMessageToUserForm = new FormLongMessageToUser(i_Message) { Text = i_Caption };
            longMessageToUserForm.Show();
        }
    }
}
