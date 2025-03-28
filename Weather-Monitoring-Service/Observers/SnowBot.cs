using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;


namespace Weather_Monitoring_Service.Observers
{
    public class SnowBot: BotSettings, IWeatherObserver
    {
        public required int TemperatureThreshold { get; set; }
        public void Update(WeatherData data)
        {
            if (data.Temperature < TemperatureThreshold)
                Console.WriteLine(Message);
        }
    }
}
