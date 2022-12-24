using AMPROJECT.Data;
using AMPROJECT.Models;

namespace AMPROJECT.ViewModels
{
    public class FilmCreateViewModel:Produit
    {
        //public FilmCreateViewModel(Film film)
        //{
        //    Duration = film.Duration;
        //    Categorie = film.Categorie;
        //    Acteurs = film.Acteurs;
        //    Paniers = film.Paniers;
        //    //Photo = new FormFile();
        //}

        //public int Id { get; set; }
        public int Duration { get; set; }

        public Categorie? Categorie { get; set; }
        public ICollection<Acteur> Acteurs { get; set; } = null!;

        public ICollection<Panier> Paniers { get; set; } = null!;

        public IFormFile? Photo { get; set; }
    }
}
