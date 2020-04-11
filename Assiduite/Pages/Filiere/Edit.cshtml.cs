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

namespace Assiduite.Pages.Filliere
{
    public class EditModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public EditModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Filiere Filiere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filiere = await _context.filiere.FirstOrDefaultAsync(m => m.Id_Fil == id);

            if (Filiere == null)
            {
                return NotFound();
            }
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

            _context.Attach(Filiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiliereExists(Filiere.Id_Fil))
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

        private bool FiliereExists(int id)
        {
            return _context.filiere.Any(e => e.Id_Fil == id);
        }
    }
}
