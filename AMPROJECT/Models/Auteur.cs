using System.ComponentModel.DataAnnotations;

namespace AMPROJECT.Models
{
    public class Auteur
    {
        public int AuteurId { get; set; }

        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public string? UrlPhoto { get; set; }
        public string Biographie { get; set; }

        public ICollection<Livre> Livres { get; set; }
    }
}
