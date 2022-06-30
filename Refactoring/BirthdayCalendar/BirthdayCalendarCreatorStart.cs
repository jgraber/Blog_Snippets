using Dapper;
using System.Data.SqlClient;
using System.Text;

namespace BirthdayCalendar
{
    public class BirthdayCalendarCreatorStart
    {
        private readonly string _connectionString;

        public BirthdayCalendarCreatorStart(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string Create()
        {
            var connection = new SqlConnection(_connectionString);

            // Load data
            var sql = @"SELECT Title, FirstName, MiddleName, LastName, e.BirthDate  
                        FROM Person.Person p
                        INNER JOIN HumanResources.Employee e 
	                        ON e.BusinessEntityID = p.BusinessEntityID
                        ORDER BY MONTH(e.BirthDate), DAY(e.BirthDate)";
            
            var rows = connection.Query(sql);


            // Process data
            var report = new StringBuilder();
            foreach (var row in rows) 
            {
                // Cleanup
                DateTime birthday = ((DateTime)row.BirthDate).Date;
                string middleName = (string)row.MiddleName;
                if (!string.IsNullOrEmpty(middleName) && middleName.Length == 1)
                {
                    middleName = $"{middleName}.";
                }
                string title = (string)row.Title;
                if (string.IsNullOrEmpty(title))
                {
                    title = "      ";
                }
                else
                {
                    title = $"({title}) ";
                }

                // Print report
                report.Append($"{title} {row.FirstName} {middleName} {row.LastName}: {birthday.ToShortDateString()}\n");
            }

            
            return report.ToString();
        }
    }
}
