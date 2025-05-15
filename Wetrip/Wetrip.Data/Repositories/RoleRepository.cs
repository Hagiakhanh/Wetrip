using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wetrip.Data.DBContext;
using Wetrip.Data.Entities;
using Wetrip.Data.GenericRepository;
using Wetrip.Data.IRepositories;

namespace Wetrip.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(WeTripContext context) : base(context)
        {
        }

        public async Task<Role?> GetRoleByName(string roleName)
        {
            return await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RoleName.ToLower() == roleName.ToLower());
        }
    }
}