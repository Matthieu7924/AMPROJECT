using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    [Table("Acteurs")]
    public class Acteur
    {

        public int ActeurId { get; set; }

        public string? Nom { get; set; }


        public ICollection<Film> Films { get; set; }
    }
}
