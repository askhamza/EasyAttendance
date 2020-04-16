using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Seance
{
    public class DetailsModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public DetailsModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
