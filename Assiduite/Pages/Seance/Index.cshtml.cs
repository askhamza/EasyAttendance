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
using Microsoft.AspNetCore.Authorization;

namespace Assiduite.Pages.Seance
{
    [Authorize]
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
        public List<Models.Seance> _seances { get; set; }
        public List<Models.Filiere> _filieres { get; set; }
        public List<Models.Matiere> _matieres { get; set; }
        public List<Models.Salle> _salles { get; set; }
        public List<Models.Utilisateur> _profs { get; set; }

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

            _seances = new List<Models.Seance>();
            _filieres = new List<Models.Filiere>();
            _matieres = new List<Models.Matiere>();
            _salles = new List<Models.Salle>();
            _profs = new List<Models.Utilisateur>();


            _seances = _context.seance.ToList();
            _filieres = _context.filiere.ToList();
            _matieres = _context.matiere.ToList();
            _salles = _context.salle.ToList();
            _profs = _context.utilisateur.Where(e => e.Type_User == "Professeur").ToList();

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
