using Employees.Utils;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    { 
        static async Task Main(string[] args)
        {
            //GetEmployeeById();
            //await GetAllEmployees();
            //AddEmployee();
            //DeleteEmployee();
            //await FilterByName("a");
        }
        public static void GetEmployeeById()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.ConnectionSql))
            {
                sqlConnection.Open();
                string command = "SELECT Fullname FROM Employee WHERE ID=2";
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    string fullname = sqlCommand.ExecuteScalar().ToString();
                    Console.WriteLine(fullname);
                }
            }

        }
        public async static Task GetAllEmployees()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.ConnectionSql))
            {
                sqlConnection.Open();
                string command = "SELECT Fullname FROM Employee";
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader.GetString(0));
                        }
                    }
                }
            }

        }
        public static void AddEmployee()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.ConnectionSql))
            {
                sqlConnection.Open();
                string command = "INSERT INTO Employee VALUES('Rasim Orucov')";
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    int employe = sqlCommand.ExecuteNonQuery();
                    if (employe > 0)
                    {
                        Console.WriteLine("Elave olundu");
                    }
                    else
                    {
                        Console.WriteLine("Elave olunmadi");
                    }
                }
            }
        }
        public static void DeleteEmployee()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.ConnectionSql))
            {
                sqlConnection.Open();
                string command = "DELETE FROM Employee WHERE ID=8";
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    int employe = sqlCommand.ExecuteNonQuery();
                    if (employe > 0)
                    {
                        Console.WriteLine("Silindi");
                    }
                    else
                    {
                        Console.WriteLine("Silinib");
                    } 
                }
            }
        }
        public async static Task FilterByName(string search)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.ConnectionSql))
            {
                sqlConnection.Open();
                string command = $"SELECT * FROM Employee WHERE Fullname LIKE '%@search%'";
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@search", search);
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine($"Fullname:{sqlDataReader["Fullname"]}");
                        }
                    }
                }
            }

        }

    }
}
