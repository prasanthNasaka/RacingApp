using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace infinitemoto.Models;

public partial class DummyProjectSqlContext : DbContext
{
    public DummyProjectSqlContext()
    {
    }

    public DummyProjectSqlContext(DbContextOptions<DummyProjectSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DummyProjectSql;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid)
                .HasMaxLength(100)
                .HasColumnName("paymentid");
            entity.Property(e => e.Accountid)
                .HasMaxLength(100)
                .HasColumnName("accountid");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Bankaccountid)
                .HasMaxLength(255)
                .HasColumnName("bankaccountid");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .HasColumnName("currency");
            entity.Property(e => e.Paydate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paydate");
            entity.Property(e => e.Paymenttype)
                .HasMaxLength(50)
                .HasColumnName("paymenttype");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Subscriptionid)
                .HasMaxLength(100)
                .HasColumnName("subscriptionid");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userinfo_pkey");

            entity.ToTable("userinfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Compid).HasColumnName("compid");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(25)
                .HasColumnName("username");
            entity.Property(e => e.Usertype).HasColumnName("usertype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
