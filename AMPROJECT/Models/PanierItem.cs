using System.ComponentModel.DataAnnotations;

namespace AMPROJECT.Models
{
    public class PanierItem
    {

        [Key]
        public int Id { get; set; }

        //public int FilmId { get; set; }
        //[ForeignKey(nameof(FilmId))]
        public Film? Films { get; set; }

        //public ICollection<Livre> LivrePaniers { get; set; }
        public int? Quantites { get; set; }


        public string? PanierItemId { get; set; }
    }
}
