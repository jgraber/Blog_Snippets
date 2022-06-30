using BirthdayCalendar;

var connection = "Server=.;Database=AdventureWorks2019;Integrated Security=true;";
var calendar = new BirthdayCalendarCreator(connection);
var report = calendar.Create();

Console.WriteLine(report);
