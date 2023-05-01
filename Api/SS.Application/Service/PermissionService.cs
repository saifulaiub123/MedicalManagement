using AutoMapper;
using SS.Application.IService;
using SS.Domain.DBModel;
using SS.Domain.IRepository;
using SS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionService(IRepository<Permission, int> permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public async Task<List<PermissionViewModel>> GetAllPermission()
        {
            var result = await _permissionRepository.GetAll();
            var data = _mapper.Map<List<PermissionViewModel>>(result);
            return data;
        }
    }
}
