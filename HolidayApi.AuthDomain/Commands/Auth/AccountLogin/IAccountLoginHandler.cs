namespace HolidayApi.AuthDomain.Commands.Auth.AccountLogin
{
    public interface IAccountLoginHandler
    {
        Task<AccountLoginResponse> Handle(AccountLoginRequest request);
    }
}
