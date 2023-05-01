using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Domain.Model;
using SS.Domain.ViewModel;


namespace SS.Application.IService
{
    public interface IPositionService
    {
        Task<List<PositionViewModel>> GetAll();
        Task<PositionViewModel> GetById(int id);
        Task Add(PositionModel position);
        Task Update(PositionModel position);
        Task Delete(int id); 
    }
}
