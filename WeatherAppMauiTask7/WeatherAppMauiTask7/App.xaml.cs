using WeatherAppMauiTask7.Pages;
namespace WeatherAppMauiTask7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherInfoPage();
        }
    }
}