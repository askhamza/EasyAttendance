using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Filliere
{
    public class DeleteModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public DeleteModel(Assiduite.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filiere = await _context.filiere.FindAsync(id);

            if (Filiere != null)
            {
                _context.filiere.Remove(Filiere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
