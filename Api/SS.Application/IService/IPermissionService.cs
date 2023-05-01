using AutoMapper;
using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.IService
{
    public interface IPermissionService
    {
        Task<List<PermissionViewModel>> GetAllPermission();
    }
}
