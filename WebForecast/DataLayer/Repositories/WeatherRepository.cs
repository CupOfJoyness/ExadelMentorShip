using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        const string AppId = "23a60ff5ee6fce381a222b1173ea24e1";
        public async Task<string> GetWeather(string cityName, string forecastLanguage = "en", string unitsSystem = "metric")
        {
            WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?q=" 
                                                   + cityName + $"&units={unitsSystem}" 
                                                   + $"&lang={forecastLanguage}" 
                                                   + $"&appid={AppId}");
            request.Method = "POST";

            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();

            return answer;
        }

        public async Task<string> GetWeatherForecast(string cityName, int daysCount, string forecastLanguage = "en", string unitsSystem = "metric")
        {

            //api.openweathermap.org/data/2.5/forecast/daily?q={city name}&cnt={cnt}&appid={API key}
            WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/forecast/daily?q="
                                                   + cityName 
                                                   + $"&units={unitsSystem}"
                                                   + $"&cnt={daysCount}"
                                                   + $"&lang={forecastLanguage}"
                                                   + $"&appid={AppId}");
            request.Method = "POST";

            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;

            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            response.Close();

            return answer;
        }
    }
}