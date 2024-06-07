namespace IndieWorld.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string? PromotionName { get; set; }
        public string? Acronym { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string? Hq { get; set; }
        public int Established { get; set; }
        public string? Owner { get; set; }
        public string? ShowFrequency { get; set; }
        public ICollection<Show>? Shows { get; set; }
        public ICollection<PromotionPic>? PromotionPics { get; set; }
    }
}
