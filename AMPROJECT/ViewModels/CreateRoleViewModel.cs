using System.ComponentModel.DataAnnotations;

namespace AMPROJECT.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; } = String.Empty;
    }
}

