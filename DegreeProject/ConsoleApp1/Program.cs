using Microsoft.EntityFrameworkCore.Migrations;
using Ninject;
using DegreeProject.DB;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using DegreeProject.DB.UnitOfWork.ProjectUnitOfWork;

var kernel = new StandardKernel();
kernel.Bind<IUnitOfWork<ProjectDTO>>().To<ProjectUnitOfWork>();
var a = kernel.Get<IUnitOfWork<ProjectDTO>>();
int k = 0;