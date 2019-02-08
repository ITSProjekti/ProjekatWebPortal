using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Projekat.Models;


namespace Projekat.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        
        [Display(Name = "Korisnicko ime")]
        
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "zapamti me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public IEnumerable<SmerModel> Smerovi { get; set; }
        public IEnumerable<IdentityRole> Uloge { get; set; }
        public IEnumerable<SkolaModel> Skole { get; set; }
        public IEnumerable<StrucnaSpremaModel> StrucneSpreme { get; set; }
        public int SelektovanaSkola { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        public int? GodinaUpisa { get; set; }
        public string SelektovanaSS { get; set; }
        public int selektovaniSmer { get; set; }
        public string selektovanaUloga { get; set; }

        [Required(ErrorMessage ="Morate uneti email!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Morate uneti ime!")]
        
        public string Ime { get; set; }
        [Required(ErrorMessage = "Morate uneti prezime!")]
        public string Prezime { get; set; }
        

        
        
    }

    public class IzmeniKorisnikaViewModel
    {
        public ApplicationUser Korisnik {get; set;}

        public IEnumerable<SmerModel> Smerovi { get; set; }
        public IEnumerable<IdentityRole> Uloge { get; set; }
        public IEnumerable<SkolaModel> Skole { get; set; }
        public IEnumerable<StrucnaSpremaModel> StrucneSpreme { get; set; }

    }
    public class DetaljiKorisnikaViewModel
    {
        public ApplicationUser Korisnik { get; set; }

        public string SelektovaniSmer { get; set; }
        
        public string SelektovanaSkola { get; set; }
        

    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Vaš email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda nove lozinke")]
        [Compare("Password", ErrorMessage = "Ponudjene sifre se ne podudaraju.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
