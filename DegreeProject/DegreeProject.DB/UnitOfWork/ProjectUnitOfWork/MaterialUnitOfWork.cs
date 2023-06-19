﻿using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.NInject;
using DegreeProject.DB.Repositories.Projects;
using DegreeProject.DTO.Projects;
using Ninject;


namespace DegreeProject.DB.UnitOfWork.ProjectUnitOfWork
{
    public class MaterialUnitOfWork : UnitOfWorkBase, IUnitOfWork<MaterialDTO>
    {
        private readonly DataContext _dbContext;
        private IRepository<Material> _materialRepository;

        public MaterialUnitOfWork()
        {
            
            var module = new MaterialModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _materialRepository = kernel.Get<IRepository<Material>>();

            _materialRepository.DbContext = _dbContext;
        }

       

        public async Task Add(MaterialDTO item)
        {
            await BeginTransaction(_dbContext);
            var material = new Material()
            {
                Name = item.Name,
                Price = item.Price,
                Amount = item.Amount,
                ElementCode = item.ElementCode,
                WorkCode = item.WorkCode,
                StandartCode = item.StandartCode,
                Unit = item.Unit
            };
            await _materialRepository.Add(material);
            await Commit();
            await Save(_dbContext);
        }

        public async Task Delete(int id)
        {
            var standart = await _materialRepository.GetById(id);
            await BeginTransaction(_dbContext);
            _materialRepository.Delete(standart);
            await Commit();
            await Save(_dbContext);
        }

        public async Task<MaterialDTO> Get(int id)
        {
            var material = await _materialRepository.GetById(id);

            return new MaterialDTO
            {
                //Key = id.GetHashCode(),
                Name = material.Name,
                Price = material.Price,
                Amount = material.Amount,
                ElementCode = material.ElementCode, 
                WorkCode = material.WorkCode,   
                StandartCode = material.StandartCode,
                Unit = material.Unit
            };
        }

        public async Task<IEnumerable<MaterialDTO>> Get()
        {
            var materials = await _materialRepository.GetAll();
            return materials.Select(material => new MaterialDTO
            {
                Name = material.Name,
                Price = material.Price, 
                Amount = material.Amount,
                ElementCode = material.ElementCode,
                WorkCode = material.WorkCode,
                StandartCode = material.StandartCode, 
                Unit = material.Unit
            }).ToList();
        }

        public async Task<IEnumerable<MaterialDTO>> GetAll()
        {
            var materials = await _materialRepository.GetAll();
            return materials.Select(material => new MaterialDTO
            {
                Name = material.Name,
                Price = material.Price,
                Amount = material.Amount,
                ElementCode = material.ElementCode,
                WorkCode = material.WorkCode,
                StandartCode = material.StandartCode,
                Unit = material.Unit
            }).ToList();
        }

        public async Task Update(int id, MaterialDTO item)
        {

            var material = new Material()
            {
                Id = id,
                Name = item.Name,
                Price = item.Price,
                Amount = item.Amount,
                ElementCode = item.ElementCode,
                WorkCode = item.WorkCode,
                StandartCode = item.StandartCode,
                Unit = item.Unit
            };

            await BeginTransaction(_dbContext);
            _materialRepository.Update(material);
            await Commit();
            await Save(_dbContext);

        }

    }
}
