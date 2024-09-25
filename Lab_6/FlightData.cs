using System.Collections.Generic;
using Newtonsoft.Json;
namespace Lab_6
{
    // Цей клас служить для коректної десеріалізації JSON у об'єкт, який містить список рейсів
    public class FlightData
    {
        [JsonProperty("flights")]
        public List<Flight> Flights { get; set; }
    }
}