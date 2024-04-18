using FedReg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedReg.Utils
{
    public static class FactoryUtils
    {
        public static HttpClient CreateHttpClient()
        {
            return new HttpClient();
        }

        public static DocumentModel CreateDocument()
        {
            return new DocumentModel();
        }

        public static List<DocumentModel> CreateDocumentList()
        {
            return new List<DocumentModel>();
        }
    }
}
