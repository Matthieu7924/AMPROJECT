using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Films")]
    public class Film:Produit
    {
        public int Id { get; set; }
        public int Duration { get; set; }

        public Categorie? Categorie { get; set; }
        public ICollection<Acteur> Acteurs { get; set; } = null!;

        public ICollection<Panier> Paniers { get; set; } = null!;

        public string? PhotoPath { get; set; }

    }
}
