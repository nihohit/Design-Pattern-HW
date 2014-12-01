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

        private void insertFriend(int i, User i_Friend)
        {
            listBox.Items.Insert(i, i_Friend.Name);
        }
    }
}
