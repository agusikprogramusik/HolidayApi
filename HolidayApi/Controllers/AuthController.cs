using HolidayApi.AuthDomain.Commands.Auth.AccountLogin;
using HolidayApi.AuthDomain.Commands.Auth.ConfirmEmail;
using HolidayApi.AuthDomain.Commands.Auth.CreateAccount;
using HolidayApi.AuthDomain.Commands.Auth.GenerateConfirmEmail;
using Microsoft.AspNetCore.Mvc;

namespace HolidayApi.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(IAccountLoginHandler accountLoginHandler, ICreateAccountHandler createAccountHandler, IConfirmEmailHandler confirmEmailHandler, IGenerateConfirmEmailHandler generateConfirmEmailHandler)
        {
            _accountLoginHandler = accountLoginHandler;
            _createAccountHandler = createAccountHandler;
            _confirmEmailHandler = confirmEmailHandler;
            _generateConfirmEmailHandler = generateConfirmEmailHandler;
        }

        private readonly IAccountLoginHandler _accountLoginHandler;
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountLoginRequest request)
        {
            var result = await _accountLoginHandler.Handle(request);

            return Ok(result);

        }

        private readonly ICreateAccountHandler _createAccountHandler;
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {

            await _createAccountHandler.Handle(request);
            return Ok();
        }
        private readonly IGenerateConfirmEmailHandler _generateConfirmEmailHandler;
        [HttpPost("generate-confirm-email")]
        public async Task<IActionResult> GenerateConfirmEmail([FromBody] GenerateConfirmEmailRequest request)
        {
            await _generateConfirmEmailHandler.Handle(request);
            return Ok();
        }


        private readonly IConfirmEmailHandler _confirmEmailHandler;

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailRequest request)
        {
            await _confirmEmailHandler.Handle(request);
            return Ok();
        }
    }
}
