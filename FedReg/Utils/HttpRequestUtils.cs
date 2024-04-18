﻿using FedReg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FedReg.Utils
{
    public class HttpRequestUtils
    {
        public static HttpClient _httpClient;
        private static int MaxRetries { get; } = 3;

        public static void ConfigureClient(HttpClient client, string url)
        {
            _httpClient = client;

            if (_httpClient.BaseAddress is null)
            {
                _httpClient.BaseAddress = new Uri(url);
                _httpClient.Timeout = TimeSpan.FromMilliseconds(1000);
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                    );
            }
        }

        public static async Task<DocumentModel> GetDocumentAsJsonAsync(string documentNumber)
        {
            DocumentModel document = FactoryUtils.CreateDocument();

            for (int retryAttempts = 0; retryAttempts < MaxRetries; retryAttempts++)
            {
                HttpResponseMessage httpResponseMessage = await ReturnDocumentAsJsonAsync(documentNumber);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await httpResponseMessage.Content.ReadAsAsync<DocumentModel>();
                }
                if (StatusCodeIsRetryable(httpResponseMessage.StatusCode))
                {
                    await Task.Delay(httpResponseMessage.Headers.RetryAfter.Delta ?? default);
                }
                else
                {
                    throw new HttpRequestException($"Request for document reference {documentNumber} failed with a status of {httpResponseMessage.StatusCode}.");
                }
            }
            return document;
        }

        private static bool StatusCodeIsRetryable(HttpStatusCode statusCode)
        {
            HttpStatusCode[] retryableStatusCodes = {
                HttpStatusCode.ServiceUnavailable,
                HttpStatusCode.TooManyRequests
            };
            return retryableStatusCodes.Contains(statusCode);
        }

        private static async Task<HttpResponseMessage> ReturnDocumentAsJsonAsync(string documentNumbers)
        {
            return await _httpClient.GetAsync($"{documentNumbers}.json");
        }
    }
}
