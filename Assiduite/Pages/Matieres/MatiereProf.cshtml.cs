using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assiduite.Pages.Matieres
{
    public class MatiereProfModel : PageModel
    {
        public readonly Assiduite.Data.ApplicationDbContext _context;

        public MatiereProfModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.SeancePresence> _MatieresPres { get; set; }
        public List<Models.MatiereStudentAbs> _MtdAbs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _MatieresPres = new List<Models.SeancePresence>();
            var Seances = await _context.seance
                                        .Where(s => s.Id_Prof_Seance == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
                                        .Include(s => s.Matriere)
                                        .Include(s => s.Filiere)
                                        .ToArrayAsync();

            var SpecSeances = Seances.OrderBy(s => s.Date_Seance)
                                        .GroupBy(s => s.Id_Mat_Seance)
                                        .Select(x => x.First());


            foreach ( var seance in SpecSeances)
            {
                var Pres = await _context.presence
                                    .Include(p => p.Seance)
                                    .Include(p => p.Etudiant)
                                    .ToListAsync();

                var nbrAbs = Pres.Where(p => p.Etat_Pres == -1).Count();


                _MatieresPres.Add( new Models.SeancePresence(seance, Pres, nbrAbs, ((double)nbrAbs / (double)Pres.Count()) * 100));

            }

            _MtdAbs = new List<Models.MatiereStudentAbs>();
            foreach( var seance in SpecSeances)
            {
                var Etudiant = await _context.etudiant
                                            .Where(e => e.Id_Fil_Etudiant == seance.Id_Fil_Seance)
                                            .Include(e => e.User)
                                            .Include(e => e.Filiere)
                                            .ToArrayAsync();
                List<Models.StudentAbs> Students = new List<Models.StudentAbs>();

                var multiSeances = await _context.seance
                                                        .Where(s => s.Id_Mat_Seance == seance.Id_Mat_Seance)
                                                        .Where(s => s.Id_Fil_Seance == seance.Id_Fil_Seance)
                                                        .ToArrayAsync();
                
                foreach ( var S in Etudiant)
                {
                    int nbrAbs = 0, nbrSeance = 0;
                    foreach ( var _seance in multiSeances)
                    {
                        var value = _context.presence.Where(p => p.Id_Seance_Pres == _seance.Id_Seance)
                                            .Where(p => p.Id_Etudiant_Pres == S.Id_Etudiant)
                                            .ToArray();
                        if( value.Count() != 0)
                        {
                            switch( value[0].Etat_Pres)
                            {
                                case 1: nbrAbs++; nbrSeance++; break;
                                case 2: nbrSeance++; break;
                            }
                        }
                        
                    }

                    Students.Add(new Models.StudentAbs(S , nbrAbs, ((double)nbrAbs / (double)nbrSeance) * 100));
                }

                _MtdAbs.Add(new Models.MatiereStudentAbs(seance.Matriere,Students));

            }

            return Page();
        }
    }
}