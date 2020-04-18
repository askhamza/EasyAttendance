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

        public MatiereSeance( Matiere _Matiere , List<Seance> _Seance)
        {
            if (_Seance == null) Seance = null;
            else Seance = _Seance;
            
            Matiere = _Matiere;
        }

    }
}
