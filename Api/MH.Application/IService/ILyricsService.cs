using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService
{
    public interface ILyricsService
    {
        Task<List<LyricsViewModel>> GetAll();
        Task<LyricsViewModel> GetById(int id);
        Task Add(LyricsModel lyrics);
        Task Update(LyricsModel lyrics);
        Task Delete(int id); 
    }
}
