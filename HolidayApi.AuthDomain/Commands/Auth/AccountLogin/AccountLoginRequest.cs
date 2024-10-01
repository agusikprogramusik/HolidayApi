using FluentValidation;

namespace HolidayApi.AuthDomain.Commands.Auth.AccountLogin
{
    public class AccountLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public void Validate()
        {
            var validator = new AccountLoginRequestValidator();
            validator.ValidateAndThrow(this);
        }
    }
    public class AccountLoginRequestValidator : AbstractValidator<AccountLoginRequest>
    {
        public AccountLoginRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
