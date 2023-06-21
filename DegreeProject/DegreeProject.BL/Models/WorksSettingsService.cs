using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;

namespace DegreeProject.BL.Models
{
    public class WorksSettingsService : IService<WorksSettingsDTO>
    {
        private readonly IUnitOfWork<WorksSettingsDTO> _unitOfWork;
        public WorksSettingsService()
        {
            var module = new WorksSettingsModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUnitOfWork<WorksSettingsDTO>>();
        }
        public async Task<WorksSettingsDTO> Create(WorksSettingsDTO entity)
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

        public async Task<WorksSettingsDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<WorksSettingsDTO>> GetAll()
        {
            return await _unitOfWork.GetAll();
        }

        public async Task<WorksSettingsDTO> Update(int id, WorksSettingsDTO entity)
        {
            return await _unitOfWork.Update(id, entity);
        }
    }
}
