using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_API.Models
{
    public class DTO_Encomenda
    {
        public int ID { get; set; }
        public System.DateTime DataEncomenda { get; set; }
        public System.DateTime DataRecolha { get; set; }
        public System.DateTime DataEntrega { get; set; }
        public int Estado { get; set; }
        public string User_ID { get; set; }
    }
}