using FedReg.Models;
using FedReg.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FedReg
{
    public static class Display
    {
        private static void ShowDocuments(List<DocumentModel> documents)
        {
            documents.ForEach(x => ShowDocument(x));
        }

        public static void ShowDocument(DocumentModel document)
        {
            foreach (var documentProp in document.GetType().GetProperties())
            {
                if (documentProp.Name == "Agencies" && document.Agencies != null)
                {
                    Console.WriteLine("Agencies:");
                    foreach (var agency in document.Agencies)
                    {
                        foreach (var agencyProp in agency.GetType().GetProperties())
                        {
                            Console.WriteLine($"    {agencyProp.Name}: {agencyProp.GetValue(agency, null)}");
                        }
                    }
                }
                else if (documentProp.Name == "Topics" && document.Topics != null)
                {
                    Console.WriteLine("Topics:");
                    foreach (var topic in document.Topics)
                    {
                            Console.WriteLine($"    {topic}");
                    }
                }
                else
                {
                    Console.WriteLine($"{documentProp.Name}: {documentProp.GetValue(document, null)}");
                }
            }
        }

        //public static void ShowDocument(DocumentModel document)
        //{
        //    Dictionary<string, string> documentDisplay = new Dictionary<string, string> {
        //        { "Document Reference", document.FederalRegisterDocumentNumber },
        //        { "Document Title", document.DocumentTitle },
        //        { "Publication Date", document.PublicationDate.ToShortDateString() },
        //        { "Publication Type", document.PublicationType },
        //        { "Presidential Document Type", document.PresidentialDocumentType },
        //        { "Document citation", document.DocumentCitation },
        //        { "Abstract", document.Abstract },
        //    };

        //    foreach (KeyValuePair<string, string> item in documentDisplay)
        //    {
        //        if (!String.IsNullOrEmpty(item.Value))
        //        {
        //            Console.WriteLine($"{item.Key}: {item.Value}");
        //        }
        //    }
        //}

        public static async Task RunAsync()
        {
            await RetrieveSingleDocument();
        }

        public static async Task RetrieveSingleDocument()
        {
            Console.WriteLine("Please enter document reference to retrieve:");
            String documentNumberToRetrieve = Console.ReadLine();
            try
            {
                var document = await DocumentUtils.GetDocumentAsync(documentNumberToRetrieve);
                ShowDocument(document);
                SaveDocumentPDF(document);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void SaveDocumentPDF(DocumentModel document)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            string url = "https://www.govinfo.gov/content/pkg/FR-2022-02-01/pdf/2022-01961.pdf";
            webClient.DownloadFile(url, $"C:\\Users\\cnlna\\Samples\\{document.DocumentNumber}.pdf");
            
            //byte[] bytes = webClient.DownloadData(url);
            //Response.ContentType = ContentType;
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(url));
            //Response.BinaryWrite(bytes);
            //Response.End();
        }
    }
}
