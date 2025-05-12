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
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        public LikeRepository(WeTripContext context) : base(context)
        {
        }

        public async Task<Like> GetAsync(int postId, int userLikedId)
        => await _context.Likes
               .SingleOrDefaultAsync(l => l.PostId == postId && l.UserLikedId == userLikedId);
    }
}
