using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UTIMCO.Models
{
    public class ResultLine
    {   [Display(Name = "Name")]
        public string Name { get; set; }
        public int TotalId { get; set; }
    }
}
