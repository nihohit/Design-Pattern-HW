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
    public partial class LongMessageToUserForm : Form
    {
        public string Message { get; private set; }
        public LongMessageToUserForm(string i_Message)
        {
            InitializeComponent();
            Message = i_Message;
        }

        private void LongMessageToUserForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
