using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Exceptions;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy.Services
{
    public interface IPracownikService
    {
        PracownikModel GetById(int id);
        IEnumerable<PracownikModel> GetAll();
        int Create(PracownikModel pracownikModel);
        void Delete(int id);
        void Update(int id, PracownikModel pracownikModel);
    }

    public class PracownikService : IPracownikService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PracownikService> _logger;

        public PracownikService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PracownikService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public int Create(PracownikModel pracownikModel)
        {
            var pracownik = _mapper.Map<Pracownik>(pracownikModel);
            _dbContext.Pracownicy.Add(pracownik);
            _dbContext.SaveChanges();
            return pracownik.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Pracownik o id: {id} został usunięty");
            var pracownik = _dbContext.Pracownicy.FirstOrDefault(p => p.Id == id);

            if (pracownik is null)
                throw new NotFoundException($"Brak pracownika o id: {id}");

            _dbContext.Pracownicy.Remove(pracownik);
            _dbContext.SaveChanges();
        }

        public IEnumerable<PracownikModel> GetAll()
        {
            var pracownicy = _dbContext.Pracownicy.ToList();
            var lista = _mapper.Map<List<PracownikModel>>(pracownicy);

            return lista;
        }

        public PracownikModel GetById(int id)
        {
            var pracownik = _dbContext
                    .Pracownicy
                    .FirstOrDefault(p => p.Id == id);

            if (pracownik is null)
                throw new NotFoundException($"Brak pracownika o id: {id}");

            var result = _mapper.Map<PracownikModel>(pracownik);
            return result;
        }

        public void Update(int id, PracownikModel pracownikModel)
        {
            var pracownik = _dbContext.Pracownicy.FirstOrDefault(p => p.Id == id);

            if (pracownik is null)
                throw new NotFoundException($"Brak pracownika o id: {id}");

            if (pracownikModel.NrTelefonu is not null)
                pracownik.NrTelefonu = pracownikModel.NrTelefonu;
            if (pracownikModel.Email is not null)
                pracownik.Email = pracownikModel.Email;
            if (pracownikModel.DataZakonczenia is not null)
                pracownik.DataZakonczenia = pracownikModel.DataZakonczenia;

            _dbContext.SaveChanges();
        }
    }
  
}
