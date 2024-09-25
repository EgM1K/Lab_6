using Newtonsoft.Json;
using System;
using System.IO;
namespace Lab_6
{
    public class FlightInformationSystem
    {
        private FlightData flightData;
        public List<Flight> Flights { get; private set; }

        // Конструктор класу, який завантажує рейси з JSON-файлу
        public FlightInformationSystem(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                flightData = JsonConvert.DeserializeObject<FlightData>(json);
                if (flightData?.Flights == null || !flightData.Flights.Any())
                {
                    Console.WriteLine("No flight data found.");
                }
                else
                {
                    Console.WriteLine("Flight data loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading flight data: " + ex.Message);
            }
        }
        // Метод для отримання всіх рейсів
        public List<Flight> GetFlights()
        {
            return flightData?.Flights;
        }
        // Приватний метод для завантаження рейсів з JSON-файлу
        private void LoadFlightsFromJson(string jsonFilePath)
        {
            // Спроба десеріалізації JSON-даних у список об'єктів Flight
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
            // Перевірка наявності файлу і виведення помилки у разі його відсутності
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
        // Призначення: Клас керує завантаженням даних про рейси з JSON-файлу та забезпечує доступ до них.
        // Метод LoadFlightsFromJson: Виконує завантаження та десеріалізацію JSON-даних про рейси.Якщо файл не знайдено або сталася помилка під час читання, метод виводить повідомлення і повертає порожній список.
        // Метод GetAllFlights: Повертає всі рейси, що завантажені в систему.
    }
}