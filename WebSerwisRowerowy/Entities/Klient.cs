using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Models
{
    public class Klient
    {
        public Klient()
        {
            this.Zlecenia = new HashSet<Zlecenie>();
        }

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Imie { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Nazwisko { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string NrTelefonu { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "char(10)")]
        public string NIP { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Firma { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Miasto { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Adres { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string KodPocztowy { get; set; }

        public virtual ICollection<Zlecenie> Zlecenia { get; set; }

    }
}
