using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assiduite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assiduite.Pages.Matieres
{
    public class ListeSeanceModel : PageModel
    {
        public readonly Assiduite.Data.ApplicationDbContext _context;

        public ListeSeanceModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Seance> Seances { get; set; }
        public Models.Matiere Matiere { get; set; }
        public Models.Filiere Filiere { get; set;  }
        public List<Models.SeancePresence> Presences { get; set; }
        public IList<Etudiant> Etudiants { get; set; }

        public async Task<IActionResult> OnGetAsync( int? id)
        {
            if (id == null) return NotFound();

            var Seance = await _context.seance.Where(s => s.Id_Seance == id).ToListAsync();

            if (Seance.Count() != 0)
            {
                int id_Mat = Seance[0].Id_Mat_Seance;
                int id_Fil = Seance[0].Id_Fil_Seance;

                Presences = new List<SeancePresence>();
                Etudiants = await _context.etudiant
                                    .Include( e => e.User )
                                    .ToArrayAsync();
                Seances = await _context.seance.Where( s => s.Id_Fil_Seance == id_Fil)
                                    .ToListAsync();

                Matiere = await _context.matiere.FirstOrDefaultAsync( m => m.Id_Mat == id_Mat );
                Filiere = await _context.filiere.FirstOrDefaultAsync(f => f.Id_Fil == id_Fil);

                foreach( var _seance in Seances)
                {
                    var pres = _context.presence.Where( p => p.Id_Seance_Pres == _seance.Id_Seance )
                                                .Include( p => p.Etudiant )
                                                .ToList();

                    foreach( var Etudiant in pres)
                    {
                        int i = 0;
                    }

                    Presences.Add(new SeancePresence(_seance, pres));
                
                }
                
            }

            return Page();
        }
    }
}
