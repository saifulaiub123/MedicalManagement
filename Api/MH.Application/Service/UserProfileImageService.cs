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
    public class UserProfileImageService : IUserProfileImageService
    {
        private readonly IUserProfileImageRepository _userProfileImageRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public UserProfileImageService(IUserProfileImageRepository userProfileImageRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userProfileImageRepository = userProfileImageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(UserProfileImageModel userProfileImageModel)
        {
            var userProfileImage = new UserProfileImage();
            using (var ms = new MemoryStream())
            {
                userProfileImageModel.File.CopyTo(ms);
                userProfileImage.Data = ms.ToArray();
                //userProfileImage.UserId = (int)userProfileImageModel.UserId;
                userProfileImage.ContentType = userProfileImageModel.File.ContentType;
                userProfileImage.FileName = userProfileImageModel.File.FileName;
                await _unitOfWork.UserProfileImageRepository.Insert(userProfileImage);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<List<UserProfileImageViewModel>> GetAll()
        {
            var data = await _unitOfWork.UserProfileImageRepository.GetAll(x => !x.IsDeleted);
            var result = _mapper.Map<List<UserProfileImageViewModel>>(data);
            return result;
        }

        public async Task<UserProfileImageViewModel> GetById(int id)
        {
            var data = await _unitOfWork.UserProfileImageRepository.FindBy(x => !x.IsDeleted && x.Id == id);
            var result = _mapper.Map<UserProfileImageViewModel>(data);
            return result;
        }

        public async Task Update(UserProfileImageModel userProfileImageModel)
        {
            var existingData = await _unitOfWork.UserProfileImageRepository.FindBy(x => x.UserProfileId == userProfileImageModel.UserId && !x.IsDeleted);
            if(existingData != null)
            {
                using (var ms = new MemoryStream())
                {
                    userProfileImageModel.File.CopyTo(ms);
                    existingData.Data = ms.ToArray();
                    existingData.ContentType = userProfileImageModel.File.ContentType;
                    existingData.FileName = userProfileImageModel.File.FileName;
                }
                await _unitOfWork.UserProfileImageRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.UserProfileImageRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if(existingData != null)
            {
                await _unitOfWork.UserProfileImageRepository.Delete(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
