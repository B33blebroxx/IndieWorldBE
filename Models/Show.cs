namespace IndieWorld.Models
{
    public class Show
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public Promotion? Promotion { get; set; }
        public string? ShowName { get; set; }
        public string? ShowImage { get; set; }
        public string? Location { get; set; }
        public DateTime? ShowDate { get; set; }
        public string? ShowTime { get; set; }
        public int Price { get; set; }
        public bool ShowComplete { get; set; }
        public ICollection<Performer>? Performers { get; set; }
    }
}
