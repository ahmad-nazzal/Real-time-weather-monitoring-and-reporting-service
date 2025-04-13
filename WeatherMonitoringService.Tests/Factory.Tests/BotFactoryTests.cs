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

            Assert.NotNull(enabledBots);
            Assert.Equal(2, enabledBots.Count);
            Assert.IsType<RainBot>(enabledBots[0]);
            Assert.IsType<SnowBot>(enabledBots[1]);
            Assert.DoesNotContain(enabledBots, bot => bot is SunBot);

        }
    }
}
