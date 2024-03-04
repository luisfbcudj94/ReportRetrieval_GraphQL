using Client_GraphQL.Client;
using Client_GraphQL.Models;
using Client_GraphQL.Services;
using System.Runtime.CompilerServices;


CommissionsService commissionsService = new CommissionsService();

Console.WriteLine("Please enter the corresponding number for what you want to do: \n 1. Export all records to Excel CSV.");

string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    
    switch (number)
    {
        case 1:
            await commissionsService.RequestAllDataAsync();
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