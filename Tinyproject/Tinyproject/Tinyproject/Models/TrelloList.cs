using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;
using Newtonsoft.Json;

namespace Ex01.Models
{
    public class TrelloList
    {
        [JsonProperty(PropertyName = "id")] // name in json for ListID = id
        public string ListId { get; set; }
        public string Name { get; set; }



        

    }
}
