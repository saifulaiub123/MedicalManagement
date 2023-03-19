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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public CountryService(ICountryRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(CountryModel country)
        {
            var data = _mapper.Map<Country>(country);
            await _unitOfWork.CountryRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<CountryViewModel>> GetAll()
        {
            var data = await _unitOfWork.CountryRepository.GetAll();
            var result = _mapper.Map<List<CountryViewModel>>(data);
            return result.OrderBy(x=> x.Name).ToList();
        }

        public async Task<CountryViewModel> GetById(int id)
        {
            var data = await _unitOfWork.CountryRepository.FindBy(x=> x.Id == id);
            var result = _mapper.Map<CountryViewModel>(data);
            return result;
        }

        public async Task Update(CountryModel country)
        {
            var existingData = await _unitOfWork.CountryRepository.FindBy(x => x.Id == country.Id);
            if(existingData != null)
            {
                //existingData.Name = server.Name;
                

                await _unitOfWork.CountryRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.CountryRepository.FindBy(x => x.Id == id);
            if(existingData != null)
            {
                await _unitOfWork.CountryRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
