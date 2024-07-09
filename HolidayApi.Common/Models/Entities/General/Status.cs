using HolidayApi.Models.Entities;

namespace HolidayApi.Common.Models.Entities;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<User> Users { get; set; }
    public IList<Team> Teams { get; set; }
    public IList<HolidayRequest> HolidayRequests { get; set; }

}