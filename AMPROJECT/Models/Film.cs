

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Films")]
    public class Film : Produit
    {
        //[Key]
        public int Id { get; set; }
        // public string? Titre { get; set; }
        public int Duration { get; set; }

        public Categorie? Categorie { get; set; }
        public ICollection<Acteur> Acteurs { get; set; } = null!;
        //public string? PanierId { get; set; }
        //[ForeignKey(nameof(PanierId))]
        //public Panier? Paniers { get; set; } 
        //public int PanierItemId { get; set; }
        //[ForeignKey(nameof(PanierItem))]
        public string? PanierItemId { get; set; }
        public string? PhotoPath { get; set; }

    }
}
