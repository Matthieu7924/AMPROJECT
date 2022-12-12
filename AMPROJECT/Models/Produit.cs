namespace AMPROJECT.Models
{
    public abstract class Produit
    {
        public string Titre { get; set; } = null!;   
        public string Description { get; set; } = null!;
        public DateTime DateSortie { get; set; }

        public float Prix { get; set; }
        public int Quantite { get; set; }
    }
}
