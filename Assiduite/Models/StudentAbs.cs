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
        public Utilisateur Student { get; set; }
        public int NbrAbs { get; set; }
        public int TauxAbs { get; set; }
        public StudentAbs(Utilisateur _etudiant , int nbrAbs, int tauxAbs)
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
