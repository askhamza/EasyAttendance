using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Assiduite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public class InputModel
        {
            [Display(Name = "Matricule")]
            [Required(ErrorMessage = "Veuillez Saisir votre matricule")]
            public string Mat_User { get; set; }

            [Display(Name = "Salle")]
            [Required(ErrorMessage = "Choisir une Salle ")]
            public int Id_Salle { get; set; }
        }
        public IList<Models.Salle> _Salles { get;set; }
        public Utilisateur _user { get; set; }
        public Etudiant _etudiant { get; set; }
        public IList<Models.Seance> _seances { get; set; }
        public IList<Presence> _listePresence { get; set; }
        public Presence _etatEtudiant { get; set; }

        public IActionResult OnGet()
        {
            _Salles =  _db.salle.ToList();

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            return Page();
        }

       

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var matricule = Input.Mat_User;
            var salle = Input.Id_Salle;
            var LocaleDate = DateTime.Now.ToString("yyyy-dd-MM");
            var LocalHour = DateTime.Now.ToString("HH:mm");
            _user = _db.utilisateur.Where(u => u.Mat_User == matricule &&
                                          u.Type_User == "Etudiant").FirstOrDefault();
            if (salle == 0)
            {
                ModelState.AddModelError(string.Empty, "Choisir une salle ");
                return Page();
            }
            if (_user != null)
            {
                _etudiant = _db.etudiant.Where(u => u.Id_User_Etudiant == _user.Id).FirstOrDefault();
                _seances = _db.seance.Where(s => s.Id_Salle_Seance == salle &&
                                           s.Id_Fil_Seance == _etudiant.Id_Fil_Etudiant).ToList();

                foreach (var _seance in _seances)
                {
                    if ((string.Compare(LocalHour, _seance.HeureDebut_Seance)) >= 0 &&
                                      string.Compare(LocalHour, _seance.HeureFin_Seance) <= 0 &&
                                      string.Compare(LocaleDate, _seance.Date_Seance.ToString("yyyy-dd-MM")) == 0)
                    {
                        _etatEtudiant = _db.presence.Where(l => l.Id_Seance_Pres == _seance.Id_Seance &&
                                                  l.Id_Etudiant_Pres == _etudiant.Id_Etudiant).FirstOrDefault();
                        switch (_etatEtudiant.Etat_Pres)
                        {
                            case -1:
                                _listePresence = await _db.presence.Where(lp => lp.Id_Seance_Pres == _seance.Id_Seance).ToListAsync();
                                foreach (var etud in _listePresence)
                                {
                                    etud.Etat_Pres = 1;
                                    _db.SaveChanges();
                                }
                                _etatEtudiant.Etat_Pres = 2;
                                _db.SaveChanges();
                                break;
                            case 1:
                                _etatEtudiant.Etat_Pres = 2;
                                _db.SaveChanges();
                                break;
                            case 2:
                                ModelState.AddModelError(string.Empty, "Vous etes deja dans la salle de cours");
                                return Page();
                                break;
                        }
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Vous ne pouvez pas accèder au cours dans cette salle, " +
                            "Veuillez vérifier votre emploie de temps");
                        return Page();
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Matricule n'existe pas !!  Veuillez vérifier votre matricule ");
                return Page();
            }

            return Page();
        }
    }
}
