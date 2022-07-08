using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Entities
{
    public class Pracownik
    {
        public Pracownik()
        {
            this.Zlecenia = new HashSet<Zlecenie>();
        }

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Imie { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Nazwisko { get; set; }
        [Column(TypeName = "char(11)")]
        public string Pesel { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string NrTelefonu { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }

        public virtual ICollection<Zlecenie> Zlecenia { get; set; }
    }
}
