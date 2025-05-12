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
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepo;
        private readonly IPostRepository _postRepo; // tuỳ chọn, để kiểm tra post tồn tại
        private readonly IUnitOfWork _unitOfWork;

        public LikeService(ILikeRepository repo, IPostRepository postRepo, IUnitOfWork unitOfWork)
        {
            _likeRepo = repo;
            _postRepo = postRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ToggleLikeAsync(int userLikedId, int postId)
        {
            // (Tuỳ) kiểm tra post tồn tại
            var post = await _postRepo.GetByIdAsync(postId);
            if (post == null || post.IsDeleted)
                throw new InvalidOperationException("Bài viết không tồn tại.");

            // Lấy bản ghi like (có thể đã IsDeleted = true)
            var existing = await _likeRepo.GetAsync(postId, userLikedId);
            if (existing == null)
            {
                // Chưa từng like -> tạo mới
                var like = new Like
                {
                    PostId = postId,
                    UserLikedId = userLikedId,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };
                await _likeRepo.InsertAsync(like);
                await _unitOfWork.SaveChanges();
                return true;
            }
            else if (existing.IsDeleted)
            {
                // Đã unlike trước đó -> re-activate thành like
                existing.IsDeleted = false;
                existing.CreatedAt = DateTime.UtcNow;
                await _likeRepo.UpdateAsync(existing);
                await _unitOfWork.SaveChanges();
                return true;
            }
            else
            {
                // Đang like -> chuyển thành unlike
                existing.IsDeleted = true;
                await _likeRepo.UpdateAsync(existing);
                await _unitOfWork.SaveChanges();
                return false;
            }
        }
    }
}
