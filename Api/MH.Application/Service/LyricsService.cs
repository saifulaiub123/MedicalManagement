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
    public class LyricsService : ILyricsService
    {
        private readonly ILyricsRepository _lyricsRepository;
        private readonly IMapper _mapper;



        private readonly IUnitOfWork _unitOfWork;

        public LyricsService(ILyricsRepository lyricsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _lyricsRepository = lyricsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(LyricsModel lyrics)
        {
            var data = _mapper.Map<Lyrics>(lyrics);
            await _unitOfWork.LyricsRepository.Insert(data);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<LyricsViewModel>> GetAll()
        {
            var data = await _unitOfWork.LyricsRepository.GetAll(x => !x.IsDeleted);
            var result = _mapper.Map<List<LyricsViewModel>>(data);
            return result.OrderByDescending(x=> x.DateCreated).ToList();
        }

        public async Task<LyricsViewModel> GetById(int id)
        {
            var data = await _unitOfWork.LyricsRepository.FindBy(x => !x.IsDeleted && x.Id == id);
            var result = _mapper.Map<LyricsViewModel>(data);
            return result;
        }

        public async Task Update(LyricsModel lyrics)
        {
            var existingData = await _unitOfWork.LyricsRepository.FindBy(x => x.Id == lyrics.Id && !x.IsDeleted);
            if(existingData != null)
            {
                //existingData.Name = server.Name;
                

                await _unitOfWork.LyricsRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existingData = await _unitOfWork.LyricsRepository.FindBy(x => x.Id == id && !x.IsDeleted);
            if(existingData != null)
            {
                existingData.IsDeleted = true;
                await _unitOfWork.LyricsRepository.Update(existingData);
                await _unitOfWork.CommitAsync();
            }
        }  
    }
}
