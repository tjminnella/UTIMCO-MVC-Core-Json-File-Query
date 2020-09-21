using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UTIMCO.Models
{
    [DataContract]
    public class Menu
    {
        //[Required]
        [DataMember]
        [JsonPropertyName("header")]
        public string header { get; set; }
        [DataMember]
        //[Required]
        [JsonPropertyName("items")]
        public List<Item> items { get; set; }
    }
}
