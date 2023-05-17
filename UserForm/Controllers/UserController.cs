using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserForm.Interfaces.IServices;
using UserForm.Models.RequestResponseModels;

namespace UserForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous, HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] UserRequestResponseModel model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);
            if (user != null)
            {
                return Ok(new
                {
                    isSuccess = false,
                    message = "User Already Exists!"
                });
            }

            var newUser = await _userService.Create(model);

            return Ok(new
            {
                isSuccess = true,
                user = newUser
            });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UserRequestResponseModel model)
        {
            var isUpdated = await _userService.UpdateAsync(model);

            if (!isUpdated)
            {
                return Ok(new
                {
                    message = "Could not update User!"
                });
            }

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return Ok(new
                {
                    isSuccess = false,
                    message = "User does not exist!"
                });
            }
            await _userService.DeleteUserAsync(user);

            return Ok(new
            {
                isSuccess = true
            });
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(new
            {
                user = user
            });
        }
    }
}
