﻿using System;
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

    public virtual DbSet<Companydetail> Companydetails { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Eventcategory> Eventcategories { get; set; }

    public virtual DbSet<Eventregistration> Eventregistrations { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Scrutineer> Scrutineers { get; set; }

    public virtual DbSet<Scrutineydetail> Scrutineydetails { get; set; }

    public virtual DbSet<Scrutinyrule> Scrutinyrules { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    public virtual DbSet<Usertoken> Usertokens { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleDoc> VehicleDocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5431;Database=DummyProjectSql;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Companydetail>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("company_pkey");

            entity.ToTable("companydetails");

            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("nextval('company_company_id_seq'::regclass)")
                .HasColumnName("company_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .HasColumnName("street");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("drivers_pkey");

            entity.ToTable("drivers");

            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.Bloodgroup).HasColumnName("bloodgroup");
            entity.Property(e => e.DlNumb)
                .HasMaxLength(20)
                .HasColumnName("dl_numb");
            entity.Property(e => e.DlPhoto)
                .HasColumnType("character varying")
                .HasColumnName("dl_photo");
            entity.Property(e => e.DlValidTill).HasColumnName("dl_valid_till");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.DriverPhoto)
                .HasColumnType("character varying")
                .HasColumnName("driver_photo");
            entity.Property(e => e.Drivername)
                .HasMaxLength(23)
                .HasColumnName("drivername");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FmsciLicPhoto)
                .HasColumnType("character varying")
                .HasColumnName("fmsci_lic_photo");
            entity.Property(e => e.FmsciNumb)
                .HasMaxLength(20)
                .HasColumnName("fmsci_numb");
            entity.Property(e => e.FmsciValidTill).HasColumnName("fmsci_valid_till");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Teammemberof).HasColumnName("teammemberof");

            entity.HasOne(d => d.TeammemberofNavigation).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.Teammemberof)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tbl_teams");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("emp_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.EmpId)
                .HasDefaultValueSql("nextval('emp_emp_id_seq'::regclass)")
                .HasColumnName("emp_id");
            entity.Property(e => e.AccId).HasColumnName("acc_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ComId).HasColumnName("com_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .HasColumnName("emp_name");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Phone).HasColumnName("phone");

            entity.HasOne(d => d.Com).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ComId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("emp_com_id_fkey");
        });

        modelBuilder.Entity<Eventcategory>(entity =>
        {
            entity.HasKey(e => e.EvtCatId).HasName("eventcategory_pkey");

            entity.ToTable("eventcategory");

            entity.Property(e => e.EvtCatId).HasColumnName("evt_cat_id");
            entity.Property(e => e.Entryprice).HasColumnName("entryprice");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EvtCategory).HasColumnName("evt_category");
            entity.Property(e => e.NoOfVeh).HasColumnName("noOfVeh");
            entity.Property(e => e.Nooflaps).HasColumnName("nooflaps");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.Wheelertype).HasColumnName("wheelertype");

            entity.HasOne(d => d.Event).WithMany(p => p.Eventcategories)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("eventcategory_eventregistration_fk");
        });

        modelBuilder.Entity<Eventregistration>(entity =>
        {
            entity.HasKey(e => e.Eventid).HasName("eventregistration_pkey");

            entity.ToTable("eventregistration");

            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Accountname)
                .HasMaxLength(100)
                .HasColumnName("accountname");
            entity.Property(e => e.Accountnum)
                .HasColumnType("character varying")
                .HasColumnName("accountnum");
            entity.Property(e => e.Bankname)
                .HasMaxLength(100)
                .HasColumnName("bankname");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Eventname)
                .HasMaxLength(255)
                .HasColumnName("eventname");
            entity.Property(e => e.Eventstatus).HasColumnName("eventstatus");
            entity.Property(e => e.Eventtype).HasColumnName("eventtype");
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(20)
                .HasColumnName("ifsccode");
            entity.Property(e => e.Isactive)
                .HasColumnType("character varying")
                .HasColumnName("isactive");
            entity.Property(e => e.Qrpath)
                .HasMaxLength(1000)
                .HasColumnName("QRpath");
            entity.Property(e => e.Showdashboard)
                .HasColumnType("character varying")
                .HasColumnName("showdashboard");
            entity.Property(e => e.Startdate).HasColumnName("startdate");

            entity.HasOne(d => d.Company).WithMany(p => p.Eventregistrations)
                .HasForeignKey(d => d.Companyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventregistration_companydetails_fk");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegId).HasName("registration_pkey");

            entity.ToTable("registration");

            entity.Property(e => e.RegId).HasColumnName("reg_id");
            entity.Property(e => e.AddBy).HasColumnName("add_by");
            entity.Property(e => e.AddDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("add_date");
            entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");
            entity.Property(e => e.ContestantNo).HasColumnName("contestant_no");
            entity.Property(e => e.DocumentStatus)
                .HasDefaultValue(0)
                .HasColumnName("document_status");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventcategoryId).HasColumnName("eventcategory_id");
            entity.Property(e => e.RaceStatus)
                .HasMaxLength(50)
                .HasColumnName("race_status");
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(50)
                .HasColumnName("reference_no");
            entity.Property(e => e.ScrutineerId).HasColumnName("scrutineer_id");
            entity.Property(e => e.ScrutinyStatus)
                .HasMaxLength(1)
                .HasColumnName("scrutiny_status");
            entity.Property(e => e.ScrutinyUpdatedDate).HasColumnName("scrutiny_updated_date");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
            entity.Property(e => e.UpdateDttm).HasColumnName("update_dttm");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.VechId).HasColumnName("vech_id");

            entity.HasOne(d => d.Driver).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("fk_driver");

            entity.HasOne(d => d.Event).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("fk_event");

            entity.HasOne(d => d.Eventcategory).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.EventcategoryId)
                .HasConstraintName("fk_eventcategory");

            entity.HasOne(d => d.Scrutineer).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.ScrutineerId)
                .HasConstraintName("registration_scrutineer_fk");

            entity.HasOne(d => d.Vech).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.VechId)
                .HasConstraintName("fk_vech");
        });

        modelBuilder.Entity<Scrutineer>(entity =>
        {
            entity.HasKey(e => e.ScrutineerId).HasName("scrutineer_pkey");

            entity.ToTable("scrutineer");

            entity.Property(e => e.ScrutineerId)
                .ValueGeneratedNever()
                .HasColumnName("scrutineer_id");
            entity.Property(e => e.ScrutineerName)
                .HasMaxLength(255)
                .HasColumnName("scrutineer_name");
        });

        modelBuilder.Entity<Scrutineydetail>(entity =>
        {
            entity.HasKey(e => e.ScrutineydetailsId).HasName("scrutineydetails_pkey");

            entity.ToTable("scrutineydetails");

            entity.Property(e => e.ScrutineydetailsId)
                .ValueGeneratedNever()
                .HasColumnName("scrutineydetails_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.RegId).HasColumnName("reg_id");
            entity.Property(e => e.ScrutineyruleId).HasColumnName("scrutineyrule_id");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.Reg).WithMany(p => p.Scrutineydetails)
                .HasForeignKey(d => d.RegId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("scrutineydetails_reg_id_fkey");

            entity.HasOne(d => d.Scrutineyrule).WithMany(p => p.Scrutineydetails)
                .HasForeignKey(d => d.ScrutineyruleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("scrutineydetails_scrutineyrule_id_fkey");
        });

        modelBuilder.Entity<Scrutinyrule>(entity =>
        {
            entity.HasKey(e => e.ScrutinyrulesId).HasName("pk_scrutinyrules");

            entity.ToTable("scrutinyrules");

            entity.HasIndex(e => e.ScrutinyrulesId, "scrutinyrules_id").IsUnique();

            entity.Property(e => e.ScrutinyrulesId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("scrutinyrules_id");
            entity.Property(e => e.ScrutinyDescription)
                .HasColumnType("character varying")
                .HasColumnName("scrutiny_description");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("teams_pkey");

            entity.ToTable("teams");

            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeamName)
                .HasMaxLength(100)
                .HasColumnName("team_name");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userinfo_pkey");

            entity.ToTable("userinfo");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Compid).HasColumnName("compid");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Token).HasColumnType("character varying");
            entity.Property(e => e.Username)
                .HasMaxLength(25)
                .HasColumnName("username");
            entity.Property(e => e.Usertype).HasColumnName("usertype");

            entity.HasOne(d => d.Comp).WithMany(p => p.Userinfos)
                .HasForeignKey(d => d.Compid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userinfo_companydetails_fk");

            entity.HasOne(d => d.Emp).WithMany(p => p.Userinfos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("userinfo_employee_fk");

            entity.HasOne(d => d.UsertypeNavigation).WithMany(p => p.Userinfos)
                .HasForeignKey(d => d.Usertype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userinfo_userroles_fk");
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
        });

        modelBuilder.Entity<Usertoken>(entity =>
        {
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("'User'::character varying");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("vehicles_pkey");

            entity.ToTable("vehicles");

            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.Cc).HasColumnName("cc");
            entity.Property(e => e.ChasisNumb)
                .HasMaxLength(20)
                .HasColumnName("chasis_numb");
            entity.Property(e => e.EngNumber)
                .HasMaxLength(50)
                .HasColumnName("eng_number");
            entity.Property(e => e.IcNum)
                .HasColumnType("character varying")
                .HasColumnName("ic_num");
            entity.Property(e => e.IcUpto).HasColumnName("ic_upto");
            entity.Property(e => e.InsuranceImage)
                .HasMaxLength(100)
                .HasColumnName("insurance_image");
            entity.Property(e => e.Make)
                .HasMaxLength(100)
                .HasColumnName("make");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.RcImage)
                .HasMaxLength(100)
                .HasColumnName("rc_image");
            entity.Property(e => e.RcNum)
                .HasColumnType("character varying")
                .HasColumnName("rc_num");
            entity.Property(e => e.RcUpto).HasColumnName("rc_upto");
            entity.Property(e => e.RegNumb)
                .HasMaxLength(20)
                .HasColumnName("reg_numb");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.VehicleOf).HasColumnName("vehicle_of");
            entity.Property(e => e.VehiclePhoto)
                .HasMaxLength(255)
                .HasColumnName("vehicle_photo");
        });

        modelBuilder.Entity<VehicleDoc>(entity =>
        {
            entity.HasKey(e => e.VehDocId).HasName("vehicle_doc_pkey");

            entity.ToTable("vehicle_doc");

            entity.Property(e => e.VehDocId)
                .ValueGeneratedOnAdd()
                .HasColumnName("veh_doc_id");
            entity.Property(e => e.DocImage)
                .HasColumnType("character varying")
                .HasColumnName("doc_image");
            entity.Property(e => e.DocType).HasColumnName("doc_type");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Active'::text")
                .HasColumnName("status");
            entity.Property(e => e.Validtill).HasColumnName("validtill");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.VehDoc).WithOne(p => p.VehicleDoc)
                .HasForeignKey<VehicleDoc>(d => d.VehDocId)
                .HasConstraintName("fk_vechiles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
