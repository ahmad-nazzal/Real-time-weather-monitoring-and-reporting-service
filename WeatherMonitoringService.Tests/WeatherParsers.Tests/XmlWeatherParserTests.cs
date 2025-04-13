using AutoFixture.Xunit2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Parser;

namespace WeatherMonitoringService.Tests.WeatherParsers.Tests
{
    public class XmlWeatherParserTests
    {
        private readonly XmlWeatherParser _parser;

        public XmlWeatherParserTests()
        {
            _parser = new XmlWeatherParser();
        }

        [Theory, AutoData]
        public void XmlWeatherParser_ShouldParseValidXml(WeatherData expected)
        {
            string xml = $"""
                      <WeatherData>
                          <Location>{expected.Location}</Location>
                          <Temperature>{expected.Temperature}</Temperature>
                          <Humidity>{expected.Humidity}</Humidity>
                      </WeatherData>
                      """;

            var result = _parser.Parse(xml);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("<xml>stuff</xml>")]
        [InlineData("<WeatherData></WeatherData>")]
        public void XmlWeatherParser_ShouldRecognizeCompatibleData(string xml)
        {
            _parser.IsCompatible(xml).Should().BeTrue();
        }

        [Theory]
        [InlineData("{\"key\":\"value\"}")]
        [InlineData("not xml")]
        public void XmlWeatherParser_ShouldRejectIncompatibleData(string data)
        {
            _parser.IsCompatible(data).Should().BeFalse();
        }

    }
}
