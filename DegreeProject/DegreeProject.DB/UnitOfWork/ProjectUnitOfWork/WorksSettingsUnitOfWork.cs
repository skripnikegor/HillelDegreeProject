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
    public class WorksSettingsUnitOfWork : UnitOfWorkBase, IUnitOfWork<WorksSettingsDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<WorksSettings> _worksSettingsRepository;
        private IMapper _mapper;

        public WorksSettingsUnitOfWork()
        {
            var module = new WorksSettingsModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _worksSettingsRepository = kernel.Get<IRepository<WorksSettings>>();
            _worksSettingsRepository.DbContext = _dbContext;
            _mapper = kernel.Get<IMapper>();
        }

        public async Task<WorksSettingsDTO> Add(WorksSettingsDTO item)
        {
            var worksSettings = _mapper.Map<WorksSettings>(item);
            await BeginTransaction(_dbContext);
            var result = await _worksSettingsRepository.Add(worksSettings);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<WorksSettingsDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            await BeginTransaction(_dbContext);
            var worksSettings = await _worksSettingsRepository.GetById(id);
            _worksSettingsRepository.Delete(worksSettings);
            await Commit();
            var result = await Save(_dbContext);
            return result;
        }

        public async Task<bool> Exist(int id)
        {
            return await _worksSettingsRepository.Exist(id);
        }

        public async Task<WorksSettingsDTO> Get(int id)
        {
            return _mapper.Map<WorksSettingsDTO>(await _worksSettingsRepository.GetById(id));
        }

        public async Task<IEnumerable<WorksSettingsDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<WorksSettingsDTO>>(await _worksSettingsRepository.GetAll());
        }

        public async Task<WorksSettingsDTO> Update(int id, WorksSettingsDTO item)
        {
            var worksSettings = _mapper.Map<WorksSettings>(item);
            worksSettings.Id = id;
            await BeginTransaction(_dbContext);
            var result = await _worksSettingsRepository.Update(worksSettings);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<WorksSettingsDTO>(result);
        }
    }
}
