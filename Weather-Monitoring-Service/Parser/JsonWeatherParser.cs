using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;

namespace Weather_Monitoring_Service.Parser
{
    public class JsonWeatherParser : IWeatherParser
    {
        public WeatherData Parse(string data)
        {
            return JsonSerializer.Deserialize<WeatherData>(data);
        }
        public bool IsCompatible(string data)
        {
            return data.StartsWith("{") && data.EndsWith("}");
        }
    }
}
