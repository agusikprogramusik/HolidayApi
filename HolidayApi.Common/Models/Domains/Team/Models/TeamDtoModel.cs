namespace HolidayApi.Common.Models.Domains.Team.Models
{
    public class TeamDtoModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}