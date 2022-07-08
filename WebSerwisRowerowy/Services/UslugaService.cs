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
    public interface IUslugaService
    {
        UslugaModel GetById(int id);
        IEnumerable<UslugaModel> GetAll();
        int Create(UslugaModel uslugaModel);
        void Delete(int id);
        void Update(int id, UslugaModel uslugaModel);
    }

    public class UslugaService : IUslugaService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UslugaService> _logger;

        public UslugaService(ApplicationDbContext dbContext, ILogger<UslugaService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public int Create(UslugaModel uslugaModel)
        {
            var usluga = _mapper.Map<Usluga>(uslugaModel);
            _dbContext.Uslugi.Add(usluga);
            _dbContext.SaveChanges();
            return usluga.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Usługa o id: {id} zostanie usunięta");

            var usluga = _dbContext.Uslugi.FirstOrDefault(u => u.Id == id);

            if (usluga is null)
                throw new NotFoundException($"Brak usługi o id: {id}");

            _dbContext.Uslugi.Remove(usluga);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UslugaModel> GetAll()
        {
            var uslugi = _dbContext.Uslugi.ToList();
            var lista = _mapper.Map<List<UslugaModel>>(uslugi);
            return lista;
        }

        public UslugaModel GetById(int id)
        {
            var usluga = _dbContext.Uslugi.FirstOrDefault(u => u.Id == id);

            if (usluga is null)
                throw new NotFoundException($"Brak usługi o id: {id}");

            var result = _mapper.Map<UslugaModel>(usluga);
            return result;
        }

        public void Update(int id, UslugaModel uslugaModel)
        {
            var usluga = _dbContext.Uslugi.FirstOrDefault(u => u.Id == id);

            if (usluga is null)
                throw new NotFoundException($"Brak usługi o id: {id}");

            if (uslugaModel.Nazwa is not null)
                usluga.Nazwa = uslugaModel.Nazwa;
            if (uslugaModel.CenaNetto is not null)
                usluga.CenaNetto = uslugaModel.CenaNetto;
            if (uslugaModel.PodatekVAT is not null)
                usluga.PodatekVAT = uslugaModel.PodatekVAT;

            _dbContext.SaveChanges();


        }
    }
}
