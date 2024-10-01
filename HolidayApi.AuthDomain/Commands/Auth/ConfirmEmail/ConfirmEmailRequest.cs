using FluentValidation;

namespace HolidayApi.AuthDomain.Commands.Auth.ConfirmEmail
{
    public class ConfirmEmailRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public void Validate()
        {
            var validator = new ConfirmEmailRequestValidator();
            validator.ValidateAndThrow(this);
        }
    }

    public class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
