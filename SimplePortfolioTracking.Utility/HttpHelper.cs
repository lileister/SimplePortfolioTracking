using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SimplePortfolioTracking.Utility
{
    public static class HttpHelper
    {
        public static async Task<string> GetAsync(string url)
        {
            string jsonString = "";
            
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                }
            }

            return jsonString;
        }
    }
}
