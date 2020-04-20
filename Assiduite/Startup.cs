using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Assiduite.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Assiduite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            /* services.AddIdentity<IdentityUser , IdentityRole >(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddEntityFrameworkStores<ApplicationDbContext>();*/
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministrateurRole",
                    Policy => Policy.RequireRole("Administrateur"));
                options.AddPolicy("RequireProfesseurRole",
                    Policy => Policy.RequireRole("Professeur"));
                options.AddPolicy("RequireEtudiantRole",
                    Policy => Policy.RequireRole("Etudiant"));
            });
            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Etudiants", "RequireAdministrateurRole");
                    options.Conventions.AuthorizeFolder("/Utilisateurs", "RequireAdministrateurRole");
                    options.Conventions.AuthorizeFolder("/Matieres", "RequireAdministrateurRole");
                    options.Conventions.AuthorizeFolder("/Filiere", "RequireAdministrateurRole");
                    options.Conventions.AuthorizeFolder("/Salle", "RequireAdministrateurRole");
                    options.Conventions.AuthorizeFolder("/Seance", "RequireAdministrateurRole");
                    options.Conventions.AuthorizeFolder("/DashAdmin", "RequireAdministrateurRole");
                    options.Conventions.AuthorizeFolder("/DashProf", "RequireProfesseurRole");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account");

                });
                
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
