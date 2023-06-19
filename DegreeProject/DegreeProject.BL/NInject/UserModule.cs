
using DegreeProject.DB.Interfaces.UnitOfWork;
using DegreeProject.DB.UnitOfWork.UserUnitOfWork;
using DegreeProject.DTO.Users;
using Ninject.Modules;


namespace DegreeProject.BL.NInject
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserUnitOfWork<UserDTO>>().To<UserUnitOfWork>();
        }
    }
}
