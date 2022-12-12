using AMPROJECT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AMPROJECT.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Panier>().HasKey(p => new { p.UserId, p.FilmId });




            modelBuilder.Entity<Panier>()
           .HasMany(left => left.FilmPaniers)
           .WithMany(right => right.Paniers)
           .UsingEntity(join => join.ToTable("FilmsPaniers"));

            modelBuilder.Entity<Film>()
           .HasMany(left => left.Acteurs)
           .WithMany(right => right.Films)
           .UsingEntity(join => join.ToTable("FilmsActeurs"));

            modelBuilder.Entity<Livre>()
          .HasMany(left => left.Auteurs)
          .WithMany(right => right.Livres)
          .UsingEntity(join => join.ToTable("LivresAuteurs"));

            modelBuilder.Entity<User>()
         .HasMany(left => left.Paniers)
         .WithMany(right => right.Users)
         .UsingEntity(join => join.ToTable("UsersPaniers"));
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Livre> Livres { get; set; }

        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }


        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<User> Users { get; set; }





    }
}
