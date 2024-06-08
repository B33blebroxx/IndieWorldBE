namespace IndieWorld.Models
{
    public class PromotionPic
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public string Image { get; set; }

        public string ShowName { get; set; }
        public DateTime ShowDate { get; set; }

    }
}
