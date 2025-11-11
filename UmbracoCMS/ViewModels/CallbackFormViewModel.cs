using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UmbracoCMS.ViewModels;
public class CallbackFormViewModel
{
    [Required(ErrorMessage = "Namn är obligatoriskt.")]
    [StringLength(100, ErrorMessage = "Namnet får vara max 100 tecken.")]
    [Display(Name = "Namn")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "E-postadress är obligatorisk.")]
    [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Ange en giltig e-postadress.")]
    [Display(Name = "E-post")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Telefonnummer är obligatoriskt.")]

    [Display(Name = "Telefon")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Du måste välja ett alternativ.")]
    [Display(Name = "Valt alternativ")]
    public string SelectedOption { get; set; } = null!;


    [BindNever]
    public IEnumerable<string> Options { get; set; } = [];

}