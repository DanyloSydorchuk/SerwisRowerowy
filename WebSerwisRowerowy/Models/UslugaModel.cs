using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Models
{
    public class UslugaModel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public decimal? CenaNetto { get; set; }
        public decimal? PodatekVAT { get; set; }
    }
}
