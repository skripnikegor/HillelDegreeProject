﻿using DegreeProject.BL.Interfaces;
using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DTO.Projects;
using Ninject;


namespace DegreeProject.BL.Models
{
    public class StandartService : IService<StandartDTO>
    {
        private readonly IUnitOfWork<StandartDTO> _unitOfWork;

        public StandartService()
        {
            var module = new StandartModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<IUnitOfWork<StandartDTO>>();
        }
        public async Task Create(StandartDTO entity)
        {
            await _unitOfWork.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Delete(id);
        }

        public async Task<StandartDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<StandartDTO>> GetAll()
        {
            return await _unitOfWork.Get();
        }

        public async Task Update(int id, StandartDTO entity)
        {
            await _unitOfWork.Update(id, entity);
        }
    }
}
