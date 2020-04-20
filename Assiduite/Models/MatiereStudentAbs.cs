using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assiduite.Models
{
    public class MatiereStudentAbs
    {
        public List<StudentAbs> std;
        public Matiere mtd;

        public MatiereStudentAbs(Matiere _mtd , List<StudentAbs> _std)
        {
            mtd = _mtd; std = _std;
        }
    }
}
