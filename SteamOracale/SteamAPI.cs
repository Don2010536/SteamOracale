using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace SteamOracale
{
    class SteamAPI
    {
        private readonly string key = "";

        //private readonly HttpClient client = new HttpClient();
        
        public string GetFriendsList(string id)
        {
            HttpClient client = new HttpClient();
            string apiURL = $"http://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key={key}&steamid={id}&relationship=friend";

            client.BaseAddress = new Uri(apiURL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = client.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    client.Dispose();
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch { }

            client?.Dispose();
            return null;
        }

        public void Dispose()
        {
        }
    }
}
