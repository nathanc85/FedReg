using FedReg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedReg.Utils
{
    public static class DocumentUtils
    {
        public static List<DocumentModel> GetDocuments(List<string> documentNumbers)
        {
            List<DocumentModel> documents = FactoryUtils.CreateDocumentList();
            documents = GetDocumentsInMultipleCalls(documentNumbers);
            return documents;
        }

        private static List<DocumentModel> GetDocumentsInSingleCall(List<string> documentNumbers)
        {
            string documentsToRetrieve = string.Join(",", documentNumbers);
            var documents = FactoryUtils.CreateDocumentList();
            return documents;
        }

        private static List<DocumentModel> GetDocumentsInMultipleCalls(List<string> documentNumbers)
        {
            List<DocumentModel> documents = FactoryUtils.CreateDocumentList();
            foreach (var documentNumber in documentNumbers)
            {
                documents.Add(GetDocumentAsync(documentNumber).Result);
            }
            return documents;
        }

        public static async Task<DocumentModel> GetDocumentAsync(string documentNumber)
        {
            return await HttpRequestUtils.GetDocumentAsJsonAsync(documentNumber);
        }
    }
}
