using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assiduite.Models
{
    public class Filiere
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Fil { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un nom de filière")]
        [Display(Name = "Nom Filière")]
        public string Nom_Fil { get; set; }
        [Required(ErrorMessage = "Veuillez fournir une année de filière")]
        [Range(1, 5, ErrorMessage = "L'année de la filière doit être entre 1 et 5")]
        [Display(Name = "Année Filière")]
        public int Annee_Fil { get; set; }
        /* Annee : 
         * 1 : 1 er année   ***  2 : 2 ème  année ***  3 : 3 ème  année ***  4 : 4 ème  année ***  5 : 5 ème  année
        */
    }
}
