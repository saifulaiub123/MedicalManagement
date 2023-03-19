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
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(UserProfileModel userProfile)
        {
            var data = _mapper.Map<UserProfile>(userProfile);
            await _unitOfWork.UserProfileRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<UserProfileViewModel>> GetAll()
        {
            var data = await _unitOfWork.UserProfileRepository.GetAll(x => !x.IsDeleted,x=> x.User, x=> x.User.UserProfileImage);
            var result = _mapper.Map<List<UserProfileViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task<UserProfileViewModel> GetById(int id)
        {
            var data = await _unitOfWork.UserProfileRepository.FindBy(x => !x.IsDeleted && x.Id == id, x => x.User, x => x.User.UserProfileImage);
            var result = _mapper.Map<UserProfileViewModel>(data);
            return result;
        }
        public async Task<UserProfileViewModel> GetByUserId(int userId)
        {
            var data = await _unitOfWork.UserProfileRepository.FindBy(x => !x.IsDeleted && x.UserId == userId, x => x.User, x => x.User.UserProfileImage);
            var result = _mapper.Map<UserProfileViewModel>(data);
            return result;
        }

        public async Task Update(UserProfileModel userProfile)
        {
            var existingData = await _unitOfWork.UserProfileRepository.FindBy(x => x.UserId == userProfile.UserId && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.FirstName = userProfile.FirstName;
                existingData.LastName = userProfile.LastName;
                existingData.Age = userProfile.Age;
                existingData.CountryId = userProfile.CountryId;
                existingData.Email = userProfile.Email;
                existingData.StateId = userProfile.StateId;
                existingData.CityId = userProfile.CityId;
                existingData.ZipCode = userProfile.ZipCode;
                existingData.Address1 = userProfile.Address1;
                existingData.Address2 = userProfile.Address2;
                existingData.LanguageId = userProfile.LanguageId;
                
                await _unitOfWork.UserProfileRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.UserProfileRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.IsDeleted = true;
                await _unitOfWork.UserProfileRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
