﻿using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;

namespace MH.Application.IService
{
    public interface IScriptService
    {
        Task AddScript(ScriptModel model);
        Task<List<ScriptViewModel>> GetAll();
        Task<List<ScriptViewModel>> GetScriptsByUserId(int userId);
        Task<ScriptViewModel> GetScriptById(int id);
        Task<List<ScriptViewModel>> GetSharedScriptsByUserId(int userId);
        Task<List<SharedScriptUserViewModel>> GetScriptSharedUser(int scriptId);
        Task UpdateScript(UpdateScriptModel script);
        Task DeleteScript(int id);
        Task<bool> HasPermissionToModify(int scriptId, int userId);
        Task<bool> HasPermissionToView(int scriptId, int userId);
        Task<bool> IsScriptOwnerOrAdmin(int scriptId, int userId);
    }
}
