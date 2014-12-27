using System;
using System.Windows.Forms;

namespace FacebookAppGUI
{
    public partial class FormLongMessageToUser : Form
    {
        public string Message { get; private set; }

        public FormLongMessageToUser(string i_Message)
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
