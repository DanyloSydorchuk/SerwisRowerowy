using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Entities
{
    public partial class Usluga
    {

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Nazwa { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal? CenaNetto { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? PodatekVAT { get; set; }


        public virtual ICollection<UslugaZlecenie> UslugaZlecenia { get; set; }
    }
}
