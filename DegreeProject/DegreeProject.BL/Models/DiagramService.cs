using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;

namespace DegreeProject.BL.Models
{
    public class DiagramService : IService<DiagramDTO>
    {
        private readonly IUnitOfWork<DiagramDTO> _unitOfWork;

        public DiagramService()
        {
            var module = new DiagramModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUnitOfWork<DiagramDTO>>();
        }
        public async Task<DiagramDTO> Create(DiagramDTO entity)
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

        public async Task<DiagramDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<DiagramDTO>> GetAll()
        {
            return await _unitOfWork.GetAll();
        }

        public async Task<DiagramDTO> Update(int id, DiagramDTO entity)
        {
            return await _unitOfWork.Update(id, entity);
        }
    }
}
