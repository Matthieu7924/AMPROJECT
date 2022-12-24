using System.ComponentModel.DataAnnotations;

namespace AMPROJECT.Models
{
    public class AchatItem
    {
        [Key]
        public int Id { get; set; }
        public int Qtt { get; set; }

        public double Prix { get; set; }    

        public int FilmId { get; set; }
        public Film? Film { get; set; }

        public int AchatId { get; set; }
        public Achat? Achat { get; set; }

    }
}
