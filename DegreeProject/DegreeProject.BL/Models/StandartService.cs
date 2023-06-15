using DegreeProject.BL.Interfaces;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;


namespace DegreeProject.BL.Models
{
    public class StandartService : IStandartService
    {
        private readonly IProjectUnitOfWork _unitOfWork;

        public StandartService()
        {
            var module = new StandartModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IProjectUnitOfWork>();
        }
        public async Task Create(StandartDTO entity)
        {
            await _unitOfWork.AddStandart(entity);
        }

        public async Task Delete(int Id)
        {
            await _unitOfWork.DeleteStandart(Id);
        }

        public async Task<StandartDTO> Get(int id)
        {
            return await _unitOfWork.GetStandart(id);
        }

        public async Task<IEnumerable<StandartDTO>> GetAll()
        {
            return await _unitOfWork.GetStandarts();
        }

        public async Task Update(int id, StandartDTO entity)
        {
            await _unitOfWork.UpdateStandart(id, entity);
        }
    }
}
