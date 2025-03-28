using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;

namespace Weather_Monitoring_Service.Observers
{
    public interface IWeatherObserver
    {
        public void Update(WeatherData data);
    }
}
