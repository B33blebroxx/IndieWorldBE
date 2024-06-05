namespace IndieWorld.Models
{
    public class Performer
    {
        public int Id { get; set; }
        public string? RingName { get; set; }
        public string? Image { get; set; }
        public string? Bio { get; set; }
        public string? Hometown { get; set; }
        public string? Accolades { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public bool Active { get; set; }
        public ICollection<Show>? Shows { get; set; }
    }
}
