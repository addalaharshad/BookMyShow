﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMyShow_BE.Models
{
    public partial class BookMyShowContext : IdentityDbContext
    {
        public BookMyShowContext()
        {
        }

        public BookMyShowContext(DbContextOptions<BookMyShowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookings> Bookings { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Register> Registers { get; set; } = null!;
        public virtual DbSet<Seats> Seats { get; set; } = null!;
        public virtual DbSet<Shows> Shows { get; set; } = null!;
        public virtual DbSet<Theater> Theaters { get; set; } = null!;
        public virtual DbSet<Userbooking> Userbookings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.ToTable("bookings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.ShowId).HasColumnName("showID");

                entity.Property(e => e.TheaterId).HasColumnName("theaterID");

                entity.Property(e => e.TicketsBooked).HasColumnName("ticketsBooked");

                entity.Property(e => e.UserId).HasColumnName("userID");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Language)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MoviePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("moviePath");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RealesedOn)
                    .HasColumnType("date")
                    .HasColumnName("realesedOn");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("Register");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seats>(entity =>
            {
                entity.ToTable("seats");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.SeatId).HasColumnName("seatID");

                entity.Property(e => e.ShowId).HasColumnName("showID");

                entity.Property(e => e.TheaterId).HasColumnName("theaterID");
            });

            modelBuilder.Entity<Shows>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shows");

                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.ShowId).HasColumnName("showID");

                entity.Property(e => e.TheaterId).HasColumnName("theaterID");

                entity.Property(e => e.Tickets).HasColumnName("tickets");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shows__movieID__30F848ED");

                entity.HasOne(d => d.Theater)
                    .WithMany()
                    .HasForeignKey(d => d.TheaterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shows__theaterID__31EC6D26");
            });

            modelBuilder.Entity<Theater>(entity =>
            {
                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userbooking>(entity =>
            {
                entity.ToTable("userbookings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.SeatId).HasColumnName("seatID");

                entity.Property(e => e.ShowId).HasColumnName("showID");

                entity.Property(e => e.TheaterId).HasColumnName("theaterID");

                entity.Property(e => e.UserId).HasColumnName("userID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
