using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UTIMCO.Models
{
    [DataContract]
    public class MyArray
    {
        [Required]
        [DataMember]
        [JsonPropertyName("menu")]
        public Menu menu { get; set; }
    }
}
