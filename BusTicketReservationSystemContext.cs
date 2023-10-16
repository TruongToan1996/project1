using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using project1.Models;

namespace project1;

public partial class BusTicketReservationSystemContext : DbContext
{
    public BusTicketReservationSystemContext()
    {
    }

    public BusTicketReservationSystemContext(DbContextOptions<BusTicketReservationSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<RouteLocation> RouteLocations { get; set; }

    public virtual DbSet<RoutesModel> RoutesModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.36.21;Initial Catalog=BusTicketReservationSystem;User ID=sa;Password=YourStrongPassword123!;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Bookings_Customers");
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.BusName).HasMaxLength(255);
            entity.Property(e => e.BusType).HasMaxLength(50);
            entity.Property(e => e.RouteId).HasColumnName("RouteID");

            entity.HasOne(d => d.Route).WithMany(p => p.Buses)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK_Buses_Routes");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.EmployeeCode).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(12);
            entity.Property(e => e.Qualification).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<RouteLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId);

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.LocationName).HasMaxLength(255);
            entity.Property(e => e.RouteId).HasColumnName("RouteID");

            entity.HasOne(d => d.Route).WithMany(p => p.RouteLocations)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK_RouteLocations_Routes");
        });

        modelBuilder.Entity<RoutesModel>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK_Routes");

            entity.ToTable("RoutesModel");

            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.DestinationPoint).HasMaxLength(255);
            entity.Property(e => e.RouteName).HasMaxLength(255);
            entity.Property(e => e.StartingPoint).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
