﻿namespace HolidayApi.Common.Models.Domains.HolidayRequest.Models;

public class HolidayRequestDtoModel
{
    public int Id { get; set; }
    public HolidayTypeEnum Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public HolidayRequestStatusEnum Status { get; set; }
    public string? RejectionReason { get; set; }
    public Guid UserId { get; set; }
    public Guid? ApprovedById { get; set; }
}

