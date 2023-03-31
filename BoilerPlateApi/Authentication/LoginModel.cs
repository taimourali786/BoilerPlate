using System.ComponentModel.DataAnnotations;

namespace BoilerPlateApi.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
