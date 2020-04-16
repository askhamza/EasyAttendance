using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assiduite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Salle> Salles { get;set; }

        public async Task OnGetAsync()
        {
            Salles = await _context.salle.ToListAsync();
            ViewData["Id_Salle"] = new SelectList(_context.salle, "Id_Salle", "Nom_Salle");
            
        }
    }
}
