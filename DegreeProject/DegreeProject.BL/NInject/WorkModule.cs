using DegreeProject.DB.Interfaces;
using DegreeProject.DB.UnitOfWork.ProjectUnitOfWork;
using DegreeProject.DTO.Projects;
using Ninject.Modules;

namespace DegreeProject.BL.NInject
{
    public class WorkModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork<WorkDTO>>().To<WorkUnitOfWork>();
        }
    }
}
