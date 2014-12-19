using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    using System;

    public static class Extensions
    {
        public const int k_FriendsCollectionLimit = 1000;

        public delegate string GetIdReturnDisplayNameDelegate<T>(T i_Item) where T : class;

        public static void FetchAndShowWaitWindow(this IWin32Window i_Win32Window, Action i_FetchActionMethod, string i_FetchTypeDisplayString = "information")
        {
            FetchingFromFacebookForm fetchingFromFacebookForm = new FetchingFromFacebookForm(i_FetchActionMethod, i_FetchTypeDisplayString);
            fetchingFromFacebookForm.ShowDialog(i_Win32Window);
        }

        public static void ShowLongMessageBox(this string i_Message, string i_Caption = "Message")
        {
            LongMessageToUserForm longMessageToUserForm = new LongMessageToUserForm(i_Message) { Text = i_Caption };
            longMessageToUserForm.Show();
        }
    }
}
