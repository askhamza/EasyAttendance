using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assiduite.Data;
using Assiduite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Assiduite.Pages.Profil
{
    [Authorize]
    public class IndexModel : PageModel
    {
      private readonly UserManager<IdentityUser> _userManager;
      private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;

        public IndexModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        ApplicationDbContext db,
        ILogger<IndexModel> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
        _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }
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
            public string Mat_User { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
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

            public string Nom_Fil{ get; set; }

            [Display(Name = "Tél")]
            [Required(ErrorMessage = "Le Champ du numero de téléphone est vide !! ")]
            public string PhoneNumber { get; set; }
        }
        public Utilisateur _user { get; set; }
        public Models.Filiere _filiere { get; set; }
        public Etudiant _etud { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }
            _user = _db.utilisateur.Where(e => e.Id == user.Id).FirstOrDefault();
            if(_user.Type_User == "Etudiant")
            {
                _etud = _db.etudiant.Where(e => e.Id_User_Etudiant == _user.Id).FirstOrDefault();
                _filiere = _db.filiere.Where(f => f.Id_Fil == _etud.Id_Fil_Etudiant).FirstOrDefault();
            }
            return Page();
            
        }
        public ActionResult OnPostAddPhone(Utilisateur _user, string id)
        {
            var user = _db.utilisateur.Find(id);
            user.PhoneNumber = _user.PhoneNumber;
            _db.SaveChanges();
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostChangePwd()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }
            */
            //var user = _db.utilisateur.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{user.Id}'.");
            }

           var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
           // await _signInManager.RefreshSignInAsync(user);
            //_logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostAsync(Utilisateur user , string id)
         {
            var nom = user.Nom_User;
            var prenom = user.Prenom_User;
            var email = user.Email;
            var _user = _db.utilisateur.Find(id);
            if (_user != null)
            {
                _user.Nom_User = nom;
                _user.Prenom_User = prenom;
                _user.Email = email;
                _db.SaveChanges();
            }
            StatusMessage = "Your profile has been updated";
            return RedirectToPage("./Profil");
        }
}
}