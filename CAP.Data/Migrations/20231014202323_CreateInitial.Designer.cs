﻿// <auto-generated />
using System;
using CAP.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CAP.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231014202323_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CAP.Entity.Entities.ADDRESS", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("STATUSS")
                        .HasColumnType("bit");

                    b.Property<string>("ad_address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ADDRESSES");
                });

            modelBuilder.Entity("CAP.Entity.Entities.TAXPAYER", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("STATUSS")
                        .HasColumnType("bit");

                    b.Property<int>("VKN")
                        .HasColumnType("int");

                    b.Property<Guid?>("tp_addressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("tp_address_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("tp_company_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("tp_email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("tp_employees_num")
                        .HasColumnType("int");

                    b.Property<string>("tp_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("tp_opening_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("tp_phone")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("tp_tax_office")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("tp_addressID");

                    b.ToTable("TAXPAYERS");
                });

            modelBuilder.Entity("CAP.Entity.Entities.USERS", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("STATUSS")
                        .HasColumnType("bit");

                    b.Property<string>("u_address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("u_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("u_department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("u_email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("u_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("u_password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("u_phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("ID");

                    b.ToTable("USERs");
                });

            modelBuilder.Entity("CAP.Entity.Entities.TAXPAYER", b =>
                {
                    b.HasOne("CAP.Entity.Entities.ADDRESS", "tp_address")
                        .WithMany("tax_payers")
                        .HasForeignKey("tp_addressID");

                    b.Navigation("tp_address");
                });

            modelBuilder.Entity("CAP.Entity.Entities.ADDRESS", b =>
                {
                    b.Navigation("tax_payers");
                });
#pragma warning restore 612, 618
        }
    }
}
