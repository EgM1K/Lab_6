using System;

namespace Lab_6
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            FlightInformationSystem flightSystem = new FlightInformationSystem("C:\\Users\\egorm\\source\\repos\\Lab_6\\flights_data.json");
            FlightQueryHandler queryHandler = new FlightQueryHandler(flightSystem);
            Console.WriteLine("Виберіть тип: ");
            Console.WriteLine("1. Номер рейсу");
            Console.WriteLine("2. Статус рейсу");
            Console.WriteLine("3. Авіалінія");
            Console.WriteLine("4. Місце призначення");
            Console.WriteLine("5. Час відправлення");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введіть номер рейсу (BA836): ");
                    string flightNumber = Console.ReadLine();
                    var flightsByNumber = queryHandler.FindFlightsByNumber(flightNumber);
                    queryHandler.DisplayFlights(flightsByNumber);
                    break;

                case 2:
                    Console.WriteLine("Введіть статус рейсу (OnTime, Delayed, Cancelled, Boarding, InFlight):");
                    FlightStatus status = (FlightStatus)Enum.Parse(typeof(FlightStatus), Console.ReadLine());
                    var flightsByStatus = queryHandler.FindFlightsByStatus(status);
                    queryHandler.DisplayFlights(flightsByStatus);
                    break;

                case 3:
                    Console.WriteLine("Введіть авіалінію (MAU):");
                    string airline = Console.ReadLine();
                    var flightsByAirline = queryHandler.FindFlightsByAirline(airline);
                    queryHandler.DisplayFlights(flightsByAirline);
                    break;

                case 4:
                    Console.WriteLine("Введіть місце призначення (Kyiv):");
                    string destination = Console.ReadLine();
                    var flightsByDestination = queryHandler.FindFlightsByDestination(destination);
                    queryHandler.DisplayFlights(flightsByDestination);
                    break;

                case 5:
                    Console.WriteLine("Введіть час відправлення (yyyy-MM-ddTHH:mm:ss) (П:2023-06-14T17:03:13):");
                    DateTime departureTime = DateTime.Parse(Console.ReadLine());
                    var flightsByDepartureTime = queryHandler.FindFlightsByDepartureTime(departureTime);
                    queryHandler.DisplayFlights(flightsByDepartureTime);
                    break;
                default:
                    Console.WriteLine("Неправильний вибір.");
                    break;
            }
        }
    }
}