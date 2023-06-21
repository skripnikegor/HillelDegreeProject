using DegreeProject.DB.Interfaces;
using DegreeProject.DB.UnitOfWork.ProjectUnitOfWork;
using DegreeProject.DTO.Projects;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.NInject
{
    public class WorksSettingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork<WorksSettingsDTO>>().To<WorksSettingsUnitOfWork>();
        }
    }
}
