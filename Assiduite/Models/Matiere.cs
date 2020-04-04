using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assiduite.Models
{
    public class Matiere
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Mat { get; set; }
        [Required(ErrorMessage = "Veuillez fournir un Nom de Matière")]
        [Display(Name = "Nom Matiere")]
        public string Nom_Mat { get; set; }
    }
}
