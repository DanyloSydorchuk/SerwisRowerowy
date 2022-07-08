using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Entities;
using WebSerwisRowerowy.Exceptions;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy.Services
{
    public interface IZlecenieService
    {
        ZlecenieModel GetById(int id);
        IEnumerable<ZlecenieModel> GetAll();
        Task<int> Create(ZlecenieModel zlecenieModel);
        void Delete(int id);
        Task UpdateAsync(int id, ZlecenieModel zlecenieModel);
    }
    public class ZlecenieService : IZlecenieService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ZlecenieService> _logger;

        public ZlecenieService(ApplicationDbContext dbContext,IMapper mapper, ILogger<ZlecenieService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Create(ZlecenieModel zlecenieModel)
        {
            var zlecenie = _mapper.Map<Zlecenie>(zlecenieModel);
            //var result = from uz in uslugaZlecenie
            //             join z in listazlecen
            //             on uz.ZlecenieID equals z.Id
            //             join u in usluga
            //             on uz.UslugiID equals u.Id
            //             select new { z.Id, uz.Ilosc, u.CenaNetto, u.PodatekVAT
            //             };
            _dbContext.Zlecenia.Add(zlecenie);
            _dbContext.SaveChanges();
            if (_dbContext.UslugiUzyte.Select(uz => uz.Id == zlecenie.Id) is not null)
            {
                var result = _dbContext.Uslugi.Join(_dbContext.UslugiUzyte,
                              u => u.Id,
                              uz => uz.UslugiID,
                              (u, uz) => new
                              {
                                  ZlecenieId = uz.ZlecenieID,
                                  UslugaId = u.Id,
                                  Cena = u.CenaNetto,
                                  Podatek = u.PodatekVAT,
                                  Ilosc = uz.Ilosc
                              })
                      .Where(u => u.ZlecenieId == zlecenie.Id)
                      .Sum(u => u.Cena * u.Ilosc * (1+u.Podatek));
                zlecenieModel.CenaBrutto = result;
                await UpdateAsync(zlecenie.Id, zlecenieModel);

            }
             return zlecenie.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Zlecenie o id: {id} zostanie usunięte");

            var zlecenie = _dbContext.Zlecenia.FirstOrDefault(z => z.Id == id);

            if (zlecenie is null)
                throw new NotFoundException($"Brak zlecenia o id: {id}");


            _dbContext.Zlecenia.Remove(zlecenie);
            _dbContext.SaveChanges();

        }


        public IEnumerable<ZlecenieModel> GetAll()
        {
            var zlecenia = _dbContext.Zlecenia
                //.Include(z => z.UslugiUzyte)
                //.Include(z => z.MetodPlatnosci)
                .ToList();

            var lista = _mapper.Map<List<ZlecenieModel>>(zlecenia);

            return lista;
        }

        public ZlecenieModel GetById(int id)
        {
            var zlecenie = _dbContext
                .Zlecenia
                    .Include(z => z.UslugaZlecenie)
                    .Include(z => z.MetodPlatnosci)
                .FirstOrDefault(z => z.Id == id);

            if (zlecenie is null)
                throw new NotFoundException($"Brak zlecenia o id: {id}");

            var result = _mapper.Map<ZlecenieModel>(zlecenie);
            result.UslugiUzyte = zlecenie.UslugaZlecenie;
            return result;
        }

        public async Task UpdateAsync(int id, ZlecenieModel zlecenieModel)
        {
            var zlecenie = _dbContext.Zlecenia.FirstOrDefault(z => z.Id == id);

            if (zlecenie is null)
                throw new NotFoundException($"Brak zlecenia o id: {id}");

            if (zlecenieModel.PracownikID is not null)
                zlecenie.PracownikID = zlecenieModel.PracownikID;
            if (zlecenieModel.DataOdbioru is not null)
                zlecenie.DataOdbioru = zlecenieModel.DataOdbioru;
            if (zlecenieModel.CenaBrutto is not null)
                zlecenie.CenaBrutto = zlecenieModel.CenaBrutto;
            if (zlecenieModel.MetodPlatnosciID is not null)
                zlecenie.MetodPlatnosciID = zlecenieModel.MetodPlatnosciID;
            if (zlecenieModel.StatusID is not null)
            {
                zlecenie.StatusID = zlecenieModel.StatusID;

                if (_dbContext.Klienci.Where(k => k.Id == zlecenie.KlientID).Select(k => k.Email) is not null)
                {
                    var email = new Email(new EmailParams
                    {
                        HostSmtp = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        SenderName = "Serwis Rowerowy",
                        SenderEmail = "serwis.rowerowy.api@gmail.com",
                        SenderEmailPassword = "mijsubmrwbrtgkdc"
                    });

                    string tresc;
                    var status = _dbContext.Statusy.Find(zlecenie.StatusID);
                    if (zlecenie.StatusID == 2)
                    {
                        tresc = $"Twoje zlecenie o numerze: {id} gotowe do odbioru.";
                    }
                    else
                    {
                        tresc = $"Twoje zlecenie o numerze: {id} zmieniło status na: {status.Nazwa}";
                    }
                    var klient = _dbContext.Klienci.Find(zlecenie.KlientID);
                    await email.Send("Zmiana statusu zlecenia w Serwisie Rowerowym", tresc, klient.Email);
                }
            }
                

            _dbContext.SaveChanges();
            
            
        }
    }
}
