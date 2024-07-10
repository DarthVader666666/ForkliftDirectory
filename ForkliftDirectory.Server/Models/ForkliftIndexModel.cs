using ForkliftDirectory.Server.Entities;

namespace ForkliftDirectory.Server.Models
{
    public class ForkliftIndexModel
    {
        public int? ForkliftId { get; set; }
        public string? Model { get; set; }
        public string? Number { get; set; }
        public int? LiftCapacity { get; set; }
        public bool Active { get; set; } = false;
        public string? UserName { get; set; }
        public string? LastEndTime { get; set; }
        public bool Modify { get; set; } = false;
    }
}
