using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Entities;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Zlecenie, ZlecenieModel>();
            CreateMap<ZlecenieModel, Zlecenie>();
            CreateMap<Zlecenie, Klient>();
            CreateMap<Klient, Zlecenie>();
            CreateMap<UslugaModel, Usluga>();
            CreateMap<Usluga, UslugaModel>();
            CreateMap<Klient, KlientModel>();
            CreateMap<KlientModel, Klient>();
            CreateMap<Pracownik, PracownikModel>();
            CreateMap<PracownikModel, Pracownik>();
        }
    }
}
