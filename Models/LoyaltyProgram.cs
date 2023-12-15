namespace WebApplication1.Models
{
    public class LoyaltyProgram
    {
        [Key]
        public string LoyaltyProgramId { get; set; }
        public int PointRequired { get; set; }
        public string Reward { get; set; }
        public string CreatedBy { get; set; }
    }
}
