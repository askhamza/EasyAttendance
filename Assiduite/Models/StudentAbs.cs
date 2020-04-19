using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assiduite.Models
{
    public class StudentAbs
    {
        public Etudiant Student { get; set; }
        public int NbrAbs { get; set; }
        public double TauxAbs { get; set; }
        public StudentAbs(Etudiant _etudiant , int nbrAbs, double tauxAbs)
        {
            if (_etudiant == null)
            {
                Student = null;
                NbrAbs = nbrAbs;
                TauxAbs = tauxAbs;
            }
            else
            {
                Student = _etudiant;
                NbrAbs = nbrAbs;
                TauxAbs = tauxAbs;
            }
        }
    }
}
