using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MainApp
{
    public class Client
    {
        public static HttpClient ApiClient;
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void SetClientUri(string uriString) 
        {
            ApiClient.BaseAddress = new Uri(uriString);
        }
    }
}
