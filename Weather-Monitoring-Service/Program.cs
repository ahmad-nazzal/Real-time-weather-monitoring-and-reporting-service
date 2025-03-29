using Weather_Monitoring_Service.Factory;
using Weather_Monitoring_Service.Parser;
using Weather_Monitoring_Service.Publishers;
using Weather_Monitoring_Service.Services;

var weatherPublisher = new WeatherDataPublisher();
var enabledBots = BotFactory.GetBots();
enabledBots.ForEach(bot => weatherPublisher.AddObserver(bot));
var weatherService = new WeatherService(new List<IWeatherParser> { new JsonWeatherParser(), new XmlWeatherParser() }, weatherPublisher);
Console.WriteLine("Enter weather data:");
var data = Console.ReadLine();
weatherService.ParseAndPublish(data);