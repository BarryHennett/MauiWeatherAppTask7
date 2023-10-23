using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherAppMauiTask7.Services;

namespace WeatherAppMauiTask7.Models.ViewModels
{
    internal partial class WeatherInfoPageViewModel : ObservableObject
    {

        private readonly WeatherApiService _weatherApiService;

        public WeatherInfoPageViewModel()
        {
            _weatherApiService = new WeatherApiService();
        }

        [ObservableProperty]
        private string latitude;

        [ObservableProperty]
        private string longitude;

        [ObservableProperty]
        private string weatherIcon;

        [ObservableProperty]
        private string temperature;

        [ObservableProperty]
        private string weatherDescription;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private int humidity;

        [ObservableProperty]
        private string cloudCoverLevel;

        [ObservableProperty]
        private string isDay;

        [RelayCommand]
        private async Task FetchWeatherInformation()
        {
            var weatherApiResponse = await _weatherApiService.GetWeatherInformation(latitude, longitude);
            if (weatherApiResponse == null)
            {
                WeatherIcon = weatherApiResponse.current.WeatherIcons[0];
                Temperature = $"{weatherApiResponse.current.temperature}°C";
                Location = $"{weatherApiResponse.location.Name}, {weatherApiResponse.location.region}, {weatherApiResponse.location.country}";
                WeatherDescription = weatherApiResponse.current.weather_descriptions[0];
                Humidity = weatherApiResponse.current.humidity;
                CloudCoverLevel = $"{weatherApiResponse.current.cloudcoverlevel}%";
                IsDay = weatherApiResponse.current.is_day.ToUpper();

            }
        }
    }
}
