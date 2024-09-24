using System;
using System.IO;
using Newtonsoft.Json;

namespace Lab_6
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            FlightInformationSystem flightSystem = new FlightInformationSystem("C:\\Users\\egorm\\source\\repos\\Lab_6\\flights_data.json");
            FlightQueryHandler queryHandler = new FlightQueryHandler(flightSystem);
            string reportDirectory = @"C:\Users\egorm\source\repos\Lab_6\reports";
            Directory.CreateDirectory(reportDirectory);

            Console.WriteLine("Виберіть тип: ");
            Console.WriteLine("1. Номер рейсу");
            Console.WriteLine("2. Статус рейсу");
            Console.WriteLine("3. Авіалінія");
            Console.WriteLine("4. Місце призначення");
            Console.WriteLine("5. Час відправлення");

            int choice = int.Parse(Console.ReadLine());
            List<Flight> result = null;
            string reportType = "";

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введіть номер рейсу (BA836): ");
                    string flightNumber = Console.ReadLine();
                    result = queryHandler.FindFlightsByNumber(flightNumber);
                    reportType = $"Flight Number: {flightNumber}";
                    queryHandler.DisplayFlights(result);
                    break;

                case 2:
                    Console.WriteLine("Введіть статус рейсу (OnTime, Delayed, Cancelled, Boarding, InFlight):");
                    FlightStatus status = (FlightStatus)Enum.Parse(typeof(FlightStatus), Console.ReadLine());
                    result = queryHandler.FindFlightsByStatus(status);
                    reportType = $"Flight Status: {status}";
                    queryHandler.DisplayFlights(result);
                    break;

                case 3:
                    Console.WriteLine("Введіть авіалінію (MAU):");
                    string airline = Console.ReadLine();
                    result = queryHandler.FindFlightsByAirline(airline);
                    reportType = $"Airline: {airline}";
                    queryHandler.DisplayFlights(result);
                    break;

                case 4:
                    Console.WriteLine("Введіть місце призначення (Kyiv):");
                    string destination = Console.ReadLine();
                    result = queryHandler.FindFlightsByDestination(destination);
                    reportType = $"Destination: {destination}";
                    queryHandler.DisplayFlights(result);
                    break;

                case 5:
                    Console.WriteLine("Введіть час відправлення (yyyy-MM-ddTHH:mm:ss) (П:2023-06-14T17:03:13):");
                    DateTime departureTime = DateTime.Parse(Console.ReadLine());
                    result = queryHandler.FindFlightsByDepartureTime(departureTime);
                    reportType = $"Departure Time: {departureTime}";
                    queryHandler.DisplayFlights(result);
                    break;
                default:
                    Console.WriteLine("Неправильний вибір.");
                    return;
            }
            int reportCount = Directory.GetFiles(reportDirectory).Length + 1;
            string reportPath = Path.Combine(reportDirectory, $"report_{reportCount}.json");
            Report report = new Report
            {
                ReportType = reportType,
                Result = result,
                GeneratedAt = DateTime.Now
            };
            ReportGenerator.GenerateReport(report, reportPath);

            Console.WriteLine($"Репорт збережено: {reportPath}");
        }
    }
    public class Report
    {
        public string ReportType { get; set; }
        public object Result { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
    public static class ReportGenerator
    {
        public static void GenerateReport(Report data, string outputFilePath)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(outputFilePath, json);
        }
    }
}