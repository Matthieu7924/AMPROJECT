using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Acteurs")]
    public class Acteur
    {

        public int ActeurId { get; set; }

        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string? Nom { get; set; }


        public ICollection<Film> Films { get; set; }
    }
}
