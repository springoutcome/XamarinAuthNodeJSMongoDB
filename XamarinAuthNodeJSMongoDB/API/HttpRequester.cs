﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace XamarinAuthNodeJSMongoDB.API
{
    public static class HttpRequester
    {
        private static HttpClient client = new HttpClient();

        public static async Task<T> Get<T>(Dictionary<string, string> queryParameters, string url) where T : class
        {
            var response =
            await client.GetAsync(url + $"? {await new FormUrlEncodedContent(queryParameters).ReadAsStringAsync()}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }

        }

        public static async Task<T> NoQueryGet<T>(string url) where T : class
        {
            var response =
            await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }

        }

        public static async Task<T> Post<T>(Dictionary<string, string> reqParameters, string url) where T : class
        {
            var response = await client.PostAsync(url, new FormUrlEncodedContent(reqParameters));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }
        }

        public static async Task<T> Put<T>(Dictionary<string, string> reqParameters, string url) where T : class
        {
            var response = await client.PutAsync(url, new FormUrlEncodedContent(reqParameters));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }
        }

        public static async Task<T> Delete<T>(string url) where T : class
        {
            var response = await client.DeleteAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return default(T);
            }
        }
    }
}