using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    public class FlightQueryHandler
    {
        private FlightInformationSystem flightSystem;
        // Конструктор класу, який приймає систему управління рейсами
        public FlightQueryHandler(FlightInformationSystem flightSystem)
        {
            this.flightSystem = flightSystem;
        }
        // Пошук рейсів за номером
        public List<Flight> FindFlightsByNumber(string flightNumber)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Дані про рейси недоступні.");
                return new List<Flight>();
            }
            return flights.Where(f => f.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        // Пошук рейсів за статусом
        public List<Flight> FindFlightsByStatus(FlightStatus status)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Дані про рейси недоступні.");
                return new List<Flight>();
            }
            return flights.Where(f => f.Status == status).ToList();
        }
        // Пошук рейсів за авіалінією
        public List<Flight> FindFlightsByAirline(string airline)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Дані про рейси недоступні.");
                return new List<Flight>();
            }
            return flights.Where(f => f.Airline.Equals(airline, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        // Пошук рейсів за місцем призначення
        public List<Flight> FindFlightsByDestination(string destination)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Дані про рейси недоступні.");
                return new List<Flight>();
            }
            return flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        // Пошук рейсів за часом відправлення
        public List<Flight> FindFlightsByDepartureTime(DateTime departureTime)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Дані про рейси недоступні.");
                return new List<Flight>();
            }
            return flights.Where(f => f.DepartureTime == departureTime).ToList();
        }
        // Виведення знайдених рейсів у консоль
        public void DisplayFlights(List<Flight> flights)
        {
            if (flights == null || !flights.Any())
            {
                Console.WriteLine("Відповідних рейсів не знайдено.");
                return;
            }
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }
        // Призначення: Клас відповідає за виконання запитів до системи керування рейсами та обробку результатів.
        // Методи запитів: Реалізовані методи для пошуку рейсів за різними критеріями: номером, статусом, авіалінією, місцем призначення та часом відправлення.
        // Метод DisplayFlights: Виводить результати пошуку рейсів на екран у зручному для користувача форматі.
        }
    }
}
