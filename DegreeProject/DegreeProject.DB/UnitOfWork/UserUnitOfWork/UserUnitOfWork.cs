using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Interfaces.UnitOfWork;
using DegreeProject.DB.Models.Users;
using DegreeProject.DB.NInject;
using DegreeProject.DTO.Users;
using Ninject;

namespace DegreeProject.DB.UnitOfWork.UserUnitOfWork
{
    public class UserUnitOfWork : UnitOfWorkBase, IUserUnitOfWork<UserDTO>
    {
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<UserBase> _userRepository;
        private readonly DataContext _dbContext;

        public UserUnitOfWork()
        {
            var module = new UserModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _userProfileRepository = kernel.Get<IRepository<UserProfile>>();
            _userRepository = kernel.Get<IRepository<UserBase>>();

            _userProfileRepository.DbContext = _dbContext;
            _userRepository.DbContext = _dbContext;
        }

        public async Task<RegisterUserDTO> Add(RegisterUserDTO registerDTO)
        {
            return registerDTO;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Get(int id)
        {
            var user = await _userRepository.GetById(id);
            return new UserDTO
            {
                Name = $"{user.Name}",
                UserProfileId = user.UserProfileId,
                UserProfile = new UserProfileDTO
                {
                    Email = user.UserProfile.Email,
                    PhoneNumber = user.UserProfile.PhoneNumber,
                    ProfileImage = user.UserProfile.ProfileImage
                }
            };
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            var users = await _userRepository.GetAll();
            return users.Select(user => new UserDTO { Name = $"{user.Name}", UserProfileId = user.UserProfileId }).ToList();
        }

        public Task Update(int id, UserDTO item)
        {
            throw new NotImplementedException();
        }

        Task IUserUnitOfWork<UserDTO>.Add(RegisterUserDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
