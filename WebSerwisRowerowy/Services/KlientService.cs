using AutoMapper;
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
    public interface IKlientService
    {
        KlientModel GetById(int id);
        IEnumerable<KlientModel> GetAll();
        int Create(KlientModel klientModel);
        void Delete(int id);
        void Update(int id, KlientModel klientModel);
    }

    public class KlientService : IKlientService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<KlientService> _logger;

        public KlientService(ApplicationDbContext dbContext, IMapper mapper, ILogger<KlientService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public int Create(KlientModel klientModel)
        {
            var klient = _mapper.Map<Klient>(klientModel);
            _dbContext.Klienci.Add(klient);
            _dbContext.SaveChanges();
            return klient.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Klient o id: {id} zostanie usunięty");

            var klient = _dbContext.Klienci.FirstOrDefault(k => k.Id == id);

            if (klient is null)
                throw new NotFoundException($"Brak klienta o id: {id}");

            _dbContext.Klienci.Remove(klient);
            _dbContext.SaveChanges();
        }

        public IEnumerable<KlientModel> GetAll()
        {
            var klienci = _dbContext.Klienci.ToList();
            var lista = _mapper.Map<List<KlientModel>>(klienci);
            return lista;
        }

        public KlientModel GetById(int id)
        {
            var klient = _dbContext.Klienci.FirstOrDefault(k => k.Id == id);

            if (klient is null)
                throw new NotFoundException($"Brak klienta o id: {id}");

            var result = _mapper.Map<KlientModel>(klient);
            return result;
        }

        public void Update(int id, KlientModel klientModel)
        {
            var klient = _dbContext.Klienci.FirstOrDefault(k => k.Id == id);

            if (klient is null)
                throw new NotFoundException($"Brak klienta o id: {id}");

            if (klientModel.Imie is not null)
                klient.Imie = klientModel.Imie;
            if (klientModel.Nazwisko is not null)
                klient.Nazwisko = klientModel.Nazwisko;
            if (klientModel.NrTelefonu is not null)
                klient.NrTelefonu = klientModel.NrTelefonu;
            if (klientModel.Email is not null)
                klient.Email = klientModel.Email;
            if (klientModel.NIP is not null)
                klient.NIP = klientModel.NIP;
            if (klientModel.Firma is not null)
                klient.Firma = klientModel.Firma;
            if (klientModel.Miasto is not null)
                klient.Miasto = klientModel.Miasto;
            if (klientModel.Adres is not null)
                klient.Adres = klientModel.Adres;
            if (klientModel.KodPocztowy is not null)
                klient.KodPocztowy = klientModel.KodPocztowy;



            _dbContext.SaveChanges();
        }
    }
}
