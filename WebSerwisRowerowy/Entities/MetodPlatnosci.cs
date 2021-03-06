using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSerwisRowerowy.Entities
{
    public class MetodPlatnosci
    {
        public MetodPlatnosci()
        {
            this.Zlecenia = new HashSet<Zlecenie>();
        }

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Nazwa { get; set; }

        public virtual ICollection<Zlecenie> Zlecenia { get; set; }
    }
}
