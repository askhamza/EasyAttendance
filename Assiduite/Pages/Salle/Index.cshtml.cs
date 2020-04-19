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

namespace Assiduite.Pages.Salle
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Salle> Salles { get;set; }

        [BindProperty]
        public Models.Salle Salle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Salles = await _context.salle.ToListAsync();

            if (id != null)
            {
                Salle = await _context.salle.FirstOrDefaultAsync(m => m.Id_Salle == id);

                if (Salle == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        //CREATE
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                Salles = await _context.salle.ToListAsync();
                return Page();
            }

            _context.salle.Add(Salle);
            await _context.SaveChangesAsync();

            Salles = await _context.salle.ToListAsync();

            return Page();
        }

        //Update
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                Salles = await _context.salle.ToListAsync();
                return Page();
            }

            _context.Attach(Salle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalleExists(Salle.Id_Salle))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Salles = await _context.salle.ToListAsync();

            return Page();
        }

        private bool SalleExists(int id)
        {
            return _context.matiere.Any(e => e.Id_Mat == id);
        }

        //Delete
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                Salles = await _context.salle.ToListAsync();
                return NotFound();
            }

            Salle = await _context.salle.FindAsync(id);

            if (Salle != null)
            {
                _context.salle.Remove(Salle);
                await _context.SaveChangesAsync();
            }

            Salles = await _context.salle.ToListAsync();

            return Page();
        }
    }
}
