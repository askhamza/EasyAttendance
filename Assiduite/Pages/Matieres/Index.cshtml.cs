﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Matieres
{
    public class IndexModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Matiere> Matieres { get;set; }

        [BindProperty]
        public Matiere Matiere { get; set; }

        public async Task<IActionResult> OnGetAsync( int? id)
        {
            Matieres = await _context.matiere.ToListAsync();

            if( id != null)
            {
                Matiere = await _context.matiere.FirstOrDefaultAsync(m => m.Id_Mat == id);

                if (Matiere == null)
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
                Matieres = await _context.matiere.ToListAsync();
                return Page();
            }

            _context.matiere.Add(Matiere);
            await _context.SaveChangesAsync();

            Matieres = await _context.matiere.ToListAsync();

            return Page();
        }

        //Update
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                Matieres = await _context.matiere.ToListAsync();
                return Page();
            }

            _context.Attach(Matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(Matiere.Id_Mat))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Matieres = await _context.matiere.ToListAsync();

            return Page();
        }

        private bool MatiereExists(int id)
        {
            return _context.matiere.Any(e => e.Id_Mat == id);
        }

        //Delete
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                Matieres = await _context.matiere.ToListAsync();
                return NotFound();
            }

            Matiere = await _context.matiere.FindAsync(id);

            if (Matiere != null)
            {
                _context.matiere.Remove(Matiere);
                await _context.SaveChangesAsync();
            }

            Matieres = await _context.matiere.ToListAsync();

            return RedirectToPage("./Index");
        }
    }
}
