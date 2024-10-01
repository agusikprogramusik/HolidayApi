using HolidayApi.AuthDomain.Commands.Auth.CreateAccount;
using HolidayApi.AuthDomain.Commands.User;
using HolidayApi.Common.Models.Domains.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayApi.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        public UserController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDtoModel>>> GetUsersAsync()
        {
            return Ok(await _userHandler.GetUsersAsync());
        }
        //[HttpGet("more")]
        //public async Task<ActionResult<IEnumerable<UserDtoModel>>> GetUsersWithMoreDataAsync()
        //{
        //    return Ok(await _userHandler.GetUsersWithMoreDataAsync());
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetAsync(int id)
        {
            var user = await _userHandler.GetUserAsync(id);
            return Ok(user);
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateAccountRequest request)
        {
            await _userHandler.CreateUserAsync(request);
            return Ok();
        }

        #endregion

        #region Put

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UserUpdateRequest request)
        {
            await _userHandler.UpdateUserAsync(request);
            return Ok();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userHandler.DeleteUserAsync(id);
            return Ok();
        }

        #endregion
    }
}
