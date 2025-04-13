using AutoFixture.Xunit2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Parser;

namespace WeatherMonitoringService.Tests.WeatherParsers.Tests
{
    public class JsonWeatherParserTests
    {
        private readonly JsonWeatherParser _parser;

        public JsonWeatherParserTests()
        {
            _parser = new JsonWeatherParser();
        }

        [Theory, AutoData]
        public void JsonWeatherParser_ShouldParseValidJson(WeatherData expected)
        {
            string json = JsonSerializer.Serialize(expected);

            var result = _parser.Parse(json);

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("{...}")]
        [InlineData("{\"key\":\"value\"}")]
        public void JsonWeatherParser_ShouldRecognizeCompatibleData(string json)
        {
            _parser.IsCompatible(json).Should().BeTrue();
        }

        [Theory]
        [InlineData("not json")]
        [InlineData("<xml>stuff</xml>")]
        public void JsonWeatherParser_ShouldRejectIncompatibleData(string data)
        {
            _parser.IsCompatible(data).Should().BeFalse();
        }
    }
}
