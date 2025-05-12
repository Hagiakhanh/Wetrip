using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wetrip.Service.IServices;

namespace Wetrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        // POST /api/posts/{postId}/likes
        [HttpPost]
        public async Task<IActionResult> ToggleLike(int postId)
        {
            //sau nay dung CurrentUserService
            var userLikedId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Toggle và nhận lại trạng thái mới
            bool isNowLiked = await _likeService.ToggleLikeAsync(userLikedId, postId);

            // Trả về 200 + JSON { isLiked: true/false }
            return Ok(new { isLiked = isNowLiked });
        }
    }
}
