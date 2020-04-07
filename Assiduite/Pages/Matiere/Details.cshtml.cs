using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Matiere
{
    public class DetailsModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public DetailsModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Matiere Matiere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Matiere = await _context.matiere.FirstOrDefaultAsync(m => m.Id_Mat == id);

            if (Matiere == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
