using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assiduite.Models
{
    public class SeancePresence
    {
        public List<Presence> Presences { get; set; }

        public Seance Seance { get; set; }
        public double tauxAbs { get; set; }
        public int nbrAbs { get; set; }

        public SeancePresence(Seance _Seance, List<Presence> _Presence , int _nbrAbs = 0 , double _taux = 0)
        {
            if (_Presence == null) Presences = null;
            else Presences = _Presence;
            
            nbrAbs = _nbrAbs;
            tauxAbs = _taux;
            Seance = _Seance;
        }

    }
}
