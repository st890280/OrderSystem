using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrderSystem
{
    public class DBHelper
    {
        public static DataTable GetUserAccount(string account)
        {
            string connectionstring =
                GetConnectionString();

            string queryString =
                $@" SELECT * FROM Account
                    WHERE Account.Account = @account;";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@account", account);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public static string GetConnectionString()
        {
            var manage = System.Configuration.ConfigurationManager.ConnectionStrings["systemDataBase"];

            if (manage == null)
                return string.Empty;
            else
                return manage.ConnectionString;
        }
    }
}