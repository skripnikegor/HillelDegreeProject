using AutoMapper;
using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DTO.Projects;
using Ninject;

namespace DegreeProject.DB.UnitOfWork.ProjectUnitOfWork
{
    public class WorkUnitOfWork : UnitOfWorkBase, IUnitOfWork<WorkDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<Work> _workRepository;
        private IMapper _mapper;

        public WorkUnitOfWork()
        {
            var module = new WorkModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _workRepository = kernel.Get<IRepository<Work>>();

            _workRepository.DbContext = _dbContext;

            _mapper = kernel.Get<IMapper>();
        }
        public async Task<WorkDTO> Add(WorkDTO item)
        {
            var work = _mapper.Map<Work>(item);
            await BeginTransaction(_dbContext);
            var result = await _workRepository.Add(work);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<WorkDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            await BeginTransaction(_dbContext);
            var standart = await _workRepository.GetById(id);
            _workRepository.Delete(standart);
            await Commit();
            var result = await Save(_dbContext);
            return result;
        }

        public Task<bool> Exist(int id)
        {
            return _workRepository.Exist(id);
        }

        public async Task<WorkDTO> Get(int id)
        {
            return _mapper.Map<WorkDTO>(await _workRepository.GetById(id));
        }

        public async Task<IEnumerable<WorkDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<WorkDTO>>(await _workRepository.GetAll());
        }

        public async Task<WorkDTO> Update(int id, WorkDTO item)
        {
            var work = _mapper.Map<Work>(item);
            work.Id = id;
            await BeginTransaction(_dbContext);
            var result = await _workRepository.Update(work);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<WorkDTO>(result);
        }
    }
}
