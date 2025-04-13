using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Observers;

namespace WeatherMonitoringService.Tests.Bots.Tests
{
    public class RainBotTests
    {
        [Theory, AutoData]
        public void RainBot_ShouldPrintMessage_WhenHumidityExceedsThreshold(
        string message, int humidity)
        {
            var bot = new RainBot
            {
                Enabled = true,
                HumidityThreshold = humidity - 1,
                Message = message
            };

            var data = new WeatherData
            {
                Humidity = humidity,
                Temperature = 22,
                Location = "AutoTown"
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            bot.Update(data);

            var output = sw.ToString();
            Assert.Contains("RainBot activated", output);
            Assert.Contains(message, output);
        }
    }
}

