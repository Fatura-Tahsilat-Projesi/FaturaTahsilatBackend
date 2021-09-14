using Microsoft.Extensions.Logging;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        //private readonly ILogService _logger;
        //private LogService _logService;
        private readonly ILogger<TEntity> _logger;

        public LogService logService { get; set; }
        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository, ILogger<TEntity> logger)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _logger = logger;
            /* Test Amaçlı Serilog Kütüphanesi Kullanılmıştır. */
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.File("logs/faturatahsilat", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Ekleme İşlemi Yapıldı. Ekleme Yapılan Model => " + entity);
           
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);

            await _unitOfWork.CommitAsync();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            _logger.LogInformation("Tüm Verileri Listeleme İşlemi Yapıldı.");
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            _logger.LogInformation("Id Değerine Göre Listeleme İşlemi Yapıldı. Listeleme Yapılan Id Değeri => " + id);
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
            _logger.LogInformation("Silme İşlemi Yapıldı. Silme Yapılan Model => " + entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            //SingleOrDefaultAsync(x => x.name == "kalem")
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = _repository.Update(entity);
            _unitOfWork.Commit();
            _logger.LogInformation("Güncelleme İşlemi Yapıldı. Güncelleme Yapılan Model => " + entity);
            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            _logger.LogInformation("Sorgulama İşlemi Yapıldı. Sorgulama Yapılan Model => " + predicate);
            return await _repository.Where(predicate);
        }
    }
}
