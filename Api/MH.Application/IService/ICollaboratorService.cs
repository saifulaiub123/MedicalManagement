using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.Model;
using MH.Domain.ViewModel;


namespace MH.Application.IService
{
    public interface ICollaboratorService
    {
        Task<List<CollaboratorViewModel>> GetAll();
        Task<CollaboratorViewModel> GetById(int id);
        Task Add(CollaboratorModel collaborator);
        Task Update(CollaboratorModel collaborator);
        Task Delete(int id); 
    }
}
