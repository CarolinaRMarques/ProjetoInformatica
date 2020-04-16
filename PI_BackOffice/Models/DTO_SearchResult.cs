using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_BackOffice.Models
{
    public class DTO_SearchResult
    {
        [Display(Name = "Texto")]
        public string text { get; set; }
        [Display(Name = "Origem")]
        public string origem { get; set; }
        public int id { get; set; }
    }
}