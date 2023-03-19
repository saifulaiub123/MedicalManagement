using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService
{
    public interface IStateService
    {
        Task<List<StateViewModel>> GetAll();
        Task<StateViewModel> GetById(int id);
        Task Add(StateModel state);
        Task Update(StateModel state);
        Task Delete(int id); 
    }
}
