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
    internal class WorksSettingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<DataContext>();
            this.Bind<IRepository<WorksSettings>>().To<WorkSettingsRepository>();
            this.Bind<IMapper>().ToMethod(ctx =>
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<WorksSettingsDTO, WorksSettings>();
                    cfg.CreateMap<WorksSettings, WorksSettingsDTO>();
                });
                return configuration.CreateMapper();
            }).InSingletonScope();
        }
    }
}
