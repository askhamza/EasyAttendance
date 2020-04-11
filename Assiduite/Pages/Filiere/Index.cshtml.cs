using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Filiere
{
    public class IndexModel : PageModel
    {
        //READ
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Filiere> Filieres { get;set; }

        [BindProperty]
        public Models.Filiere Filiere { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Filieres = await _context.filiere.ToListAsync();

            return Page();
        }

        //CREATE


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.filiere.Add(Filiere);
            await _context.SaveChangesAsync();

            Filieres = await _context.filiere.ToListAsync();

            return Page();
        }

    }
}
