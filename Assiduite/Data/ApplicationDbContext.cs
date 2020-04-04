using System;
using System.Collections.Generic;
using System.Text;
using Assiduite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assiduite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Utilisateur> utilisateur { get; set; }
        public DbSet<Matiere> matiere { get; set; }
        public DbSet<Filiere> filiere { get; set; }
        public DbSet<Etudiant> etudiant { get; set; }
        public DbSet<Salle> salle { get; set; }
        public DbSet<Seance> seance { get; set; }
        public DbSet<Presence> presence { get; set; }
    }
}
