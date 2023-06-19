using DegreeProject.DB.Interfaces;
using DegreeProject.DB.UnitOfWork.Project;
using DegreeProject.DB.UnitOfWork.ProjectUnitOfWork;
using DegreeProject.DTO.Projects;
using Ninject;
using Ninject.Modules;


namespace DegreeProject.BL.NInject
{
    internal class MaterialModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork<MaterialDTO>>().To<MaterialUnitOfWork>();

        }
    }
}
