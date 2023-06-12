using DegreeProject.DB.Interfaces;
using DegreeProject.DB.UnitOfWork;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.NInject
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserUnitofWork>().To<UserUnitOfWork>();
        }
    }
}
