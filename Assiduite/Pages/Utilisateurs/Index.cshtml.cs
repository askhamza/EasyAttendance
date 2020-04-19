using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assiduite.Areas.Identity.Pages.Account;
using Assiduite.Data;
using Assiduite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assiduite.Pages.Utilisateurs
{
    [Authorize]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly ApplicationDbContext _db;

        public IList<Utilisateur> Utilisateur { get; set; }

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _db = db;
        }
        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            public string Mat_User { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Nom d'utilisateur")]
            [Required(ErrorMessage = "Veuillez fournir un nom d'utilisateur")]
            public string Nom_User { get; set; }

            [Display(Name = "Prenom d'utilisateur")]
            [Required(ErrorMessage = "Veuillez fournir un prénom d'utilisateur")]
            public string Prenom_User { get; set; }

            [Display(Name = "Type d'utilisateur")]
            [Required(ErrorMessage = "Veuillez affecter à cet utilisateur un type")]
            public string Type_User { get; set; } // Admin ***  Professeur  ***  Etudiant 
        }

        public ActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            return Page();
            //Utilisateur = await _db.utilisateur.Where(e=>e.Type_User != "Etudiant").ToListAsync();
         /*   ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            */
        }
        public Utilisateur _user { get; set; }
        public async Task<IActionResult> OnPostDelete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _user = await _db.utilisateur.FindAsync(id);

            if (_user != null)
            {
                _db.utilisateur.Remove(_user);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }


        public ActionResult OnPostEdit(Utilisateur _user, string id)
        {
            var item = _db.utilisateur.Find(id);
            item.Nom_User = _user.Nom_User;
            item.Prenom_User = _user.Prenom_User;
            item.Type_User = _user.Type_User;
            item.Email = _user.Email;
            _db.SaveChanges();
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if(Input.Type_User == "Null")
            {
                ModelState.AddModelError(string.Empty, "Choisir un type à votre utilisateur ");
                return Page();
            }
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                Utilisateur = await _db.utilisateur.ToListAsync();
                string mat = Input.Nom_User + '_' + Input.Prenom_User + '_' + RandomString();
                foreach (var item in Utilisateur)
                {
                    if (item.Mat_User == mat)
                    {
                        return Page();
                    }
                }
                var user = new Utilisateur
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nom_User = Input.Nom_User,
                    Prenom_User = Input.Prenom_User,
                    Mat_User = mat ,
                    Type_User = Input.Type_User,
                };
               
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(GestionRole.AdminUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(GestionRole.AdminUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(GestionRole.EtudUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(GestionRole.EtudUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(GestionRole.ProfUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(GestionRole.ProfUser));
                    }

                    if (user.Type_User == "E")
                    {
                        await _userManager.AddToRoleAsync(user, GestionRole.EtudUser);
                    }
                    else if (user.Type_User == "A")
                    {
                        await _userManager.AddToRoleAsync(user, GestionRole.AdminUser);
                    }
                    else if (user.Type_User == "P")
                    {
                        await _userManager.AddToRoleAsync(user, GestionRole.ProfUser);
                    }

                    _logger.LogInformation("User created a new account with password.");

                    
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToPage("./Index");
        }
    }
}