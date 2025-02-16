﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using infinitemoto.Models;

#nullable disable

namespace infinitemoto.Migrations
{
    [DbContext(typeof(DummyProjectSqlContext))]
    [Migration("20241230075325_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("infinitemoto.Models.Category", b =>
                {
                    b.Property<int>("Categoryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Categoryid"));

                    b.Property<string>("Categoryname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("categoryname");

                    b.Property<int>("Eventtypeid")
                        .HasColumnType("integer")
                        .HasColumnName("eventtypeid");

                    b.HasKey("Categoryid")
                        .HasName("category_pkey");

                    b.HasIndex(new[] { "Eventtypeid" }, "IX_category_eventtypeid");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("infinitemoto.Models.Eventregistration", b =>
                {
                    b.Property<int>("Eventid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("eventid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Eventid"));

                    b.Property<DateOnly>("Enddate")
                        .HasColumnType("date")
                        .HasColumnName("enddate");

                    b.Property<string>("Eventname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("eventname");

                    b.Property<int>("Eventtype")
                        .HasColumnType("integer")
                        .HasColumnName("eventtype");

                    b.Property<short>("Isactive")
                        .HasColumnType("smallint")
                        .HasColumnName("isactive");

                    b.Property<short>("Showdashboard")
                        .HasColumnType("smallint")
                        .HasColumnName("showdashboard");

                    b.Property<DateOnly>("Startdate")
                        .HasColumnType("date")
                        .HasColumnName("startdate");

                    b.HasKey("Eventid")
                        .HasName("eventregistration_pkey");

                    b.ToTable("eventregistration", (string)null);
                });

            modelBuilder.Entity("infinitemoto.Models.Eventtype", b =>
                {
                    b.Property<int>("Eventtypeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("eventtypeid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Eventtypeid"));

                    b.Property<string>("Eventtypename")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("eventtypename");

                    b.HasKey("Eventtypeid")
                        .HasName("eventtypes_pkey");

                    b.ToTable("eventtypes", (string)null);
                });

            modelBuilder.Entity("infinitemoto.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("infinitemoto.Models.Userinfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("Compid")
                        .HasColumnType("integer")
                        .HasColumnName("compid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("username");

                    b.Property<int>("Usertype")
                        .HasColumnType("integer")
                        .HasColumnName("usertype");

                    b.HasKey("Id")
                        .HasName("userinfo_pkey");

                    b.ToTable("userinfo", (string)null);
                });

            modelBuilder.Entity("infinitemoto.Models.Userrole", b =>
                {
                    b.Property<int>("Roleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("roleid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Roleid"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("Eventtypeid")
                        .HasColumnType("integer")
                        .HasColumnName("eventtypeid");

                    b.Property<string>("Rolename")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("rolename");

                    b.HasKey("Roleid")
                        .HasName("userroles_pkey");

                    b.HasIndex(new[] { "Eventtypeid" }, "IX_userroles_eventtypeid");

                    b.ToTable("userroles", (string)null);
                });

            modelBuilder.Entity("infinitemoto.Models.Usertoken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usertokens");
                });

            modelBuilder.Entity("infinitemoto.Models.Category", b =>
                {
                    b.HasOne("infinitemoto.Models.Eventtype", "Eventtype")
                        .WithMany("Categories")
                        .HasForeignKey("Eventtypeid")
                        .IsRequired()
                        .HasConstraintName("category_eventtypeid_fkey");

                    b.Navigation("Eventtype");
                });

            modelBuilder.Entity("infinitemoto.Models.Userrole", b =>
                {
                    b.HasOne("infinitemoto.Models.Eventtype", "Eventtype")
                        .WithMany("Userroles")
                        .HasForeignKey("Eventtypeid")
                        .HasConstraintName("userroles_eventtypeid_fkey");

                    b.Navigation("Eventtype");
                });

            modelBuilder.Entity("infinitemoto.Models.Eventtype", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Userroles");
                });
#pragma warning restore 612, 618
        }
    }
}
