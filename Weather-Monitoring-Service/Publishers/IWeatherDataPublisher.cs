using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Observers;

namespace Weather_Monitoring_Service.Publishers
{
    public interface IWeatherDataPublisher
    {
        List<IWeatherObserver> Observers { get; set; }

        void AddObserver(IWeatherObserver observer);
        void NotifyObservers(WeatherData data);
        void RemoveObserver(IWeatherObserver observer);
    }
}