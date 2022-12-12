using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Panier")]

    public class Panier
    {

        [Key]
        public int PanierId { get; set; }

        public ICollection<Film> FilmPaniers { get; set; }

        public ICollection<Livre> LivrePaniers { get; set; }


        public ICollection<User> Users { get; set; }

    }
}
