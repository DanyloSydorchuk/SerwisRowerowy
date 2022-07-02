using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Models
{
    public class KlientModel
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTelefonu { get; set; }
        public string Email { get; set; }
        public string NIP { get; set; }
        public string Firma { get; set; }
        public string Miasto { get; set; }
        public string Adres { get; set; }
        public string KodPocztowy { get; set; }

    }
}
