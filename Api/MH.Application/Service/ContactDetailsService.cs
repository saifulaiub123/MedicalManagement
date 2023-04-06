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
    public class ContactDetailsService : IContactDetailsService
    {
        private readonly IContactDetailsRepository _contactDetailsRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public ContactDetailsService(IContactDetailsRepository contactDetailsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _contactDetailsRepository = contactDetailsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(ContactDetailsModel contactDetails)
        {
            var data = _mapper.Map<ContactDetails>(contactDetails);
            await _unitOfWork.ContactDetailsRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<ContactDetailsViewModel>> GetAll()
        {
            var data = await _unitOfWork.ContactDetailsRepository.GetAll(x => !x.IsDeleted);
            var result = _mapper.Map<List<ContactDetailsViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task<ContactDetailsViewModel> GetById(int id)
        {
            var data = await _unitOfWork.ContactDetailsRepository.FindBy(x => !x.IsDeleted && x.Id == id);
            var result = _mapper.Map<ContactDetailsViewModel>(data);
            return result;
        }

        public async Task Update(ContactDetailsModel contactDetails)
        {
            var existingData = await _unitOfWork.ContactDetailsRepository.FindBy(x => x.Id == contactDetails.Id && !x.IsDeleted);
            if(existingData != null)
            {
                //existingData.Name = server.Name;
                

                await _unitOfWork.ContactDetailsRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.ContactDetailsRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.IsDeleted = true;
                await _unitOfWork.ContactDetailsRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
