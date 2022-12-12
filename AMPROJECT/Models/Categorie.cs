namespace AMPROJECT.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string? Name { get; set; }

        public enum FilmCat{
            Aventure,
            Comedie,
            Drame,
            Policier,
            SF
        }

        public enum LivreCat
        {
            Roman,
            Essai,
            Litterature
        }
    }
}
