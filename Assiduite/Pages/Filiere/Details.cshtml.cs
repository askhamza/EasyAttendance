﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Filliere
{
    public class DetailsModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public DetailsModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Filiere Filiere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filiere = await _context.filiere.FirstOrDefaultAsync(m => m.Id_Fil == id);

            if (Filiere == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
