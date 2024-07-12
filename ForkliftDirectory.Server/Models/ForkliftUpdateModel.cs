namespace ForkliftDirectory.Server.Models
{
    public class ForkliftUpdateModel
    {
        public int? ForkliftId { get; set; }
        public int? UserId { get; set; }
        public string? Model { get; set; }
        public string? Number { get; set; }
        public bool Active { get; set; } = false;
    }
}
