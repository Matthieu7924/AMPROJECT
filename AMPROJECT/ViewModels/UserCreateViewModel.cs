using AMPROJECT.Data;

namespace AMPROJECT.ViewModels
{
    public class UserCreateViewModel
    {


        public string? Nom { get; set; }
        public string? Prenom { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Tel { get; set; }

        public ICollection<Panier>? Paniers { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
