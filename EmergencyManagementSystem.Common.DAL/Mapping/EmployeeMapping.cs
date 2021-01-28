using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.Common.DAL.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Guid)
                .HasColumnName("Guid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(d => d.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.CPF)
                .HasColumnName("CPF")
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(d => d.ProfessionalRegistration)
                .HasColumnName("ProfessionalRegistration")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(d => d.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(d => d.Occupation)
                .WithMany()
                .HasForeignKey(d => d.OccupationId);

            builder.Property(d => d.RG)
                .HasColumnName("RG")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.Telephone)
                .HasColumnName("Telephone")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(d => d.Address)
                .WithMany()
                .HasForeignKey(d => d.AddressId);
        }
    }
}
