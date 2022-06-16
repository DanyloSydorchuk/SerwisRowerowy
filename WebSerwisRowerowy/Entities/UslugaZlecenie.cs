using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Models
{
    public partial class UslugaZlecenie
    {
        public int Id { get; set; }
        public int ZlecenieID { get; set; }
        public int UslugiID { get; set; }
        public int Ilosc { get; set; }

        public virtual Usluga Uslugi { get; set; }
        public virtual Zlecenie Zlecenia { get; set; }
    }
}
