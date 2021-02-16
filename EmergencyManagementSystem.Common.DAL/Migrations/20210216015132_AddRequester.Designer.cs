﻿// <auto-generated />
using System;
using EmergencyManagementSystem.Common.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmergencyManagementSystem.Common.DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210216015132_AddRequester")]
    partial class AddRequester
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CEP")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("CEP");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("City");

                    b.Property<string>("Complement")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Complement");

                    b.Property<string>("District")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("District");

                    b.Property<string>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Number");

                    b.Property<string>("Reference")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Reference");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Street");

                    b.HasKey("Id");

                    b.ToTable("Addresses", "dbo");
                });

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime")
                        .HasColumnName("BirthDate");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CPF");

                    b.Property<int>("Company")
                        .HasColumnType("int")
                        .HasColumnName("Company");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Guid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<int>("Occupation")
                        .HasColumnType("int")
                        .HasColumnName("Occupation");

                    b.Property<string>("ProfessionalRegistration")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ProfessionalRegistration");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("RG");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telephone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Employees", "dbo");
                });

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.Requester", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Guid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telephone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Requesters", "dbo");
                });

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.Employee", b =>
                {
                    b.HasOne("EmergencyManagementSystem.Common.Entities.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.Requester", b =>
                {
                    b.HasOne("EmergencyManagementSystem.Common.Entities.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.User", b =>
                {
                    b.HasOne("EmergencyManagementSystem.Common.Entities.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
