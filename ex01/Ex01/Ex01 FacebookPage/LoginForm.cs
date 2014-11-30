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
    using FacebookApplication;
    using FacebookApplication.Interfaces;
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;

    public partial class LoginForm : Form
    {
        private IFacebookApplicationManager m_FacebookApplicationManager;
        private readonly string r_AppId = "540432436034011";//"501103096696183";
        private readonly string[] r_Permissions =
        {
            "user_about_me", "user_friends", "friends_about_me", "publish_stream", "user_events", "read_stream",
            "user_status", "publish_actions", "read_mailbox", "friends_checkins", "read_friendlists",
            "manage_friendlists"
        };

        public LoginForm()
        {
            InitializeComponent();
            m_FacebookApplicationManager = new FacebookApplicationManager();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void loginAndInit()
        {
            try
            {
                m_FacebookApplicationManager.LoginUser(r_AppId, r_Permissions);
                var tabsPage = new ApplicationTabsForm(m_FacebookApplicationManager)
                {
                    Location = this.Location,
                    StartPosition = FormStartPosition.Manual
                };
                tabsPage.FormClosing += delegate { this.Show(); };
                tabsPage.Show();
                this.Hide();
            }
            catch (Facebook.FacebookOAuthException exception)
            {
                exception.ShowErrorMessageBox();
            } 
        }
    }
}
