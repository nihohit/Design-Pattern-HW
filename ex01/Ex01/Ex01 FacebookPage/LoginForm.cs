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
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void loginAndInit()
        {
            /// Owner: design.patterns

            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
            LoginResult result = FacebookService.Login("501103096696183",
                "user_about_me", "user_friends", "friends_about_me", "publish_stream", "user_events", "read_stream",
                "user_status");
            // These are NOT the complete list of permissions.
            // The documentation regarding facebook login and permissions can be found here: 
            // v2.0: https://developers.facebook.com/docs/facebook-login/permissions/v2.0
            // v1.0: https://developers.facebook.com/docs/facebook-login/permissions/v1.0
            //"user_activities", "friends_activities",
            //"user_birthday", "friends_birthday",
            //"user_checkins", "friends_checkins",
            //"user_education_history", "friends_education_history",
            //"user_events", "friends_events",
            //"user_groups" , "friends_groups",
            //"user_hometown", "friends_hometown",
            //"user_interests", "friends_interests",
            //"user_likes", "friends_likes",
            //"user_location", "friends_location",
            //"user_notes", "friends_notes",
            //"user_online_presence", "friends_online_presence",
            //"user_photo_video_tags", "friends_photo_video_tags",
            //"user_photos", "friends_photos",
            //"user_photos", "friends_photos",
            //"user_relationships", "friends_relationships",
            //"user_relationship_details","friends_relationship_details",
            //"user_religion_politics","friends_religion_politics",
            //"user_status", "friends_status",
            //"user_videos", "friends_videos",
            //"user_website", "friends_website",
            //"user_work_history", "friends_work_history",
            //"email",
            //"read_friendlists",
            //"read_insights",
            //"read_mailbox",
            //"read_requests",
            //"read_stream",
            //"xmpp_login",

            //"create_event",
            //"rsvp_event",
            //"sms",
            //"publish_checkins",
            //"manage_friendlists",
            //"manage_pages"

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                var tabsPage = new TabsPage(result.LoggedInUser);
                tabsPage.Location = this.Location;
                tabsPage.StartPosition = FormStartPosition.Manual;
                tabsPage.FormClosing += delegate { this.Show(); };
                tabsPage.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }
    }
}
