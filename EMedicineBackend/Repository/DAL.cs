using EMedicineBackend.Models;
using System.Data.SqlClient;
using System.Data;

namespace EMedicineBackend.Repository
{
    public class DAL
    {
        public Response register(Users users, IConfiguration configuration)
        {
            Response response = new Response();
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection").ToString()))
            {
                SqlCommand cmd = new SqlCommand("sp_register", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
                cmd.Parameters.AddWithValue("@LastName", users.LastName);
                cmd.Parameters.AddWithValue("@Password", users.Password);
                cmd.Parameters.AddWithValue("@Email", users.Email);
                cmd.Parameters.AddWithValue("@Fund", 0);
                cmd.Parameters.AddWithValue("@Type", "Users");
                cmd.Parameters.AddWithValue("@Status", "Pending");
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User registered successfully";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User registration failed";

                }

            }



            return response;
        }


        public Response login(string Email, string Password, IConfiguration configuration)
        {
            Response response = new Response();
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection").ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_login", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Email", Email);
                da.SelectCommand.Parameters.AddWithValue("@Password", Password);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User is Valid";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User is Invalid";
                }
               

            }

            return response;

        }
    }
}
