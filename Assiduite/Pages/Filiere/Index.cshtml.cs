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

namespace Assiduite.Pages.Filiere
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Filiere> Filieres { get;set; }

        [BindProperty]
        public Models.Filiere Filiere { get; set; }

        public async Task<IActionResult> OnGetAsync( int? id)
        {
            Filieres = await _context.filiere.ToListAsync();

            if (id != null)
            {
                Filiere = await _context.filiere.FirstOrDefaultAsync(m => m.Id_Fil == id);

                if (Filiere == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        //CREATE
        public async Task<IActionResult> OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                Filieres = await _context.filiere.ToListAsync();
                return Page();
            }

            _context.filiere.Add(Filiere);
            await _context.SaveChangesAsync();

            Filieres = await _context.filiere.ToListAsync();

            return Page();
        }

        //Update
        public async Task<IActionResult> OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                Filieres = await _context.filiere.ToListAsync();
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

            Filieres = await _context.filiere.ToListAsync();

            return Page();
        }

        private bool FiliereExists(int id)
        {
            return _context.filiere.Any(e => e.Id_Fil == id);
        }

        //Delete
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                Filieres = await _context.filiere.ToListAsync();
                return NotFound();
            }

            Filiere = await _context.filiere.FindAsync(id);

            if (Filiere != null)
            {
                _context.filiere.Remove(Filiere);
                await _context.SaveChangesAsync();
            }

            Filieres = await _context.filiere.ToListAsync();

            return Page();
        }

    }
}
