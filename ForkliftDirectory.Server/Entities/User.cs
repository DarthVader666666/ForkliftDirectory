namespace ForkliftDirectory.Server.Entities
{
    public class User
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public Forklift? Forklift { get; set; }
    }
}
