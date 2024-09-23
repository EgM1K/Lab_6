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
                Console.WriteLine("Flight data is not available.");
                return new List<Flight>();
            }
            return flights.Where(f => f.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Flight> FindFlightsByStatus(FlightStatus status)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Flight data is not available.");
                return new List<Flight>();
            }
            return flights.Where(f => f.Status == status).ToList();
        }
        public List<Flight> FindFlightsByAirline(string airline)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Flight data is not available.");
                return new List<Flight>();
            }
            return flights.Where(f => f.Airline.Equals(airline, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Flight> FindFlightsByDestination(string destination)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Flight data is not available.");
                return new List<Flight>();
            }
            return flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Flight> FindFlightsByDepartureTime(DateTime departureTime)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Flight data is not available.");
                return new List<Flight>();
            }
            return flights.Where(f => f.DepartureTime == departureTime).ToList();
        }
        public List<Flight> FindFlightsByDate(DateTime date)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Flight data is not available.");
                return new List<Flight>();
            }
            return flights.Where(f => f.DepartureTime.Date == date.Date || f.ArrivalTime.Date == date.Date).ToList();
        }
        public List<Flight> FindFlightsInTimeRange(DateTime startTime, DateTime endTime)
        {
            var flights = flightSystem.GetFlights();
            if (flights == null)
            {
                Console.WriteLine("Flight data is not available.");
                return new List<Flight>();
            }
            return flights.Where(f => (f.DepartureTime >= startTime && f.DepartureTime <= endTime) ||
                                      (f.ArrivalTime >= startTime && f.ArrivalTime <= endTime)).ToList();
        }
        public void DisplayFlights(List<Flight> flights)
        {
            if (flights == null || !flights.Any())
            {
                Console.WriteLine("No matching flights found.");
                return;
            }
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }
        }
    }
}
