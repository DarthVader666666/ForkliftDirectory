namespace ForkliftDirectory.Server.Models
{
    public class MalfunctionUpdateModel
    {
        public int? MalfunctionId { get; set; }
        public int? ForkliftId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? TimeSpan { get; set; } = null;
        public string? Describtion { get; set; }
    }
}
