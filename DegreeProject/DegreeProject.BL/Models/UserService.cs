using DegreeProject.BL.Interfaces;
using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.UnitOfWork;
using DegreeProject.DB.Models;
using DegreeProject.DB.UnitOfWork;
using DegreeProject.DTO.Users;
using Ninject;


namespace DegreeProject.BL.Models
{
    public class UserService : IService<UserDTO>
    {
        private readonly IUserUnitOfWork<UserDTO> _unitOfWork;

        public UserService()
        {
            var module = new UserModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUserUnitOfWork<UserDTO>>();
        }

        public UserService(IUserUnitOfWork<UserDTO> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(UserDTO entity)
        {


        }

        public async Task Delete(int id)
        {

        }

        public async Task<UserDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return await _unitOfWork.Get();
        }

        public async Task Update(int id, UserDTO entity)
        {

        }
    }
}
