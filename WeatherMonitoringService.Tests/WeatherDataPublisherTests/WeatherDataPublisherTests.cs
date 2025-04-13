using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Weather_Monitoring_Service.models;
using Weather_Monitoring_Service.Observers;
using Weather_Monitoring_Service.Publishers;

namespace WeatherMonitoringService.Tests.WeatherDataPublisherTests
{
    public class WeatherDataPublisherTests
    {
        private readonly WeatherDataPublisher _publisher;

        public WeatherDataPublisherTests()
        {
            _publisher = new WeatherDataPublisher();
        }
        [Theory, AutoData]
        public void NotifyObservers_ShouldNotifyAllObservers(
            WeatherData data,
            Mock<IWeatherObserver> observer1,
            Mock<IWeatherObserver> observer2)
        {

            _publisher.AddObserver(observer1.Object);
            _publisher.AddObserver(observer2.Object);

            _publisher.NotifyObservers(data);

            observer1.Verify(o => o.Update(data), Times.Once);
            observer2.Verify(o => o.Update(data), Times.Once);
        }

        [Theory, AutoData]
        public void AddObserver_ShouldAddToObserversList(Mock<IWeatherObserver> observer)
        {

            _publisher.AddObserver(observer.Object);

            _publisher.Observers.Should().ContainSingle(o => o == observer.Object);
        }

        [Theory, AutoData]
        public void RemoveObserver_ShouldRemoveFromObserversList(Mock<IWeatherObserver> observer)
        {
            _publisher.AddObserver(observer.Object);

            _publisher.RemoveObserver(observer.Object);

            _publisher.Observers.Should().BeEmpty();
        }
    }
}
