using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Seance
{
    public class EditModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public EditModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Seance Seance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seance = await _context.seance
                .Include(s => s.Filiere)
                .Include(s => s.Matriere)
                .Include(s => s.Salle)
                .Include(s => s.User).FirstOrDefaultAsync(m => m.Id_Seance == id);

            if (Seance == null)
            {
                return NotFound();
            }
           ViewData["Id_Fil_Seance"] = new SelectList(_context.filiere, "Id_Fil", "Nom_Fil");
           ViewData["Id_Mat_Seance"] = new SelectList(_context.matiere, "Id_Mat", "Nom_Mat");
           ViewData["Id_Salle_Seance"] = new SelectList(_context.salle, "Id_Salle", "Nom_Salle");
           ViewData["Id_Prof_Seance"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
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

            return RedirectToPage("./Index");
        }

        private bool SeanceExists(int id)
        {
            return _context.seance.Any(e => e.Id_Seance == id);
        }
    }
}
