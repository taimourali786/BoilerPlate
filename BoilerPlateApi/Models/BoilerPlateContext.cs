using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlateApi.Models;

public partial class BoilerPlateContext : DbContext
{
    public BoilerPlateContext()
    {
    }

    public BoilerPlateContext(DbContextOptions<BoilerPlateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserHotelBooking> UserHotelBookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=boilerplate;Integrated Security=True; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasOne(d => d.City).WithMany(p => p.Hotels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hotel_City");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.AspNet).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_AspNetUsers");

            entity.HasOne(d => d.City).WithMany(p => p.Users).HasConstraintName("FK_User_City");
        });

        modelBuilder.Entity<UserHotelBooking>(entity =>
        {
            entity.HasOne(d => d.Hotel).WithMany(p => p.UserHotelBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserHotelBooking_Hotel");

            entity.HasOne(d => d.User).WithMany(p => p.UserHotelBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserHotelBooking_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
