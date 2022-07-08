using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Entities
{
    public partial class UslugaZlecenie
    {
        public int Id { get; set; }
        public int ZlecenieID { get; set; }
        public int UslugiID { get; set; }
        public int Ilosc { get; set; }

        public Usluga Uslugi { get; set; }
    }
}
