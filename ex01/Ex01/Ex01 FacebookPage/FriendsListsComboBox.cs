using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    public partial class FriendsListsComboBox : UserControl
    {
        private const string k_CAllFriendsOptionDisplayName = "All friends";
        private FriendList[] m_FriendLists;

        public event EventHandler FriendsListChanged;

        public FriendList SelectedFriendList { get; private set; }

        public string LabelText
        {
            get { return friendsListsLabel.Text; }
            set
            {
                friendsListsLabel.Text = value;
                int origComboBoxLocationX = comboBox.Location.X;
                comboBox.Location =
                    new Point(
                        friendsListsLabel.Location.X + friendsListsLabel.Size.Width +
                        Math.Max(
                        friendsListsLabel.Margin.Right,
                        comboBox.Margin.Left),
                        comboBox.Location.Y);
                comboBox.Size = new Size(
                    comboBox.Size.Width + origComboBoxLocationX - comboBox.Location.X,
                    comboBox.Size.Height);
            }
        }

        public bool AllFriendsSelected
        {
            get { return SelectedFriendList == null; }
        }

        public FriendsListsComboBox()
        {
            InitializeComponent();
            SelectedFriendList = null;
            m_FriendLists = null;
        }

        public void UpdateFriendsLists(IEnumerable<FriendList> i_FriendsLists)
        {
            var friendsListsAsArray = i_FriendsLists as FriendList[] ?? i_FriendsLists.ToArray();
            m_FriendLists = i_FriendsLists == null ? null : new FriendList[friendsListsAsArray.Count()];
            comboBox.Items.Clear();
            int i = 0;
            foreach (FriendList friendList in friendsListsAsArray)
            {
                string friendListDisplayName = friendList.Name == k_CAllFriendsOptionDisplayName
                    ? k_CAllFriendsOptionDisplayName + " (friends list)"
                    : friendList.Name;
                m_FriendLists[i] = friendList;
                comboBox.Items.Insert(i, friendListDisplayName);
                i++;
            }

            comboBox.SelectedIndex = comboBox.Items.Add(k_CAllFriendsOptionDisplayName);
            comboBox.SelectedItem = k_CAllFriendsOptionDisplayName;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox.SelectedIndex;
            //// if All friends (c_AllFriendsOptionDisplayName) choosen SelectedFriendList will be null
            SelectedFriendList = (selectedIndex == -1 || selectedIndex > (m_FriendLists.Length - 1))
                ? null
                : m_FriendLists[selectedIndex];

            if (FriendsListChanged != null)
            {
                FriendsListChanged(this, new EventArgs());
            }
        }
    }
}
