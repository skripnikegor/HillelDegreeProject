using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DTO.Projects;
using Ninject;
using DegreeProject.Utilits;


namespace DegreeProject.DB.UnitOfWork.Project
{
    public class StandartUnitOfWork : UnitOfWorkBase, IUnitOfWork<StandartDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<Standart> _standartRepository;

        
        public StandartUnitOfWork()
        {
            var module = new StandartModule();
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

        public async Task<IEnumerable<StandartDTO>> GetAll()
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

        public async Task<StandartDTO> Update(int id, StandartDTO item)
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
            var result = await _standartRepository.Update(standart);
            await Commit();
            await Save(_dbContext);

            return new StandartDTO()
            {
                Name = $"{result.Name}",
                CodeResourse = $"{result.CodeResourse}",
                NameResourse = $"{result.NameResourse}",
                Unit = $"{result.Unit}",
                UnitAmount = result.UnitAmount,
                LaborCostHour = result.LaborCostHour,
                LaborCostMachine = result.LaborCostMachine
            };

        }

        public async Task<bool> Delete(int id)
        {
            var standart = await _standartRepository.GetById(id);
            await BeginTransaction(_dbContext);
            _standartRepository.Delete(standart);
            await Commit();
            var result = await Save(_dbContext);
            return result;

        }

        public async Task<StandartDTO> Add(StandartDTO item)
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
            var result = await _standartRepository.Add(standart);
            await Commit();
            await Save(_dbContext);

            return new StandartDTO
            {
                Key = Encriptor.GenerateRandomKey(result.Id),
                Name = $"{result.Name}",
                CodeResourse = $"{result.CodeResourse}",
                NameResourse = $"{result.NameResourse}",
                Unit = $"{result.Unit}",
                UnitAmount = result.UnitAmount,
                LaborCostHour = result.LaborCostHour,
                LaborCostMachine = result.LaborCostMachine
            };
        }

        public Task<bool> Exist(int id)
        {
            return _standartRepository.Exist(id);
        }
    }
}
