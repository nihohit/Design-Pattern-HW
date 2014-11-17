using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    using FacebookWrapper.ObjectModel;

    public partial class TabsPage : Form
    {
        private User m_User;

        public TabsPage(User user)
        {
            InitializeComponent();
            this.m_User = user;
        }

        private void TabsPage_Load(object sender, EventArgs e)
        {

        }
    }
}
