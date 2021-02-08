using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmergencyManagementSystem.Common.DAL.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Login)
                .HasColumnName("Login")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(32)
                .IsRequired();

            builder.HasOne(d => d.Employee)
                .WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .IsRequired();
        }
    }
}
