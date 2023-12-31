﻿using DegreeProject.DB.Interfaces;
using DegreeProject.DB.UnitOfWork.Project;
using DegreeProject.DTO.Projects;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.NInject
{
    internal class StandartModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork<StandartDTO>>().To<StandartUnitOfWork>();
        }
    }
}
