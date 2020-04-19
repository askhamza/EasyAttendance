using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assiduite.Pages.Matieres
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Matiere> Matieres { get;set; }

        [BindProperty]
        public Matiere Matiere { get; set; }

        public IList<MatiereSeance> _Matieres { get; set; }

        public async Task<IActionResult> OnGetAsync( int? id)
        {
            Matieres = await _context.matiere
                .ToListAsync();

            _Matieres = new List<MatiereSeance>();

            foreach( var Mat in Matieres)
            {
                var seance = _context.seance.Where(s => s.Id_Mat_Seance == Mat.Id_Mat)
                                                                            .Include(s => s.Filiere)
                                                                            .ToList();

                _Matieres.Add(new MatiereSeance( Mat, seance ) );
            }

            if( id != null)
            {
                Matiere = await _context.matiere.FirstOrDefaultAsync(m => m.Id_Mat == id);

                if (Matiere == null)
                {
                    return NotFound();
                }
            }

            ViewData["_Matieres"] = _Matieres;

            return Page();
        }

        //CREATE
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                Matieres = await _context.matiere.ToListAsync();
                return Page();
            }

            _context.matiere.Add(Matiere);
            await _context.SaveChangesAsync();


            return Redirect("/Matieres");
        }

        //Update
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                Matieres = await _context.matiere.ToListAsync();
                return Page();
            }

            _context.Attach(Matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(Matiere.Id_Mat))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("/Matieres");
        }

        private bool MatiereExists(int id)
        {
            return _context.matiere.Any(e => e.Id_Mat == id);
        }

        //Delete
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                Matieres = await _context.matiere.ToListAsync();
                return NotFound();
            }

            Matiere = await _context.matiere.FindAsync(id);

            if (Matiere != null)
            {
                _context.matiere.Remove(Matiere);
                await _context.SaveChangesAsync();
            }

            return Redirect("/Matieres");
        }

    }
}
