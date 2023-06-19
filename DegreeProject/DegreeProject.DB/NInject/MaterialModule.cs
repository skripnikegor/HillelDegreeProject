using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.Repositories.Projects;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.NInject
{
    internal class MaterialModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<DataContext>();
            this.Bind<IRepository<Material>>().To<MaterialRepository>();
        }
    }
}
