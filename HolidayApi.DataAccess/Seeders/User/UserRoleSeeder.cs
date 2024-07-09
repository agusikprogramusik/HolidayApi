using HolidayApi.Common.Models;
using HolidayApi.Common.Models.Entities;

namespace HolidayApi.Infrastructure.Seeders.User
{
    public static class UserRoleSeed
    {
        public static List<UserRole> Seed()
        {
            List<UserRole> items = [];
            items.AddRange(from UserRolesEnum item in Enum.GetValues(typeof(UserRolesEnum)) 
                select new UserRole { Id = (int)item, Name = item.ToString() });
            return items;
        }
    }
}