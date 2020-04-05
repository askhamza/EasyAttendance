using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public DeleteModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etudiant = await _context.etudiant
                .Include(e => e.Filiere)
                .Include(e => e.User).FirstOrDefaultAsync(m => m.Id_Etudiant == id);

            if (Etudiant == null)
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

            Etudiant = await _context.etudiant.FindAsync(id);

            if (Etudiant != null)
            {
                _context.etudiant.Remove(Etudiant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
