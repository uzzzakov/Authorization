using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AuthorizationApp
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PhoneNumber { get; set; }

        public async Task<int> RegistrateUserAsync()
        {
            using (var con = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("INSERT INTO Users(UserName, Password, LastName, FirstName, MiddleName, DateOfBirth, PlaceOfBirth, PhoneNumber) " +
                    "Values(@UserName, @Password, @LastName, @FirstName, @MiddleName, @DateOfBirth, @PlaceOfBirth, @PhoneNumber)", con))
            {
                try
                {
                    command.Parameters.AddWithValue("@UserName", this.UserName);
                    command.Parameters.AddWithValue("@Password", this.Password);
                    command.Parameters.AddWithValue("@LastName", this.LastName);
                    command.Parameters.AddWithValue("@FirstName", this.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", this.MiddleName);
                    command.Parameters.AddWithValue("@DateOfBirth", this.DateOfBirth);
                    command.Parameters.AddWithValue("@PlaceOfBirth", this.PlaceOfBirth);
                    command.Parameters.AddWithValue("@PhoneNumber", this.PhoneNumber);

                    await con.OpenAsync();

                    var result = await command.ExecuteNonQueryAsync();

                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return 0;
        }
    }
}
