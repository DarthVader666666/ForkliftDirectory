using ForkliftDirectory.Server.Entities;

namespace ForkliftDirectory.Server.Models
{
    public class MalfunctionIndexModel
    {
        public int? MalfunctionId { get; set; }
        public int? ForkliftId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? TimeSpan { get; set; }
        public string? Describtion { get; set; }
        public string? Number {  get; set; }
    }
}
