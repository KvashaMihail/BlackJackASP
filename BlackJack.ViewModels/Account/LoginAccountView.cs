using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Account
{
    public class LoginAccountView
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //public string ReturnUrl { get; set; }
    }
}
