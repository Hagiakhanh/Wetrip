using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetrip.Data.Entities;

namespace Wetrip.Service.IServices
{
    public interface IRoleService
    {
        Task<Role> GetRoleByIdAsync(int roleId);
    }
}
