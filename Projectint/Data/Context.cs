using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using Epione.Data.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;
using Data.CustomConventions;

namespace Data
{
    public class Context : IdentityDbContext<User, CustomRole, int, CustomLogin, CustomUserRole, CustomUserClaim>
    {
        public static Context Create()
        {
            return new Context();

        }
        public Context() : base("name=BD")
        {

        }
        //les dbsets
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

        public DbSet<Admin> Admins { get; set; }
        //  public DbSet<Address> Adress { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilitys { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Path> Paths { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Raiting> Raitings { get; set; }
        public DbSet<Speciality> Specialites { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasRequired(s => s.Raiting).WithRequiredPrincipal(ad => ad.Appointment);
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Conventions.Add(new DateTime2Convention());
            //modelBuilder.Entity<Post>()
    //.HasRequired(c => c.user)
    //.WithMany()
    //.WillCascadeOnDelete(false);
    //        modelBuilder.Entity<Comment>()
   //.HasRequired(c => c.user)
   //.WithMany()
   //.WillCascadeOnDelete(false);



        }




    }
}
