using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AoCHelper
{
    public static class AdventOfCodeService
    {

        static string cookie = "";

        private static HttpClientHandler handler = new HttpClientHandler
        {
            CookieContainer = GetCookieContainer(),
            UseCookies = true,
        };

        private static HttpClient client = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://adventofcode.com/"),
        };

        public static async Task<string> FetchInput(uint year, uint day)
        {
            var currentEst = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc).AddHours(-5);
            if (currentEst < new DateTime((int)year, 12, (int)day))
            {
                throw new InvalidOperationException("Too early to get puzzle input.");
            }

            var response = await client.GetAsync($"{year}/day/{day}/input");
            return await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }

        private static CookieContainer GetCookieContainer()
        {
            var container = new CookieContainer();
            container.Add(new Cookie
            {
                Name = "session",
                Domain = ".adventofcode.com",
                Value = cookie,
            });

            return container;
        }
    }
}
