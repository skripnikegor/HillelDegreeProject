﻿using DegreeProject.DB.Interfaces;
using DegreeProject.DB.UnitOfWork.ProjectUnitOfWork;
using DegreeProject.DTO.Projects;
using Ninject.Modules;

namespace DegreeProject.BL.NInject
{
    public class DiagramModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork<DiagramDTO>>().To<DiagramUnitOfWork>();
        }
    }
}
