using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.Factory;
using Weather_Monitoring_Service.Observers;

namespace WeatherMonitoringService.Tests.Factory.Tests
{
    public class BotFactoryTests
    {
        [Fact]
        public void GetBots_ShouldReturnEnabledBots()
        {
            string json = @"
            {
                ""RainBot"": {
                    ""enabled"": true,
                    ""humidityThreshold"": 70,
                    ""message"": ""Rain alert!""
                },
                ""SunBot"": {
                    ""enabled"": false,
                    ""temperatureThreshold"": 30,
                    ""message"": ""Sunny day!""
                },
                ""SnowBot"": {
                    ""enabled"": true,
                    ""temperatureThreshold"": -5,
                    ""message"": ""Snow warning!""
                }
            }";

            var enabledBots = BotFactory.GetBots(json);

            enabledBots.Should().HaveCount(2);
            enabledBots.Should().ContainSingle(b => b is RainBot);
            enabledBots.Should().ContainSingle(b => b is SnowBot);
            enabledBots.Should().NotContain(b => b is SunBot);

        }
    }
}
