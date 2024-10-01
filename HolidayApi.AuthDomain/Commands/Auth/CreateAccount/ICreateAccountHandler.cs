using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayApi.AuthDomain.Commands.Auth.CreateAccount
{
    public interface ICreateAccountHandler
    {
        Task Handle(CreateAccountRequest request);
    }
}
