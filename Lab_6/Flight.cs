using System;
using Newtonsoft.Json;
namespace Lab_6
{
    public enum FlightStatus
    {
        OnTime,
        Delayed,
        Cancelled,
        Boarding,
        InFlight
    }
    // Призначення: Це перелічуваний тип(enum), який визначає можливі статуси рейсу: вчасно, затримано, скасовано, посадка, у польоті.
    // Використання: Даний перелічуваний тип використовують у класі Flight для позначення статусу рейсу.
    public class Flight
    {
        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; } // Номер рейсу
        [JsonProperty("Airline")]
        public string Airline { get; set; } // Авіалінія
        [JsonProperty("Destination")]
        public string Destination { get; set; } // Місце призначення
        [JsonProperty("DepartureTime")]
        public DateTime DepartureTime { get; set; } // Час відправлення
        [JsonProperty("ArrivalTime")]
        public DateTime ArrivalTime { get; set; } // Час прибуття
        [JsonProperty("Gate")]
        public string Gate { get; set; } // Ворота відправлення
        [JsonProperty("Status")]
        public FlightStatus Status { get; set; } // Статус
        [JsonProperty("Duration")]
        public TimeSpan Duration { get; set; } // Тривалість
        [JsonProperty("AircraftType")]
        public string AircraftType { get; set; } // Тип літаку
        [JsonProperty("Terminal")]
        public string Terminal { get; set; } // Термінал
        public override string ToString()
        {
            return $"Flight \n{{\n FlightNumber='{FlightNumber}',\n Airline='{Airline}',\n Destination='{Destination}',\n DepartureTime='{DepartureTime}',\n ArrivalTime='{ArrivalTime}',\n Gate='{Gate}'\n,Status='{Status}',\n Duration='{Duration}',\n AircraftType='{AircraftType}',\n Terminal='{Terminal}'}}";
        }
        // Призначення: Клас представляє рейс із відповідними властивостями: номер рейсу, авіалінія, місце призначення, час відправлення та прибуття, статус, ворота і тд.
        // Автоматичні властивості: Всі властивості мають автоматичні геттери та сеттери, що спрощує доступ до даних.
    }
}