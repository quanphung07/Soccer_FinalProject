﻿// <auto-generated />
using System;
using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalTest.Migrations
{
    [DbContext(typeof(LeagueContext))]
    [Migration("20201221083421_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FinalTest.Models.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Attendance")
                        .HasColumnType("integer");

                    b.Property<int?>("AwayResTeamID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("HomeResTeamID")
                        .HasColumnType("integer");

                    b.Property<int?>("StadiumID")
                        .HasColumnType("integer");

                    b.HasKey("MatchID");

                    b.HasIndex("AwayResTeamID");

                    b.HasIndex("HomeResTeamID");

                    b.HasIndex("StadiumID");

                    b.ToTable("match");
                });

            modelBuilder.Entity("FinalTest.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<int>("Kit")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<int?>("TeamID")
                        .HasColumnType("integer");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("player");
                });

            modelBuilder.Entity("FinalTest.Models.Result", b =>
                {
                    b.Property<int>("MatchID")
                        .HasColumnType("integer");

                    b.Property<int>("AwayRes")
                        .HasColumnType("integer");

                    b.Property<int>("HomeRes")
                        .HasColumnType("integer");

                    b.HasKey("MatchID");

                    b.ToTable("result");
                });

            modelBuilder.Entity("FinalTest.Models.Score", b =>
                {
                    b.Property<int>("ScoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("integer");

                    b.Property<int>("Goals")
                        .HasColumnType("integer");

                    b.Property<int?>("MatchID")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("integer");

                    b.Property<int?>("TeamID")
                        .HasColumnType("integer");

                    b.HasKey("ScoreID");

                    b.HasIndex("MatchID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("score");
                });

            modelBuilder.Entity("FinalTest.Models.Stadium", b =>
                {
                    b.Property<int>("StadiumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("StadiumID");

                    b.ToTable("stadium");
                });

            modelBuilder.Entity("FinalTest.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("StadiumID")
                        .HasColumnType("integer");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("TeamID");

                    b.HasIndex("StadiumID")
                        .IsUnique();

                    b.ToTable("team");
                });

            modelBuilder.Entity("FinalTest.Models.Match", b =>
                {
                    b.HasOne("FinalTest.Models.Team", "AwayRes")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayResTeamID");

                    b.HasOne("FinalTest.Models.Team", "HomeRes")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeResTeamID");

                    b.HasOne("FinalTest.Models.Stadium", "Stadium")
                        .WithMany("Matches")
                        .HasForeignKey("StadiumID");
                });

            modelBuilder.Entity("FinalTest.Models.Player", b =>
                {
                    b.HasOne("FinalTest.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("FinalTest.Models.Result", b =>
                {
                    b.HasOne("FinalTest.Models.Match", "Match")
                        .WithOne("Result")
                        .HasForeignKey("FinalTest.Models.Result", "MatchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalTest.Models.Score", b =>
                {
                    b.HasOne("FinalTest.Models.Match", "Match")
                        .WithMany("Scores")
                        .HasForeignKey("MatchID");

                    b.HasOne("FinalTest.Models.Player", "Player")
                        .WithMany("Scores")
                        .HasForeignKey("PlayerID");

                    b.HasOne("FinalTest.Models.Team", "Team")
                        .WithMany("Scores")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("FinalTest.Models.Team", b =>
                {
                    b.HasOne("FinalTest.Models.Stadium", "Stadium")
                        .WithOne("Team")
                        .HasForeignKey("FinalTest.Models.Team", "StadiumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
