using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService
{
    public interface ICityService
    {
        Task<List<CityViewModel>> GetAll();
        Task<CityViewModel> GetById(int id);
        Task Add(CityModel city);
        Task Update(CityModel city);
        Task Delete(int id); 
    }
}
