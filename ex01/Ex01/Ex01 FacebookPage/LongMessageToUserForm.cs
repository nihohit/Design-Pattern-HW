using System;
using System.Windows.Forms;

namespace Ex01_FacebookPage
{
    public partial class LongMessageToUserForm : Form
    {
        public string Message { get; private set; }

        public LongMessageToUserForm(string i_Message)
        {
            InitializeComponent();
            Message = i_Message;
        }

        private void longMessageToUserForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
