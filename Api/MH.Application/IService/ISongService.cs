using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService
{
    public interface ISongService
    {
        Task<List<SongViewModel>> GetAll();
        Task<SongViewModel> GetById(int id);
        Task Add(SongModel song);
        Task Update(SongModel song);
        Task Delete(int id); 
    }
}
