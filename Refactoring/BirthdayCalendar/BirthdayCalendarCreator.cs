using Dapper;
using System.Data.SqlClient;
using System.Text;

namespace BirthdayCalendar
{
    public class BirthdayCalendarCreator
    {
        private readonly string _connectionString;

        public BirthdayCalendarCreator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string Create()
        {
            var rows = LoadEmployees();
            
            var report = new StringBuilder();
            foreach (var row in rows)
            {
                ReportEmployee reportEmployee = Cleanup(row);
                PrintReportLine(reportEmployee, report);
            }

            return report.ToString();
        }

        private IEnumerable<dynamic> LoadEmployees()
        {
            var connection = new SqlConnection(_connectionString);

            // Load data
            var sql = @"SELECT Title, FirstName, MiddleName, LastName, e.BirthDate  
                        FROM Person.Person p
                        INNER JOIN HumanResources.Employee e 
	                        ON e.BusinessEntityID = p.BusinessEntityID
                        ORDER BY MONTH(e.BirthDate), DAY(e.BirthDate)";

            var rows = connection.Query(sql);
            return rows;
        }

        private ReportEmployee Cleanup(dynamic row)
        {
            var reportEmployee = new ReportEmployee();
            reportEmployee.FirstName = row.FirstName;
            reportEmployee.LastName = row.LastName;
            
            reportEmployee.Birthday = ((DateTime)row.BirthDate).Date;
            string middleName = (string)row.MiddleName;
            if (!string.IsNullOrEmpty(middleName) && middleName.Length == 1)
            {
                reportEmployee.MiddleName = $"{middleName}.";
            }

            string title = (string)row.Title;
            if (string.IsNullOrEmpty(title))
            {
                reportEmployee.Title = "      ";
            }
            else
            {
                reportEmployee.Title = $"({title}) ";
            }

            return reportEmployee;
        }

        private static void PrintReportLine(ReportEmployee reportEmployee, StringBuilder report)
        {
            report.Append($"{reportEmployee.Title} {reportEmployee.FirstName} {reportEmployee.MiddleName} {reportEmployee.LastName}: {reportEmployee.Birthday.ToShortDateString()}\n");
        }
    }

    public class ReportEmployee
    {
        public string Title { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ReportEmployee()
        {
            MiddleName = string.Empty;
        }
    }
}
