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
            return flightSystem.Flights.Where(f => f.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Flight> FindFlightsByStatus(FlightStatus status)
        {
            return flightSystem.Flights.Where(f => f.Status == status).ToList();
        }

        public List<Flight> FindFlightsByAirline(string airline)
        {
            return flightSystem.Flights.Where(f => f.Airline.Equals(airline, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Flight> FindFlightsByDestination(string destination)
        {
            return flightSystem.Flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Flight> FindFlightsByDepartureTime(DateTime departureTime)
        {
            return flightSystem.Flights.Where(f => f.DepartureTime == departureTime).ToList();
        }

        public List<Flight> FindFlightsByDate(DateTime date)
        {
            return flightSystem.Flights.Where(f => f.DepartureTime.Date == date.Date || f.ArrivalTime.Date == date.Date).ToList();
        }

        public List<Flight> FindFlightsInTimeRange(DateTime startTime, DateTime endTime)
        {
            return flightSystem.Flights.Where(f => (f.DepartureTime >= startTime && f.DepartureTime <= endTime) ||
                                                   (f.ArrivalTime >= startTime && f.ArrivalTime <= endTime)).ToList();
        }

        public void DisplayFlights(List<Flight> flights)
        {
            if (flights.Any())
            {
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight.ToString());
                }
            }
            else
            {
                Console.WriteLine("No matching flights found.");
            }
        }
    }
}

