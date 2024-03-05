using Client_GraphQL.Client;
using Client_GraphQL.Models;
using Client_GraphQL.Services;
using System.Runtime.CompilerServices;


CommissionsService commissionsService = new CommissionsService();

Console.WriteLine("Please enter the corresponding number for what you want to do: \n 1. Export all records to Excel CSV.");

string input = Console.ReadLine();

Console.WriteLine("Please enter the day of the start date.");
int day_startDate = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Please enter the month of the start date.");
int month_startDate = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Please enter the year of the start date.");
int year_startDate = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Please enter the day of the end date.");
int day_endDate = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Please enter the month of the end date.");
int month_endDate = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Please enter the year of the end date.");
int year_endDate = Convert.ToInt16(Console.ReadLine());

DateTime start_date = new DateTime(year_startDate, month_startDate, day_startDate);
DateTime end_date = new DateTime(year_endDate, month_endDate, day_endDate);

if (int.TryParse(input, out int number))
{
    
    switch (number)
    {
        case 1:
            await commissionsService.RequestAllDataAsync(start_date, end_date);
            Console.WriteLine("One");
            break;
        case 2:
            Console.WriteLine("Two");
            break;
        default:
            Console.WriteLine("\r\nNumber out of specified range.");
            break;
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a number from 1 to 2.");
}

Console.ReadLine();