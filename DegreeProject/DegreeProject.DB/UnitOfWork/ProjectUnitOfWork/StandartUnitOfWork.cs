using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DTO.Projects;
using Microsoft.EntityFrameworkCore.Storage;
using Ninject;


namespace DegreeProject.DB.UnitOfWork.Project
{
    public class StandartUnitOfWork : UnitOfWorkBase, IUnitOfWork<StandartDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<Standart> _standartRepository;

        
        public StandartUnitOfWork()
        {
            var module = new ProjectModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _standartRepository = kernel.Get<IRepository<Standart>>();

            _standartRepository.DbContext = _dbContext;
        }

 

        public async Task<StandartDTO> Get(int id)
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

        public async Task<IEnumerable<StandartDTO>> Get()
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

        public async Task Update(int id, StandartDTO item)
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

            await BeginTransaction(_dbContext);
            _standartRepository.Update(standart);
            await Commit();
            await Save(_dbContext);

        }

        public async Task Delete(int id)
        {
            var standart = await _standartRepository.GetById(id);
            await BeginTransaction(_dbContext);
            _standartRepository.Delete(standart);
            await Commit();
            await Save(_dbContext);

        }

        public async Task Add(StandartDTO item)
        {
            await BeginTransaction(_dbContext);
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
            await Save(_dbContext);

        }
       
    }
}
