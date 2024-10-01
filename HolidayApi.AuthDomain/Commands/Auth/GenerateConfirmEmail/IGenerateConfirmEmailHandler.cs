namespace HolidayApi.AuthDomain.Commands.Auth.GenerateConfirmEmail
{
    public interface IGenerateConfirmEmailHandler
    {
        public Task Handle(GenerateConfirmEmailRequest request);
    }
}
