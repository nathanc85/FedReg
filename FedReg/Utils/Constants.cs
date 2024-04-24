using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedReg.Utils
{
    public static class Constants
    {
        public static string Path => @"C:\Users\cnlna\Samples\";

        public static int MaxRetries => 3;

        public static string FedRegAPI => "https://www.federalregister.gov/api/v1/documents/";
    }
}
