using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetrip.Data.Entities;
using Wetrip.Data.GenericRepository;

namespace Wetrip.Data.IRepositories
{
    public interface ILikeRepository : IGenericRepository<Like>
    {
        Task<Like> GetAsync(int postId, int userLikedId);
    }
}
