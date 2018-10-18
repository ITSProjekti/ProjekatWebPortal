using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Projekat.Models;
using System.Collections.Generic;
using Projekat.ViewModels;
using System.Security.Cryptography;


namespace Projekat.Controllers
{
    /// <summary>
    /// Account kontroler
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        public PartialViewResult LoggedUserData()
        {
            ApplicationUser user = UserManager.FindByName(this.User.Identity.Name);
            LoggedUserViewModel lu;
            if (user != null)
            {
                lu = new LoggedUserViewModel
                {
                    Username = user.UserName,
                    slika = user.Slika,
                    Role = user.Uloga
                };
                return PartialView(lu);
            }
            this.LogOff();
            return null;
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public ActionResult Register()
        {
            RegisterViewModel ViewModel = new RegisterViewModel();

            MaterijalContext matcont = new MaterijalContext();
            ViewModel.Skole = matcont.Skole.ToList();
            ViewModel.Smerovi = matcont.smerovi.ToList();
            ViewModel.Uloge = matcont.Roles.ToList();
            return View(ViewModel);

        }
        /// <summary>
        /// Vraca view sa formom za izmenu korisnika
        /// </summary>
        /// <param name="ID">Id korisnika kog zelimo da izmenimo.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public ActionResult IzmeniKorisnika(string ID)
        {
            if (ID != null)
            {
                IzmeniKorisnikaViewModel ViewModel = new IzmeniKorisnikaViewModel();

                MaterijalContext matcon = new MaterijalContext();

                ViewModel.Uloge = matcon.Roles.ToList();
                ViewModel.Skole = matcon.Skole.ToList();
                ViewModel.Smerovi = matcon.smerovi.ToList();

                ApplicationUser Korisnik = UserManager.FindById(ID);
                if (Korisnik != null)
                {
                    ViewModel.Korisnik = Korisnik;
                    return View(ViewModel);
                }
                else
                {
                    return RedirectToAction("ListaKorisnika");
                }
            }
            else
            {
                return RedirectToAction("ListaKorisnika");
            }
        }
        /// <summary>
        /// Vrsi izmenu korisnika.
        /// </summary>
        /// <param name="model">Model u kome se drze novi podaci o korisniku. <seealso cref="IzmeniKorisnikaViewModel"/></param>
        /// <param name="Fajl">Nova slika korisnika. Ukoliko se prosledi null, ostaje stara slika</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<ActionResult> IzmeniKorisnika(IzmeniKorisnikaViewModel model, HttpPostedFileBase Fajl)
        {

            if (ModelState.IsValid)
            {

                MaterijalContext context = new MaterijalContext();
                ApplicationUser user;
                user = model.Korisnik;

                ApplicationUser postojeci = UserManager.FindByName(model.Korisnik.UserName);
                if (postojeci != null)
                {
                    if ((postojeci.Ime != user.Ime || postojeci.GodinaUpisa != user.GodinaUpisa || postojeci.SkolaId != user.SkolaId || user.SmerId != postojeci.SmerId) && user.Uloga == "Ucenik")
                    {
                        GenerisiUsername(user);
                        postojeci.UserName = user.UserName;
                        await UserManager.SendEmailAsync(postojeci.Id, "Promenjeno korisnicko ime", "Vase novo korisnicko ime za ulaz u web portal je " + user.UserName);
                    }
                    else if ((postojeci.Ime != user.Ime || postojeci.SkolaId != user.SkolaId || postojeci.Prezime != user.Prezime))
                    {
                        GenerisiUsername(user);
                        postojeci.UserName = user.UserName;
                        await UserManager.SendEmailAsync(postojeci.Id, "Promenjeno korisnicko ime", "Vase novo korisnicko ime za ulaz u web portal je " + user.UserName);
                    }
                    if (user.Uloga != postojeci.Uloga)
                    {
                        UserManager.RemoveFromRole(postojeci.Id, postojeci.Uloga);
                        UserManager.AddToRole(postojeci.Id, user.Uloga);
                    }
                    if (Fajl != null)
                    {
                        user.Slika = new byte[Fajl.ContentLength];
                        Fajl.InputStream.Read(user.Slika, 0, Fajl.ContentLength);
                    }
                    if (user.Slika != postojeci.Slika)
                    {
                        postojeci.Slika = user.Slika;
                    }
                    if (user.Uloga == "Ucenik")
                    {
                        postojeci.GodinaUpisa = user.GodinaUpisa;
                    }
                    else
                    {
                        postojeci.GodinaUpisa = null;
                    }

                    postojeci.Ime = user.Ime;
                    postojeci.Email = user.Email;
                    postojeci.Prezime = user.Prezime;

                    postojeci.SkolaId = user.SkolaId;

                    postojeci.SmerId = user.SmerId;
                    postojeci.Uloga = user.Uloga;
                    postojeci.PhoneNumber = user.PhoneNumber;

                    UserManager.Update(postojeci);
                }


            }
            return RedirectToAction("ListaKorisnika");
        }

        /// <summary>
        /// Vraca nasumicnu sifru
        /// </summary>
        /// <param name="length">Duzina sifre koju funkcija generise.</param>
        /// <returns>string koji sadrzi random sifu <seealso cref="GetRandomString(int, IEnumerable{char})"/></returns>
        private static string GetRandomPassword(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }

        /// <summary>
        /// Vraca nasumicni string
        /// </summary>
        /// <param name="length">Duzina stringa za generisanje.</param>
        /// <param name="characterSet">Slova, brojevi i specijalni karakteri koji se mogu naci u generisanom stringu.</param>
        /// <returns>String zeljene duzine sastavljen od nasumicno odabranih karaktera iz prosledjene kolekcije</returns>
        /// <exception cref="System.ArgumentException">
        /// length must not be negative - length
        /// or
        /// length is too big - length
        /// or
        /// characterSet must not be empty - characterSet
        /// </exception>
        /// <exception cref="System.ArgumentNullException">characterSet</exception>
        private static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8)
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }

        //
        // POST: /Account/Register
        /// <summary>
        /// Registruje novog korisnika i salje mejl sa login informacijama korisnika.
        /// </summary>
        /// <param name="model">Model sa podacima korisnika kog zelimo da dodamo. <seealso cref="RegisterViewModel"/></param>
        /// <param name="Fajl">Slika korisnika. Ako je null, korisniku se dodeljuje default slika.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, HttpPostedFileBase Fajl)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user;

                user = new ApplicationUser
                {
                    UserName = model.Ime,
                    Email = model.Email,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    SkolaId = model.SelektovanaSkola,
                    SmerId = model.selektovaniSmer,
                    Uloga = model.selektovanaUloga,
                    PhoneNumber = model.phoneNumber



                };
                if (model.selektovanaUloga == "Ucenik")
                {
                    user.GodinaUpisa = model.GodinaUpisa;
                }
                else
                {
                    user.GodinaUpisa = null;
                }

                GenerisiUsername(user);

                if (Fajl != null)
                {
                    user.Slika = new byte[Fajl.ContentLength];
                    Fajl.InputStream.Read(user.Slika, 0, Fajl.ContentLength);
                }
                else
                {
                    user.Slika = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/img/Default.png"));
                }

                string password = GetRandomPassword(10);
                var result = await UserManager.CreateAsync(user, password);


                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, model.selektovanaUloga);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Login informacije", "Vase korisnicko ime za ulaz u web portal je " + user.UserName + " , a vasa lozinka je:  " + password + "  Lozinku mozete promeniti.");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            MaterijalContext matcont = new MaterijalContext();

            model.Skole = matcont.Skole.ToList();
            model.Smerovi = matcont.smerovi.ToList();
            model.Uloge = matcont.Roles.ToList();
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Geenerise username za prosledjenok korisnika
        /// </summary>
        /// <param name="user">Korisnik za koga zelimo da generisemo username</param>
        private void GenerisiUsername(ApplicationUser user)
        {
            ApplicationUser duplikat = null;
            MaterijalContext context = new MaterijalContext();
            string username = "";
            if (user.Uloga == "Ucenik")
            {
                username += user.Ime;
                username += context.Skole.Where(x => x.IdSkole == user.SkolaId).First().Skraceno;
                username += user.GodinaUpisa.ToString().Remove(0, 2);
                username += context.smerovi.Where(x => x.smerId == user.SmerId).First().smerSkraceno;
                int id = 1;
                string usernamesaID;
                do
                {
                    usernamesaID = username + id.ToString();
                    duplikat = UserManager.FindByName(usernamesaID);
                    id++;

                }
                while (duplikat != null);
                user.UserName = usernamesaID;
            }
            else
            {
                username += user.Ime;
                username += user.Prezime;
                username += context.Skole.Where(x => x.IdSkole == user.SkolaId).First().Skraceno;
                int id = 1;
                string usernamesaID;
                do
                {
                    usernamesaID = username + id.ToString();
                    duplikat = UserManager.FindByName(usernamesaID);
                    id++;

                }
                while (duplikat != null);
                user.UserName = usernamesaID;
            }
        }

        //
       
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        /// <summary>
        /// Akcija koja se poziva ako je korisnik zaboravio password.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        /// <summary>
        /// Salje korisniku mail sa odgovarajucim tookenom za rest passworda.
        /// </summary>
        /// <param name="model"><see cref="ForgotPasswordViewModel"/></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        /// <summary>
        /// Resetuje password korisnika.
        /// </summary>
        /// <param name="model">Model. <see cref="ResetPasswordViewModel"/></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        /// <summary>
        /// Vraca listu korisnika, sa mogucnoscu pretrage
        /// </summary>
        /// <param name="vm">Model u kome se nalaze detalji po kojima se vrsi pretraga. <seealso cref="ListaNaprednaPretragaViewModel"/></param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public ActionResult ListaKorisnika(ListaNaprednaPretragaViewModel vm)
        {
            MaterijalContext context = new MaterijalContext();
            ListaNaprednaPretragaViewModel ViewModel = new ListaNaprednaPretragaViewModel();
            List<SkolaModel> skole = context.Skole.ToList();
            List<SmerModel> smerovi = context.smerovi.ToList();
            ViewModel.Skole = skole.ToList();
            ViewModel.Smerovi = smerovi.ToList();
            ViewModel.Uloge = context.Roles.ToList();
            ViewModel.Korisnici = new List<ListaKorisnikaViewModel>();
            List<ListaKorisnikaViewModel> lista = new List<ListaKorisnikaViewModel>();
            List<ApplicationUser> useri;
            int? skolaId;


            if (User.IsInRole("SuperAdministrator"))
            {
                useri = context.Users.ToList();
            }
            else
            {
                skolaId = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)?.SkolaId;
                //useri = context.Users.Where(x => x.SkolaId == skolaId && x.Uloga != "Administrator" && x.Uloga != "SuperAdministrator").ToList();
                useri = context.Users.Where(x => x.SkolaId == skolaId ).ToList();
            }
            if (vm.FilterSkolaID != 0)
            {
                useri = useri.Where(x => x.SkolaId == vm.FilterSkolaID).ToList();
            }
            if (vm.FilterSmerID != 0)
            {
                useri = useri.Where(x => x.SmerId == vm.FilterSmerID).ToList();
            }
            if (vm.FilterUloga != null)
            {
                useri = useri.Where(x => x.Uloga == vm.FilterUloga).ToList();
            }

            #region dodavanje
            foreach (ApplicationUser a in useri)
            {
                SkolaModel s = skole.FirstOrDefault(x => x.IdSkole == a.SkolaId);
                SmerModel sm = smerovi.FirstOrDefault(c => c.smerId == a.SmerId);
                string Skola;
                string Smer;

                if (s != null)
                {
                    Skola = s.NazivSkole;
                }
                else
                {
                    Skola = "Nema";
                }
                if (sm != null)
                {
                    Smer = sm.smerNaziv;
                }
                else
                {
                    Smer = "Nema";
                }


                ViewModel.Korisnici.Add(new ListaKorisnikaViewModel
                {
                    UserName = a.UserName,
                    Prezime = a.Prezime,
                    BrojTelefona = a.PhoneNumber,
                    Skola = Skola,
                    Smer = Smer

                });


            }
            #endregion


            return View(ViewModel);
        }
        /// <summary>
        /// Vraca view sa detaljima korisnika
        /// </summary>
        /// <param name="Username">Username korisnika za koga zelimo da prikazemo detalje</param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdministrato,Administrator")]
        public ActionResult DetaljiKorisnika(string Username)
        {
            if (Username == null)
            {
                return RedirectToAction("ListaKorisnika", "Account");
            }
            MaterijalContext matCon = new MaterijalContext();
            DetaljiKorisnikaViewModel viewmodel = new DetaljiKorisnikaViewModel();

            viewmodel.Korisnik = UserManager.FindByName(Username);
            SkolaModel SelektovanaSkola;
            SmerModel SelektovaniSmer;

            if (viewmodel.Korisnik != null)
            {
                SelektovanaSkola = matCon.Skole.FirstOrDefault(x => x.IdSkole == viewmodel.Korisnik.SkolaId);
                SelektovaniSmer = matCon.smerovi.FirstOrDefault(x => x.smerId == viewmodel.Korisnik.SmerId);
                viewmodel.SelektovanaSkola = (SelektovanaSkola == null) ? "NemaSelektovaneSkole" : (SelektovanaSkola.NazivSkole);
                viewmodel.SelektovaniSmer = (SelektovaniSmer == null) ? "NemaSelektovanogSmera" : (SelektovaniSmer.smerNaziv);
                return View(viewmodel);

            }
            else
                return RedirectToAction("ListaKorisnika", "Account");

        }
        /// <summary>
        /// Brise korisnika
        /// </summary>
        /// <param name="ID">Id korisnika kog zelimo da obrisemo.</param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        [HttpPost]
        public ActionResult ObrisiKorisnika(string ID)
        {
            MaterijalContext matcon = new MaterijalContext();

            ApplicationUser Korisnik = UserManager.FindById(ID);

            if (Korisnik != null)
            {

                UserManager.Delete(Korisnik);
            }



            return RedirectToAction("ListaKorisnika");
        }
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}