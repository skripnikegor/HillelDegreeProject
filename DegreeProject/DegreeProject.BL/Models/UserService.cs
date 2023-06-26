using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.UnitOfWork;
using DegreeProject.DTO.Projects;
using DegreeProject.DTO.Users;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<RegisterUserDTO> Create(RegisterUserDTO entity)
        {
            await _unitOfWork.Add(entity);
            return entity;
        }

        public Task<UserDTO> Create(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.Delete(id);
            return true;
        }

        public async Task<bool> Exist(int id)
        {
            await _unitOfWork.Exist(id);

            return true;
        }

        public async Task<UserDTO> Get(int id)
        {
            await _unitOfWork.Get(id);
            return new UserDTO();
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<UserDTO>> GetAll()
        //{
        //    await _unitOfWork.GetAll();
        //    return
        //}

        public async Task<UserDTO> Update(int id, UserDTO entity)
        {
            await _unitOfWork.Update(id, entity);
            return entity;
        }
    }
}
