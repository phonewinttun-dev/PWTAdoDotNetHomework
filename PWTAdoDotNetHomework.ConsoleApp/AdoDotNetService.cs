using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTAdoDotNetHomework.ConsoleApp
{
    internal class AdoDotNetService
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "PWTDotNetTrainingInPerson",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string readQuery = @"SELECT [InstructorID]
                                      ,[Name]
                                      ,[PhoneNumber]
                                      ,[Department]
                                      ,[DeleteFlag]
                                  FROM [dbo].[tbl_instructors]
                                ";
            SqlCommand cmd = new SqlCommand(readQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
        }

        public void Create()
        {
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();
            string createQuery = @"INSERT INTO [dbo].[tbl_instructors]
                                       ([Name]
                                       ,[PhoneNumber]
                                       ,[Department]
                                       ,[DeleteFlag])
                                 VALUES
                                       ('U Si Thu'
                                       ,'09423567890'
                                       ,'Microcontroller'
                                       ,0)";

            SqlCommand cmd = new SqlCommand(createQuery, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Create Successful!" : "Create Failed!";
            Console.WriteLine(message);
        }

        public void Update()
        {
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string updateQuery = @"UPDATE [dbo].[tbl_instructors]
                                   SET [Name] = 'U Aung Aung'
                                      ,[PhoneNumber] = '09423567891'
                                      ,[Department] = 'Embedded System'
                                      ,[DeleteFlag] = 0
                                 WHERE [InstructorID] = 1";

            SqlCommand cmd = new SqlCommand(updateQuery, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Update Successful!" : "Update Failed!";  
            Console.WriteLine(message);

        }

        public void Delete()
        {
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string deleteQuery = @"UPDATE FROM [dbo].[tbl_students]
                                    SET [DeleteFlag] = 1
                                    WHERE [InstructorID] = 2";

            SqlCommand cmd = new SqlCommand(deleteQuery, connection);
            int result = cmd.ExecuteNonQuery(); 

            connection.Close();

            string message = result > 0 ? "Delete Successful!" : "Delete Failed!";
            Console.WriteLine(message);
        }

    }
}
