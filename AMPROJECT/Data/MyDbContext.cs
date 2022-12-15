using AMPROJECT.Models;
using AMPROJECT.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMPROJECT.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Panier>().HasKey(p => new { p.UserId, p.FilmId });
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new UserWithRoleConfiguration());




            modelBuilder.Entity<Film>()
           .HasMany(left => left.Acteurs)
           .WithMany(right => right.Films)
           .UsingEntity(join => join.ToTable("FilmsActeurs"));

            // modelBuilder.Entity<Livre>()
            //.HasMany(left => left.Auteurs)
            //.WithMany(right => right.Livres)
            //.UsingEntity(join => join.ToTable("LivresAuteurs"));

            // modelBuilder.Entity<User>()
            //.HasKey(left => left.Paniers)
            //.WithKey(right => right.Users)
            //.UsingEntity(join => join.ToTable("UsersPaniers"));
        }


        public DbSet<Film> Films { get; set; }
        public DbSet<Livre> Livres { get; set; }

        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }


        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<User> Users1 { get; set; }








    }


}
