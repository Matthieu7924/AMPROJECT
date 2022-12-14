using System.ComponentModel.DataAnnotations;

namespace AMPROJECT.ViewModels
{
    public class EditRoleViewModel
    {
        [Required]
        public string Id { get; set; } = String.Empty;

        [Required]
        public string RoleName { get; set; } = String.Empty;

        public List<string> Users { get; set; } = new();
    }
}