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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public CityService(ICityRepository cityRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(CityModel city)
        {
            var data = _mapper.Map<City>(city);
            await _unitOfWork.CityRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<CityViewModel>> GetAll()
        {
            var data = await _unitOfWork.CityRepository.GetAll();
            var result = _mapper.Map<List<CityViewModel>>(data);
            return result.OrderBy(x=> x.Name).ToList();
        }

        public async Task<CityViewModel> GetById(int id)
        {
            var data = await _unitOfWork.CityRepository.FindBy(x => x.Id == id);
            var result = _mapper.Map<CityViewModel>(data);
            return result;
        }

        public async Task Update(CityModel city)
        {
            var existingData = await _unitOfWork.CityRepository.FindBy(x => x.Id == city.Id);
            if(existingData != null)
            {
                //existingData.Name = server.Name;
                

                await _unitOfWork.CityRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.CityRepository.FindBy(x => x.Id == id);
            if(existingData != null)
            {
                await _unitOfWork.CityRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
