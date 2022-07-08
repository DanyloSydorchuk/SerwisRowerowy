using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Entities;
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
                if (!_dbContext.Statusy.Any())
                {
                    var statusy = GetStatusy();
                    _dbContext.Statusy.AddRange(statusy);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Klienci.Any())
                {
                    var klienci = GetKlienci();
                    _dbContext.Klienci.AddRange(klienci);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Pracownicy.Any())
                {
                    var pracownik = GetPracownik();
                    _dbContext.Pracownicy.AddRange(pracownik);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Zlecenia.Any())
                {
                    var zlecenie = GetZlecenie();
                    _dbContext.Zlecenia.AddRange(zlecenie);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.UslugiUzyte.Any())
                {
                    var uslugiUz = GetUslugiUzyte();
                    _dbContext.UslugiUzyte.AddRange(uslugiUz);
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

        private IEnumerable<Status> GetStatusy()
        {
            var metod = new List<Status>()
            {
                new Status()
                {
                    Nazwa="Przyjęty"
                },
                new Status()
                {
                    Nazwa="W realizacji"
                },
                new Status()
                {
                    Nazwa="Do odbioru"
                },
                new Status()
                {
                    Nazwa="Anulowane"
                }

            };
            return metod;
        }

        private IEnumerable<Klient> GetKlienci()
        {
            var metod = new List<Klient>()
            {
                new Klient()
                {
                    Imie = "Daniel",
                    Nazwisko = "Sydorchuk",
                    NrTelefonu = "123123123",
                    Email = "dsydorchuk26@gmail.com",
                    NIP = "1231231233",
                    Firma = "Firma",
                    Miasto = "Kraków",
                    Adres = "Ludwinowska",
                    KodPocztowy = "30-331"
                }
            };
            return metod;
        }

        private IEnumerable<Pracownik> GetPracownik()
        {
            var metod = new List<Pracownik>()
            {
                new Pracownik()
                {
                    Imie = "Dariusz",
                    Nazwisko = "Kowalski",
                    Pesel = "12312312312",
                    NrTelefonu = "123123123",
                    Email = "dsydorchuk26@gmail.com",
                    DataRozpoczecia = DateTime.Now
                }
            };
            return metod;
        }

        private IEnumerable<Zlecenie> GetZlecenie()
        {
            var metod = new List<Zlecenie>()
            {
                new Zlecenie()
                {
                    PracownikID =1,
                    KlientID = 1,
                    NazwaRoweru = "Bianchi Szosa",
                    DataPrzyjecia = DateTime.Now
                }
            };
            return metod;
        }

        private IEnumerable<UslugaZlecenie> GetUslugiUzyte()
        {
            var metod = new List<UslugaZlecenie>()
            {
                new UslugaZlecenie()
                {
                    ZlecenieID = 1,
                    UslugiID = 1,
                    Ilosc = 2
                },
                new UslugaZlecenie()
                {
                    ZlecenieID = 1,
                    UslugiID = 3,
                    Ilosc = 1
                },
                new UslugaZlecenie()
                {
                    ZlecenieID = 1,
                    UslugiID = 4,
                    Ilosc = 3
                }
            };
            return metod;
        }




    }
}
