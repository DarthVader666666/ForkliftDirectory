using ForkliftDirectory.Server.Entities;

namespace ForkliftDirectory.Server.Models
{
    public class MalfunctionInsertModel
    {
        public int? ForkliftId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? TimeSpan { get; set; }
        public string? Describtion { get; set; }
    }
}
