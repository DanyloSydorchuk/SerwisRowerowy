using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Models
{
    public class ZlecenieModel
    {
        public int Id { get; set; }
        public int? PracownikID { get; set; }
        public int KlientID { get; set; }
        public string NazwaRoweru { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataOdbioru { get; set; }
        public decimal? CenaBrutto { get; set; }
        public int? MetodPlatnosciID { get; set; }
        public int? StatusID { get; set; }

        public virtual Status Statusy { get; set; }
        public virtual Klient Klienci { get; set; }
        public virtual MetodPlatnosci MetodPlatnosci { get; set; }
        public virtual Pracownik Pracownicy { get; set; }
        public virtual ICollection<UslugaZlecenie> UslugiUzyte { get; set; }
    }
}
