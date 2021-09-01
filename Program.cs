using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using jhPokemon.Interfaces;

namespace jhPokemon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Utils
    {
         public static T GetFromExternalApi<T>(string uri)
        {
            T result = default;
            Model.WebApiCallResponse response = Utils.ExecuteCall(uri, "");
            if (response.HttpStatusCode.Equals(200))
            {
                //PokemonFullDto pokemonDetail = JsonSerializer.Deserialize<PokemonFullDto>(response.ResponseBody);
                result = JsonSerializer.Deserialize<T>(response.ResponseBody);
            }

            return result;
        }


        public static string TranslateText(ITranslationEngine.TranslationTypes translationType, string text)
        {
            return new Core.FunTranslationEngine().GetTranslation(translationType, text);
        }

        public static string CleanDescription(string description)
        {
            return System.Text.RegularExpressions.Regex.Replace(description, @"\t|\n|\r|\f", " ");
        }

        public static Model.WebApiCallResponse ExecuteCall(string requestUrl, List<string> requestParameterList)
        {
            return ExecuteCall(requestUrl, GetParamString(requestParameterList));
        }

        public static Model.WebApiCallResponse ExecuteCall(string requestUrl, string requestParameters)
        {
            Model.WebApiCallResponse result = new();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(requestUrl);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                result.HttpStatusCode = (int)response.StatusCode;
                result.ResponseBody = response.Content.ReadAsStringAsync().Result;
            }


            return result;
        }


        private static string GetParamString(List<string> requestParameterList)
        {
            if (requestParameterList != null && requestParameterList.Count > 0)
            {
                System.Text.StringBuilder ret = new System.Text.StringBuilder();
                ret.Append(@"?");
                foreach (var item in requestParameterList)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        ret.Append(item).Append(@"&");
                    }
                }

                return ret.ToString().Substring(0, ret.Length - 1);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
