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

        public static void SaveDocumentPDF(DocumentModel document)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(document.PdfUrl, $"{Constants.Path}{document.DocumentNumber}.pdf");
        }

        public static async Task DownloadPdfHttp(DocumentModel document)
        {
            try
            {
                await DownloadPdfFileAsync(document.PdfUrl, $"{Constants.Path}{document.DocumentNumber}-1.pdf");
                Console.WriteLine("PDF file downloaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to download PDF file: {ex.Message}");
            }
        }

        static async Task DownloadPdfFileAsync(string url, string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                // Send a GET request to the URL
                HttpResponseMessage response = await client.GetAsync(url);

                // Check if the request was successful
                response.EnsureSuccessStatusCode();

                // Get the content of the response as a stream
                using (Stream pdfStream = await response.Content.ReadAsStreamAsync())
                {
                    // Create a FileStream to write the PDF content to a file
                    using (FileStream fileStream = File.Create(filePath))
                    {
                        // Copy the content of the PDF stream to the file stream
                        await pdfStream.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
}
