using HolidayApi.Common.Models.Domains.HolidayRequest.Models;
using Mapster;

namespace HolidayApi.Common.Models.Domains.HolidayRequest.Mappings;

public class HolidayDtoModelMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entities.HolidayRequest, HolidayRequestDtoModel>()
            .Map(src => src.Id, dest => dest.Id)
            .Map(src => src.Type, dest => dest.Type)
            .Map(src => src.StartDate, dest => dest.StartDate)
            .Map(src => src.EndDate, dest => dest.EndDate)
            .Map(src => src.CreatedAt, dest => dest.CreatedAt)
            .Map(src => src.Status, dest => dest.Status)
            .Map(src => src.RejectionReason, dest => dest.RejectionReason)
            .Map(src => src.UserId, dest => dest.UserId)
            .Map(src => src.ApprovedById, dest => dest.ApprovedById);
    }
}

