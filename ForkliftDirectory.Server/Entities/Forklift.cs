namespace ForkliftDirectory.Server.Entities
{
    public class Forklift
    {
        public int? ForkliftId { get; set; }
        public int? UserId { get; set; }
        public string? Model { get; set; }
        public string? Number { get; set; }
        public int? LiftCapacity { get; set; }
        public bool Active { get; set; } = false;
        public User? User { get; set; }
        public ICollection<Malfunction>? Malfunctions { get; set; }
    }
}
