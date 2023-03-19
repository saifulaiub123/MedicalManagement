using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;

namespace MH.Application.IService
{
    public interface IScriptHistoryService
    {
        Task<ScriptHistoryModel> AddReturn(ScriptHistoryModel scriptHistory);
        Task Update(ScriptHistoryModel scriptHistory);
        Task<ScriptHistoryViewModel> GetById(int id);
        Task<List<ScriptHistoryViewModel>> GetByUserId(int userId);
        Task<List<ScriptHistoryViewModel>> GetAll();
    }
}
