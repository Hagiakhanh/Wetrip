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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(WeTripContext context) : base(context)
        {
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Phone.Equals(phone));
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress.Equals(email)); 
        }

        public async Task<User> GetUserByRequestId(string requestId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.RequestId == Guid.Parse(requestId)); 
        }
    }
}