using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ex01.Models
{
    public class TrelloBoard
    {
        [JsonProperty(PropertyName = "id")] // name in json
        public string BoardId { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "starred")]
        public bool IsFavorite { get; set; }
    }
}
