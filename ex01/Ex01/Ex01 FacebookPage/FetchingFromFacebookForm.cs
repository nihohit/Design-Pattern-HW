using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    public partial class FetchingFromFacebookForm : Form
    {
        private const string k_MessageFormat = "Fetching {0} from facebook...";
        private readonly Action r_FetchActionMethod;

        public FetchingFromFacebookForm(Action i_FetchActionMethod, string i_FetchTypeDisplayString = "information")
        {
            InitializeComponent();
            r_FetchActionMethod = i_FetchActionMethod;
            int origLabelWidth = waitLabel.Width;
            waitLabel.Text = string.Format(k_MessageFormat, i_FetchTypeDisplayString);
            this.Size = new Size(this.Width + waitLabel.Width - origLabelWidth, this.Height);
        }

        private void FetchingFromFacebookForm_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            this.Close();
        }

        private void FetchingFromFacebookForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            r_FetchActionMethod();
        }
    }
}
