﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;

namespace Weather_Monitoring_Service.Observers
{
    public class SunBot : BotSettings, IWeatherObserver
    {
        public required int TemperatureThreshold { get; set; }
        public void Update(WeatherData data)
        {
            Console.WriteLine("SunBot activated");
            if (data.Temperature > TemperatureThreshold)
                Console.WriteLine(Message);
        }
    }
}
