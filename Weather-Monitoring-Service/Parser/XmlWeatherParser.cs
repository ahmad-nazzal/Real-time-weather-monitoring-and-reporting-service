using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Weather_Monitoring_Service.models;

namespace Weather_Monitoring_Service.Parser
{
    public class XmlWeatherParser: IWeatherParser
    {
        public WeatherData Parse(string data)
        {
            var serializer = new XmlSerializer(typeof(WeatherData));
            using var reader = new StringReader(data);
            return (WeatherData)serializer.Deserialize(reader);
        }
        public bool IsCompatible(string data)
        {
            return data.StartsWith("<") && data.EndsWith(">");
        }
    }
}
