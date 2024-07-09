using Microsoft.AspNetCore.Identity;

namespace HolidayApi.Common.Models.Entities;

public class UserRole : IdentityRole<int>
{
    public virtual IList<User> Users { get; set; }
}

