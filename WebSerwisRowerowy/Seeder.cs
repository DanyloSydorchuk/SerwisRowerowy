using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy
{
    public class Seeder
    {
        public readonly ApplicationDbContext _dbContext;

        public Seeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Uslugi.Any())
                {
                    var uslugi = GetUslugi();
                    _dbContext.Uslugi.AddRange(uslugi);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Role.Any())
                {
                    var role = GetRole();
                    _dbContext.Role.AddRange(role);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.MetodPlatnosci.Any())
                {
                    var metodyPl = GetMetodyPl();
                    _dbContext.MetodPlatnosci.AddRange(metodyPl);
                    _dbContext.SaveChanges();
                }

            }
        }

        private IEnumerable<Usluga> GetUslugi()
        {
            var uslugi = new List<Usluga>()
            {
                new Usluga()
                {
                    Nazwa="Montaż roweru",
                    CenaNetto=(decimal)119.99,
                    PodatekVAT=(decimal)0.23,
                },
                new Usluga()
                {
                    Nazwa="Regulacja hamulca",
                    CenaNetto=(decimal)35,
                    PodatekVAT=(decimal)0.23,
                },
                new Usluga()
                {
                    Nazwa="Wymiana mechanizmu korbowego",
                    CenaNetto=(decimal)30.99,
                    PodatekVAT=(decimal)0.23,

                },
                new Usluga()
                {
                    Nazwa="Wymiana suportu",
                    CenaNetto=(decimal)49.5,
                    PodatekVAT=(decimal)0.23,
                },
                new Usluga()
                {
                    Nazwa="Wymiana łańcucha",
                    CenaNetto=(decimal)15,
                    PodatekVAT=(decimal)0.23,
                },
                new Usluga()
                {
                    Nazwa="Centrowanie koła",
                    CenaNetto=(decimal)60,
                    PodatekVAT=(decimal)0.23,
                },
                new Usluga()
                {
                    Nazwa="Wymiana dętki/opony",
                    CenaNetto=(decimal)15.99,
                    PodatekVAT=(decimal)0.23,
                },
                new Usluga()
                {
                    Nazwa="Przeglad roweru",
                    CenaNetto=(decimal)65.99,
                    PodatekVAT=(decimal)0.23,
                },
                new Usluga()
                {
                    Nazwa="Mycie roweru i smarowanie czesci",
                    CenaNetto=(decimal)99.5,
                    PodatekVAT=(decimal)0.23,
                }
            };
            return uslugi;
        }

        private IEnumerable<Role> GetRole()
        {
            var role = new List<Role>()
            {
                new Role()
                {
                    Nazwa="Admin"
                },
                new Role()
                {
                    Nazwa="User"
                }
            };
            return role;
        }

        private IEnumerable<MetodPlatnosci> GetMetodyPl()
        {
            var metod = new List<MetodPlatnosci>()
            {
                new MetodPlatnosci()
                {
                    Nazwa="Karta"
                },
                new MetodPlatnosci()
                {
                    Nazwa="Gotówka"
                },
                new MetodPlatnosci()
                {
                    Nazwa="Przelew"
                },
                new MetodPlatnosci()
                {
                    Nazwa="Inny"
                }
            };
            return metod;
        }
    }
}
