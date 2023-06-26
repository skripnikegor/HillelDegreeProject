using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.UnitOfWork;
using DegreeProject.DB.UnitOfWork.ProjectUnitOfWork;
using DegreeProject.DB.UnitOfWork.UserUnitOfWork;
using DegreeProject.DTO.Projects;
using DegreeProject.DTO.Users;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.NInject
{
    internal class UserModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserUnitOfWork<UserDTO>>().To<UserUnitOfWork>();
        
        }
    }
}
