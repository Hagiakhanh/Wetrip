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
    public class UserFollowService : IUserFollowService
    {
        private readonly IUserFollowRepository _userFollowRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UserFollowService(IUserFollowRepository userFollowRepo, IUnitOfWork unitOfWork) 
        {
            _userFollowRepo = userFollowRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task FollowAsync(int followerId, int followingId)
        {
            if (followerId == followingId)
                throw new InvalidOperationException("Không thể follow chính mình.");

            var existing = await _userFollowRepo.GetAsync(followerId, followingId);
            if (existing != null)
            {
                if (existing.IsActive)
                    throw new InvalidOperationException("Đã đang follow người này.");

                // Re-activate
                existing.IsActive = true;
                existing.FollowedAt = DateOnly.FromDateTime(DateTime.UtcNow);
                existing.UnfollowedAt = null;
                await _userFollowRepo.UpdateAsync(existing);
            }
            else
            {
                var uf = new UserFollow
                {
                    FollowerId = followerId,
                    FollowingId = followingId,
                    FollowedAt = DateOnly.FromDateTime(DateTime.UtcNow),
                    IsActive = true
                };
                await _userFollowRepo.InsertAsync(uf);
            }

            await _unitOfWork.SaveChanges();
        }

        public async Task UnfollowAsync(int followerId, int followingId)
        {
            var existing = await _userFollowRepo.GetAsync(followerId, followingId);
            if (existing == null || !existing.IsActive)
                throw new InvalidOperationException("Chưa follow hoặc đã unfollow rồi.");

            existing.IsActive = false;
            existing.UnfollowedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            await _userFollowRepo.UpdateAsync(existing);
            await _unitOfWork.SaveChanges();
        }
    }
}
