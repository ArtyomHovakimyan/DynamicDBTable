using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mic.Volo.InsertData
{
    class Program
    {

        static void Main(string[] args)
        {
            string connectionString;
            // for example my  (localdb)\MSSQLLocalDB
            Console.WriteLine("Enter your Data Source: ");
            string source = Console.ReadLine();
            Console.WriteLine("Enter your database Name: ");
            string dbname = Console.ReadLine();
            connectionString = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True;",source);
            string createdatabase = "CREATE DATABASE " + dbname;

            string createcategoriestable = "use master; CREATE TABLE [dbo].[Category] (" +
                " [Id]    UNIQUEIDENTIFIER NOT NULL," +
                "[Title] NVARCHAR(MAX)   NOT NULL," +
                " CONSTRAINT[PK_Category] PRIMARY KEY CLUSTERED([Id] ASC)" +
                ");";
            
            try
            {
                using (SqlConnection connection=new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(createdatabase,connection);
                    connection.Open();
                    Console.WriteLine("connected");
                    command = new SqlCommand(createcategoriestable, connection);
                    Console.WriteLine("Db created successfully....");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error "+ex.Message);
            }
        }
    }
}
