using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;

namespace Weather_Monitoring_Service.Observers
{
    public class RainBot : BotSettings, IWeatherObserver
    {
        public required int HumidityThreshold { get; set; }
        public void Update(WeatherData data)
        {
            Console.WriteLine("RainBot activated");
            if (data.Humidity > HumidityThreshold)
                Console.WriteLine(Message);
        }
    }
}
