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
    public partial class FetchingFromFacebookForm : Form
    {
        private const string c_messageFormat = "Fetching {0} from facebook...";
        private readonly Action r_FetchActionMethod;
        private readonly string r_FetchTypeDisplayString;

        public FetchingFromFacebookForm(Action i_FetchActionMethod, string i_FetchTypeDisplayString = "information")
        {
            InitializeComponent();
            r_FetchActionMethod = i_FetchActionMethod;
            r_FetchTypeDisplayString = i_FetchTypeDisplayString;
            int origLabelWidth = waitLabel.Width;
            waitLabel.Text = string.Format(c_messageFormat, r_FetchTypeDisplayString);
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
