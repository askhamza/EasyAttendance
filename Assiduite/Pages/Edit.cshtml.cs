﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages
{
    public class EditModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public EditModel(Assiduite.Data.ApplicationDbContext context)
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
           ViewData["Id_Fil_Etudiant"] = new SelectList(_context.filiere, "Id_Fil", "Nom_Fil");
           ViewData["Id_User_Etudiant"] = new SelectList(_context.Users, "Id", "Id");
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

            _context.Attach(Etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(Etudiant.Id_Etudiant))
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

        private bool EtudiantExists(int id)
        {
            return _context.etudiant.Any(e => e.Id_Etudiant == id);
        }
    }
}
