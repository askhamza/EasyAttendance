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

namespace Assiduite.Pages.Seance
{
    public class IndexModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Seance> Seances { get;set; }

        [BindProperty]
        public Models.Seance Seance { get; set; }

        public async Task<IActionResult> OnGetAsync( int? id )
        {
            Seances = await _context.seance
                .Include(s => s.Filiere)
                .Include(s => s.Matriere)
                .Include(s => s.Salle)
                .Include(s => s.User).ToListAsync();

            if( id != null)
            {
                Seance = await _context.seance
                .Include(s => s.Filiere)
                .Include(s => s.Matriere)
                .Include(s => s.Salle)
                .Include(s => s.User).FirstOrDefaultAsync(m => m.Id_Seance == id);

                if (Seance == null)
                {
                    return NotFound();
                }
            }

            List<Object> Filiere_List = new List<object>();
            foreach (var Filieres in _context.filiere)
                Filiere_List.Add(new
                {
                    Id = Filieres.Id_Fil,
                    Name = Filieres.Annee_Fil + " " + Filieres.Nom_Fil
                }); 
            ViewData["Id_Fil_Seance"] = new SelectList(Filiere_List, "Id", "Name");
            ViewData["Id_Mat_Seance"] = new SelectList(_context.matiere, "Id_Mat", "Nom_Mat");
            ViewData["Id_Salle_Seance"] = new SelectList(_context.salle, "Id_Salle", "Nom_Salle");

            List<Object> Prof_List = new List<object>();
            foreach (var Prof in _context.utilisateur.Where(e=> e.Type_User =="Professeur"))
                Prof_List.Add(new
                {
                    Id = Prof.Id,
                    Name = Prof.Nom_User + " " + Prof.Prenom_User
                });
            ViewData["Id_Prof_Seance"] = new SelectList( Prof_List , "Id", "Name" );

            return Page();
        }

        //CREATE
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                Seances = await _context.seance
                .Include(s => s.Filiere)
                .Include(s => s.Matriere)
                .Include(s => s.Salle)
                .Include(s => s.User).ToListAsync();

                return Redirect("/Seance");
            }

            _context.seance.Add(Seance);


            await _context.SaveChangesAsync();

            List<Etudiant> Etudiants = await _context.etudiant.Where(e => e.Id_Fil_Etudiant == Seance.Id_Fil_Seance).ToListAsync();

            foreach (Etudiant e in Etudiants)
            {
                var P = new Presence
                {
                    Id_Seance_Pres = Seance.Id_Seance,
                    Id_Etudiant_Pres = e.Id_Etudiant,
                    Etat_Pres = -1,
                };

                _context.presence.Add(P);

            }

            await _context.SaveChangesAsync();


            return Redirect("/Seance");
        }

        //UPDATE
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                Seances = await _context.seance
                .Include(s => s.Filiere)
                .Include(s => s.Matriere)
                .Include(s => s.Salle)
                .Include(s => s.User).ToListAsync();

                return Page();
            }

            _context.Attach(Seance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(Seance.Id_Seance))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("/Seance");
        }

        private bool SeanceExists(int id)
        {
            return _context.seance.Any(e => e.Id_Seance == id);
        }

        //DELETE
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                Seances = await _context.seance
                .Include(s => s.Filiere)
                .Include(s => s.Matriere)
                .Include(s => s.Salle)
                .Include(s => s.User).ToListAsync();

                return NotFound();
            }

            Seance = await _context.seance.FindAsync(id);

            if (Seance != null)
            {
                _context.seance.Remove(Seance);
                await _context.SaveChangesAsync();
            }

            return Redirect("/Seance");
        }
    }
}
