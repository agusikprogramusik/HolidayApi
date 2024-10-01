namespace HolidayApi.AuthDomain.Commands.Auth.ConfirmEmail
{
    public interface IConfirmEmailHandler
    {
        public Task Handle(ConfirmEmailRequest request);
    }
}
