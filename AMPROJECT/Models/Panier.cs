using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Panier")]

    public class Panier
    {

        [Key]
        public int PanierId { get; set; }

        //public int FilmId { get; set; }
        //[ForeignKey(nameof(FilmId))]
        public Film? Films { get; set; }

        //public ICollection<Livre> LivrePaniers { get; set; }


        public User? Users { get; set; }



    }
}
