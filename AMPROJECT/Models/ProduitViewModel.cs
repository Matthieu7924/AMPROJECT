namespace AMPROJECT.Models
{
    public class ProduitViewModel
    {
        public class ProductViewModel
        {
            public string Titre { get; set; } = null!;
            public string Description { get; set; } = null!;
            public DateTime DateSortie { get; set; }

            public float Prix { get; set; }
            public int Quantite { get; set; }

            public IFormFile Image { get; set; }
        }
    }
}
