using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Models
{
    public class PracownikModel
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string NrTelefonu { get; set; }
        public string Email { get; set; }
        public DateTime DataRozpoczecia { get; set; } = DateTime.Now;
        public DateTime? DataZakonczenia { get; set; }
    }
}
