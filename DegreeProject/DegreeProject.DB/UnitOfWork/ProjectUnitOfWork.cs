using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DTO.Projects;
using Microsoft.EntityFrameworkCore.Storage;
using Ninject;


namespace DegreeProject.DB.UnitOfWork
{
    public class ProjectUnitOfWork : IProjectUnitOfWork
    {
        private readonly DataContext _dbContext;
        private IDbContextTransaction _transaction;
        private IRepository<Standart> _standartRepository;
        private bool _disposed;

        public ProjectUnitOfWork()
        {
            var module = new ProjectModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _standartRepository = kernel.Get<IRepository<Standart>>();

            _standartRepository.DbContext = _dbContext;
        }

        public async Task BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            _transaction.Commit();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<StandartDTO> GetStandart(int id)
        {
            var standart = await _standartRepository.GetById(id);

            return new StandartDTO
            {
                Name = $"{standart.Name}",
                CodeResourse = $"{standart.CodeResourse}",
                NameResourse = $"{standart.NameResourse}",
                Unit = $"{standart.Unit}",
                UnitAmount = standart.UnitAmount,
                LaborCostHour = standart.LaborCostHour,
                LaborCostMachine = standart.LaborCostMachine
            };
        }

        public async Task<IEnumerable<StandartDTO>> GetStandarts()
        {
            var standarts = await _standartRepository.GetAll();
            return standarts.Select(standart => new StandartDTO
            {
                Name = $"{standart.Name}",
                CodeResourse = $"{standart.CodeResourse}",
                NameResourse = $"{standart.NameResourse}",
                Unit = $"{standart.Unit}",
                UnitAmount = standart.UnitAmount,
                LaborCostHour = standart.LaborCostHour,
                LaborCostMachine = standart.LaborCostMachine
            }).ToList();
        }

        public async Task UpdateStandart(int id, StandartDTO item)
        {
            
            var standart = new Standart()
            {
                Id = id,
                Name = $"{item.Name}",
                CodeResourse = $"{item.CodeResourse}",
                NameResourse = $"{item.NameResourse}",
                Unit = $"{item.Unit}",
                UnitAmount = item.UnitAmount,
                LaborCostHour = item.LaborCostHour,
                LaborCostMachine = item.LaborCostMachine
            };

            await BeginTransaction();
            _standartRepository.Update(standart);
            await Commit();
            await Save();
            
        }

        public async Task DeleteStandart(int Id)
        {
            await BeginTransaction();
            _standartRepository.Delete(Id);
            await Commit();
            await Save();
            
        }

        public async Task AddStandart(StandartDTO item)
        {
            await BeginTransaction();
            var standart = new Standart()
            {
                Name = $"{item.Name}",
                CodeResourse = $"{item.CodeResourse}",
                NameResourse = $"{item.NameResourse}",
                Unit = $"{item.Unit}",
                UnitAmount = item.UnitAmount,
                LaborCostHour = item.LaborCostHour,
                LaborCostMachine = item.LaborCostMachine
            };
            await _standartRepository.Add(standart);
            await Commit();
            await Save();
            
        }
    }
}
