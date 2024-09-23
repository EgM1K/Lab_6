using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    public class FlightQueryHandler
    {
        private FlightInformationSystem flightSystem;
        public FlightQueryHandler(FlightInformationSystem flightSystem)
        {
            this.flightSystem = flightSystem;
        }
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
        }
    }
}
