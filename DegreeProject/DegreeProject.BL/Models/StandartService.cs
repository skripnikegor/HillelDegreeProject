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
        public async Task<StandartDTO> Create(StandartDTO entity)
        {
            return await _unitOfWork.Add(entity);
            
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.Delete(id);
        }

        public async Task<bool> Exist(int id)
        {
            return await _unitOfWork.Exist(id);
        }

        public async Task<StandartDTO> Get(int id)
        {
            return await _unitOfWork.Get(id);
        }

        public async Task<IEnumerable<StandartDTO>> GetAll()
        {
            return await _unitOfWork.GetAll();
        }

        public async Task<StandartDTO> Update(int id, StandartDTO entity)
        {
            return await _unitOfWork.Update(id, entity);
        }
    }
}
