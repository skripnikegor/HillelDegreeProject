using DegreeProject.BL.Interfaces;
using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;


namespace DegreeProject.BL.Models
{
    public class MaterialService : IService<MaterialDTO>
    {
        private readonly IUnitOfWork<MaterialDTO> _unitOfWork;

        public MaterialService()
        {
            var module = new MaterialModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUnitOfWork<MaterialDTO>>();
        }
        public async Task<MaterialDTO> Create(MaterialDTO entity)
        {
            return await _unitOfWork.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.Delete(id);
        }

        public Task<bool> Exist(int id)
        {
            return _unitOfWork.Exist(id);
        }

        public async Task<MaterialDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<MaterialDTO>> GetAll()
        {
            return await _unitOfWork.GetAll();
        }

        public async Task<MaterialDTO> Update(int id, MaterialDTO entity)
        {
            return await _unitOfWork.Update(id, entity);
        }
    }
}
