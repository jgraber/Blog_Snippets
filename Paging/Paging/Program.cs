using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    using Dapper;

    public class Program
    {
        static void Main(string[] args)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["PagingDb"].ConnectionString;
            var conn = new SqlConnection(connectionString);

            var selectQuery = @"SELECT [Id]
                                      ,[FirstName]
                                      ,[LastName]
                                      ,[Email]
                                FROM [Users]
                                WHERE [Subscribed] = 1
                                Order By [Id]
                                OFFSET @offset ROWS
                                FETCH NEXT @rowsPerPage ROWS ONLY;";


            ReadWithSqlCommand(connectionString, selectQuery);
            Console.WriteLine("----------------");
            ReadWithDapper(conn, selectQuery);

            var email = ConfigurationManager.AppSettings["senderemail"];
            Console.WriteLine(email);
        }

        private static void ReadWithSqlCommand(string connectionString, string selectQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);

                SqlParameter offset = new SqlParameter("@offset", SqlDbType.Int, 0);
                offset.Value = 0;
                command.Parameters.Add(offset);

                SqlParameter rowsPerPage = new SqlParameter("@rowsPerPage", SqlDbType.Int, 0);
                rowsPerPage.Value = 20;
                command.Parameters.Add(rowsPerPage);

                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]} {reader[3]}");
                }
            }
        }

        private static void ReadWithDapper(SqlConnection conn, string selectQuery)
        {
            var results = conn.Query<User>(selectQuery, new { offset = 20, rowsPerPage = 20 }).ToList();

            foreach (var user in results)
            {
                Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Email}");
            }
        }
    }
}
