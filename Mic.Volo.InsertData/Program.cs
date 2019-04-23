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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mydbname;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string createtablewallet = "use mydbname;DROP Table IF EXISTS Wallet,Category;" +
                " CREATE TABLE Wallet (" +
                " [Id]          UNIQUEIDENTIFIER NOT NULL," +
                " [CategoryId] UNIQUEIDENTIFIER NOT NULL," +
                "[Amount] MONEY NOT NULL," +
                " [Comment] NVARCHAR(MAX)   NULL," +
                "[Day] DATETIME2(7)    NOT NULL," +
                "[DateCreated] DATETIME2(7)    CONSTRAINT[DF_Wallet_DateCreated] DEFAULT(getutcdate()) NOT NULL," +
                "CONSTRAINT[PK_Wallet] PRIMARY KEY CLUSTERED([Id] ASC)," +
                " CONSTRAINT[FK_Wallet_Category] FOREIGN KEY([CategoryId]) REFERENCES[dbo].[Category] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE" +
                ");";
            string createtbalecategories = "use mydbname;DROP Table IF EXISTS Category; " +
                "CREATE TABLE Category (" +
                " [Id]    UNIQUEIDENTIFIER NOT NULL," +
                "[Title] NVARCHAR(MAX)   NOT NULL," +
                "CONSTRAINT[PK_Category] PRIMARY KEY CLUSTERED([Id] ASC)" +
                ");";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(createtablewallet, connection);
                    SqlCommand command = new SqlCommand(createtbalecategories, connection);
                    command1.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
