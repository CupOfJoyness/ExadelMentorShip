using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        const string AppId = "23a60ff5ee6fce381a222b1173ea24e1";
        public async Task<string> GetWeatherForecast(string cityName, int daysCount, string forecastLanguage = "en", string unitsSystem = "metric")
        {
            if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentException(nameof(cityName));
            if (daysCount is < 0 or > 16) throw new ArgumentException(nameof(daysCount));

            var request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/forecast/daily?q="
                                                   + cityName
                                                   + $"&units={unitsSystem}"
                                                   + $"&cnt={daysCount}"
                                                   + $"&lang={forecastLanguage}"
                                                   + $"&appid={AppId}");
            request.Method = "POST";

            var response = await request.GetResponseAsync();

            string answer = string.Empty;

            await using (Stream s = response.GetResponseStream())
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