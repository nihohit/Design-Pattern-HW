using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FacebookAppGUI
{
    public partial class FriendsListBox : UserControl
    {
        private readonly ListItemsContainer<User> r_ListItemsContainer;

        public event EventHandler CurrentFriendChanged
        {
            add { r_ListItemsContainer.CurrentItemChanged += value; }
            remove { r_ListItemsContainer.CurrentItemChanged -= value; }
        }

        public User SelectedFriend
        {
            get { return r_ListItemsContainer.SelectedItem; }
        }

        public FriendsListBox()
        {
            InitializeComponent();
            r_ListItemsContainer = new ListItemsContainer<User>(insertFriend, () => listBox.Items.Clear());
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_ListItemsContainer.ChangeSelectedItem(listBox.SelectedIndex);
        }

        public void UpdateFriends(IEnumerable<User> i_Friends)
        {
            r_ListItemsContainer.UpdateItems(i_Friends);
        }

        private void insertFriend(int i_Index, User i_Friend)
        {
            listBox.Items.Insert(i_Index, i_Friend.Name);
        }
    }
}
