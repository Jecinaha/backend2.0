using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels
{
    public class QuestionFormViewModel
    {
        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Namnet får vara max 100 tecken.")]
        public string QuestionName { get; set; } = null!;

        [Required(ErrorMessage = "E-postadress är obligatorisk.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        public string QuestionEmail { get; set; } = null!;

        [Required(ErrorMessage = "Du måste skriva en fråga.")]
        public string QuestionText { get; set; } = null!;
    }
}
