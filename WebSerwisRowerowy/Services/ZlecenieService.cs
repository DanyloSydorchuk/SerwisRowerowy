using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Exceptions;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy.Services
{
    public interface IZlecenieService
    {
        ZlecenieModel GetById(int id);
        IEnumerable<ZlecenieModel> GetAll();
        int Create(ZlecenieModel zlecenieModel);
        void Delete(int id);
        void Update(int id, ZlecenieModel zlecenieModel);
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

        public int Create(ZlecenieModel zlecenieModel)
        {
            var zlecenie = _mapper.Map<Zlecenie>(zlecenieModel);
            _dbContext.Zlecenia.Add(zlecenie);
            _dbContext.SaveChanges();

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
            var zlecenia = _dbContext
                .Zlecenia
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
                //.Include(z => z.UslugiUzyte)
                //.Include(z => z.MetodPlatnosci)
                .FirstOrDefault(z => z.Id == id);

            if (zlecenie is null)
                throw new NotFoundException($"Brak zlecenia o id: {id}");

            var result = _mapper.Map<ZlecenieModel>(zlecenie);
            return result;
        }

        public void Update(int id, ZlecenieModel zlecenieModel)
        {
            var zlecenie = _dbContext.Zlecenia.FirstOrDefault(z => z.Id == id);

            if (zlecenie is null)
                throw new NotFoundException($"Brak zlecenia o id: {id}");

            zlecenie.PracownikID = zlecenieModel.PracownikID;
            zlecenie.DataOdbioru = zlecenieModel.DataOdbioru;
            zlecenie.CenaBrutto = zlecenieModel.CenaBrutto;
            zlecenie.MetodPlatnosciID = zlecenieModel.MetodPlatnosciID;

            _dbContext.SaveChanges();
        }
    }
}
