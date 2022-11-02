﻿// <auto-generated />
using System;
using Film_Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Film_Catalog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221102181115_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.Genre", b =>
                {
                    b.Property<Guid>("Genre_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Genre_Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.JwtLoggedOutToken", b =>
                {
                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("JwtLoggedOutTokens");
                });

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.Movie", b =>
                {
                    b.Property<Guid>("Movie_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("integer");

                    b.Property<int?>("Budget")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Director")
                        .HasColumnType("text");

                    b.Property<int?>("Fees")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Poster")
                        .HasColumnType("text");

                    b.Property<string>("Tagline")
                        .HasColumnType("text");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.Property<int?>("Year")
                        .HasColumnType("integer");

                    b.Property<string>("country")
                        .HasColumnType("text");

                    b.HasKey("Movie_Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.Review", b =>
                {
                    b.Property<Guid>("Review_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorUser_Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("boolean");

                    b.Property<Guid>("Movie_Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .HasColumnType("text");

                    b.HasKey("Review_Id");

                    b.HasIndex("AuthorUser_Id");

                    b.HasIndex("Movie_Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.User", b =>
                {
                    b.Property<Guid>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarLink")
                        .HasColumnType("text");

                    b.Property<int>("BirthDate")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("GenresGenre_Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MoviesMovie_Id")
                        .HasColumnType("uuid");

                    b.HasKey("GenresGenre_Id", "MoviesMovie_Id");

                    b.HasIndex("MoviesMovie_Id");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.Property<Guid>("MoviesMovie_Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersUser_Id")
                        .HasColumnType("uuid");

                    b.HasKey("MoviesMovie_Id", "UsersUser_Id");

                    b.HasIndex("UsersUser_Id");

                    b.ToTable("MovieUser");
                });

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.Review", b =>
                {
                    b.HasOne("Film_Catalog.Models.DBClasses.User", "Author")
                        .WithMany("Reviews")
                        .HasForeignKey("AuthorUser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Film_Catalog.Models.DBClasses.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("Movie_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("Film_Catalog.Models.DBClasses.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenre_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Film_Catalog.Models.DBClasses.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovie_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.HasOne("Film_Catalog.Models.DBClasses.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovie_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Film_Catalog.Models.DBClasses.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.Movie", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Film_Catalog.Models.DBClasses.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
