namespace AMPROJECT.Models
{
    public class Achat
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public List<AchatItem>? AchatItem { get; set; }

    }
}
