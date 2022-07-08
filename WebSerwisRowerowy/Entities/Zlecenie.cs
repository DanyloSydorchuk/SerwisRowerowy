using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy.Entities
{
    public class Zlecenie
    { 
        public int Id { get; set; }
        public int? PracownikID { get; set; }
        public int KlientID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string NazwaRoweru { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataOdbioru { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal? CenaBrutto { get; set; }
        public int? MetodPlatnosciID { get; set; }
        public int? StatusID { get; set; }

        public virtual Status Statusy { get; set; }
        public virtual Klient Klienci { get; set; }
        public virtual MetodPlatnosci MetodPlatnosci { get; set; }
        public virtual Pracownik Pracownicy { get; set; }
        public virtual ICollection<UslugaZlecenie> UslugaZlecenie { get; set; }
    }
}
