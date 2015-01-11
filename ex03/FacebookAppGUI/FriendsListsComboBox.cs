using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FacebookAppGUI
{
    public partial class FriendsListsComboBox : UserControl
    {
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
            FriendList[] friendsListsAsArray = i_FriendsLists as FriendList[] ?? i_FriendsLists.ToArray();
            m_FriendLists = i_FriendsLists == null ? null : new FriendList[friendsListsAsArray.Count()];
            comboBox.Items.Clear();
            int i = 0;
            foreach (FriendList friendList in friendsListsAsArray)
            {
                if (friendList.Members.Count > 0)
                {
                    string friendListDisplayName = friendList.Name;
                    m_FriendLists[i] = friendList;
                    comboBox.Items.Insert(i, friendListDisplayName);
                    i++;
                }
            }
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
