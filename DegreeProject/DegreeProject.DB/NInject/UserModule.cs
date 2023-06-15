using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models;
using DegreeProject.DB.Repositories;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.NInject
{
    //internal class UserModule : NinjectModule
    //{
    //    public override void Load()
    //    {
    //        this.Bind<DbContext>().To<DataContext>();
    //        this.Bind<IRepository<Customer>>().To<CustomerRepository>();
    //        this.Bind<IRepository<UserProfile>>().To<UserProfileRepository>();
    //    }
    //}
}
