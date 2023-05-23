﻿// <auto-generated />
using JudoOrganizer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JudoOrganizer.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JudoOrganizer.Data.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Draw", b =>
                {
                    b.Property<int>("SportsmanId")
                        .HasColumnType("integer");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer");

                    b.Property<int>("MatchId")
                        .HasColumnType("integer");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DrawType")
                        .HasColumnType("integer");

                    b.HasKey("SportsmanId", "TournamentId", "MatchId");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.HasIndex("SportsmanId")
                        .IsUnique();

                    b.HasIndex("TournamentId")
                        .IsUnique();

                    b.ToTable("Draws");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SportsmanId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SportsmanId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.MatchResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MatchId")
                        .HasColumnType("integer");

                    b.Property<string>("Round")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TournamentResultId")
                        .HasColumnType("integer");

                    b.Property<int>("WinnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.HasIndex("TournamentResultId");

                    b.HasIndex("WinnerId");

                    b.ToTable("MatchResults");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Registration", b =>
                {
                    b.Property<int>("SportsmanId")
                        .HasColumnType("integer");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer");

                    b.Property<int>("SportCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SportsmanId", "TournamentId", "SportCategoryId", "UserId");

                    b.HasIndex("SportCategoryId")
                        .IsUnique();

                    b.HasIndex("SportsmanId")
                        .IsUnique();

                    b.HasIndex("TournamentId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.SportCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer");

                    b.Property<int>("WeightId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WeightId")
                        .IsUnique();

                    b.ToTable("SportCategories");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Sportsman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("integer");

                    b.Property<int>("CoachId")
                        .HasColumnType("integer");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("CoachId");

                    b.ToTable("Sportsmen");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Organizer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.TournamentResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId")
                        .IsUnique();

                    b.ToTable("TournamentResults");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Weighing", b =>
                {
                    b.Property<int>("SportsmanId")
                        .HasColumnType("integer");

                    b.Property<int>("TournamentId")
                        .HasColumnType("integer");

                    b.Property<int>("SportCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WeightValue")
                        .HasColumnType("integer");

                    b.HasKey("SportsmanId", "TournamentId", "SportCategoryId");

                    b.HasIndex("SportCategoryId")
                        .IsUnique();

                    b.HasIndex("SportsmanId")
                        .IsUnique();

                    b.HasIndex("TournamentId")
                        .IsUnique();

                    b.ToTable("Weighings");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("WeightValue")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.City", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Club", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.City", "City")
                        .WithMany("Clubs")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Coach", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Club", "Club")
                        .WithMany("Coaches")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Draw", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Match", "Match")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Draw", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Sportsman", "Sportsman")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Draw", "SportsmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Tournament", "Tournament")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Draw", "TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Sportsman");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Match", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Sportsman", "Sportsman")
                        .WithMany("Matches")
                        .HasForeignKey("SportsmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sportsman");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.MatchResult", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Match", "Match")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.MatchResult", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.TournamentResult", "TournamentResult")
                        .WithMany("MatchResults")
                        .HasForeignKey("TournamentResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Sportsman", "Winner")
                        .WithMany("MatchResults")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("TournamentResult");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Registration", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.SportCategory", "SportCategory")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Registration", "SportCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Sportsman", "Sportsman")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Registration", "SportsmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Tournament", "Tournament")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Registration", "TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Registration", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SportCategory");

                    b.Navigation("Sportsman");

                    b.Navigation("Tournament");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.SportCategory", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Tournament", "Tournament")
                        .WithMany("SportCategories")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Weight", "Weight")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.SportCategory", "WeightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");

                    b.Navigation("Weight");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Sportsman", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Club", "Club")
                        .WithMany("Sportsmen")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Coach", "Coach")
                        .WithMany("Sportsmen")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.TournamentResult", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.Tournament", "Tournament")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.TournamentResult", "TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Weighing", b =>
                {
                    b.HasOne("JudoOrganizer.Data.Models.SportCategory", "SportCategory")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Weighing", "SportCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Sportsman", "Sportsman")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Weighing", "SportsmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JudoOrganizer.Data.Models.Tournament", "Tournament")
                        .WithOne()
                        .HasForeignKey("JudoOrganizer.Data.Models.Weighing", "TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SportCategory");

                    b.Navigation("Sportsman");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.City", b =>
                {
                    b.Navigation("Clubs");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Club", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Sportsmen");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Coach", b =>
                {
                    b.Navigation("Sportsmen");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Sportsman", b =>
                {
                    b.Navigation("MatchResults");

                    b.Navigation("Matches");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.Tournament", b =>
                {
                    b.Navigation("SportCategories");
                });

            modelBuilder.Entity("JudoOrganizer.Data.Models.TournamentResult", b =>
                {
                    b.Navigation("MatchResults");
                });
#pragma warning restore 612, 618
        }
    }
}
