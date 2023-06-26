using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Users;


namespace DegreeProject.DB.NInject
{
    internal class UserModule : NinjectModule   
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<DataContext>();
            this.Bind<IRepository<UserBase>>().To<UserRepository>();
            this.Bind<IRepository<UserProfile>>().To<UserProfileRepository>();
        }
    }
}
