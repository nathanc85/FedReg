using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using System.Net.Http.Headers;
using System;
using System.Reflection.Metadata;
using FedReg.Models;
using FedReg.Utils;
//using System.Text.Json;

namespace FedReg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //MyWayCallinFed();

            WorkWay();
        }

        private static void WorkWay()
        {
            HttpRequestUtils.ConfigureClient(
                FactoryUtils.CreateHttpClient(), "https://www.federalregister.gov/api/v1/documents/");
            Display
                .RunAsync().GetAwaiter().GetResult();
        }
        private static void MyWayCallinFed()
        {
            string document_number = "2022-01449";
            string format = "json";

            //string url = $"https://www.federalregister.gov/api/v1/documents/{document_number}.{format}";

            string url = "https://www.federalregister.gov/api/v1/documents/2022-01449.json";
            string baseUrl = "https://www.federalregister.gov/api/v1/documents/";

            try
            {
                using (var client = new HttpClient())
                {
                    if (client.BaseAddress is null)
                    {
                        client.BaseAddress = new Uri(baseUrl);
                        client.Timeout = TimeSpan.FromMilliseconds(1000);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json")
                            );
                    }

                    var response = client.GetAsync(url).Result;
                    var responseStream = response.Content.ReadAsStreamAsync().Result;

                    var responseData = System.Text.Json.JsonSerializer.DeserializeAsync<Root2>(responseStream).Result;

                    //var foo = responseData;
                    //foreach (var prop in foo.GetType().GetProperties())
                    //{
                    //    Console.WriteLine("{0}={1}, " + prop.Name + ", " + prop.GetValue(foo, null));
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Agency
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("raw_name")]
        public string? RawName { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }
    }

    public class Root
    {
        [JsonProperty("abstract")]
        public string? Abstract { get; set; }

        [JsonProperty("action")]
        public string? Action { get; set; }

        [JsonProperty("agencies")]
        public List<Agency>? Agencies { get; set; }

        [JsonProperty("body_html_url")]
        public string? BodyHtmlUrl { get; set; }

        [JsonProperty("citation")]
        public string? Citation { get; set; }

        [JsonProperty("dates")]
        public string? Dates { get; set; }

        [JsonProperty("document_number")]
        public string? DocumentNumber { get; set; }

        [JsonProperty("effective_on")]
        public string? EffectiveOn { get; set; }

        [JsonProperty("full_text_xml_url")]
        public string? FullTextXmlUrl { get; set; }

        [JsonProperty("html_url")]
        public string? HtmlUrl { get; set; }

        [JsonProperty("json_url")]
        public string? JsonUrl { get; set; }

        [JsonProperty("page_length")]
        public int PageLength { get; set; }

        [JsonProperty("pdf_url")]
        public string? PdfUrl { get; set; }

        [JsonProperty("publication_date")]
        public string? PublicationDate { get; set; }

        [JsonProperty("raw_text_url")]
        public string? RawTextUrl { get; set; }

        [JsonProperty("start_page")]
        public int StartPage { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("topics")]
        public List<string>? Topics { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

    }

    public class Root2
    {
        [JsonProperty("abstract")]
        public string? Abstract { get; set; }

    }

}