using MH.Domain.Model;
using MH.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Application.IService
{
    public interface IServerService
    {
        Task<List<ServerViewModel>> GetAllServer();
        Task Add(ServerModel model);
        Task<ServerViewModel> GetById(int id);
        Task Update(ServerModel script);
        Task Delete(int id);
    }
}
