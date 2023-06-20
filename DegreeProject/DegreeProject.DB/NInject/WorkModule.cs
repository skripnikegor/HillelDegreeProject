using AutoMapper;
using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.Repositories.Projects;
using DegreeProject.DTO.Projects;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.NInject
{
    public class WorkModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<DataContext>();
            this.Bind<IRepository<Work>>().To<WorkRepository>();
            this.Bind<IMapper>().ToMethod(ctx =>
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<WorkDTO, Work>();
                    cfg.CreateMap<Work, WorkDTO>();
                });
                return configuration.CreateMapper();
            }).InSingletonScope();
        }
    }
}
