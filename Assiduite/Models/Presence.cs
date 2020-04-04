using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assiduite.Models
{
    public class Presence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Pres { get; set; }
        public int Id_Seance_Pres { get; set; }
        [ForeignKey("Id_Seance_Pres")]
        public Seance Seance { get; set; }
        public int Id_Etudiant_Pres { get; set; }
        [ForeignKey("Id_Etudiant_Pres")]
        public Etudiant Etudiant { get; set; }
        public Boolean Etat_Pres { get; set; } // true => prensent (1) | false => absent (0)
    }
}
