using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Seance
{
    public class CreateModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public CreateModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Id_Fil_Seance"] = new SelectList(_context.filiere, "Id_Fil", "Nom_Fil");
        ViewData["Id_Mat_Seance"] = new SelectList(_context.matiere, "Id_Mat", "Nom_Mat");
        ViewData["Id_Salle_Seance"] = new SelectList(_context.salle, "Id_Salle", "Nom_Salle");
        ViewData["Id_Prof_Seance"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.Seance Seance { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.seance.Add(Seance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
