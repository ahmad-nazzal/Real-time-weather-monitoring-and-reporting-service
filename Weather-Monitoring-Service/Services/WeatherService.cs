using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.Parser;
using Weather_Monitoring_Service.Publishers;

namespace Weather_Monitoring_Service.Services
{
    public class WeatherService
    {
        private readonly List<IWeatherParser> _parsers;
        private readonly IWeatherDataPublisher _weatherPublisher;
        public WeatherService(List<IWeatherParser> parsers, IWeatherDataPublisher weatherDataPublisher)
        {
            _parsers = parsers;
            _weatherPublisher = weatherDataPublisher;
        }

        public void ParseAndPublish(string data)
        {
            try
            { 
                var weatherData = _parsers.FirstOrDefault(p => p.IsCompatible(data))?.Parse(data);
                if (weatherData != null)
                {
                    _weatherPublisher.NotifyObservers(weatherData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Format");
            }
        }
    }
}
