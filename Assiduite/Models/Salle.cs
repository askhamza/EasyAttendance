using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assiduite.Models
{
    public class Salle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Salle { set; get; }
        [Display(Name = "Nomde la Salle")]
        [Required(ErrorMessage = "Veuillez fournir le Nom de la Salle ")]
        public string Nom_Salle { set; get; }
        [Display(Name = "Capacite de la Salle")]
        [Required(ErrorMessage = "Veuillez fournir la capacité de la Salle ")]
        public int Capacite_Salle { get; set; }
    }
}
