using System;
using System.Collections.Generic;
using Aptech3.Models;
using Microsoft.EntityFrameworkCore;

namespace Aptech3.Data;

public partial class Aptech3Context : DbContext
{
    public Aptech3Context()
    {
    }

    public Aptech3Context(DbContextOptions<Aptech3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeGroup> AgeGroups { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<BusRoute> BusRoutes { get; set; }

    public virtual DbSet<BusType> BusTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<RouteDetail> RouteDetails { get; set; }

    public virtual DbSet<TicketCounter> TicketCounters { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=192.168.36.21;Initial Catalog=Aptech3;User ID=sa;Password=YourStrongPassword123!;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeGroup>(entity =>
        {
            entity.ToTable("AgeGroup");

            entity.Property(e => e.AgeGroupId)
                .ValueGeneratedNever()
                .HasColumnName("AgeGroupID");
            entity.Property(e => e.AgeGroup1)
                .HasMaxLength(50)
                .HasColumnName("AgeGroup");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("BookingID");
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TravelDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Bus).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BusId)
                .HasConstraintName("FK_Bookings_Buses1");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Bookings_Customers");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Bookings_Employees");
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.Property(e => e.BusId)
                .ValueGeneratedNever()
                .HasColumnName("BusID");
            entity.Property(e => e.BusName).HasMaxLength(255);
            entity.Property(e => e.BusTypeId).HasColumnName("BusTypeID");
            entity.Property(e => e.RouteId).HasColumnName("RouteID");

            entity.HasOne(d => d.BusType).WithMany(p => p.Buses)
                .HasForeignKey(d => d.BusTypeId)
                .HasConstraintName("FK_Buses_BusType");

            entity.HasOne(d => d.Route).WithMany(p => p.Buses)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK_Buses_Routes");
        });

        modelBuilder.Entity<BusRoute>(entity =>
        {
            entity.HasKey(e => e.BusRouteId).HasName("PK_Routes");

            entity.Property(e => e.BusRouteId)
                .ValueGeneratedNever()
                .HasColumnName("BusRouteID");
            entity.Property(e => e.BusRouteName).HasMaxLength(255);
        });

        modelBuilder.Entity<BusType>(entity =>
        {
            entity.ToTable("BusType");

            entity.Property(e => e.BusTypeId)
                .ValueGeneratedNever()
                .HasColumnName("BusTypeID");
            entity.Property(e => e.BusTypeName).HasMaxLength(50);
            entity.Property(e => e.Price).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.AgeGroupId).HasColumnName("AgeGroupID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.AgeGroup).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AgeGroupId)
                .HasConstraintName("FK_Customers_AgeGroup");
        });

        modelBuilder.Entity<RouteDetail>(entity =>
        {
            entity.HasKey(e => e.RouteDetailId).HasName("PK_RouteLocations");

            entity.Property(e => e.RouteDetailId)
                .ValueGeneratedNever()
                .HasColumnName("RouteDetailID");
            entity.Property(e => e.BusRouteId).HasColumnName("BusRouteID");
            entity.Property(e => e.DestinationPoint).HasMaxLength(255);
            entity.Property(e => e.StartingPoint).HasMaxLength(255);

            entity.HasOne(d => d.BusRoute).WithMany(p => p.RouteDetails)
                .HasForeignKey(d => d.BusRouteId)
                .HasConstraintName("FK_RouteLocations_Routes");
        });

        modelBuilder.Entity<TicketCounter>(entity =>
        {
            entity.HasKey(e => e.CounterId);

            entity.ToTable("TicketCounter");

            entity.Property(e => e.CounterId)
                .ValueGeneratedNever()
                .HasColumnName("CounterID");
            entity.Property(e => e.CounterName).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Employees");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CounterId).HasColumnName("CounterID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.Qualification).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserCode).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Counter).WithMany(p => p.Users)
                .HasForeignKey(d => d.CounterId)
                .HasConstraintName("FK_Users_TicketCounter");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
