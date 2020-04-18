﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assiduite.Pages
{
    public class DashAdminModel : PageModel
    {
        public readonly Assiduite.Data.ApplicationDbContext _context;

        public DashAdminModel(Assiduite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<double> AnneePourcentage_Abs { get; set; }
        public List<double> DayPourcentage_Abs { get; set; }
        public IList<Models.Seance> FutureSeance { get; set; }
        public IList<Models.Etudiant> Etudiants { get; set; }
                
        public async Task<IActionResult> OnGetAsync()
        {
            // Graph Nombre d'absence par filière
            var Pres = await _context.presence.Include( p => p.Etudiant.Filiere ).ToArrayAsync();
            AnneePourcentage_Abs = new List<double>();

            int Abs_Annee_1 = 0, Abs_Annee_2 = 0, Abs_Annee_3 = 0, Abs_Annee_4 = 0, Abs_Annee_5 = 0;

            foreach (var presence in Pres)
            {
                switch ( presence.Etudiant.Filiere.Annee_Fil )
                {
                    case 1 :
                        if (presence.Etat_Pres == 1) Abs_Annee_1++;
                        break;
                    case 2 :
                        if (presence.Etat_Pres == 1) Abs_Annee_2++;
                        break;
                    case 3 :
                        if (presence.Etat_Pres == 1) Abs_Annee_3++;
                        break;
                    case 4 :
                        if (presence.Etat_Pres == 1) Abs_Annee_4++;
                        break;
                    case 5 :
                        if (presence.Etat_Pres == 1) Abs_Annee_5++;
                        break;
                }
            }

            AnneePourcentage_Abs.Add( Abs_Annee_1 );
            AnneePourcentage_Abs.Add( Abs_Annee_2 );
            AnneePourcentage_Abs.Add( Abs_Annee_3 );
            AnneePourcentage_Abs.Add( Abs_Annee_4 );
            AnneePourcentage_Abs.Add( Abs_Annee_5 );

            // Graph Taux absence pour 5 derniers jours
            DayPourcentage_Abs = new List<double>();
            var Seances = await _context.seance.Where(s => s.Date_Seance < DateTime.Today )
                                                .Where( s => s.Date_Seance > DateTime.Today.AddDays(-5)  )
                                                .OrderBy( s => s.Date_Seance )
                                                .ToArrayAsync();
            int Som_Day1 = 0, Som_Day2 = 0, Som_Day3 = 0, Som_Day4 = 0, Som_Day5 = 0;
            double Abs_Day1 = 0, Abs_Day2 = 0, Abs_Day3 = 0, Abs_Day4 = 0, Abs_Day5 = 0;

            int D = Seances[0].Date_Seance.Day;

            foreach ( var Seance in Seances)
            {
                int index = Seance.Date_Seance.Day - D;

                var _Presences = await _context.presence.Where(p => p.Id_Seance_Pres == Seance.Id_Seance).ToArrayAsync();
                foreach( var p in _Presences)
                {
                    if( p.Etat_Pres == 1 )
                        switch( index)
                        {
                            case 0: Abs_Day1++; break;
                            case 1: Abs_Day2++; break;
                            case 2: Abs_Day3++; break;
                            case 3: Abs_Day4++; break;
                            case 4: Abs_Day5++; break;
                        }
                }

                switch (index)
                {
                    case 0: Som_Day1 += _Presences.Count(); break;
                    case 1: Som_Day2 += _Presences.Count(); break;
                    case 2: Som_Day3 += _Presences.Count(); break;
                    case 3: Som_Day4 += _Presences.Count(); break;
                    case 4: Som_Day5 += _Presences.Count(); break;
                }
            }

            DayPourcentage_Abs.Add((Som_Day1 != 0) ? (Abs_Day1 / Som_Day1 * 100) : 0);
            DayPourcentage_Abs.Add((Som_Day2 != 0) ? (Abs_Day2 / Som_Day2 * 100) : 0);
            DayPourcentage_Abs.Add((Som_Day3 != 0) ? (Abs_Day3 / Som_Day3 * 100) : 0);
            DayPourcentage_Abs.Add((Som_Day4 != 0) ? (Abs_Day4 / Som_Day4 * 100) : 0);
            DayPourcentage_Abs.Add((Som_Day5 != 0) ? (Abs_Day5 / Som_Day5 * 100) : 0);

            //Future séance
            FutureSeance = await _context.seance
                                    .Where(s => s.Date_Seance > DateTime.Today)
                                    .Include(s => s.Matriere)
                                    .Include(s => s.Filiere)
                                    .Include(s => s.Salle)
                                    .ToArrayAsync();

            //Absence Etudiant
            var Pres_Etudiant = await _context.presence.
                                        Where(p => p.Etat_Pres == 1)
                                        .OrderBy(p => p.Etat_Pres)
                                        .ToArrayAsync();

                                   
            return Page();
        }
    }
}