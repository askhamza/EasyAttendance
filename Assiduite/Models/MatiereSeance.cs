using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assiduite.Models
{
    public class MatiereSeance
    {
        public List<Seance> Seance { get; set; }

        public Matiere Matiere { get; set; }
        public double tauxAbs { get; set; }
        public int nbrAbs { get; set; }

        public MatiereSeance( Matiere _Matiere , List<Seance> _Seance, int _nbrAbs = 0, double _taux = 0)
        {
            if (_Seance == null) Seance = null;
            else Seance = _Seance;

            nbrAbs = _nbrAbs;
            tauxAbs = _taux;
            Matiere = _Matiere;
        }

    }
}
