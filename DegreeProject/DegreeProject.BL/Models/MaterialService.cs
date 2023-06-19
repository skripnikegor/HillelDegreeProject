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
        public async Task Create(MaterialDTO entity)
        {
            await _unitOfWork.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Delete(id);
        }

        public async Task<MaterialDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<MaterialDTO>> GetAll()
        {
            return await _unitOfWork.Get();
        }

        public async Task Update(int id, MaterialDTO entity)
        {
            await _unitOfWork.Update(id, entity);
        }
    }
}
