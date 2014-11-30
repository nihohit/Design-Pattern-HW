using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    public partial class FriendsListsComboBox : UserControl
    {
        private const string c_AllFriendsOptionDisplayName = "All friends";
        private FriendList[] m_FriendLists;
        public event EventHandler FriendsListChanged;
        public FriendList SelectedFriendList { get; private set; }
        public bool AllFriendsSelected { get { return SelectedFriendList == null; } }

        public FriendsListsComboBox()
        {
            InitializeComponent();
            SelectedFriendList = null;
            m_FriendLists = null;
        }

        public void UpdateFriendsLists(IEnumerable<FriendList> i_FriendsLists)
        {
            m_FriendLists = i_FriendsLists == null ? null : new FriendList[i_FriendsLists.Count()];
            comboBox.Items.Clear();
            int i = 0;
            foreach (FriendList friendList in i_FriendsLists)
            {
                string friendListDisplayName = friendList.Name == c_AllFriendsOptionDisplayName ? c_AllFriendsOptionDisplayName + " (friends list)" : friendList.Name;
                m_FriendLists[i] = friendList;
                comboBox.Items.Insert(i, friendListDisplayName);
                i++;
            }

            comboBox.SelectedIndex = comboBox.Items.Add(c_AllFriendsOptionDisplayName);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox.SelectedIndex;
            //// if All friends (c_AllFriendsOptionDisplayName) choosen SelectedFriendList will be null
            SelectedFriendList = (selectedIndex == -1 || selectedIndex > ( m_FriendLists.Length - 1 ) ) ? null : m_FriendLists[selectedIndex];

            if (FriendsListChanged != null)
            {
                FriendsListChanged(this, new EventArgs());
            }
        }
    }
}
