using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetrip.Service.IServices
{
    public interface IUserFollowService
    {
        Task FollowAsync(int followerId, int followingId);
        Task UnfollowAsync(int followerId, int followingId);
    }
}
