using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Domain.Model;
using SS.Domain.ViewModel;


namespace SS.Application.IService
{
    public interface IContactDetailsService
    {
        Task<List<ContactDetailsViewModel>> GetAll();
        Task<ContactDetailsViewModel> GetByUserId(int userId);
        Task Add(ContactDetailsModel contactDetails);
        Task Update(ContactDetailsModel contactDetails);
        Task Delete(int id); 
    }
}
