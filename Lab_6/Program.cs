using System;

namespace Lab_6
{
    class Program
    {
        static void Main()
        {
            FlightInformationSystem flightSystem = new FlightInformationSystem("C:\\Users\\egorm\\source\\repos\\Lab_6\\flights_data.json");
            FlightQueryHandler queryHandler = new FlightQueryHandler(flightSystem);

            Console.WriteLine("Choose search type: ");
            Console.WriteLine("1. Flight Number");
            Console.WriteLine("2. Status");
            Console.WriteLine("3. Airline");
            Console.WriteLine("4. Destination");
            Console.WriteLine("5. Departure Time");
            Console.WriteLine("6. Time Range");
            Console.WriteLine("7. Date");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter flight number:");
                    string flightNumber = Console.ReadLine();
                    var flightsByNumber = queryHandler.FindFlightsByNumber(flightNumber);
                    queryHandler.DisplayFlights(flightsByNumber);
                    break;

                case 2:
                    Console.WriteLine("Enter flight status (OnTime, Delayed, Cancelled, Boarding, InFlight):");
                    FlightStatus status = (FlightStatus)Enum.Parse(typeof(FlightStatus), Console.ReadLine());
                    var flightsByStatus = queryHandler.FindFlightsByStatus(status);
                    queryHandler.DisplayFlights(flightsByStatus);
                    break;

                case 3:
                    Console.WriteLine("Enter airline:");
                    string airline = Console.ReadLine();
                    var flightsByAirline = queryHandler.FindFlightsByAirline(airline);
                    queryHandler.DisplayFlights(flightsByAirline);
                    break;

                case 4:
                    Console.WriteLine("Enter destination:");
                    string destination = Console.ReadLine();
                    var flightsByDestination = queryHandler.FindFlightsByDestination(destination);
                    queryHandler.DisplayFlights(flightsByDestination);
                    break;

                case 5:
                    Console.WriteLine("Enter departure time (yyyy-MM-ddTHH:mm:ss):");
                    DateTime departureTime = DateTime.Parse(Console.ReadLine());
                    var flightsByDepartureTime = queryHandler.FindFlightsByDepartureTime(departureTime);
                    queryHandler.DisplayFlights(flightsByDepartureTime);
                    break;

                case 6:
                    Console.WriteLine("Enter start time (yyyy-MM-ddTHH:mm:ss):");
                    DateTime startTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter end time (yyyy-MM-ddTHH:mm:ss):");
                    DateTime endTime = DateTime.Parse(Console.ReadLine());
                    var flightsInTimeRange = queryHandler.FindFlightsInTimeRange(startTime, endTime);
                    queryHandler.DisplayFlights(flightsInTimeRange);
                    break;

                case 7:
                    Console.WriteLine("Enter date (yyyy-MM-dd):");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    var flightsByDate = queryHandler.FindFlightsByDate(date);
                    queryHandler.DisplayFlights(flightsByDate);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}