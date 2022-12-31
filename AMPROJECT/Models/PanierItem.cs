using AMPROJECT.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    public class PanierItem
    {

        [Key]
        public int? Id { get; set; }

    
        public Film? Films { get; set; }
        public Panier? Panier { get; set; }

        //public ICollection<Livre> LivrePaniers { get; set; }
        public int? Quantites { get; set; }

        public string? PanierItemId { get; set; }


    }
}
