namespace AMPROJECT.Models
{
    public class Achat
    {
        public int Id { get; set; }
        public DateTime DateDAchat { get; set; } = DateTime.Now;
        public string? UserId { get; set; }

        public List<AchatItem>? AchatItem { get; set; }

    }
}
