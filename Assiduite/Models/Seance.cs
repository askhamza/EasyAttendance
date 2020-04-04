﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Assiduite.Models
{
    public class Seance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Seance { get; set; }
        public int Id_Mat_Seance { get; set; }
        [ForeignKey("Id_Mat_Seance")]
        public Matiere Matriere { get; set; }
        public string Id_Prof_Seance { get; set; }
        [ForeignKey("Id_Prof_Seance")]
        public IdentityUser User { get; set; }
        public int Id_Fil_Seance { get; set; }
        [ForeignKey("Id_Fil_Seance")]
        public Filiere Filiere { get; set; }
        public int Id_Salle_Seance { get; set; }
        [ForeignKey("Id_Salle_Seance")]
        public Salle Salle { get; set; }
        [Display(Name = "Heure  Debut de Seance")]
        [Required(ErrorMessage = "Veuillez fournir une heure de début de la seance")]
        public DateTime HeureDebut_Seance { get; set; }
        [Display(Name = "Heure Fin de Seance")]
        [Required(ErrorMessage = "Veuillez fournir une heure de fin de la seance")]
        public DateTime HeureFin_Seance { get; set; }
        [Display(Name = "Date de Seance")]
        [Required(ErrorMessage = "Veuillez fournir une date de la seance")]
        public DateTime Date_Seance { get; set; }
    }
}
