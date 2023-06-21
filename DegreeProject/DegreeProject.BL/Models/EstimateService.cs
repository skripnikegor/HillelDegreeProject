using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;

namespace DegreeProject.BL.Models
{
    public class EstimateService : IService<EstimateDTO>
    {
        private readonly IUnitOfWork<EstimateDTO> _unitOfWork;

        public EstimateService()
        {
            var module = new EstimateModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUnitOfWork<EstimateDTO>>();
        }
        public async Task<EstimateDTO> Create(EstimateDTO entity)
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

        public async Task<EstimateDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<EstimateDTO>> GetAll()
        {
            return await _unitOfWork.GetAll();
        }

        public async Task<EstimateDTO> Update(int id, EstimateDTO entity)
        {
            return await _unitOfWork.Update(id, entity);
        }
    }
}
