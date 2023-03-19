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
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public StateService(IStateRepository stateRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(StateModel state)
        {
            var data = _mapper.Map<State>(state);
            await _unitOfWork.StateRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<StateViewModel>> GetAll()
        {
            var data = await _unitOfWork.StateRepository.GetAll();
            var result = _mapper.Map<List<StateViewModel>>(data);
            return result.OrderBy(x=> x.Name).ToList();
        }

        public async Task<StateViewModel> GetById(int id)
        {
            var data = await _unitOfWork.StateRepository.FindBy(x=> x.Id == id);
            var result = _mapper.Map<StateViewModel>(data);
            return result;
        }

        public async Task Update(StateModel state)
        {
            var existingData = await _unitOfWork.StateRepository.FindBy(x => x.Id == state.Id);
            if(existingData != null)
            {
                await _unitOfWork.StateRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.StateRepository.FindBy(x => x.Id == id);
            if(existingData != null)
            {
                await _unitOfWork.StateRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
