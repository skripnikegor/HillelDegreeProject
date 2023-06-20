using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;

namespace DegreeProject.BL.Models
{
    public class WorkService : IService<WorkDTO>
    {
        private readonly IUnitOfWork<WorkDTO> _unitOfWork;

        public WorkService()
        {
            var module = new WorkModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUnitOfWork<WorkDTO>>();
        }
        public async Task<WorkDTO> Create(WorkDTO entity)
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

        public async Task<WorkDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<WorkDTO>> GetAll()
        {
            return await _unitOfWork.GetAll();
        }

        public async Task<WorkDTO> Update(int id, WorkDTO entity)
        {
            return await _unitOfWork.Update(id, entity);
        }
    }
}
