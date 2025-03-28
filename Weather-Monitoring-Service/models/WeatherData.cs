using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Monitoring_Service.models
{
    public class WeatherData
    {
        public required string Location { get; set; }
        public required int Temperature { get; set; }
        public required int Humidity { get; set; }
    }
}
