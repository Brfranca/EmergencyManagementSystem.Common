﻿using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.Common.DAL.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.CEP)
                .HasColumnName("CEP")
                .HasColumnType("varchar")
                .HasMaxLength(8);

            builder.Property(d => d.City)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(d => d.Complement)
                .HasColumnName("Complement")
                .HasColumnType("varchar")
                .HasMaxLength(60);


            builder.Property(d => d.District)
                .HasColumnName("District")
                .HasColumnType("varchar")
                .HasMaxLength(60);

            builder.Property(d => d.Number)
                .HasColumnName("Number")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder.Property(d => d.Reference)
                .HasColumnName("Reference")
                .HasColumnType("varchar")
                .HasMaxLength(60);

            builder.Property(d => d.State)
                .HasColumnName("State")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(d => d.Street)
                .HasColumnName("Street")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
