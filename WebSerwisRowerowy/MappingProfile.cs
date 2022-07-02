using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Zlecenie, ZlecenieModel>()
                .ForMember(m => m.KlientID, c => c.MapFrom(s => s.Klienci.Id))
                .ForMember(m => m.PracownikID, c => c.MapFrom(s => s.Pracownicy.Id))
                .ForMember(m => m.MetodPlatnosciID, c => c.MapFrom(s => s.MetodPlatnosci.Id));

            CreateMap<ZlecenieModel, Zlecenie>();
            CreateMap<UslugaModel, Usluga>();
            CreateMap<Usluga, UslugaModel>();
            CreateMap<Klient, KlientModel>();
            CreateMap<KlientModel, Klient>();
        }
    }
}
