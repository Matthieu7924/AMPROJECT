using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMPROJECT.Models
{
    public class User
    {
        public int Id { get; set; }

        
        public string? Nom{ get; set; }
        public string? Prenom { get; set; }

        public string? Email { get; set; }   
        public string? Password { get; set; }    
        public string? Tel { get; set; }
        public int PanierId { get; set; }
        [ForeignKey(nameof(PanierId))]
        public Panier? Paniers { get; set; } 

        public string? PhotoPath { get; set; }

    }
}
