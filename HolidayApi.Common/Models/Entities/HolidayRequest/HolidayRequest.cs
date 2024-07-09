using HolidayApi.Common.Models;

namespace HolidayApi.Common.Models.Entities;

public class HolidayRequest
{
    #region Properties
    public int Id { get; set; }
    public string? Description { get; set; }
    public HolidayTypeEnum Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public HolidayRequestStatusEnum Status { get; set; }
    public string? RejectionReason { get; set; }
    #endregion

    #region Navigation Properties
    public int StatusId { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid? ApprovedById { get; set; }
    public virtual User? ApprovedBy { get; set; }
    #endregion

}