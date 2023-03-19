using MH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Application.IService
{
    public interface IScriptUserPermissionService
    {
        Task<List<ScriptUserPermissionModel>> GetScriptUserPermissionsByScriptId(int scriptId);
    }
}
