﻿// <auto-generated />
using System;
using AMPROJECT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AMPROJECT.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221213112435_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AMPROJECT.Models.Acteur", b =>
                {
                    b.Property<int>("ActeurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActeurId"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActeurId");

                    b.ToTable("Acteurs");
                });

            modelBuilder.Entity("AMPROJECT.Models.Auteur", b =>
                {
                    b.Property<int>("AuteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuteurId"));

                    b.Property<string>("Biographie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuteurId");

                    b.ToTable("Auteurs");
                });

            modelBuilder.Entity("AMPROJECT.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AMPROJECT.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("AMPROJECT.Models.Livre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Livres");
                });

            modelBuilder.Entity("AMPROJECT.Models.Panier", b =>
                {
                    b.Property<int>("PanierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PanierId"));

                    b.HasKey("PanierId");

                    b.ToTable("Panier");
                });

            modelBuilder.Entity("AMPROJECT.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActeurFilm", b =>
                {
                    b.Property<int>("ActeursActeurId")
                        .HasColumnType("int");

                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.HasKey("ActeursActeurId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("FilmsActeurs", (string)null);
                });

            modelBuilder.Entity("AuteurLivre", b =>
                {
                    b.Property<int>("AuteursAuteurId")
                        .HasColumnType("int");

                    b.Property<int>("LivresId")
                        .HasColumnType("int");

                    b.HasKey("AuteursAuteurId", "LivresId");

                    b.HasIndex("LivresId");

                    b.ToTable("LivresAuteurs", (string)null);
                });

            modelBuilder.Entity("FilmPanier", b =>
                {
                    b.Property<int>("FilmPaniersId")
                        .HasColumnType("int");

                    b.Property<int>("PaniersPanierId")
                        .HasColumnType("int");

                    b.HasKey("FilmPaniersId", "PaniersPanierId");

                    b.HasIndex("PaniersPanierId");

                    b.ToTable("FilmsPaniers", (string)null);
                });

            modelBuilder.Entity("LivrePanier", b =>
                {
                    b.Property<int>("LivrePaniersId")
                        .HasColumnType("int");

                    b.Property<int>("PaniersPanierId")
                        .HasColumnType("int");

                    b.HasKey("LivrePaniersId", "PaniersPanierId");

                    b.HasIndex("PaniersPanierId");

                    b.ToTable("LivrePanier");
                });

            modelBuilder.Entity("PanierUser", b =>
                {
                    b.Property<int>("PaniersPanierId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PaniersPanierId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersPaniers", (string)null);
                });

            modelBuilder.Entity("AMPROJECT.Models.Film", b =>
                {
                    b.HasOne("AMPROJECT.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("AMPROJECT.Models.Livre", b =>
                {
                    b.HasOne("AMPROJECT.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("ActeurFilm", b =>
                {
                    b.HasOne("AMPROJECT.Models.Acteur", null)
                        .WithMany()
                        .HasForeignKey("ActeursActeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMPROJECT.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuteurLivre", b =>
                {
                    b.HasOne("AMPROJECT.Models.Auteur", null)
                        .WithMany()
                        .HasForeignKey("AuteursAuteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMPROJECT.Models.Livre", null)
                        .WithMany()
                        .HasForeignKey("LivresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmPanier", b =>
                {
                    b.HasOne("AMPROJECT.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmPaniersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMPROJECT.Models.Panier", null)
                        .WithMany()
                        .HasForeignKey("PaniersPanierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LivrePanier", b =>
                {
                    b.HasOne("AMPROJECT.Models.Livre", null)
                        .WithMany()
                        .HasForeignKey("LivrePaniersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMPROJECT.Models.Panier", null)
                        .WithMany()
                        .HasForeignKey("PaniersPanierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PanierUser", b =>
                {
                    b.HasOne("AMPROJECT.Models.Panier", null)
                        .WithMany()
                        .HasForeignKey("PaniersPanierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMPROJECT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
