using HolidayApi.Common.Models.Entities;

namespace HolidayApi.Models.Entities;

public class Team
{
    #region Properties
    public int TeamId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string Department { get; set; }
    #endregion

    #region Navigation Properties
    public int StatusId { get; set; }
    public int TeamLeaderId { get; set; }
    public User TeamLeader { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    #endregion
}