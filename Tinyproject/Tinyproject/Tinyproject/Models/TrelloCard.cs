using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ex01.Models
{
    public class TrelloCard
    {
        [JsonProperty(PropertyName = "id")]
        public string CardId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "closed")]
        public bool IsClosed { get; set; }
    }
}
