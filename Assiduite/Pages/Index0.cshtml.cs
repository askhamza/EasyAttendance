using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Assiduite.Models;

namespace Assiduite.Pages.Etudiants
{
    public class IndexStudentModel : PageModel
    {
        private readonly Assiduite.Data.ApplicationDbContext _context;

        public IndexStudentModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get;set; }

        public async Task OnGetAsync()
        {
            Etudiant = await _context.etudiant
                .Include(e => e.Filiere)
                .Include(e => e.User).ToListAsync();
        }
    }
}
