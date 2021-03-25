using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthorizationApp
{
    public partial class PassChange : Form
    {
        public PassChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //need to add pass change in DB
            this.Close();
            AuthPage auth = new AuthPage();
            auth.Show();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            this.Close();
            AuthPage auth = new AuthPage();
            auth.Show();
        }
    }
}
