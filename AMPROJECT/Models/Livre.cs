using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Livres")]
    public class Livre:Produit
    {

        public int Id { get; set; }

        public Categorie? Categorie { get; set; }
        public ICollection<Auteur> Auteurs { get; set; } = null!;

        public ICollection<Panier> Paniers { get; set; } = null!;
    }
}
