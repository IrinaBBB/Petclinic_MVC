namespace Petclinic.Models
{
    public class TwoFactorAuthenticationViewModel
    {
        // is used to log in 
        public string Code { get; set; }

        // is used to register / sign up
        public string Token { get; set; }
    }
}