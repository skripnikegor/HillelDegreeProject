using AutoMapper;
using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DB.Repositories.Projects;
using DegreeProject.DTO.Projects;
using Ninject;

namespace DegreeProject.DB.UnitOfWork.ProjectUnitOfWork
{
    public class EstimateUnitOfWork : UnitOfWorkBase, IUnitOfWork<EstimateDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<Estimate> _estimateRepository;
        private IMapper _mapper;

        public EstimateUnitOfWork()
        {
            var module = new EstimateModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _estimateRepository = kernel.Get<IRepository<Estimate>>();

            _estimateRepository.DbContext = _dbContext;

            _mapper = kernel.Get<IMapper>();
        }
        public async Task<EstimateDTO> Add(EstimateDTO item)
        {
            var estimate = _mapper.Map<Estimate>(item);
            await BeginTransaction(_dbContext);
            var result = await _estimateRepository.Add(estimate);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<EstimateDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            await BeginTransaction(_dbContext);
            var estimate = await _estimateRepository.GetById(id);
            _estimateRepository.Delete(estimate);
            await Commit();
            var result = await Save(_dbContext);
            return result;
        }

        public Task<bool> Exist(int id)
        {
            return _estimateRepository.Exist(id);
        }

        public async Task<EstimateDTO> Get(int id)
        {
            return _mapper.Map<EstimateDTO>(await _estimateRepository.GetById(id));
        }

        public async Task<IEnumerable<EstimateDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<EstimateDTO>>(await _estimateRepository.GetAll());
        }

        public async Task<EstimateDTO> Update(int id, EstimateDTO item)
        {
            var diagram = _mapper.Map<Estimate>(item);
            diagram.Id = id;
            await BeginTransaction(_dbContext);
            var result = await _estimateRepository.Update(diagram);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<EstimateDTO>(result);
        }
    }
}
