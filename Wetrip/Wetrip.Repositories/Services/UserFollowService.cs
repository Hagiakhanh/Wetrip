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

        public async Task<bool> ToggleFollowAsync(int followerId, int followingId)
        {
            if (followerId == followingId)
                throw new InvalidOperationException("Không thể follow chính mình.");

            // (Tuỳ) kiểm tra target user có tồn tại không
            /*var target = await _userRepo.GetByIdAsync(followingId);
            if (target == null)
                throw new InvalidOperationException("User không tồn tại.");*/

            var existing = await _userFollowRepo.GetAsync(followerId, followingId);
            if (existing == null)
            {
                // chưa từng follow → tạo mới
                var uf = new UserFollow
                {
                    FollowerId = followerId,
                    FollowingId = followingId,
                    FollowedAt = DateOnly.FromDateTime(DateTime.UtcNow),
                    IsActive = true
                };
                await _userFollowRepo.InsertAsync(uf);
                await _unitOfWork.SaveChanges();
                return true;
            }
            else if (!existing.IsActive)
            {
                // đã unfollow trước đó → re-activate
                existing.IsActive = true;
                existing.FollowedAt = DateOnly.FromDateTime(DateTime.UtcNow);
                existing.UnfollowedAt = null;
                await _userFollowRepo.UpdateAsync(existing);
                await _unitOfWork.SaveChanges();
                return true;
            }
            else
            {
                // đang follow → bỏ follow
                existing.IsActive = false;
                existing.UnfollowedAt = DateOnly.FromDateTime(DateTime.UtcNow);
                await _userFollowRepo.UpdateAsync(existing);
                await _unitOfWork.SaveChanges();
                return false;
            }
        }
    }
}
