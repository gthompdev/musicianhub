using System.ComponentModel.DataAnnotations;

namespace MusicianHub.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}