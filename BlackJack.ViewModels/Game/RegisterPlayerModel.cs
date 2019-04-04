using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Game
{
    public class RegisterPlayerModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

    }
}
