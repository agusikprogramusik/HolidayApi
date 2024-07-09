using HolidayApi.Common.Models;
using HolidayApi.Common.Models.Entities;

namespace HolidayApi.Infrastructure.Seeders.User
{
    public static class StatusSeed
    {
        public static List<Status> Seed()
        {
            List<Status> items = [];
            items.AddRange(from StatusEnum item in Enum.GetValues(typeof(StatusEnum)) 
                select new Status { Id = (int)item, Name = item.ToString() });
            return items;
        }
    }
}

