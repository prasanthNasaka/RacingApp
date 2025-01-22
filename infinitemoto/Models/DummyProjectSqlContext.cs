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

    public virtual DbSet<Authenticationrole> Authenticationroles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Eventcategory> Eventcategories { get; set; }

    public virtual DbSet<Eventregistration> Eventregistrations { get; set; }

    public virtual DbSet<Eventtype> Eventtypes { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    public virtual DbSet<Usertoken> Usertokens { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<Vehicledoc> Vehicledocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5431;Database=DummyProjectSql;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authenticationrole>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("authenticationroles_pkey");

            entity.ToTable("authenticationroles");

            entity.Property(e => e.Roleid)
                .ValueGeneratedNever()
                .HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("category_pkey");

            entity.ToTable("category");

            entity.HasIndex(e => e.Eventtypeid, "IX_category_eventtypeid");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(255)
                .HasColumnName("categoryname");
            entity.Property(e => e.Eventtypeid).HasColumnName("eventtypeid");

            entity.HasOne(d => d.Eventtype).WithMany(p => p.Categories)
                .HasForeignKey(d => d.Eventtypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("category_eventtypeid_fkey");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("driver_pkey");

            entity.ToTable("driver");

            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.Bloodgroup)
                .HasMaxLength(10)
                .HasColumnName("bloodgroup");
            entity.Property(e => e.DlNumb)
                .HasMaxLength(25)
                .HasColumnName("dl_numb");
            entity.Property(e => e.DlValidTill).HasColumnName("dl_valid_till");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.DriverPhoto)
                .HasMaxLength(255)
                .HasColumnName("driver_photo");
            entity.Property(e => e.Drivername)
                .HasMaxLength(25)
                .HasColumnName("drivername");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FmsciNumb)
                .HasMaxLength(25)
                .HasColumnName("fmsci_numb");
            entity.Property(e => e.FmsciValidTill).HasColumnName("fmsci_valid_till");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Teammemberof).HasColumnName("teammemberof");

             entity.HasOne(d => d.TeammemberofNavigation).WithMany( p => p.Drivers)
                 .HasForeignKey(d => d.Teammemberof)
                 .HasConstraintName("driver_teammemberof_fkey");
        });

        modelBuilder.Entity<Eventcategory>(entity =>
        {
            entity.HasKey(e => e.Eventid);
        });

        modelBuilder.Entity<Eventregistration>(entity =>
        {
            entity.HasKey(e => e.Eventid).HasName("eventregistration_pkey");

            entity.ToTable("eventregistration");

            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Eventname)
                .HasMaxLength(255)
                .HasColumnName("eventname");
            entity.Property(e => e.Eventtype).HasColumnName("eventtype");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Showdashboard).HasColumnName("showdashboard");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
        });

        modelBuilder.Entity<Eventtype>(entity =>
        {
            entity.HasKey(e => e.Eventtypeid).HasName("eventtypes_pkey");

            entity.ToTable("eventtypes");

            entity.Property(e => e.Eventtypeid).HasColumnName("eventtypeid");
            entity.Property(e => e.Eventtypename)
                .HasMaxLength(255)
                .HasColumnName("eventtypename");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FmsciLicense).HasColumnName("FMSCI_License");
            entity.Property(e => e.FmsciLicenseValidTill).HasColumnName("FMSCI_LicenseValidTill");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("team_pkey");

            entity.ToTable("team");

            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeamName)
                .HasMaxLength(100)
                .HasColumnName("team_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("'User'::character varying");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userinfo_pkey");

            entity.ToTable("userinfo");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Compid).HasColumnName("compid");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(25)
                .HasColumnName("username");
            entity.Property(e => e.Usertype).HasColumnName("usertype");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("userroles_pkey");

            entity.ToTable("userroles");

            entity.HasIndex(e => e.Eventtypeid, "IX_userroles_eventtypeid");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Eventtypeid).HasColumnName("eventtypeid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(100)
                .HasColumnName("rolename");

            entity.HasOne(d => d.Eventtype).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.Eventtypeid)
                .HasConstraintName("userroles_eventtypeid_fkey");
        });

        modelBuilder.Entity<Usertoken>(entity =>
        {
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("'User'::character varying");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("vehicle_pkey");

            entity.ToTable("vehicle");

            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.Cc)
                .HasMaxLength(50)
                .HasColumnName("cc");
            entity.Property(e => e.ChasisNumb)
                .HasMaxLength(255)
                .HasColumnName("chasis_numb");
            entity.Property(e => e.EngNumber)
                .HasMaxLength(255)
                .HasColumnName("eng_number");
            entity.Property(e => e.FcUpto).HasColumnName("fc_upto");
            entity.Property(e => e.Make)
                .HasMaxLength(255)
                .HasColumnName("make");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.RegNumb)
                .HasMaxLength(255)
                .HasColumnName("reg_numb");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.VehicleOf).HasColumnName("vehicle_of");
            entity.Property(e => e.VehiclePhoto)
                .HasMaxLength(255)
                .HasColumnName("vehicle_photo");

            entity.HasOne(d => d.VehicleOfNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleOf)
                .HasConstraintName("vehicle_vehicle_of_fkey");
        });

        modelBuilder.Entity<Vehicledoc>(entity =>
        {
            entity.HasKey(e => e.VehDocId).HasName("vehicledoc_pkey");

            entity.ToTable("vehicledoc");

            entity.Property(e => e.VehDocId).HasColumnName("veh_doc_id");
            entity.Property(e => e.DocPath)
                .HasMaxLength(255)
                .HasColumnName("doc_path");
            entity.Property(e => e.DocType)
                .HasMaxLength(255)
                .HasColumnName("doc_type");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Vehicledocs)
               .HasForeignKey(d => d.VehicleId)
               .HasConstraintName("vehicledoc_vehicle_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
