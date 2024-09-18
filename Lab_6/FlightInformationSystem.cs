using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_6
{

    public class FlightInformationSystem
    {
        public List<Flight> Flights { get; private set; }

        public FlightInformationSystem(string jsonFilePath)
        {
            LoadFlightsFromJson(jsonFilePath);
        }

        private void LoadFlightsFromJson(string jsonFilePath)
        {
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                Flights = JsonConvert.DeserializeObject<List<Flight>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flight data: {ex.Message}");
                Flights = new List<Flight>();
            }
        }

        public void DisplayFlights()
        {
            if (Flights != null && Flights.Count > 0)
            {
                foreach (var flight in Flights)
                {
                    Console.WriteLine(flight.ToString());
                }
            }
            else
            {
                Console.WriteLine("No flights available.");
            }
        }
    }
}