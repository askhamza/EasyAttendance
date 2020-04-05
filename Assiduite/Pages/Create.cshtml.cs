using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages
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
        ViewData["Id_Fil_Etudiant"] = new SelectList(_context.filiere, "Id_Fil", "Nom_Fil");
        ViewData["Id_User_Etudiant"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.etudiant.Add(Etudiant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
