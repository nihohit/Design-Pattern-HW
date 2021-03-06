using System;
using System.Windows.Forms;
using FacebookApplication;
using FacebookApplication.Interfaces;

namespace FacebookAppGUI
{
    using FacebookApplication.Filters;

    public partial class FormLogin : Form
    {
        private const string k_AppId = "540432436034011"; // "501103096696183"; //facebook stop supporting manage_friendlists, so cannot get members with our application any more

        private readonly IFiltersFeatureManager r_FiltersFeatureManager;

        private readonly string[] r_Permissions =
        {
            "user_about_me", "user_friends", "friends_about_me", "publish_stream", "user_events", "read_stream",
            "user_status", "publish_actions", "read_mailbox", "friends_checkins", "read_friendlists",
            "manage_friendlists"
        };

        public FormLogin()
        {
            InitializeComponent();
            this.r_FiltersFeatureManager = new FiltersFeatureManager();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void loginAndInit()
        {
            try
            {
                UserWrapper.Instance.LoginUser(k_AppId, r_Permissions);
                FormApplicationTabs tabsPage = new FormApplicationTabs(this.r_FiltersFeatureManager)
                {
                    Location = this.Location,
                    StartPosition = FormStartPosition.Manual
                };
                tabsPage.FormClosed += delegate { this.Close(); };
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
