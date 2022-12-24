using AMPROJECT.Data;
using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Films")]
    public class Film : Produit
    {
        //[Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Duration { get; set; }

        public Categorie? Categorie { get; set; }
        public ICollection<Acteur> Acteurs { get; set; } = null!;
        public int PanierId { get; set; }
        //[ForeignKey(nameof(PanierId))]
        //public Panier? Paniers { get; set; } 

        public string? PhotoPath { get; set; }

    }
}
