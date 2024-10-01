using HolidayApi.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace HolidayApi.Common.Models.Entities;

public class User : IdentityUser<int>
{
    #region Properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public float HolidayTimeRemain { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsFullTime { get; set; }
    #endregion

    #region Navigation Properties
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public int? TeamId { get; set; }
    public virtual Team? Team { get; set; }
    public int RoleId { get; set; }
    public UserRole Role { get; set; }
    public ContactDetails? ContactDetails { get; set; }
    public virtual IList<HolidayRequest>? HolidayRequests { get; set; }
    #endregion
}
