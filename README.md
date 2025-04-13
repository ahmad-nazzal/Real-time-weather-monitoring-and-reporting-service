# Real-time Weather Monitoring and Reporting Service

## Description
This C# console application simulates a real-time weather monitoring and reporting service. The system processes weather data from multiple weather stations in different formats (JSON, XML), and activates different types of 'weather bots' that react to weather conditions based on pre-configured thresholds.

### Key Features:
- Receives and processes weather data in multiple formats (JSON, XML).
- Configures and activates weather bots (RainBot, SunBot, SnowBot) based on specific weather conditions.
- Bots print pre-configured messages when triggered.
- Easily extensible to add new bot types or data formats with minimal code changes (Open-Closed principle).
- Configuration controlled via a JSON file.

## Design Patterns Used
- **Observer Pattern**: Allows the bots to be notified and react to weather data updates in real-time.
- **Strategy Pattern**: Defines a set of algorithms (bot behaviors) and allows the system to switch between them based on the weather data.

## Supported Input Formats

### JSON Format:
```json
{
  "Location": "City Name",
  "Temperature": 23.0,
  "Humidity": 85.0
}
```

### XML Format:
```xml
<WeatherData>
  <Location>City Name</Location>
  <Temperature>23.0</Temperature>
  <Humidity>85.0</Humidity>
</WeatherData>
```

## Bot Types
- **RainBot**: Activated when humidity exceeds a certain threshold.
  - Example message: "It looks like it's about to pour down!"
  
- **SunBot**: Activated when the temperature exceeds a certain threshold.
  - Example message: "Wow, it's a scorcher out there!"
  
- **SnowBot**: Activated when the temperature falls below a certain threshold.
  - Example message: "Brrr, it's getting chilly!"

## Configuration File
The bot configurations are controlled by a JSON file that defines the behavior of each bot (enabled/disabled, activation threshold, and the message to display). Below is an example configuration:

```json
{
  "RainBot": {
    "enabled": true,
    "humidityThreshold": 70,
    "message": "It looks like it's about to pour down!"
  },
  "SunBot": {
    "enabled": true,
    "temperatureThreshold": 30,
    "message": "Wow, it's a scorcher out there!"
  },
  "SnowBot": {
    "enabled": false,
    "temperatureThreshold": 0,
    "message": "Brrr, it's getting chilly!"
  }
}
```

- **enabled**: Whether the bot is activated or not.
- **humidityThreshold** / **temperatureThreshold**: The value that activates the bot (for RainBot, the threshold is humidity; for SunBot and SnowBot, it's temperature).
- **message**: The message displayed by the bot when activated.

## Example Usage

1. **Start the application**: The system prompts: `Enter weather data:`.
   
2. **Input weather data**:
   - For JSON format: 
   ```json
   {"Location": "City Name", "Temperature": 32, "Humidity": 40}
   ```
   - For XML format:
   ```xml
   <WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>
   ```

3. **Bot Activation**: Based on the weather data and bot configuration, the system activates the relevant bot(s):
   - Example output when SunBot is activated:
   ```bash
   SunBot activated!
   SunBot: "Wow, it's a scorcher out there!"
   ```

## Extensibility
- New data formats (e.g., CSV, YAML) can be added easily by extending the data handling functionality.
- New bot types can be added by creating new classes that implement a common interface (e.g., `IWeatherBot`).

[![build and test](https://github.com/ahmad-nazzal/Real-time-weather-monitoring-and-reporting-service/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/ahmad-nazzal/Real-time-weather-monitoring-and-reporting-service/actions/workflows/build-and-test.yml)
