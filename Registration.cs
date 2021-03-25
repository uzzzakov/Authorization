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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
        public User RegistrationMenu()
        {
            try
            {
                User user = new User();
                user.UserName = usernameTxb.Text;
                user.Password = passTxb.Text;
                user.LastName = lastnameTbx.Text;
                user.FirstName = firstnameTxb.Text;
                user.MiddleName = middlenameTxb.Text;
                user.DateOfBirth = DateTime.Parse(dateofbirthTxb.Text);
                user.PlaceOfBirth = placeofbirthTxb.Text;
                user.PhoneNumber = phonenumberTxb.Text;
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            var newClient = RegistrationMenu();
            if (newClient != null)
            {
                var result = await newClient.RegistrateUserAsync();
                if (result > 0)
                {
                    MessageBox.Show("Success");
                    this.Close();
                    Form1 form1 = new Form1();
                    form1.Show();
                }
            }
        }
    }
}
