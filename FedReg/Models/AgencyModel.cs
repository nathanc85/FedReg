using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedReg.Models
{
    public class AgencyModel
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
}
