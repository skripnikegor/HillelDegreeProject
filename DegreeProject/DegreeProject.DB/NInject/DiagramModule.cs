using AutoMapper;
using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.Repositories.Projects;
using DegreeProject.DTO.Projects;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;


namespace DegreeProject.DB.NInject
{
    public class DiagramModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<DataContext>();
            this.Bind<IRepository<Diagram>>().To<DiagramRepository>();
            this.Bind<IMapper>().ToMethod(ctx =>
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DiagramDTO, Diagram>();
                    cfg.CreateMap<Diagram, DiagramDTO>();
                    cfg.CreateMap<WorkDTO, Work>();
                    cfg.CreateMap<Work, WorkDTO>();
                });
                return configuration.CreateMapper();
            }).InSingletonScope();
        }
    }
}
