using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AreaInsted.Database;

public partial class AreaInstedContext : DbContext
{
    public AreaInstedContext()
    {
    }

    public AreaInstedContext(DbContextOptions<AreaInstedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAcadActivity> TbAcadActivities { get; set; }

    public virtual DbSet<TbAddress> TbAddresses { get; set; }

    public virtual DbSet<TbClass> TbClasses { get; set; }

    public virtual DbSet<TbFrequency> TbFrequencies { get; set; }

    public virtual DbSet<TbGrade> TbGrades { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserClass> TbUserClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NELIO\\SQLSERVER;Database=area_insted;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAcadActivity>(entity =>
        {
            entity.HasKey(e => e.IdAcadActivity).HasName("PK_ACAC");

            entity.HasOne(d => d.IdUserClassNavigation).WithMany(p => p.TbAcadActivities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACAC_UC");
        });

        modelBuilder.Entity<TbAddress>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PK_ADDRESS");
        });

        modelBuilder.Entity<TbClass>(entity =>
        {
            entity.HasKey(e => e.IdClass).HasName("PK_CLASS");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TbClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLASS_USER");
        });

        modelBuilder.Entity<TbFrequency>(entity =>
        {
            entity.HasKey(e => e.IdFrequency).HasName("PK_FREQ");

            entity.HasOne(d => d.IdUserClassNavigation).WithMany(p => p.TbFrequencies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FREQ_UC");
        });

        modelBuilder.Entity<TbGrade>(entity =>
        {
            entity.HasKey(e => e.IdGrades).HasName("PK_GRADES");

            entity.HasOne(d => d.IdUserClassNavigation).WithMany(p => p.TbGrades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRADES_UC");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_USER");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.TbUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_ADDRESS");
        });

        modelBuilder.Entity<TbUserClass>(entity =>
        {
            entity.HasKey(e => e.IdUserClass).HasName("PK_UC");

            entity.HasOne(d => d.IdClassNavigation).WithMany(p => p.TbUserClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UC_CLASS");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TbUserClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UC_USER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
