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
    public class SunBotTests
    {
        [Theory, AutoData]
        public void SunBot_ShouldPrintMessage_WhenTempretureExceedsThreshold(
            string message, int threshold)
        {
            var bot = new SunBot
            {
                Enabled = true,
                TemperatureThreshold = threshold - 1,
                Message = message
            };
            var data = new WeatherData
            {
                Humidity = 22,
                Temperature = threshold,
                Location = "AutoTown"
            };
            using var sw = new StringWriter();
            Console.SetOut(sw);

            bot.Update(data);

            var output = sw.ToString();
            output.Should().Contain("SunBot activated");
            output.Should().Contain(message);
        }
    }
}
