using System.ComponentModel.DataAnnotations;

namespace AMPROJECT.Models
{
    public class User
    {
        public int Id { get; set; }

        
        public string Nom{ get; set; }
        public string Prenom { get; set; }

        public string Email { get; set; }   
        public string Password { get; set; }    
        public string Tel { get; set; }

        public ICollection<Panier> Paniers { get; set; } 
        public string? PhotoPath { get; set; }

    }
}
