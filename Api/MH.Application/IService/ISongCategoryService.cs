using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService
{
    public interface ISongCategoryService
    {
        Task<List<SongCategoryViewModel>> GetAll();
        Task<SongCategoryViewModel> GetById(int id);
        Task Add(SongCategoryModel songCategory);
        Task Update(SongCategoryModel songCategory);
        Task Delete(int id); 
    }
}
