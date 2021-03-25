using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthorizationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int IsInBase(string username, string pass)
        {
            string conString = "Data source = MANUCHO; initial catalog=MTUCI; integrated security=true";
            SqlConnection connection = new SqlConnection(conString);
            int result = -1;
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "use MTUCI";

                command.CommandText = $"select * from Users where UserName = '{username}' and Password = '{pass}'";
                SqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    result = (int)Reader["Id"];
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static string GetName(int id)
        {
            string conString = "Data source = MANUCHO; initial catalog=MTUCI; integrated security=true";
            SqlConnection connection = new SqlConnection(conString);
            string result = null;
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "use MTUCI";
                var auth = new AuthPage();
                command.CommandText = $"select * from Users where Id = {id}";
                SqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    result = (string)Reader["FirstName"];
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string user = loginTxtbx.Text;
            string pass = passwordTxtbx.Text;
            int isInBase = IsInBase(user, pass);
            if (isInBase > 0)
            {
                MessageBox.Show($"Здравствуй {GetName(isInBase)}");
                AuthPage auth = new AuthPage();
                auth.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный ввод!");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
