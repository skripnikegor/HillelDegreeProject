using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;


namespace DegreeProject.BL.Models
{
    public class ProjectService : IService<ProjectDTO>
    {
        private readonly IUnitOfWork<ProjectDTO> _unitOfWork;
        public ProjectService()
        {
            var module = new NInject.ProjectModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUnitOfWork<ProjectDTO>>();
        }
        public async Task<ProjectDTO> Create(ProjectDTO entity)
        {
            return await _unitOfWork.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.Delete(id);
        }

        public async Task<bool> Exist(int id)
        {
            return await _unitOfWork.Exist(id);
        }

        public async Task<ProjectDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAll()
        {
            return await _unitOfWork.GetAll();
        }

        public async Task<ProjectDTO> Update(int id, ProjectDTO entity)
        {
            return await _unitOfWork.Update(id, entity);
        }
    }
}
