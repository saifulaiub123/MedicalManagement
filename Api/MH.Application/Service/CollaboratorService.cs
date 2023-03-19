using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using MH.Domain.ViewModel;


namespace MH.Application.Service
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public CollaboratorService(ICollaboratorRepository collaboratorRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _collaboratorRepository = collaboratorRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(CollaboratorModel collaborator)
        {
            var data = _mapper.Map<Collaborator>(collaborator);
            await _unitOfWork.CollaboratorRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<CollaboratorViewModel>> GetAll()
        {
            var data = await _unitOfWork.CollaboratorRepository.GetAll(x => !x.IsDeleted);
            var result = _mapper.Map<List<CollaboratorViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task<CollaboratorViewModel> GetById(int id)
        {
            var data = await _unitOfWork.CollaboratorRepository.FindBy(x => !x.IsDeleted && x.Id == id);
            var result = _mapper.Map<CollaboratorViewModel>(data);
            return result;
        }

        public async Task Update(CollaboratorModel collaborator)
        {
            var existingData = await _unitOfWork.CollaboratorRepository.FindBy(x => x.Id == collaborator.Id && !x.IsDeleted);
            if(existingData != null)
            {
                //existingData.Name = server.Name;
                

                await _unitOfWork.CollaboratorRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.CollaboratorRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.IsDeleted = true;
                await _unitOfWork.CollaboratorRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
