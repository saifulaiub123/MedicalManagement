using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;

namespace MH.Application.IService
{
    public interface ICountryService
    {
        Task<List<CountryViewModel>> GetAll();
        Task<CountryViewModel> GetById(int id);
        Task Add(CountryModel country);
        Task Update(CountryModel country);
        Task Delete(int id); 
    }
}
