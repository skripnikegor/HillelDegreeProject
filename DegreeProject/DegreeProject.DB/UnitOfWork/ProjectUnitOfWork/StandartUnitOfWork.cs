using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DTO.Projects;
using Ninject;
using AutoMapper;
using DegreeProject.Utilit;

namespace DegreeProject.DB.UnitOfWork.Project
{
    public class StandartUnitOfWork : UnitOfWorkBase, IUnitOfWork<StandartDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<Standart> _standartRepository;
        private IMapper _mapper;


        public StandartUnitOfWork()
        {
            var module = new StandartModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _standartRepository = kernel.Get<IRepository<Standart>>();

            _standartRepository.DbContext = _dbContext;
            _mapper = kernel.Get<IMapper>();
        }


        public async Task<StandartDTO> Get(int id)
        {
            return _mapper.Map<StandartDTO>(await _standartRepository.GetById(Criptor.Decrypt(id)));
        }

        public async Task<IEnumerable<StandartDTO>> GetAll()
        {
            var standarts = await _standartRepository.GetAll();
            foreach (var standart in standarts)
            {
                standart.Id = Criptor.Decrypt(standart.Id);
            }
            return _mapper.Map<IEnumerable<StandartDTO>>(standarts);
        }

        public async Task<StandartDTO> Update(int id, StandartDTO item)
        {

            var standart = _mapper.Map<Standart>(item);
            standart.Id = Criptor.Decrypt(id);

            await BeginTransaction(_dbContext);
            var result = await _standartRepository.Update(standart);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<StandartDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            var standart = await _standartRepository.GetById(Criptor.Decrypt(id));
            await BeginTransaction(_dbContext);
            _standartRepository.Delete(standart);
            await Commit();
            var result = await Save(_dbContext);
            return result;

        }

        public async Task<StandartDTO> Add(StandartDTO item)
        {
            await BeginTransaction(_dbContext);
            var standart = _mapper.Map<Standart>(item);
            var result = await _standartRepository.Add(standart);
            await Commit();
            await Save(_dbContext);

            result.Id = Criptor.Encrypt(result.Id);

            return _mapper.Map<StandartDTO>(result);
        }

        public Task<bool> Exist(int id)
        {
            return _standartRepository.Exist(Criptor.Decrypt(id));
        }
    }
}
