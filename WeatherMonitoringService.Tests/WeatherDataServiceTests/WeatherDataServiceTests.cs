using AutoFixture.Xunit2;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Parser;
using Weather_Monitoring_Service.Publishers;
using Weather_Monitoring_Service.Services;

namespace WeatherMonitoringService.Tests.WeatherDataServiceTests
{
    public class WeatherDataServiceTests
    {
        [Theory, AutoData]
        public void ParseAndPublish_ShouldNotifyObservers_WhenCompatibleParserReturnsData(
            WeatherData expectedData,
            string input)
        {
            var mockParser = new Mock<IWeatherParser>();
            mockParser.Setup(p => p.IsCompatible(It.IsAny<string>())).Returns(true);
            mockParser.Setup(p => p.Parse(It.IsAny<string>())).Returns(expectedData);

            var mockPublisher = new Mock<IWeatherDataPublisher>();

            var service = new WeatherService(
                new List<IWeatherParser> { mockParser.Object },
                mockPublisher.Object);

            service.ParseAndPublish(input);

            mockPublisher.Verify(p => p.NotifyObservers(expectedData), Times.Once);
        }

        [Theory, AutoData]
        public void ParseAndPublish_ShouldNotNotifyObservers_WhenNoCompatibleParser(
            string input)
        {
            var mockParser = new Mock<IWeatherParser>();
            mockParser.Setup(p => p.IsCompatible(It.IsAny<string>())).Returns(false);

            var mockPublisher = new Mock<IWeatherDataPublisher>();

            var service = new WeatherService(
                new List<IWeatherParser> { mockParser.Object },
                mockPublisher.Object);

            service.ParseAndPublish(input);

            mockPublisher.Verify(p => p.NotifyObservers(It.IsAny<WeatherData>()), Times.Never);
        }
    }
}
