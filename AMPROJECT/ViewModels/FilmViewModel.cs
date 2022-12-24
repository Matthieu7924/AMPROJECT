using AMPROJECT.Data;
using AMPROJECT.Models;

namespace AMPROJECT.ViewModels
{
    public class FilmViewModel:Produit
    {
            public int Id { get; set; }
            public int Duration { get; set; }

            public Categorie? Categorie { get; set; }
            public ICollection<Acteur> Acteurs { get; set; } = null!;

            public ICollection<Panier> Paniers { get; set; } = null!;

            public IFormFile? Photo { get; set; }
        
    }
}
