using System;
using System.Collections.Generic;
using System.Net;
using GrandRepairAuto.Services.Contracts;
using Newtonsoft.Json;

namespace GrandRepairAuto.Services
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly String BASE_URI = "https://free.currconv.com";
        private readonly String API_VERSION = "v7";
        private readonly String API_KEY = "5d363582e0f1d27c708c";
        
        public CurrencyConverter() {}

        public double GetCurrencyExchange(String localCurrency, String foreignCurrency)
        {
            var code = $"{localCurrency}_{foreignCurrency}";
            var newRate = FetchSerializedData(code);
            return newRate;
        }

        private double FetchSerializedData(String code)
        {
            var url = $"{BASE_URI}/api/{API_VERSION}/convert?q={code}&compact=y&apiKey={API_KEY}";
            var webClient = new WebClient();
            var jsonData = String.Empty;

            var conversionRate = 1.0d;
            try
            {
                jsonData = webClient.DownloadString(url);
                var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, double>>>(jsonData);
                var result = jsonObject[code];
                conversionRate = result["val"];
                
            }
            catch (Exception) { }

            return conversionRate;
        }
    }
}