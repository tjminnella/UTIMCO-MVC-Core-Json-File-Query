using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UTIMCO.Models;

namespace UTIMCO.ViewModel
{
    public class JsonEvaluateViewModel
    {
        public List<ResultLine> MyResults { get; set; }
        [Display(Name = "UTIMCO Json")]
        public IFormFile JsonFile { get; set; }
        public string ErrorMessage { get; set; }
    }
}
