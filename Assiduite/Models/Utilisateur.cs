using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assiduite.Models
{
    public class Utilisateur : IdentityUser
    {
        [Display(Name = "Matricule d'utilisateur")]
        [Required(ErrorMessage = "Veuillez fournir un matricule")]
        public string Mat_User { get; set; }

        [Display(Name = "Nom d'utilisateur")]
        [Required(ErrorMessage = "Veuillez fournir un nom d'utilisateur")]
        public string Nom_User { get; set; }

        [Display(Name = "Prenom d'utilisateur")]
        [Required(ErrorMessage = "Veuillez fournir un prénom d'utilisateur")]
        public string Prenom_User { get; set; }

        [Display(Name = "Type d'utilisateur")]
        [Required(ErrorMessage = "Veuillez affecter à cet utilisateur un type")]
        public string Type_User { get; set; } // Admin ***  Prof  ***  Etudiant 
    }
}
