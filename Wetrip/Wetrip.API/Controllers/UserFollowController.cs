using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wetrip.Service.IServices;

namespace Wetrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFollowController : ControllerBase
    {
        private readonly IUserFollowService _userFollowService;
        
        public UserFollowController(IUserFollowService userFollowService)
        {
            _userFollowService = userFollowService;
        }

        // POST /api/follows/{userId}/follow
        [HttpPost("{userId}/follow")]
        public async Task<IActionResult> ToggleFollow(int userId)
        {
            // sau dung CurrentUserService
            var followerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            bool isNowFollowing = await _userFollowService.ToggleFollowAsync(followerId, userId);

            // Trả về trạng thái hiện tại để UI biết nút nên hiển thị Follow hay Unfollow
            return Ok(new { isFollowing = isNowFollowing });
        }
    }
}
