using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Assiduite.Models
{
    public class Etudiant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Etudiant { get; set; }
        public string Id_User_Etudiant { get; set; } // user de type Etudiant 
        [ForeignKey("Id_User_Etudiant")]
        public IdentityUser User { get; set; }
        public int Id_Fil_Etudiant { get; set; } // id de filiere d'etudiant 
        [ForeignKey("Id_Fil_Etudiant")]
        public Filiere Filiere { get; set; }
    }
}
