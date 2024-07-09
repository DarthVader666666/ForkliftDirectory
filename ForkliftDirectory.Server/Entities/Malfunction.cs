namespace ForkliftDirectory.Server.Entities
{
    public class Malfunction
    {
        public int? MalfunctionId {  get; set; }
        public int? ForkliftId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? TimeSpan { get; set; }
        public string? Describtion { get; set; }
        public Forklift? Forklift { get; set; }
    }
}
