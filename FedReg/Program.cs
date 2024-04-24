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
            WorkWay();
        }

        private static void WorkWay()
        {
            HttpRequestUtils.ConfigureClient(
                FactoryUtils.CreateHttpClient(), Constants.FedRegAPI);
            Display
                .RunAsync().GetAwaiter().GetResult();
        }
    }

}