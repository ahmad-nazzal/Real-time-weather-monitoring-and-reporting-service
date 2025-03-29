using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Observers;

namespace Weather_Monitoring_Service.Factory
{
    public class BotFactory
    {
        public static List<IWeatherObserver> GetBots()
        {
            string json = File.ReadAllText(@"D:\\Trainings\\Foothill-trainig\\Tasks\\Real-time-weather-monitoring-and-reporting-service\\Weather-Monitoring-Service\\Config\\BotsConfiguration.json");
            var jsonDocument = JsonDocument.Parse(json);
            var bots = new List<IWeatherObserver>();

            foreach (var bot in jsonDocument.RootElement.EnumerateObject())
            {
                if (bot.Value.GetProperty("enabled").GetBoolean())
                {
                    switch (bot.Name)
                    {
                        case "RainBot":
                            bots.Add(new RainBot
                            { 
                                HumidityThreshold = bot.Value.GetProperty("humidityThreshold").GetInt32(),
                                Message =  bot.Value.GetProperty("message").GetString()
                            });
                            break;
                        case "SunBot":
                            bots.Add(new SunBot 
                            {
                                TemperatureThreshold = bot.Value.GetProperty("temperatureThreshold").GetInt32(),
                                Message = bot.Value.GetProperty("message").GetString()
                            });
                            break;
                        case "SnowBot":
                            bots.Add(new SnowBot 
                            {
                                TemperatureThreshold = bot.Value.GetProperty("temperatureThreshold").GetInt32(),
                                Message = bot.Value.GetProperty("message").GetString() 
                            });
                            break;
                    }
                }
            }

            return bots;
        }
    }
}
