using Dapper;
using System.Data.SqlClient;
using System.Text;

namespace BirthdayCalendar
{
    public class BirthdayCalendarCreatorMiddlePhaseExtracted
    {
        private readonly string _connectionString;

        public BirthdayCalendarCreatorMiddlePhaseExtracted(string connectionString)
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
                var reportEmployee = new ReportEmployee();
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

                // Print report
                
                PrintReportLine(reportEmployee, report, row);
            }

            
            return report.ToString();
        }

        private static void PrintReportLine(ReportEmployee reportEmployee, StringBuilder report, dynamic row)
        {
            report.Append($"{reportEmployee.Title} {row.FirstName} {reportEmployee.MiddleName} {row.LastName}: {reportEmployee.Birthday.ToShortDateString()}\n");
        }
    }

    ////public class ReportEmployee
    ////{
    ////    public string Title { get; set; }
    ////    public string MiddleName { get; set; }
    ////    public DateTime Birthday { get; set; }

    ////    public ReportEmployee()
    ////    {
    ////        MiddleName = string.Empty;
    ////    }
    ////}
}
