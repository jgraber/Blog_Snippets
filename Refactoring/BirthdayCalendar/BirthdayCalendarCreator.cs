﻿using Dapper;
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
                var reportEmployee = new ReportEmployee();
                PrintReportLine(reportEmployee, report, title, row, middleName, birthday);
            }

            
            return report.ToString();
        }

        private static void PrintReportLine(ReportEmployee reportEmployee, StringBuilder report, string title, dynamic row, string middleName, DateTime birthday)
        {
            report.Append($"{title} {row.FirstName} {middleName} {row.LastName}: {birthday.ToShortDateString()}\n");
        }
    }

    public class ReportEmployee
    {

    }
}
