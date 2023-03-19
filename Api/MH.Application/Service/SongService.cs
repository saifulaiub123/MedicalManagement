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
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public SongService(ISongRepository songRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _songRepository = songRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(SongModel song)
        {
            var data = _mapper.Map<Song>(song);
            await _unitOfWork.SongRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<SongViewModel>> GetAll()
        {
            var data = await _unitOfWork.SongRepository.GetAll(x => !x.IsDeleted);
            var result = _mapper.Map<List<SongViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task<SongViewModel> GetById(int id)
        {
            var data = await _unitOfWork.SongRepository.FindBy(x => !x.IsDeleted && x.Id == id);
            var result = _mapper.Map<SongViewModel>(data);
            return result;
        }

        public async Task Update(SongModel song)
        {
            var existingData = await _unitOfWork.SongRepository.FindBy(x => x.Id == song.Id && !x.IsDeleted);
            if(existingData != null)
            {
                //existingData.Name = server.Name;
                

                await _unitOfWork.SongRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.SongRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.IsDeleted = true;
                await _unitOfWork.SongRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
