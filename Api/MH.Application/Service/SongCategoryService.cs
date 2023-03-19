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
    public class SongCategoryService : ISongCategoryService
    {
        private readonly ISongCategoryRepository _songCategoryRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public SongCategoryService(ISongCategoryRepository songCategoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _songCategoryRepository = songCategoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(SongCategoryModel songCategory)
        {
            var data = _mapper.Map<SongCategory>(songCategory);
            await _unitOfWork.SongCategoryRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<SongCategoryViewModel>> GetAll()
        {
            var data = await _unitOfWork.SongCategoryRepository.GetAll(x => !x.IsDeleted);
            var result = _mapper.Map<List<SongCategoryViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task<SongCategoryViewModel> GetById(int id)
        {
            var data = await _unitOfWork.SongCategoryRepository.FindBy(x => !x.IsDeleted && x.Id == id);
            var result = _mapper.Map<SongCategoryViewModel>(data);
            return result;
        }

        public async Task Update(SongCategoryModel songCategory)
        {
            var existingData = await _unitOfWork.SongCategoryRepository.FindBy(x => x.Id == songCategory.Id && !x.IsDeleted);
            if(existingData != null)
            {
                //existingData.Name = server.Name;
                

                await _unitOfWork.SongCategoryRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.SongCategoryRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.IsDeleted = true;
                await _unitOfWork.SongCategoryRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
