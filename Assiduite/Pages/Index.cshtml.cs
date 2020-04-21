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
using Microsoft.AspNetCore.Identity;

namespace Assiduite.Pages
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db,
            UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
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
        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task<IActionResult> OnGetAsync()
        {
         
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            /*
            //Creation d'administrateur
            for( int i = 0; i < 5; i++)
            {
                var user = new Utilisateur
                {
                    UserName = "admin"+i + "@admin.com",
                    Email = "admin" + i + "@admin.com",
                    Nom_User = "admin" + i,
                    Prenom_User = "admin" + i,
                    Mat_User = "admin" + i,
                    Type_User = "Administrateur",
                };

                await _userManager.CreateAsync(user, "P@ssw0rd");
                await _userManager.AddToRoleAsync(user, GestionRole.AdminUser);

            }

            // Creation de prof
            for (int i = 0; i < 20; i++)
            {
                var user = new Utilisateur
                {
                    UserName = "prof" + i + "@admin.com",
                    Email = "prof" + i + "@admin.com",
                    Nom_User = "prof" + i,
                    Prenom_User = "prof" + i,
                    Mat_User = "prof" + i,
                    Type_User = "Professeur",
                };

                await _userManager.CreateAsync(user, "P@ssw0rd");
                await _userManager.AddToRoleAsync(user, GestionRole.ProfUser);

            }

            // CREATION DE FILIERE
            foreach ( var Filiere in _db.filiere.ToList())
            {
                List<Utilisateur> users = new List<Utilisateur>();
                for (int i = 0; i < 20; i++)
                {
                    var email = RandomString() + "@" + RandomString() + ".com";
                    var name = RandomString();
                    var prenom = RandomString();
                    string mat = name + '_' + prenom + '_' + RandomString();

                    users.Add(new Utilisateur
                    {
                        UserName = email,
                        Email = email,
                        Nom_User = name,
                        Prenom_User = prenom,
                        Mat_User = mat,
                        Type_User = "Etudiant",
                    });
                }

                foreach (var user in users)
                {
                    await _userManager.CreateAsync(user, "P@ssw0rd");
                    await _userManager.AddToRoleAsync(user, GestionRole.EtudUser);

                    _db.etudiant.Add(new Etudiant
                    {
                        Id_User_Etudiant = user.Id,
                        Id_Fil_Etudiant = Filiere.Id_Fil,
                    });
                }
            }
            _db.SaveChanges();
            
            // Creation de seance
            var prof = _db.utilisateur.Where(e => e.Type_User == "Professeur").ToList();
            var Fillieres = _db.filiere.ToList();
            var Salles = _db.salle.ToList();
            foreach ( var Matiere in _db.matiere.ToList())
            {
                List<Models.Seance> SeancesAv = new List<Models.Seance>();
                List<Models.Seance> SeancesAp = new List<Models.Seance>();

                int randomIndexProf = random.Next( prof.Count );
                int randomIndexSalle = random.Next(Salles.Count);
                Random rnd = new Random();
                
                int i = 1;
                foreach ( var Fil in Fillieres)
                {
                    var SeanceAv = new Models.Seance
                    {
                        Id_Prof_Seance = prof[randomIndexProf].Id,
                        Id_Fil_Seance = Fil.Id_Fil,
                        Id_Mat_Seance = Matiere.Id_Mat,
                        Id_Salle_Seance = Salles[randomIndexSalle].Id_Salle ,
                        HeureDebut_Seance = "10:00",
                        HeureFin_Seance = "12:00",
                        Date_Seance = DateTime.Today.AddDays( -i ),
                    };
                    var SeanceAp = new Models.Seance
                    {
                        Id_Prof_Seance = prof[randomIndexProf].Id,
                        Id_Fil_Seance = Fil.Id_Fil,
                        Id_Mat_Seance = Matiere.Id_Mat,
                        Id_Salle_Seance = Salles[randomIndexSalle].Id_Salle,
                        HeureDebut_Seance = "10:00",
                        HeureFin_Seance = "12:00",
                        Date_Seance = DateTime.Today.AddDays(i),
                    };

                    SeancesAv.Add(SeanceAv); SeancesAp.Add(SeanceAp);

                    _db.seance.Add(SeanceAv); _db.seance.Add(SeanceAp);
                    i++;
                }

                await _db.SaveChangesAsync();
                
                foreach( var Seance in SeancesAv)
                {
                    List<Etudiant> Etudiants = await _db.etudiant.Where(e => e.Id_Fil_Etudiant == Seance.Id_Fil_Seance).ToListAsync();

                    foreach (Etudiant e in Etudiants)
                    {
                        var etat = rnd.Next(1, 3);
                        var P = new Presence
                        {
                            Id_Seance_Pres = Seance.Id_Seance,
                            Id_Etudiant_Pres = e.Id_Etudiant,
                            Etat_Pres = etat,
                        };

                        _db.presence.Add(P);

                    }

                }

                foreach (var Seance in SeancesAp)
                {
                    List<Etudiant> Etudiants = await _db.etudiant.Where(e => e.Id_Fil_Etudiant == Seance.Id_Fil_Seance).ToListAsync();

                    foreach (Etudiant e in Etudiants)
                    {
                        var P = new Presence
                        {
                            Id_Seance_Pres = Seance.Id_Seance,
                            Id_Etudiant_Pres = e.Id_Etudiant,
                            Etat_Pres = -1,
                        };

                        _db.presence.Add(P);

                    }

                }

            }
            */
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
