using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Observers;

namespace Weather_Monitoring_Service.Publishers
{
    public class WeatherDataPublisher
    {
        public List<IWeatherObserver> Observers { get; set; } = new();

        public void AddObserver(IWeatherObserver observer)
        {
            Observers.Add(observer);
        }
        public void RemoveObserver(IWeatherObserver observer)
        {
            Observers.Remove(observer);
        }
        public void NotifyObservers(WeatherData data)
        {
            foreach (var observer in Observers)
            {
                observer.Update(data);
            }
        }

    }
}
