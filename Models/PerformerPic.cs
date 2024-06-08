namespace IndieWorld.Models
{
    public class PerformerPic
        {
            public int Id { get; set; }
            public int PerformerId { get; set; }
            public string Image { get; set; }

            public string ShowName { get; set; }
            public DateTime ShowDate { get; set; }

        }
    
}
