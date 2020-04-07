using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Assiduite.Data;
using Assiduite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Assiduite.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
       // private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            //IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
          //  _emailSender = emailSender;
            _roleManager = roleManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Display(Name = "Matricule d'utilisateur")]
            [Required(ErrorMessage = "Veuillez fournir un matricule")]
            public string Mat_User { get; set; }

            [Display(Name = "Nom d'utilisateur")]
            [Required(ErrorMessage = "Veuillez fournir un nom d'utilisateur")]
            public string Nom_User { get; set; }

            [Display(Name = "Prenom d'utilisateur")]
            [Required(ErrorMessage = "Veuillez fournir un pr�nom d'utilisateur")]
            public string Prenom_User { get; set; }

            [Display(Name = "Type d'utilisateur")]
            [Required(ErrorMessage = "Veuillez affecter � cet utilisateur un type")]
            public string Type_User { get; set; } // Admin ***  Prof  ***  Etudiant 
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Utilisateur {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nom_User = Input.Nom_User,
                    Prenom_User = Input.Prenom_User,
                    Mat_User = Input.Mat_User,
                    Type_User = Input.Type_User,
                  };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if ( !await _roleManager.RoleExistsAsync(GestionRole.AdminUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(GestionRole.AdminUser));
                    }

                    if ( !await _roleManager.RoleExistsAsync(GestionRole.EtudUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(GestionRole.EtudUser));
                    }

                    if ( !await _roleManager.RoleExistsAsync(GestionRole.ProfUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(GestionRole.ProfUser));

                    }

                    if(user.Type_User == "E") { 
                    await _userManager.AddToRoleAsync(user, GestionRole.EtudUser);
                    }
                    else  if (user.Type_User == "A") { 
                    await _userManager.AddToRoleAsync(user, GestionRole.AdminUser);
                    }
                    else if (user.Type_User == "P") { 
                    await _userManager.AddToRoleAsync(user, GestionRole.ProfUser);
                    }

                    _logger.LogInformation("User created a new account with password.");

                    /*var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {*/
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                   // }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
