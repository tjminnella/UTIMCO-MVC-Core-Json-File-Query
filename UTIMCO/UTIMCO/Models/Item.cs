using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UTIMCO.Models
{
    [DataContract]
    public class Item
    {
        //[Required]
        [DataMember]
        [JsonPropertyName("id")]
        public int id { get; set; }
        [DataMember]
        [JsonPropertyName("label")]
        public string label { get; set; }
    }
}
