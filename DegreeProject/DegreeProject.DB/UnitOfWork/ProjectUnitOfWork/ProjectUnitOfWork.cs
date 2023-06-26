using AutoMapper;
using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DB.Repositories.Projects;
using DegreeProject.DTO.Projects;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.UnitOfWork.ProjectUnitOfWork
{
    public class ProjectUnitOfWork : UnitOfWorkBase, IUnitOfWork<ProjectDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<ProjectBase> _projectRepository;
        private IMapper _mapper;

        public ProjectUnitOfWork()
        {
            var module = new ProjectModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _projectRepository = kernel.Get<IRepository<ProjectBase>>();

            _projectRepository.DbContext = _dbContext;

            _mapper = kernel.Get<IMapper>();
        }
        public async Task<ProjectDTO> Add(ProjectDTO item)
        {
            var project = _mapper.Map<ProjectBase>(item);
            await BeginTransaction(_dbContext);
            var result = await _projectRepository.Add(project);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<ProjectDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            await BeginTransaction(_dbContext);
            var project = await _projectRepository.GetById(id);
            _projectRepository.Delete(project);
            await Commit();
            var result = await Save(_dbContext);
            return result;
        }

        public Task<bool> Exist(int id)
        {
            return _projectRepository.Exist(id);
        }

        public async Task<ProjectDTO> Get(int id)
        {
            return _mapper.Map<ProjectDTO>(await _projectRepository.GetById(id));
        }

        public async Task<IEnumerable<ProjectDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectDTO>>(await _projectRepository.GetAll());
        }

        public async Task<ProjectDTO> Update(int id, ProjectDTO item)
        {
            var project = _mapper.Map<ProjectBase>(item);
            project.Id = id;
            await BeginTransaction(_dbContext);
            var result = await _projectRepository.Update(project);
            await Commit();
            await Save(_dbContext);

            return _mapper.Map<ProjectDTO>(result);
        }
    }
}
