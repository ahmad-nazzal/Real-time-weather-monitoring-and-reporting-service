using AutoFixture.Xunit2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Observers;

namespace WeatherMonitoringService.Tests.Bots.Tests
{
    public class SnowBotTests
    {
        [Theory, AutoData]
        public void SnowBot_ShouldPrintMessage_WhenThresholdExceedsTempreture(
        string message, int threshold)
        {
            var bot = new SnowBot
            {
                Enabled = true,
                TemperatureThreshold = 5 + 1,
                Message = message
            };

            var data = new WeatherData
            {
                Humidity = 22,
                Temperature = 5,
                Location = "AutoTown"
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            bot.Update(data);

            var output = sw.ToString();
            output.Should().Contain("SnowBot activated");
            output.Should().Contain(message);
        }
    }
}
