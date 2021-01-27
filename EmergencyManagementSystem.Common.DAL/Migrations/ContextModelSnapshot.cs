﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EmergencyManagementSystem.Common.DAL.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("State");

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

                    b.Property<short>("Company")
                        .HasColumnType("smallint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<long>("OccupationId")
                        .HasColumnType("bigint");

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

                    b.HasIndex("OccupationId");

                    b.ToTable("Employees", "dbo");
                });

            modelBuilder.Entity("EmergencyManagementSystem.Common.Entities.Entities.Occupation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Profession");

                    b.HasKey("Id");

                    b.ToTable("Occupations", "dbo");
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
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
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

                    b.HasOne("EmergencyManagementSystem.Common.Entities.Entities.Occupation", "Occupation")
                        .WithMany()
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Occupation");
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
