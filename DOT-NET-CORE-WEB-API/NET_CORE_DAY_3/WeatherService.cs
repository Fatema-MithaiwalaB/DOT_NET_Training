using NET_CORE_DAY_3;
using Weather.NET;

public class WeatherService : IWeatherService
{
    private readonly WeatherClient _weatherClient;

    public WeatherService()
    {
        string API_Key = "f2859064e653f0275cccf0bc0179efca";
        _weatherClient = new WeatherClient(API_Key);
    }

    public object GetWeather(string city)
    {
        return _weatherClient.GetCurrentWeather(city);
    }
}
