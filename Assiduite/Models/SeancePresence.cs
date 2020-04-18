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

        public SeancePresence(Seance _Seance, List<Presence> _Presence)
        {
            if (_Presence == null) Presences = null;
            else Presences = _Presence;

            Seance = _Seance;
        }
    }
}
