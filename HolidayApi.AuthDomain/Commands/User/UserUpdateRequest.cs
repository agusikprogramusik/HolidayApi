using FluentValidation;
using HolidayApi.Common.Models.Domains.Users.Models;
using Mapster;

namespace HolidayApi.AuthDomain.Commands.User
{
    public class UserUpdateRequest : UserDtoModel
    {

        public void Validate()
        {
            new UserUpdateRequestValidator().ValidateAndThrow(this);
        }
    }
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
    public class UserUpdateRequestMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserUpdateRequest, UserDtoModel>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName);

        }
    }
}