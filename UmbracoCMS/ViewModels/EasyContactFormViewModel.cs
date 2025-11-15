using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels
{
    public class EasyContactFormViewModel
    {
        [Required(ErrorMessage = "E-postadress är obligatorisk.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        [Display(Name = "E-postadress")]
        public string Email { get; set; } = null!;
    }
}
