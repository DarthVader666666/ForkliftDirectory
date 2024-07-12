namespace ForkliftDirectory.Server.Models
{
    public class ForkliftInsertModel
    {
        public string? Model { get; set; }
        public string? Number { get; set; }
        public bool Active { get; set; } = false;
        public int? UserId { get; set; }
    }
}
