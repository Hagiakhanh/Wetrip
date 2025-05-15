using Microsoft.AspNetCore.Mvc;
using Wetrip.Service.IServices;
using Wetrip.Services.DTO.RequestDTO.UserModel;
using Wetrip.Services.DTO.ResponseDTO.ResponseModel;

namespace Wetrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CustomerRegister")]
        public async Task<IActionResult> RegisterAccountCustomer(RequestRegisterAccount modelRequestRegisterAccount)
        {
            try
            {
                var result = await _userService.RegisterAccountCustomer(modelRequestRegisterAccount);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
                {
                    HttpStatusCode = StatusCodes.Status400BadRequest,
                    Message = e.Message
                });
            }
        }

        [HttpPost("CustomerConfirm")]
        public async Task<IActionResult> ConfirmAccountCustomer(RequestConfirmAccount modelRequestConfirmAccount)
        {
            try
            {
                var result = await _userService.ConfirmAccountCustomer(modelRequestConfirmAccount);
                return Ok(new ResponseModel()
                {
                    HttpStatusCode = StatusCodes.Status200OK,
                    Message = "Confirm account successfully"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
                {
                    HttpStatusCode = StatusCodes.Status400BadRequest,
                    Message = e.Message
                });
            }
        }
    }
}