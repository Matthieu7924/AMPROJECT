﻿using AMPROJECT.Models;
using System.ComponentModel.DataAnnotations;

namespace AMPROJECT.ViewModels
{
    public class RegisterViewModel:ApplicationUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = String.Empty;

      
    }
}
