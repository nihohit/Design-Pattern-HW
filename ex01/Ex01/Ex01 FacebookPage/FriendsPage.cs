using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookApplication;
using FacebookApplication.Interfaces;
using FacebookWrapper.ObjectModel;

namespace Ex01_FacebookPage
{
    public partial class FriendsPage : ApplicationTabPage
    {
        private User[] m_Friends;
        public event EventHandler FilterChanged;
        private List<IUsersFilter> m_Filters;

        public FriendsPage()
        {
            InitializeComponent();
        }

        protected override void m_FacebookApplicationManager_AfterFetch(object i_Sender, EventArgs e)
        {
            updateFriendsList();
        }

        private void updateFriendsList()
        {
            Dictionary<Exception, FacebookObjectCollection<User>> usersThatThrowException;
            IEnumerable<User> friends = FacebookApplicationLogicManager.GetFriends(m_Filters, out usersThatThrowException);
            m_Friends = new User[4];
            listBox1.Items.Clear();
            int i = 0;
            foreach (User friend in friends)
            {
                string friendDisplayName = friend.Name;
                m_Friends[i] = friend;
                listBox1.Items.Insert(i, friend.Name);
                i++;
                if (i > 3)
                    break;
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            m_Filters = new List<IUsersFilter>();
            if (comboBox1.Text == "Male")
            {
                m_Filters.Add(new UsersGenderFilter(User.eGender.male));
            }
            else
            {
                m_Filters.Add(new UsersGenderFilter(User.eGender.female));
            }
            updateFriendsList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacebookApplicationLogicManager.CreateFriendList(textBox1.Text, m_Friends);
        }
    }
}
