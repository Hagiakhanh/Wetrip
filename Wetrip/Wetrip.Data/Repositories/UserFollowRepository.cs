using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetrip.Data.DBContext;
using Wetrip.Data.Entities;
using Wetrip.Data.GenericRepository;
using Wetrip.Data.IRepositories;

namespace Wetrip.Data.Repositories
{
    public class UserFollowRepository : GenericRepository<UserFollow>, IUserFollowRepository
    {
        public UserFollowRepository(WeTripContext context) : base(context)
        {
        }

        public async Task<UserFollow> GetAsync(int followerId, int followingId)
        {
            return await _context.UserFollows
                .SingleOrDefaultAsync(uf => uf.FollowerId == followerId
                                         && uf.FollowingId == followingId);
        }
    }
}
