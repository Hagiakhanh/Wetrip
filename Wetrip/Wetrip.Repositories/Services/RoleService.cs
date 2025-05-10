using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetrip.Data.Entities;
using Wetrip.Data.IRepositories;
using Wetrip.Data.UnitOfWork;
using Wetrip.Service.IServices;

namespace Wetrip.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) 
        { 
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            if (roleId <= 0)
            {
                throw new ArgumentException("Role ID must be greater than 0");
            }
            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null)
            {
                throw new KeyNotFoundException("Role with Id not found");
            }

            return role;
        }
    }
}
