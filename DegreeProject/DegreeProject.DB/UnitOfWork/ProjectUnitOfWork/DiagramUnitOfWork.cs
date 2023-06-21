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
    public class DiagramUnitOfWork : UnitOfWorkBase, IUnitOfWork<DiagramDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<Diagram> _diagramRepository;
        private IMapper _mapper;

        public DiagramUnitOfWork()
        {
            var module = new DiagramModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _diagramRepository = kernel.Get<IRepository<Diagram>>();

            _diagramRepository.DbContext = _dbContext;

            _mapper = kernel.Get<IMapper>();
        }
        public async Task<DiagramDTO> Add(DiagramDTO item)
        {
            var diagram = _mapper.Map<Diagram>(item);
            await BeginTransaction(_dbContext);
            var result = await _diagramRepository.Add(diagram);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<DiagramDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            await BeginTransaction(_dbContext);
            var diagram = await _diagramRepository.GetById(id);
            _diagramRepository.Delete(diagram);
            await Commit();
            var result = await Save(_dbContext);
            return result;
        }

        public Task<bool> Exist(int id)
        {
            return _diagramRepository.Exist(id);
        }

        public async Task<DiagramDTO> Get(int id)
        {
            return _mapper.Map<DiagramDTO>(await _diagramRepository.GetById(id));
        }

        public async Task<IEnumerable<DiagramDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<DiagramDTO>>(await _diagramRepository.GetAll());
        }

        public async Task<DiagramDTO> Update(int id, DiagramDTO item)
        {
            var diagram = _mapper.Map<Diagram>(item);
            diagram.Id = id;
            await BeginTransaction(_dbContext);
            var result = await _diagramRepository.Update(diagram);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<DiagramDTO>(result);
        }
    }
}
