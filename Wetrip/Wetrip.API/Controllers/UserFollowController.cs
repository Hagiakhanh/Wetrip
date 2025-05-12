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
        public async Task<IActionResult> Follow(int userId)
        {
            // sau nay thay bang CurrentUserService
            var followerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _userFollowService.FollowAsync(followerId, userId);
            return NoContent();
        }

        // DELETE /api/follows/{userId}/follow
        [HttpDelete("{userId}/follow")]
        public async Task<IActionResult> Unfollow(int userId)
        {
            var followerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _userFollowService.UnfollowAsync(followerId, userId);
            return NoContent();
        }
    }
}
