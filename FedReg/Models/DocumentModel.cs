using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedReg.Models
{
    //public class DocumentModel
    //{
    //    [JsonProperty("document_number")]
    //    public string FederalRegisterDocumentNumber { get; set; }

    //    [JsonProperty("title")]
    //    public string DocumentTitle { get; set; }

    //    [JsonProperty("type")]
    //    public string PublicationType { get; set; }

    //    [JsonProperty("publication_date")]
    //    public DateTime PublicationDate { get; set; }

    //    [JsonProperty("citation")]
    //    public string DocumentCitation { get; set; }

    //    [JsonProperty("subtype")]
    //    public string PresidentialDocumentType { get; set; }

    //    [JsonProperty("abstract")]
    //    public string Abstract { get; set; }
    //}

    public class DocumentModel
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
}
