namespace HolidayApi.AuthDomain.Commands.Auth.AccountLogin
{
    public class AccountLoginResponse
    {
        public DateTime Expires { get; set; }
        public string Token { get; set; }

    }
}
